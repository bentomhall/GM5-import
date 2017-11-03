using System;
using System.Collections.Generic;
using System.Text;
using Schemas;
using System.Linq;

namespace CampaignCore
{
    public class Character : IEquatable<Character>
    {
        public Character(CharacterType role)
        {
            c = new creature();
            CharacterRole = role;
        }

        public Character(creature loaded, CharacterType role) {
            c = loaded;
            CharacterRole = role;
            var parser = new CreatureParser(c);
            vulnerabilities = parser.ParseStringList("vulnerability");
            resistances = parser.ParseStringList("resistance");
            immunities = parser.ParseStringList("immunity");
            conditionImmunities = parser.ParseStringList("condition");
            skills = parser.ParseNameValuePair("skill");
            saves = parser.ParseNameValuePair("save");
            senses = parser.ParseNameValuePair("sense");
            traits = parser.ParseFeatures(FeatureType.Trait);
            actions = parser.ParseFeatures(FeatureType.Action);
            reactions = parser.ParseFeatures(FeatureType.Reaction);
            legendaries = parser.ParseFeatures(FeatureType.Legendary);
            spells = parser.ParseSpells();
            ac = parser.ParseArmorClass();
            hp = parser.ParseHitPoints();
        }

        public creature BuildForPersistance()
        {
            c.vulnerable = vulnerabilities.ToSeparatedString();
            c.resist = resistances.ToSeparatedString();
            c.immune = immunities.ToSeparatedString();
            c.conditionimmune = conditionImmunities.ToSeparatedString();
            c.skill = skills.ToSeparatedString();
            c.save = saves.ToSeparatedString();
            c.senses = senses.ToSeparatedString();
            c.spells = spells.SpellNames;
            c.slots = spells.SpellSlots;
            c.trait = traits.Select(x => x.Feature as creatureTrait).ToList();
            c.action = actions.Select(x => x.Feature as creatureAction).ToList();
            c.reaction = reactions.Select(x => x.Feature as creatureReaction).ToList();
            c.legendary = legendaries.Select(x => x.Feature as creatureLegendary).ToList();
            c.hp = hp.ToString();
            c.ac = ac.ToString();
            return c;
        }

        public string Name
        {
            get => c.label;
            set => c.label = value ?? "New character";
        }

        public string RaceAndClass
        {
            get => c.name;
            set => c.name = value ?? "";
        }

        public creatureSize Size
        {
            get => c.size;
            set => c.size = value;
        }

        public string Type
        {
            get => c.type;
            set => c.type = value ?? "Humanoid";
        }

        public string Alignment
        {
            get => c.alignment;
            set => c.alignment = value ?? "Unaligned";
        }

        public ArmorClass AC => ac;

        public void SetArmor(int value, string source)
        {
            ac = new ArmorClass(value, source);
        }

        public HitPoints HP => hp;

        public void SetHitPoints(int maximum, DiceValue hd)
        {
            hp = new HitPoints(maximum, hd);
        }

        public string Speed
        {
            get => c.speed;
            set => c.speed = value ?? "30 ft.";
        }

        public CharacterAttribute Strength
        {
            get => new CharacterAttribute(c.str);
            set => c.str = value.Score;
        }

        public CharacterAttribute Dexterity
        {
            get => new CharacterAttribute(c.dex);
            set => c.dex = value.Score;
        }

        public CharacterAttribute Constitution
        {
            get => new CharacterAttribute(c.con);
            set => c.con = value.Score;
        }

        public CharacterAttribute Intelligence
        {
            get => new CharacterAttribute(c.@int);
            set => c.@int = value.Score;
        }

        public CharacterAttribute Wisdom
        {
            get => new CharacterAttribute(c.wis);
            set => c.wis = value.Score;
        }

        public CharacterAttribute Charisma
        {
            get => new CharacterAttribute(c.cha);
            set => c.cha = value.Score;
        }

        public IEnumerable<NameValuePair> Saves => saves;

        public void AddSave(NameValuePair s)
        {
            if (saves.Contains(s)) { return; }
            saves.Add(s);
        }

        public void RemoveSave(NameValuePair s)
        {
            saves.Remove(s);
        }

        public IEnumerable<NameValuePair> Skills => skills;

        public void AddSkill(NameValuePair s)
        {
            if (skills.Contains(s)) { return; }
            skills.Add(s);
        }

        public void RemoveSkill(NameValuePair s)
        {
            skills.Remove(s);
        }

        public IEnumerable<string> Vulnerabilities => vulnerabilities;
        public IEnumerable<string> Resistances => resistances;
        public IEnumerable<string> Immunities => immunities;
        public IEnumerable<string> ConditionImmunities => conditionImmunities;

