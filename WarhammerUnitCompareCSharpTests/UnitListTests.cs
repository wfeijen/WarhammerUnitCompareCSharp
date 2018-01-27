using Microsoft.VisualStudio.TestTools.UnitTesting;
using WarhammerUnitCompareCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarhammerUnitCompareCSharp.Tests
{
    [TestClass()]
    public class UnitListTests
    {
        [TestMethod()]
        public void UnitListTest1()
        {
            UnitList unitList = new UnitList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/Units.csv");
            Assert.IsInstanceOfType(unitList, typeof(UnitList));
            Assert.AreEqual(9, unitList.Count);
        }

        [TestMethod()]
        public void UnitListTest2()
        {
            UnitList unitList = new UnitList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestUnits.csv");
            Assert.IsInstanceOfType(unitList, typeof(UnitList));
            Assert.AreEqual(9, unitList.Count);
        }
    }
}