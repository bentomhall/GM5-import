using Microsoft.VisualStudio.TestTools.UnitTesting;
using CampaignCore;
using System.Collections.Generic;
using System;

namespace CampaignCoreTest
{
    [TestClass]
    public class DataTypesTest
    {
        [TestMethod]
        public void TestAC()
        {
            var AC = new ArmorClass(14, "natural armor");
            var correct = "14 (natural armor)";
            Assert.AreEqual(correct, AC.ToString());
        }


        [TestMethod]
        public void TestDiceValuePositiveMod()
        {
            var dice = new DiceValue(1, 4, 4);
            var correctString = "1d4+4";
            Assert.AreEqual(correctString, dice.ToString());
        }

        [TestMethod]
        public void TestDiceValueNegativeMod()
        {
            var dice = new DiceValue(1, 4, -4);
            var correctString = "1d4-4";
            Assert.AreEqual(correctString, dice.ToString());
        }

        [TestMethod]
        public void TestDiceValueZeroMod()
        {
            var dice = new DiceValue(1, 4, 0);
            var correctString = "1d4";
            Assert.AreEqual(correctString, dice.ToString());
        }

        [TestMethod]
        public void TestDiceValueNoDice()
        {
            var dice = new DiceValue(0, 4, 4);
            var correctString = "+4";
            Assert.AreEqual(correctString, dice.ToString());
            dice = new DiceValue(0, 4, -4);
            correctString = "-4";
            Assert.AreEqual(correctString, dice.ToString());
            dice = new DiceValue(0, 4, 40);
            correctString = "+40";
            Assert.AreEqual(correctString, dice.ToString());
        }

        [TestMethod]
        public void TestHitPoints()
        {
            var dice = new DiceValue(3, 8, 6);
            var max = 0; //test 1
            Assert.AreEqual("0", new HitPoints(max, dice).ToString());
            max = 42;
            Assert.AreEqual("42 (3d8+6)", new HitPoints(max, dice).ToString());
        }

        [TestMethod]
        public void TestAttribute()
        {
            var a1 = new CharacterAttribute(20);
            var a2 = new CharacterAttribute(1);
            var a3 = new CharacterAttribute(10);
            Assert.AreEqual(5, a1.Modifier);
            Assert.AreEqual(-5, a2.Modifier);
            Assert.AreEqual(0, a3.Modifier);
        }

        [TestMethod]
        public void TestEqualityNameValuePair()
        {
            var first = new NameValuePair("test", 42);
            var second = new NameValuePair("test", 42);
            var third = new NameValuePair("tast", 42);
            var fourth = new NameValuePair("test", 40);
            Assert.AreEqual(first, second);
            Assert.AreNotEqual(first, third);
            Assert.AreNotEqual(first, fourth);
        }

        [TestMethod]
        public void TestAttackRoll()
        {
            var dv = new DiceValue(1, 6, 2);
            var obj = new AttackRoll("This is an attack", 4, dv);
            var expected = "This is an attack|+4|1d6+2";
            Assert.AreEqual(expected, obj.ToString());
        }

        [TestMethod]
        public void TestCreatureFeature()
        {
            var dv = new DiceValue(1, 6, 2);
            var ar = new AttackRoll("Test", 4, dv);
            var obj = new CreatureFeature(FeatureType.Action, "test", "test", ar);
            var nullobj = new CreatureFeature(FeatureType.Legendary, "test", "test", null);
            Assert.AreEqual(ar.ToString(), obj.Feature.attack);
            Assert.AreEqual("", nullobj.Feature.attack);
            Assert.IsInstanceOfType(obj.Feature, typeof(Schemas.creatureAction));
        }

        [TestMethod]
        public void TestNVPSeparatedString()
        {
            var nvp = new NameValuePair("test", 42);
            var lst = new List<NameValuePair>() { nvp, nvp, nvp };
            Assert.AreEqual("test +42,test +42,test +42", lst.ToSeparatedString());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSpellcastingSetSlotsLevelTooHigh()
        {
            var sp = new SpellCasting();
            sp.SetSlots(12, 4);
        }
    }
}