        public void AddVulnerability(string v)
        {
            if (vulnerabilities.Contains(v)) { return; }
            vulnerabilities.Add(v);
        }

        public void RemoveVulnerability(string v)
        {
            vulnerabilities.Remove(v);
        }

        public void AddResistance(string s)
        {
            if (resistances.Contains(s)) { return; }
            resistances.Add(s);
        }

        public void RemoveResistance(string s)
        {
            resistances.Remove(s);
        }

        public void AddImmunity(string s)
        {
            if (immunities.Contains(s)) { return; }
            immunities.Add(s);
        }

        public void RemoveImmunity(string s)
        {
            immunities.Remove(s);
        }

        public void AddConditionImmunity(string s)
        {
            if (conditionImmunities.Contains(s)) { return; }
            conditionImmunities.Add(s);
        }

        public void RemoveConditionImmunity(string s)
        {
            conditionImmunities.Remove(s);
        }

        public IEnumerable<NameValuePair> Senses => senses;
        public void AddSense(NameValuePair sense)
        {
            if (senses.Contains(sense)) { return; }
            senses.Add(sense);
        }

        public void RemoveSense(NameValuePair sense)
        {
            senses.Remove(sense);
        }

        public int PassivePerception {
            get => c.passive;
            set => c.passive = value;
        }

        public CharacterType CharacterRole { get; private set; }

        public string Languages {
            get => c.languages;
            set => c.languages = value;
        }

        public int Rating {
            get {
                switch (CharacterRole) {
                    case CharacterType.Ally:
                        return c.level;
                    case CharacterType.PC:
                        return c.level;
                    case CharacterType.Monster:
                        return c.cr;
                    default:
                        return c.cr;
                }                                      
            }
            set {
                switch (CharacterRole) {
                    case CharacterType.Ally:
                    case CharacterType.PC:
                        c.level = value;
                        break;
                    case CharacterType.Monster:
                        c.cr = value;
                        break;
                }
            }
        }

        public IEnumerable<int> SpellSlots => spells.Slots;
        public IEnumerable<string> Spells => spells.Spells;

        public void SetSlots(int level, int number) => spells.SetSlots(level, number);
        public void AddSpell(string name) => spells.AddSpell(name);
        public void RemoveSpell(string name) => spells.RemoveSpell(name);

        public IEnumerable<CreatureFeature> Traits => traits;
        public IEnumerable<CreatureFeature> Actions => actions;
        public IEnumerable<CreatureFeature> Reactions => reactions;
        public IEnumerable<CreatureFeature> Legendaries => legendaries;

        public void AddFeature(CreatureFeature f, FeatureType type) 
        {
            switch (type) {
                case FeatureType.Trait:
                    if (!traits.Contains(f)) { traits.Add(f); }
                    break;
                case FeatureType.Action:
                    if (!actions.Contains(f)) { actions.Add(f); }
                    break;
                case FeatureType.Reaction:
                    if (!reactions.Contains(f)) { reactions.Add(f);}
                    break;
                case FeatureType.Legendary:
                    if (!legendaries.Contains(f)) { legendaries.Add(f);}
                    break;
            }
        }

        public void RemoveFeature(CreatureFeature f, FeatureType t)
        {
            switch (t)
            {
                case FeatureType.Trait:
                    traits.Remove(f);
                    break;
                case FeatureType.Action:
                    actions.Remove(f); 
                    break;
                case FeatureType.Reaction:
                    reactions.Remove(f);
                    break;
                case FeatureType.Legendary:
                    legendaries.Remove(f);
                    break;
            }
        }

        public bool Equals(Character other)
        {
            return other.Name == Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            var other = obj as Character;
            if (other == null) { return false; }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public creature Creature => c;

        private SpellCasting spells = new SpellCasting();
        private List<NameValuePair> senses = new List<NameValuePair>();
        private List<string> resistances = new List<string>();
        private List<string> immunities = new List<string>();
        private List<string> conditionImmunities = new List<string>();
        private List<string> vulnerabilities = new List<string>();
        private List<NameValuePair> skills = new List<NameValuePair>();
        private List<NameValuePair> saves = new List<NameValuePair>();
        private List<CreatureFeature> traits =  new List<CreatureFeature>();
        private List<CreatureFeature> actions = new List<CreatureFeature>();
        private List<CreatureFeature> reactions = new List<CreatureFeature>();
        private List<CreatureFeature> legendaries = new List<CreatureFeature>();
        private HitPoints hp;
        private ArmorClass ac;
        private creature c;
    }
}
