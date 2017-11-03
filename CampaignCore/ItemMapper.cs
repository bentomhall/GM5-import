using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Schemas;

namespace CampaignCore
{
    class ItemMapper
    {
        public ItemMapper()
        {
            codeToTypeMap = typeToCodeMap.ToDictionary(x => x.Value, x => x.Key);
            letterCodeToPropertyMap = propertyToCodeMap.ToDictionary(x => x.Value, x => x.Key);
        }

        public ItemType GetItemType(campaignItemType letterCode) => codeToTypeMap[letterCode];
        public campaignItemType GetItemCode(ItemType itemType) => typeToCodeMap[itemType];
        public DamageType GetDamageType(campaignItemDmgType letterCode) => codeToDmgMap[letterCode];
        public campaignItemDmgType GetDamageCode(DamageType damageType) => dmgToCodeMap[damageType];
        public ItemProperty GetItemProperty(campaignItemProperty property) => letterCodeToPropertyMap[property];
        public campaignItemProperty GetPropertyLetterCode(ItemProperty property) => propertyToCodeMap[property];


        private Dictionary<ItemType, campaignItemType> typeToCodeMap = new Dictionary<ItemType, campaignItemType>()
        {
            {ItemType.Ammunition, campaignItemType.A },
            {ItemType.LightArmor, campaignItemType.LA },
            {ItemType.Currency, campaignItemType.Currency },
            {ItemType.Gem, campaignItemType.G },
            {ItemType.HeavyArmor, campaignItemType.HA },
            {ItemType.MediumArmor, campaignItemType.MA },
            {ItemType.Melee, campaignItemType.M },
            {ItemType.Potion, campaignItemType.P },
            {ItemType.Ranged, campaignItemType.R },
            {ItemType.Ring, campaignItemType.RG },
            {ItemType.Rod, campaignItemType.RD },
            {ItemType.Scroll, campaignItemType.SC },
            {ItemType.Shield, campaignItemType.S },
            {ItemType.Staff, campaignItemType.ST },
            {ItemType.Wand, campaignItemType.WD },
            {ItemType.WondrousItem, campaignItemType.W }
        };

        private Dictionary<campaignItemType, ItemType> codeToTypeMap;

        private Dictionary<DamageType, campaignItemDmgType> dmgToCodeMap = new Dictionary<DamageType, campaignItemDmgType>()
        {
            { DamageType.Bludgeoning, campaignItemDmgType.B },
            { DamageType.Piercing, campaignItemDmgType.P },
            { DamageType.Slashing, campaignItemDmgType.S }
        };

        private Dictionary<campaignItemDmgType, DamageType> codeToDmgMap = new Dictionary<campaignItemDmgType, DamageType>()
        {
            { campaignItemDmgType.B, DamageType.Bludgeoning },
            { campaignItemDmgType.P, DamageType.Piercing },
            { campaignItemDmgType.S, DamageType.Slashing }

        };

        private Dictionary<ItemProperty, campaignItemProperty> propertyToCodeMap = new Dictionary<ItemProperty, campaignItemProperty>()
        {
            { ItemProperty.Ammunition, campaignItemProperty.A },
            { ItemProperty.Finesse, campaignItemProperty.F },
            { ItemProperty.Heavy, campaignItemProperty.H },
            { ItemProperty.Light, campaignItemProperty.L },
            { ItemProperty.Loading, campaignItemProperty.LD },
            { ItemProperty.Ranged, campaignItemProperty.R },
            { ItemProperty.Special, campaignItemProperty.S },
            { ItemProperty.Thrown, campaignItemProperty.T },
            { ItemProperty.TwoHanded, campaignItemProperty.Item2H },
            { ItemProperty.Versitile, campaignItemProperty.V }
        };
        private Dictionary<campaignItemProperty, ItemProperty> letterCodeToPropertyMap;

    }
}
