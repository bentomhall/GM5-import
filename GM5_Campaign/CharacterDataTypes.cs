﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GM5_Campaign
{
    public enum CharacterType {
        PC,
        Monster,
        Ally
    }

    public enum FeatureType {
        Trait,
        Action,
        Legendary,
        Reaction
    }

    public enum AttackType {
        MeleeWeapon,
        MeleeSpell,
        RangedWeapon,
        RangedSpell,
        SavingThrow
    }


    public struct ArmorClass
    {
        public ArmorClass(int value, string source)
        {
            Value = value;
            Source = source;
        }

        public int Value { get; private set; }
        public string Source { get; private set; }

        public override string ToString()
        {
            return $"{Value} ({Source})";
        }
    }

    public struct HitPoints
    {
        public HitPoints(int maximum, DiceValue hitdice)
        {
            Maximum = maximum;
            HitDice = hitdice;
        }

        public int Maximum { get; private set; }
        public DiceValue HitDice { get; private set; }

        public override string ToString()
        {
            if (Maximum == 0) { return "0"; }
            return $"{Maximum} ({HitDice})";
        }
    }

    public struct DiceValue
    {
        public DiceValue(int number, int sides, int staticBonus)
        {
            Number = number >= 0 ? number : 0;
            Sides = sides >= 0 ? sides : 0;
            StaticBonus = staticBonus;
        }

        public DiceValue(string combinedValue)
        {
            Regex rx = new Regex(@"(\d +)d(\d +)(\+(\d +) | (-\d +))?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matches = rx.Match(combinedValue);
            var captures = matches.Captures;
            if (captures.Count < 2) { throw new ArgumentException($"Incorrect format for input string: {combinedValue}"); }
            if (captures.Count == 2) { StaticBonus = 0; }
            else { StaticBonus = int.Parse(captures[3].Value); }
            Number = int.Parse(captures[0].Value);
            Sides = int.Parse(captures[1].Value);
        }

        public int Number { get; private set; }
        public int Sides { get; private set; }
        public int StaticBonus {get; private set; }

        public override string ToString()
        {
            if ((Number == 0 || Sides == 0) && StaticBonus == 0) { return ""; }
            if (StaticBonus > 0) { return $"{Number}d{Sides}+{StaticBonus}"; }
            else if (StaticBonus == 0) { return $"{Number}d{Sides}"; }
            else { return $"{Number}d{Sides}-{Math.Abs(StaticBonus)}";}
        }
    }

    public struct Attribute
    {
        public Attribute(int score)
        {
            Score = Math.Max(score, 1);
            Modifier = (Score - 10) / 2;
        }

        public int Score { get; private set; }
        public int Modifier { get; private set; }

        public override string ToString()
        {
            return $"{Score} ({Modifier.ToString("+0;-0")})";
        }
    }

    public struct NameValuePair
    {
        public NameValuePair (string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public int Value { get; private set; }

        public override string ToString()
        {
            return $"{Name} {Value.ToString("+0;-0")}";
        }
    }

    public class AttackRoll {
        public AttackRoll(AttackType type, int hitBonus, DiceValue damage) 
        {
            Attack = type;
            HitBonus = hitBonus;
            Damage = damage;
        }

        public override string ToString()
        {
            return $"{attackMap[Attack]}|{HitBonus.ToString("+00;00;-00")}|{Damage}";
        }

        public AttackType Attack { get; private set; }
        public int HitBonus {get; private set; }
        public DiceValue Damage {get; private set; }

        private Dictionary<AttackType, string> attackMap = new Dictionary<AttackType, string> {
            { AttackType.MeleeSpell, "Melee Spell Attack" },
            { AttackType.MeleeWeapon, "Melee Weapon Attack" },
            { AttackType.RangedSpell, "Ranged Spell Attack" },
            { AttackType.RangedWeapon, "Ranged Weapon Attack" },
            { AttackType.SavingThrow, "--"}
        };
    }

    public class CreatureFeature {
        public CreatureFeature(FeatureType type, string name, string text, AttackRoll attack) 
        {
            switch (type) {
                case FeatureType.Action:
                    feature = new Schemas.creatureAction();
                    break;
                case FeatureType.Legendary:
                    feature = new Schemas.creatureLegendary();
                    break;
                case FeatureType.Reaction:
                    feature = new Schemas.creatureReaction();
                    break;
                case FeatureType.Trait:
                    feature = new Schemas.creatureTrait();
                    break;
            }
            feature.attack = attack.ToString();
            feature.name = name;
            feature.text = text;
            this.attack = attack;
        }

        public AttackRoll Attack => attack;
        public string Name => feature.name;
        public string Text => feature.text;

        private AttackRoll attack;
        private Schemas.IFeature feature;
    }

    public class SpellCasting 
    {
        public IEnumerable<int> Slots => slots;
        public IEnumerable<string> Spells => spells;

        public void SetSlots(int level, int number)
        {
            if (level > 9 || level <= 0) { throw new ArgumentException($"Invalid spell level: {level}"); }
            if (number < 0) { throw new ArgumentException($"Cannot have negative slots"); }
            slots[level - 1] = number;
        }

        public void AddSpell(string name)
        {
            if (spells.Contains(name)) { return; }
            spells.Add(name);
            return;
        }

        public void RemoveSpell(string name)
        {
            if (!spells.Contains(name)) { return; }
            spells.Remove(name);
            return;
        }

        public string SpellSlots => slots.ToSeparatedString();
        public string SpellNames => spells.ToSeparatedString();

        private List<int> slots = new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0};
        private List<string> spells = new List<string>();
    }

    public static class ExtensionMethods
    {
        public static string ToSeparatedString(this IEnumerable<NameValuePair> lst)
        {
            var output = new StringBuilder();
            output.AppendJoin(',', lst.Select(x => x.ToString()));
            return output.ToString();
        }

        public static string ToSeparatedString(this IEnumerable<string> lst)
        {
            var output = new StringBuilder();
            output.AppendJoin(',', lst);
            return output.ToString();
        }

        public static string ToSeparatedString(this IEnumerable<int> lst)
        {
            var output = new StringBuilder();
            output.AppendJoin(',', lst);
            return output.ToString();
        }

        public static string ToSeparatedString(this IEnumerable<Schemas.campaignItemProperty> lst)
        {
            var output = new StringBuilder();
            output.AppendJoin(',', lst);
            return output.ToString();
        }
    }
}