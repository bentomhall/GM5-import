using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schemas;

namespace CampaignCore
{
    public enum ItemType
    {
        LightArmor,
        MediumArmor,
        HeavyArmor,
        Shield,
        Melee,
        Ranged,
        Ammunition,
        Rod,
        Staff,
        Wand,
        Ring,
        Potion,
        Scroll,
        WondrousItem,
        Gem,
        Currency
    }

    public enum DamageType
    {
        Bludgeoning,
        Piercing,
        Slashing
    }

    public enum ItemProperty
    {
        Ammunition,
        Finesse,
        Heavy,
        Light,
        Loading,
        Ranged,
        Thrown,
        TwoHanded,
        Versitile,
        Special
    }

    class Item : IEquatable<Item>
    {
        public Item(ItemMapper map)
        {
            mapper = map;
        }

        public campaignItem ItemEntity => item;

        public string Name
        {
            get => item.name;
            set => item.name = value;
        }

        public ItemType Type
        {
            get => mapper.GetItemType(item.type);
            set => item.type = mapper.GetItemCode(value);
        }

        public string Detail
        {
            get => item.detail;
            set => item.detail = value;
        }

        public bool IsMagic
        {
            get => item.magic > 0;
            set
            {
                if (value) { item.magic = 1; }
                else { item.magic = 0; }
            }
        }

        public decimal Weight
        {
            get => item.weight;
            set => item.weight = value;
        }

        public string Text
        {
            get => item.text;
            set => item.text = value;
        }

        public int ArmorClass
        {
            get => item.ac;
            set => item.ac = value;
        }

        public int StrengthRequirement
        {
            get => item.strength;
            set => item.strength = value;
        }

        public bool AffectsStealth
        {
            get => item.stealth == campaignItemStealth.YES;
            set
            {
                if (value) { item.stealth = campaignItemStealth.YES; }
                else { item.stealth = campaignItemStealth.NO; }
            }
        }

        public DiceValue OneHandDamage
        {
            get => oneHandDamage;
            set => oneHandDamage = value; 
        }

        public DiceValue TwoHandDamage
        {
            get => twoHandDamage;
            set => twoHandDamage = value;
        }

        public IEnumerable<ItemProperty> Properties => properties;
        public void AddProperty(ItemProperty p)
        {
            if (properties.Contains(p)) { return; }
            properties.Add(p);
        }
        public void RemoveProperty(ItemProperty p)
        {
            properties.Remove(p);
        }

        public campaignItem BuildForPersistance()
        {
            item.property = properties.Select(x => mapper.GetPropertyLetterCode(x)).ToSeparatedString();
            if (oneHandDamage.Number != 0) {item.dmg1 = oneHandDamage.ToString(); }
            if (twoHandDamage.Number != 0) { item.dmg2 = twoHandDamage.ToString(); }
            return item;
        }

        public bool Equals(Item other)
        {
            return other.Name == Name && other.Type == Type;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) { return false; }
            var other = obj as Item;
            if (other == null) { return false; }
            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Type.GetHashCode();
        }

        private DiceValue oneHandDamage;
        private DiceValue twoHandDamage;
        private List<ItemProperty> properties = new List<ItemProperty>();
        private campaignItem item = new campaignItem();
        private ItemMapper mapper;
    }
}
