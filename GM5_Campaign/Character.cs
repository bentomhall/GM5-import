using System;
using System.Collections.Generic;
using System.Text;
using Schemas;
using System.Linq;

namespace GM5_Campaign
{
    public class Character
    {
        public Character(CharacterType role)
        {
            c = new creature();
            CharacterRole = role;
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
            c.ac = ac.ToString();
        }

        public HitPoints HP => hp;

        public void SetHitPoints(int maximum, DiceValue hd)
        {
            hp = new HitPoints(maximum, hd);
            c.hp = hp.ToString();
        }

        public string Speed
        {
            get => c.speed;
            set => c.speed = value ?? "30 ft.";
        }

        public Attribute Strength
        {
            get => new Attribute(c.str);
            set => c.str = value.Score;
        }

        public Attribute Dexterity
        {
            get => new Attribute(c.dex);
            set => c.dex = value.Score;
        }

        public Attribute Constitution
        {
            get => new Attribute(c.con);
            set => c.con = value.Score;
        }

        public Attribute Intelligence
        {
            get => new Attribute(c.@int);
            set => c.@int = value.Score;
        }

        public Attribute Wisdom
        {
            get => new Attribute(c.wis);
            set => c.wis = value.Score;
        }

        public Attribute Charisma
        {
            get => new Attribute(c.cha);
            set => c.cha = value.Score;
        }

        public IEnumerable<NameValuePair> Saves => saves;

        public void AddSave(NameValuePair s)
        {
            if (saves.Contains(s)) { return; }
            saves.Add(s);
            c.save = saves.ToSeparatedString();
        }

        public void RemoveSave(NameValuePair s)
        {
            saves.Remove(s);
            c.save = saves.ToSeparatedString();
        }

        public IEnumerable<NameValuePair> Skills => skills;

        public void AddSkill(NameValuePair s)
        {
            if (skills.Contains(s)) { return; }
            skills.Add(s);
            c.skill = skills.ToSeparatedString();
        }

        public void RemoveSkill(NameValuePair s)
        {
            skills.Remove(s);
            c.skill = skills.ToSeparatedString();
        }

        public IEnumerable<string> Vulnerabilities => vulnerabilities;
        public IEnumerable<string> Resistances => resistances;
        public IEnumerable<string> Immunities => immunities;
        public IEnumerable<string> ConditionImmunities => conditionImmunities;

        public void AddVulnerability(string v)
        {
            if (vulnerabilities.Contains(v)) { return; }
            vulnerabilities.Add(v);
            c.vulnerable = vulnerabilities.ToSeparatedString();
        }

        public void RemoveVulnerability(string v)
        {
            vulnerabilities.Remove(v);
            c.vulnerable = vulnerabilities.ToSeparatedString();
        }

        public void AddResistance(string s)
        {
            if (resistances.Contains(s)) { return; }
            resistances.Add(s);
            c.resist = resistances.ToSeparatedString();
        }

        public void RemoveResistance(string s)
        {
            resistances.Remove(s);
            c.resist = vulnerabilities.ToSeparatedString();
        }

        public void AddImmunity(string s)
        {
            if (immunities.Contains(s)) { return; }
            immunities.Add(s);
            c.immune = immunities.ToSeparatedString();
        }

        public void RemoveImmunity(string s)
        {
            immunities.Remove(s);
            c.immune = immunities.ToSeparatedString();
        }

        public void AddConditionImmunity(string s)
        {
            if (conditionImmunities.Contains(s)) { return; }
            conditionImmunities.Add(s);
            c.conditionimmune = conditionImmunities.ToSeparatedString();
        }

        public void RemoveConditionImmunity(string s)
        {
            conditionImmunities.Remove(s);
            c.conditionimmune = conditionImmunities.ToSeparatedString();
        }

        public IEnumerable<NameValuePair> Senses => senses;
        public void AddSense(NameValuePair sense)
        {
            if (senses.Contains(sense)) { return; }
            senses.Add(sense);
            c.senses = senses.ToSeparatedString();
        }

        public void RemoveSense(NameValuePair sense)
        {
            senses.Remove(sense);
            c.senses = senses.ToSeparatedString();
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

        public creature Creature => c;

        private SpellCasting spells = new SpellCasting();
        private List<NameValuePair> senses = new List<NameValuePair>();
        private List<string> resistances = new List<string>();
        private List<string> immunities = new List<string>();
        private List<string> conditionImmunities = new List<string>();
        private List<string> vulnerabilities = new List<string>();
        private List<NameValuePair> skills = new List<NameValuePair>();
        private List<NameValuePair> saves = new List<NameValuePair>();
        private HitPoints hp;
        private ArmorClass ac;
        private creature c;
    }
}
