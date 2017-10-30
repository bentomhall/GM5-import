using Microsoft.VisualStudio.TestTools.UnitTesting;
using GM5_Campaign;

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

    }
}
