using System;
using GM5_Campaign;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CampaignCoreTest
{
    [TestClass]
    public class CampaignTest
    {
        private Character testPc;
        private Character testEnemy;
        private Character testAlly;
        private Campaign c;

        [TestInitialize]
        public void Initialize()
        {
            testPc = new Character(CharacterType.PC);
            testEnemy = new Character(CharacterType.Monster);
            testAlly = new Character(CharacterType.Ally);
            c = new Campaign();
        }

        [TestMethod]
        public void TestAddCharacter()
        {
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
