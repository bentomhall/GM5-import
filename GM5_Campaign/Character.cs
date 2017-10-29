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
            get { return c.label; }
            set
            {
                c.label = value ?? "New character";
            }
        }

        public string RaceAndClass
        {
            get { return c.name; }
            set { c.name = value ?? ""; }
        }

        public creatureSize Size
        {
            get { return c.size; }
            set { c.size = value; }
        }

        public string Type
        {
            get { return c.type; }
            set { c.type = value ?? "Humanoid"; }
        }

        public string Alignment
        {
            get { return c.alignment; }
            set { c.alignment = value ?? "Unaligned"; }
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
            get { return c.speed; }
            set { c.speed = value ?? "30 ft."; }
        }

        public Attribute Strength
        {
            get { return new Attribute(c.str); }
            set { c.str = value.Score; }
        }

        public Attribute Dexterity
        {
            get { return new Attribute(c.dex); }
            set { c.dex = value.Score; }
        }

        public Attribute Constitution
        {
            get { return new Attribute(c.con); }
            set { c.con = value.Score; }
        }

        public Attribute Intelligence
        {
            get { return new Attribute(c.@int); }
            set { c.@int = value.Score; }
        }

        public Attribute Wisdom
        {
            get { return new Attribute(c.wis); }
            set { c.wis = value.Score; }
        }

        public Attribute Charisma
        {
            get { return new Attribute(c.cha); }
            set { c.cha = value.Score; }
        }

        public IEnumerable<NameValuePair> Saves => saves;

        public void AddSave(NameValuePair s)
        {
            saves.Add(s);
            c.save = saves.ToSeparatedString();
        }

        public IEnumerable<NameValuePair> Skills => skills;

        public void AddSkill(NameValuePair s)
        {
            skills.Add(s);
            c.skill = skills.ToSeparatedString();
        }

        public IEnumerable<string> Vulnerabilities => vulnerabilities;
        public IEnumerable<string> Resistances => resistances;
        public IEnumerable<string> Immunities => immunities;
        public IEnumerable<string> ConditionImmunities => conditionImmunities;

        public void AddVulnerability(string v)
        {
            vulnerabilities.Add(v);
            c.vulnerable = vulnerabilities.ToSeparatedString();
        }

        public void AddResistance(string s)
        {
            resistances.Add(s);
            c.resist = resistances.ToSeparatedString();
        }

        public void AddImmunity(string s)
        {
            immunities.Add(s);
            c.immune = immunities.ToSeparatedString();
        }

        public void AddConditionImmunity(string s)
        {
            conditionImmunities.Add(s);
            c.conditionimmune = conditionImmunities.ToSeparatedString();
        }

        public IEnumerable<NameValuePair> Senses => senses;
        public void AddSense(NameValuePair sense)
        {
            senses.Add(sense);
            c.senses = senses.ToSeparatedString();
        }

        public int PassivePerception {
            get { return c.passive; }
            set { c.passive = value; }
        }

        public CharacterType CharacterRole { get; private set; }

        public string Languages {
            get { return c.languages; }
            set { c.languages = value; }
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
