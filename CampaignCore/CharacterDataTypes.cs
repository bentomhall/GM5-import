﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace CampaignCore
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

        public int Number { get; private set; }
        public int Sides { get; private set; }
        public int StaticBonus {get; private set; }

        public override string ToString()
        {
            if ((Number == 0 || Sides == 0) && StaticBonus == 0) { return ""; }
            else if ((Number == 0 || Sides == 0) && StaticBonus != 0) { return StaticBonus.ToString("+0;-0"); }
            if (StaticBonus > 0) { return $"{Number}d{Sides}+{StaticBonus}"; }
            else if (StaticBonus == 0) { return $"{Number}d{Sides}"; }
            else { return $"{Number}d{Sides}-{Math.Abs(StaticBonus)}";}
        }
    }

    public struct CharacterAttribute
    {
        public CharacterAttribute(int score)
        {
            Score = Math.Max(score, 1);
            Modifier = (int)Math.Floor((Score - 10.0) / 2.0);

        }

        public int Score { get; private set; }
        public int Modifier { get; private set; }

        public override string ToString()
        {
            return $"{Score} ({Modifier.ToString("+0;-0")})";
        }
    }

    public class NameValuePair : IEquatable<NameValuePair>
    {
        public NameValuePair (string name, int value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public int Value { get; private set; }

        public bool Equals(NameValuePair other)
        {
            return other.Name == Name && other.Value == Value;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            NameValuePair NVPOther = obj as NameValuePair;
            if (NVPOther == null) { return false; }
            return Equals(NVPOther);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} {Value.ToString("+0;-0")}";
        }
    }

    public class AttackRoll {
        public AttackRoll(string text, int hitBonus, DiceValue damage) 
        {
            Details = text;
            HitBonus = hitBonus;
            Damage = damage;
        }

        public override string ToString()
        {
            if (Details == "" && HitBonus == 0 && Damage.Number == 0 && Damage.StaticBonus == 0) { return ""; } //empty value, null replacement
            return $"{Details}|{HitBonus.ToString("+0;0;-0")}|{Damage}";
        }

        public string Details { get; private set; }
        public int HitBonus {get; private set; }
        public DiceValue Damage { get; private set; }
    }

    public class CreatureFeature : IEquatable<CreatureFeature>
    {
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
            feature.attack = attack?.ToString() ?? "";
            feature.name = name;
            feature.text = text;
            this.attack = attack ?? new AttackRoll("", 0, new DiceValue(0,0,0));
        }

        public AttackRoll Attack => attack ;
        public string Name => feature.name;
        public string Text => feature.text;

        public Schemas.IFeature Feature => feature;

        private AttackRoll attack;
        private Schemas.IFeature feature;

        public bool Equals(CreatureFeature other)
        {
            return other.Name == Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            var other = obj as CreatureFeature;
            if (other == null) { return false; }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }

    public class SpellCasting 
    {
        public SpellCasting() 
        {
            
        }

        public SpellCasting(List<int> _slots, List<string> _spells)
        {
            //does not validate spell slots!
            slots = _slots;
            spells = _spells;
        }


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
            var output = string.Join(",", lst);
            return output;

        }

        public static string ToSeparatedString(this IEnumerable<string> lst)
        {
            return string.Join(",", lst);
        }

        public static string ToSeparatedString(this IEnumerable<int> lst)
        {
            return string.Join(",", lst);
        }

        public static string ToSeparatedString(this IEnumerable<Schemas.campaignItemProperty> lst)
        {
            return string.Join(",", lst);
        }
    }
}