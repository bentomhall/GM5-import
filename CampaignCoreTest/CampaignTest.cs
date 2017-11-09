using System;
using CampaignCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Schemas;

namespace CampaignCoreTest
{
    [TestClass]
    public class CampaignTest
    {
        [TestMethod]
        public void TestAddCharacter()
        {
            var testPc = new Character(CharacterType.PC);
            var testEnemy = new Character(CharacterType.Monster);
            var testAlly = new Character(CharacterType.Ally);
            var c = new Campaign();
            c.AddCharacter(testPc);
            Assert.AreEqual(1, c.PCs.Count());
            c.AddCharacter(testAlly);
            Assert.AreEqual(1, c.NPCs.Count());
            Assert.AreNotEqual(2, c.PCs.Count());
            c.AddCharacter(testEnemy);
            Assert.AreNotEqual(2, c.NPCs.Count());
            Assert.AreNotEqual(3, c.PCs.Count());
        }

        [TestMethod]
        public void TestPersist()
        {
            var testPc = new Character(CharacterType.PC);
            var testEnemy = new Character(CharacterType.Monster);
            var note = new Note();
            var encounter = new Encounter();
            var c = new Campaign();
            testPc.Name = "George";
            testEnemy.Name = "Bob";
            note.Title = "A Note";
            encounter.AddCombatant(CharacterType.PC, "George");
            encounter.AddCombatant(CharacterType.Monster, "Bob");
            c.AddCharacter(testEnemy);
            c.AddCharacter(testPc);
            c.AddNote(note);
            c.AddEncounter(encounter);
            var persisted = c.BuildForPersistance();
            var handler = new XMLHandler();
            var path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "test_output.xml");
            handler.SaveXML(persisted, path);
            Assert.IsTrue(path != "");
        }

        private static Campaign BuildTestCampaign()
        {
            var testPc = new Character(CharacterType.PC);
            var testEnemy = new Character(CharacterType.Monster);
            var note = new Note();
            var encounter = new Encounter();
            var c = new Campaign();
            testPc.Name = "George";
            testEnemy.Name = "Bob";
            note.Title = "A Note";
            encounter.AddCombatant(CharacterType.PC, "George");
            encounter.AddCombatant(CharacterType.Monster, "Bob");
            c.AddCharacter(testEnemy);
            c.AddCharacter(testPc);
            c.AddNote(note);
            c.AddEncounter(encounter);
            return c;
        }

    }
}
