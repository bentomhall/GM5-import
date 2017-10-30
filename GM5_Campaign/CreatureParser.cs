using System;
using Schemas;
using System.Collections.Generic;
using System.Linq;
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

        public List<NameValuePair> ParseSkills() {
            var output = new List<NameValuePair>();
            foreach (var f in c.skill.Split(',')) {
                var ar = f.Split(' ');
                var nvp = new NameValuePair(ar[0], int.Parse(ar[1]));
                output.Add(nvp);
            }
            return output;
        }

        public List<NameValuePair> ParseSaves() {
            var output = new List<NameValuePair>();
            foreach (var f in c.save.Split(','))
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
                {"condition", c.conditionimmune}
            };
            var charSource = sMap[source];
            return charSource.Split(',').ToList();
        }

        public AttackRoll ParseAttack(string a) {
            return new AttackRoll(AttackType.MeleeSpell, 0, new DiceValue(1, 6, 0));
        }

        private creature c;
    }
}
