using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLib.Model;
using RestItemService.Controllers;

namespace RestItemUnitTest
{
    [TestClass]
    public class ItemsTest
    {
        private ItemsController cntr = null;

        [TestInitialize]
        public void BeforeEachTest()
        {
            cntr = new ItemsController();
        }

        [TestMethod]
        public void GetTest()
        {
            //arrange
            // i before each test

            //act 
            List<Item> liste = new List<Item>(cntr.Get());

            //assert
            Assert.AreEqual(5,liste.Count);
        }

        [TestMethod]
        public void GetFromSubstringTest()
        {
            //arrange
            // i before each test

            //act
            List<Item> liste = new List<Item>(cntr.GetFromSubstring("Bread"));

            //assert
            

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
