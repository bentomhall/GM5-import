//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
//This source code was auto-generated by MonoXSD
//

using System.Collections.Generic;

namespace Schemas {
    public interface IFeature
    {
        string name { get; set; }
        string text { get; set; }
        string attack { get; set; }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class campaign {
        
        private List<creature> pcField =  new List<creature>();
        
        private List<creature> npcField = new List<creature>();
        
        private List<campaignNote> noteField = new List<campaignNote>();
        
        private List<campaignEncounter> encounterField = new List<campaignEncounter>();
        
        private List<campaignItem> itemField = new List<campaignItem>();
        
        private string versionField = "5";
        
        private string auto_indentField = "YES";
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("pc", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<creature> pc {
            get {
                return this.pcField;
            }
            set {
                this.pcField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("npc", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<creature> npc {
            get {
                return this.npcField;
            }
            set {
                this.npcField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("note", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<campaignNote> note {
            get {
                return this.noteField;
            }
            set {
                this.noteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("encounter", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<campaignEncounter> encounter {
            get {
                return this.encounterField;
            }
            set {
                this.encounterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<campaignItem> item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string version {
            get {
                return this.versionField;
            }
            set {
                this.versionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string auto_indent {
            get {
                return this.auto_indentField;
            }
            set {
                this.auto_indentField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class creature {
        
        private string labelField = "";
        
        private string nameField = "";
        
        private creatureSize sizeField = creatureSize.M;
        
        private string typeField = "";
        
        private string alignmentField ="";
        
        private string acField = "10";
        
        private string hpField = "";
        
        private string speedField = "30 ft.";
        
        private int strField = 10;
        
        private int dexField = 10;
        
        private int conField = 10;
        
        private int intField = 10;
        
        private int wisField = 10;
        
        private int chaField = 10;
        
        private string saveField = "";
        
        private string skillField = "";
        
        private string vulnerableField = "";
        
        private string resistField = "";
        
        private string immuneField = "";
        
        private string conditionimmuneField = "";
        
        private string sensesField = "";
        
        private int passiveField = 10;
        
        private string languagesField = "";
        
        private int crField = 0;
        
        private int levelField = 0;
        
        private string slotsField = "0,0,0,0,0,0,0,0,0";
        
        private string spellsField = "";
        
        private List<creatureTrait> traitField;
        
        private List<creatureAction> actionField;
        
        private List<creatureReaction> reactionField;
        
        private List<creatureLegendary> legendaryField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string label {
            get {
                return this.labelField;
            }
            set {
                this.labelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public creatureSize size {
            get {
                return this.sizeField;
            }
            set {
                this.sizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string alignment {
            get {
                return this.alignmentField;
            }
            set {
                this.alignmentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string ac {
            get {
                return this.acField;
            }
            set {
                this.acField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string hp {
            get {
                return this.hpField;
            }
            set {
                this.hpField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string speed {
            get {
                return this.speedField;
            }
            set {
                this.speedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public int str {
            get {
                return this.strField;
            }
            set {
                this.strField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public int dex {
            get {
                return this.dexField;
            }
            set {
                this.dexField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public int con {
            get {
                return this.conField;
            }
            set {
                this.conField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public int @int {
            get {
                return this.intField;
            }
            set {
                this.intField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public int wis {
            get {
                return this.wisField;
            }
            set {
                this.wisField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public int cha {
            get {
                return this.chaField;
            }
            set {
                this.chaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string save {
            get {
                return this.saveField;
            }
            set {
                this.saveField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string skill {
            get {
                return this.skillField;
            }
            set {
                this.skillField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string vulnerable {
            get {
                return this.vulnerableField;
            }
            set {
                this.vulnerableField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string resist {
            get {
                return this.resistField;
            }
            set {
                this.resistField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string immune {
            get {
                return this.immuneField;
            }
            set {
                this.immuneField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string conditionimmune {
            get {
                return this.conditionimmuneField;
            }
            set {
                this.conditionimmuneField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string senses {
            get {
                return this.sensesField;
            }
            set {
                this.sensesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public int passive {
            get {
                return this.passiveField;
            }
            set {
                this.passiveField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string languages {
            get {
                return this.languagesField;
            }
            set {
                this.languagesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public int cr {
            get {
                return this.crField;
            }
            set {
                this.crField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, DataType="integer")]
        public int level {
            get {
                return this.levelField;
            }
            set {
                this.levelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string slots {
            get {
                return this.slotsField;
            }
            set {
                this.slotsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string spells {
            get {
                return this.spellsField;
            }
            set {
                this.spellsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("trait", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<creatureTrait> trait {
            get {
                return this.traitField;
            }
            set {
                this.traitField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("action", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<creatureAction> action {
            get {
                return this.actionField;
            }
            set {
                this.actionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("reaction", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<creatureReaction> reaction {
            get {
                return this.reactionField;
            }
            set {
                this.reactionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("legendary", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<creatureLegendary> legendary {
            get {
                return this.legendaryField;
            }
            set {
                this.legendaryField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum creatureSize {
        
        /// <remarks/>
        T,
        
        /// <remarks/>
        S,
        
        /// <remarks/>
        M,
        
        /// <remarks/>
        L,
        
        /// <remarks/>
        H,
        
        /// <remarks/>
        G,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class creatureTrait : IFeature {
        
        private string nameField;
        
        private string textField;
        
        private string attackField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string attack {
            get {
                return this.attackField;
            }
            set {
                this.attackField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class creatureAction : IFeature {
        
        private string nameField;
        
        private string textField;
        
        private string attackField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string attack {
            get {
                return this.attackField;
            }
            set {
                this.attackField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class creatureReaction : IFeature{
        
        private string nameField;
        
        private string textField;
        
        private string attackField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string attack {
            get {
                return this.attackField;
            }
            set {
                this.attackField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class creatureLegendary : IFeature {
        
        private string nameField;
        
        private string textField;
        
        private string attackField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string attack {
            get {
                return this.attackField;
            }
            set {
                this.attackField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class campaignNote {
        
        private string titleField = "";
        
        private string textField = "";
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string title {
            get {
                return this.titleField;
            }
            set {
                this.titleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class campaignEncounter {
        
        private string nameField = "";
        
        private List<campaignEncounterCombatant> combatantField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("combatant", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<campaignEncounterCombatant> combatant {
            get {
                return this.combatantField;
            }
            set {
                this.combatantField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class campaignEncounterCombatant {
        
        private string hpField = "";
        
        private string pcField;
        
        private string labelField;
        
        private string monsterField;
        
        private campaignEncounterCombatantRole roleField = campaignEncounterCombatantRole.enemy;
        
        private bool roleFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string hp {
            get {
                return this.hpField;
            }
            set {
                this.hpField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string pc {
            get {
                return this.pcField;
            }
            set {
                this.pcField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string label {
            get {
                return this.labelField;
            }
            set {
                this.labelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string monster {
            get {
                return this.monsterField;
            }
            set {
                this.monsterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public campaignEncounterCombatantRole role {
            get {
                return this.roleField;
            }
            set {
                this.roleField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool roleSpecified {
            get {
                return this.roleFieldSpecified;
            }
            set {
                this.roleFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum campaignEncounterCombatantRole {
        
        /// <remarks/>
        enemy,
        
        /// <remarks/>
        ally,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class campaignItem {
        
        private string nameField = "";
        
        private campaignItemType typeField = campaignItemType.W;
        
        private bool typeFieldSpecified = false;
        
        private string detailField = "";
        
        private int magicField = 0;
        
        private decimal weightField = 0;
        
        private string textField = "";
        
        private int acField = 10;
        
        private int strengthField = 0;
        
        private campaignItemStealth stealthField;
        
        private bool stealthFieldSpecified;
        
        private string dmg1Field;
        
        private string dmg2Field;
        
        private campaignItemDmgType dmgTypeField;
        
        private bool dmgTypeFieldSpecified;
        
        private string propertyField;
        
        private bool propertyFieldSpecified;
        
        private string rangeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public campaignItemType type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool typeSpecified {
            get {
                return this.typeFieldSpecified;
            }
            set {
                this.typeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string detail {
            get {
                return this.detailField;
            }
            set {
                this.detailField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int magic {
            get {
                return this.magicField;
            }
            set {
                this.magicField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public decimal weight {
            get {
                return this.weightField;
            }
            set {
                this.weightField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string text {
            get {
                return this.textField;
            }
            set {
                this.textField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int ac {
            get {
                return this.acField;
            }
            set {
                this.acField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int strength {
            get {
                return this.strengthField;
            }
            set {
                this.strengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public campaignItemStealth stealth {
            get {
                return this.stealthField;
            }
            set {
                this.stealthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool stealthSpecified {
            get {
                return this.stealthFieldSpecified;
            }
            set {
                this.stealthFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string dmg1 {
            get {
                return this.dmg1Field;
            }
            set {
                this.dmg1Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string dmg2 {
            get {
                return this.dmg2Field;
            }
            set {
                this.dmg2Field = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public campaignItemDmgType dmgType {
            get {
                return this.dmgTypeField;
            }
            set {
                this.dmgTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool dmgTypeSpecified {
            get {
                return this.dmgTypeFieldSpecified;
            }
            set {
                this.dmgTypeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string property {
            get {
                return this.propertyField;
            }
            set {
                this.propertyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool propertySpecified {
            get {
                return this.propertyFieldSpecified;
            }
            set {
                this.propertyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string range {
            get {
                return this.rangeField;
            }
            set {
                this.rangeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum campaignItemType {
        
        /// <remarks/>
        LA,
        
        /// <remarks/>
        MA,
        
        /// <remarks/>
        HA,
        
        /// <remarks/>
        S,
        
        /// <remarks/>
        M,
        
        /// <remarks/>
        R,
        
        /// <remarks/>
        A,
        
        /// <remarks/>
        RD,
        
        /// <remarks/>
        ST,
        
        /// <remarks/>
        WD,
        
        /// <remarks/>
        RG,
        
        /// <remarks/>
        P,
        
        /// <remarks/>
        SC,
        
        /// <remarks/>
        W,
        
        /// <remarks/>
        G,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("$")]
        Currency,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum campaignItemStealth {
        
        /// <remarks/>
        YES,
        
        /// <remarks/>
        NO,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum campaignItemDmgType {
        
        /// <remarks/>
        B,
        
        /// <remarks/>
        P,
        
        /// <remarks/>
        S,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public enum campaignItemProperty {
        
        /// <remarks/>
        A,
        
        /// <remarks/>
        F,
        
        /// <remarks/>
        H,
        
        /// <remarks/>
        L,
        
        /// <remarks/>
        LD,
        
        /// <remarks/>
        R,
        
        /// <remarks/>
        S,
        
        /// <remarks/>
        T,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("2H")]
        Item2H,
        
        /// <remarks/>
        V,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "0.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class GMCampaign {
        
        private campaign[] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("campaign")]
        public campaign[] Items {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }
    }
}
