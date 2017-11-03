using System;
using CampaignCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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
    }
}
