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
    public class WeaponOptionNodeTests
    {
        [TestMethod()]
        public void WeaponOptionNodeTest1()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            WeaponOptionNode won = new WeaponOptionNode("a", weaponList);
            Assert.IsNotNull(won);
            List<List<WeaponChoice>> wcl = won.validWeaponLists();
            Assert.IsNotNull(wcl);
        }

        [TestMethod()]
        public void WeaponOptionNodeTest2()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            WeaponOptionNode won = new WeaponOptionNode("a+b", weaponList);
            Assert.IsNotNull(won);
            List<List<WeaponChoice>> wcl = won.validWeaponLists();
            Assert.IsNotNull(wcl);
        }

        [TestMethod()]
        public void WeaponOptionNodeTest3()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            WeaponOptionNode won = new WeaponOptionNode("a/b", weaponList);
            Assert.IsNotNull(won);
            List<List<WeaponChoice>> wcl = won.validWeaponLists();
            Assert.IsNotNull(wcl);
        }

        [TestMethod()]
        public void WeaponOptionNodeTest4()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            WeaponOptionNode won = new WeaponOptionNode("a/[b+c]", weaponList);
            Assert.IsNotNull(won);
            List<List<WeaponChoice>> wcl = won.validWeaponLists();
            Assert.IsNotNull(wcl);
        }

        [TestMethod()]
        public void WeaponOptionNodeTest5()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            WeaponOptionNode won = new WeaponOptionNode("[a/b]+[c/d]", weaponList);
            Assert.IsNotNull(won);
            List<List<WeaponChoice>> wcl = won.validWeaponLists();
            Assert.IsNotNull(wcl);
            Assert.AreEqual(wcl[0][0].weapon._name , "a");
            Assert.AreEqual(wcl[0][1].weapon._name, "c");
            Assert.AreEqual(wcl[1][0].weapon._name, "a");
            Assert.AreEqual(wcl[1][1].weapon._name, "d");
            Assert.AreEqual(wcl[2][0].weapon._name, "b");
            Assert.AreEqual(wcl[2][1].weapon._name, "c");
            Assert.AreEqual(wcl[3][0].weapon._name, "b");
            Assert.AreEqual(wcl[3][1].weapon._name, "d");
        }

        [TestMethod()]
        public void getWeaponOptionTest1()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            int min=0, max=0;
            Weapon weapon=null;
            string dummy =WeaponOptionNode.stripMinMaxOffString("a", ref min, ref max);
            Assert.AreEqual(1, min);
            Assert.AreEqual(1, max);
            weapon = weaponList[dummy];
            Assert.IsNotNull(weapon);
        }

        [TestMethod()]
        public void getWeaponOptionTest2()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            int min = 0, max = 0;
            Weapon weapon = null;
            string dummy = WeaponOptionNode.stripMinMaxOffString("3a", ref min, ref max);
            Assert.AreEqual(3, min);
            Assert.AreEqual(3, max);
            weapon = weaponList[dummy];
            Assert.IsNotNull(weapon);
        }

        [TestMethod()]
        public void getWeaponOptionTest3()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            int min = 0, max = 0;
            Weapon weapon = null;
            string dummy = WeaponOptionNode.stripMinMaxOffString("3-5a", ref min, ref max);
            Assert.AreEqual(3, min);
            Assert.AreEqual(5, max);
            weapon = weaponList[dummy];
            Assert.IsNotNull(weapon);
        }

        [TestMethod()]
        public void getWeaponOptionTest5()
        {
            WeaponList weaponList = new WeaponList("C:/Users/wfeij/Dropbox/WH8/Vergelijken units/TestWeapons.csv");
            int min = 0, max = 0;
            Weapon weapon = null;
            string dummy = WeaponOptionNode.stripMinMaxOffString("5-3a", ref min, ref max);
            Assert.AreEqual(5, min);
            Assert.AreEqual(5, max);
            weapon = weaponList[dummy];
            Assert.IsNotNull(weapon);
        }
    }
}