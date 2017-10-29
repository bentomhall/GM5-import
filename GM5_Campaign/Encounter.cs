using System;
using System.Collections.Generic;
using System.Text;
using Schemas;
using System.Linq;

namespace GM5_Campaign
{
    class Encounter
    {
        public string Name
        {
            get => encounter.name;
            set => encounter.name = value;
        }

        public void AddCombatant(CharacterType role, string label, string monsterName = "", int currentHP = 0, int maxHP = 0)
        {
            var combatant = new campaignEncounterCombatant();
            if (role == CharacterType.PC)
            {
                combatant.pc = label;
            }
            else
            {
                if (role == CharacterType.Ally) { combatant.role = campaignEncounterCombatantRole.ally; combatant.roleSpecified = true; }
                else { combatant.role = campaignEncounterCombatantRole.enemy; combatant.roleSpecified = true; }
                combatant.label = label;
                if (monsterName != "") { combatant.monster = monsterName; }
            }
            if (maxHP > 0)
            {
                combatant.hp = $"{currentHP}/{maxHP}";
            }
            encounter.combatant.Add(combatant);
        }

        public campaignEncounterCombatant GetCombatant(string label)
        {
            return encounter.combatant.Single(x => x.label == label || x.pc == label);
        }

        public void RemoveCombatant(campaignEncounterCombatant c)
        {
            encounter.combatant.Remove(c);
        }

        private campaignEncounter encounter = new campaignEncounter();

    }
}
