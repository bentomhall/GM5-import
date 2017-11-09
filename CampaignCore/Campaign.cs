using System;
using System.Collections.Generic;
using System.Text;
using Schemas;
using System.Linq;

namespace CampaignCore
{
    public class Campaign
    {
        public Campaign() {
            c = new campaign();
        }

        public Campaign(campaign loaded) {
            c = loaded;
        }

        public string Title
        {
            get => c.name;
            set => c.name = value;
        }

        public IEnumerable<Character> PCs => pcEntities;
        public IEnumerable<Character> NPCs => npcEntities;
        public void AddCharacter(Character newCharacter)
        {
            if (newCharacter.CharacterRole == CharacterType.PC)
            {
                if (pcEntities.Contains(newCharacter)) { return; }
                pcEntities.Add(newCharacter);
            }
            else
            {
                if (npcEntities.Contains(newCharacter)) { return; }
                npcEntities.Add(newCharacter);
            }
        }
        public void RemoveCharacter(Character character)
        {
            if (character.CharacterRole == CharacterType.PC)
            {
                pcEntities.Remove(character);
            }
            else
            {
                npcEntities.Remove(character);
            }
        }

        public IEnumerable<Note> Notes => notes;
        public void AddNote(Note note)
        {
            if (notes.Contains(note)) { return; }
            notes.Add(note);
        }
        public void RemoveNote(Note note)
        {
            notes.Remove(note);
        }

        public IEnumerable<Encounter> Encounters => encounters;
        public void AddEncounter(Encounter encounter)
        {
            if (encounters.Contains(encounter)) { return; }
            encounters.Add(encounter);
        }
        public void RemoveEncounter(Encounter encounter)
        {
            encounters.Remove(encounter);
        }

        public campaign BuildForPersistance()
        {
            c.pc = pcEntities.Select(x => x.BuildForPersistance()).ToList();
            c.npc = npcEntities.Select(x => x.BuildForPersistance()).ToList();
            c.note = notes.Select(x => x.NoteEntity).ToList();
            c.encounter = encounters.Select(x => x.EncounterEntity).ToList();
            c.item = treasures.Select(x => x.BuildForPersistance()).ToList();
            return c;
        }

        private campaign c;
        private List<Character> pcEntities = new List<Character>();
        private List<Character> npcEntities = new List<Character>();
        private List<Note> notes = new List<Note>();
        private List<Encounter> encounters = new List<Encounter>();
        private List<Item> treasures = new List<Item>();
    }
}
