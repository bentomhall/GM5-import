using System;
using Schemas;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
namespace GM5_Campaign
{

    public class CreatureParser
    {
        public CreatureParser(creature loaded)
        {
            c = loaded;
        }

        public List<CreatureFeature> ParseFeatures(FeatureType source) {

            var output = new List<CreatureFeature>();
            if (source == FeatureType.Trait)
            {
                foreach (var f in c.trait) {
                    var data = parseFeature(f);
                    var feature = new CreatureFeature(source, data.Item1, data.Item2, data.Item3);
                    output.Add(feature);
                }
            }
            else if (source == FeatureType.Action) 
            {
                foreach (var f in c.action)
                {
                    var data = parseFeature(f);
                    var feature = new CreatureFeature(source, data.Item1, data.Item2, data.Item3);
                    output.Add(feature);
                }
            }
            else if (source == FeatureType.Reaction) 
            {
                foreach (var f in c.reaction)
                {
                    var data = parseFeature(f);
                    var feature = new CreatureFeature(source, data.Item1, data.Item2, data.Item3);
                    output.Add(feature);
                }
            }
            else
            {
                foreach (var f in c.legendary)
                {
                    var data = parseFeature(f);
                    var feature = new CreatureFeature(source, data.Item1, data.Item2, data.Item3);
                    output.Add(feature);
                }
            }
            return output;
        }

        private Tuple<string, string, AttackRoll> parseFeature(IFeature f) {
            var ar = ParseAttack(f.attack);
            var title = f.name;
            var text = f.text;
            return new Tuple<string, string, AttackRoll>(title, text, ar);
        }

        public List<NameValuePair> ParseNameValuePair(string source) 
        {
            var map = new Dictionary<string, string>()
            {
                {"skill", c.skill},
                {"sense", c.senses},
                {"save", c.save}
            };
            var output = new List<NameValuePair>();
            foreach (var f in map[source].Split(','))
            {
                var ar = f.Split(' ');
                var nvp = new NameValuePair(ar[0], int.Parse(ar[1]));
                output.Add(nvp);
            }
            return output;
        } 

        public List<string> ParseStringList(string source) {
            var sMap = new Dictionary<string, string>()
            {
                {"vulnerability", c.vulnerable},
                {"resistance", c.resist},
                {"immunity", c.immune},
                {"condition", c.conditionimmune},
            };
            var charSource = sMap[source];
            return charSource.Split(',').ToList();
        }

        public AttackRoll ParseAttack(string a)
        {
            var lst = a.Split('|');
            var atk = int.Parse(lst[1]);
            var dice = ParseDiceValue(lst[2]);
            var map = new Dictionary<string, AttackType>()
            {
                {"Melee Spell Attack", AttackType.MeleeSpell},
                {"Melee Weapon Attack", AttackType.MeleeWeapon},
                {"Ranged Spell Attack", AttackType.RangedSpell},
                {"Ranged Weapon Attack", AttackType.RangedWeapon},
                {"Saving Throw", AttackType.SavingThrow}
            };

            return new AttackRoll(map[lst[0]], atk, dice);
        }



        public SpellCasting ParseSpells()
        {
            var slots = c.slots.Split(',').Select(x => int.Parse(x)).ToList();
            var spells = c.spells.Split(',').ToList();
            return new SpellCasting(slots, spells);
        }

        public ArmorClass ParseArmorClass() 
        {
            Regex rx = new Regex(@"(\d+) \(\w+) \)", RegexOptions.Compiled);
            var matches = rx.Match(c.ac);
            var captures = matches.Captures;
            var ac = int.Parse(captures[0].Value);
            var source = captures[1].Value;
            return new ArmorClass(ac, source);
        }

        public HitPoints ParseHitPoints()
        {
            Regex rx = new Regex(@"(\d+) \(\w+) \)", RegexOptions.Compiled);
            var matches = rx.Match(c.ac);
            var captures = matches.Captures;
            var max = int.Parse(captures[0].Value);
            var dice = ParseDiceValue(captures[1].Value);
            return new HitPoints(max, dice);
        }

        private DiceValue ParseDiceValue(string s)
        {
            Regex rx = new Regex(@"(\d +)d(\d +)(\+(\d +) | (-\d +))?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matches = rx.Match(s);
            var captures = matches.Captures;
            int staticBonus;
            int number;
            int sides;
            if (captures.Count < 2) { throw new ArgumentException($"Incorrect format for input string: {s}"); }
            else if (captures.Count == 2) { staticBonus = 0; }
            else { staticBonus = int.Parse(captures[3].Value); }
            number = int.Parse(captures[0].Value);
            sides = int.Parse(captures[1].Value);
            return new DiceValue(number, sides, staticBonus);
        }
        private creature c;
    }
}
