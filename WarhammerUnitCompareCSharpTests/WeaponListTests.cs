using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarhammerUnitCompareCSharp
{
    [TestClass()]
    public class WeaponListTests
    {
        [TestMethod()]
        public void WeaponListTest1()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/Weapons.csv");
            Assert.IsInstanceOfType(weaponList, typeof(WeaponList));
            Assert.AreEqual(82, weaponList.Count);
        }

        [TestMethod()]
        public void WeaponListTest2()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            Assert.IsInstanceOfType(weaponList, typeof(WeaponList));
            Assert.AreEqual(83, weaponList.Count);
        }
    }
}