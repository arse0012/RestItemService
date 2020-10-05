using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib.Model;

namespace RestItemUnitTest
{
    [TestClass]
    public class ItemsTest
    {
        [TestMethod]
        public void GetTest()
        {
            Item item = new Item();
            item.Id = 7;
            Assert.AreEqual(7, item.Id);
        }

        [TestMethod]
        public void GetFromSubstringTest()
        {

        }

        [TestMethod]
        public void GetQualityTest()
        {

        }

        [TestMethod]
        public void GetFilterTest()
        {

        }

        [TestMethod]
        public void PostTest()
        {

        }
        [TestMethod]
        public void PutTest()
        {

        }

        [TestMethod]
        public void DeleteTest()
        {

        }
    }
}
