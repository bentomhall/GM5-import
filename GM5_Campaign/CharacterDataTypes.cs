using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public int Value { get; set; }
        public string Source { get; set; }

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
        public int Number { get; set; }
        public int Sides { get; set; }
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
        public AttackRoll(AttackType type, int hitBonus, DiceValue damage) {}
    }

    public struct CreatureFeature {
        public CreatureFeature(FeatureType type, string name, string text, AttackRoll attack ) {
            
        }

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
    }
}