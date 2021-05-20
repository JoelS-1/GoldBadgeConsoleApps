using MenuRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace RepoTests
{
    [TestClass]
    public class RepoUnitTests
    {
        private MenuItem _item;
        private MenuRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _item = new MenuItem(1, "Burger and Fries Combo", "The classic burger and fries with a drink", "beef patty on bun with lettuce, tomato, and mayo", 9.99);
            _repo = new MenuRepo();
            _repo.AddMenuItem(_item);
        }

        [TestMethod]
        public void AddItemToMenu()
        {
            bool addResult = _repo.AddMenuItem(_item);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetAllMenuItems()
        {
            List<MenuItem> menuGetItemsTest = _repo.GetMenuItems();

            bool hasItem = menuGetItemsTest.Contains(_item);
            Assert.IsTrue(hasItem);
        }

        [TestMethod]
        public void GetMenuItemByNumber()
        {
            MenuItem menuGetItemTest = _repo.GetMenuItemByMealNumber(1);

            bool isItem = (menuGetItemTest == _item) ? true : false;
            Assert.IsTrue(isItem);
        }

        [TestMethod]
        public void UpdateItem()
        {
            bool wasUpdated = _repo.UpdateMenuItem(1, new MenuItem(2, "Chicken Sandwich Combo", "The tasty chicken sandwich and chips with drink", "fried chicken on toasted bread with house sauce, lettuce, and your choice of cheese", 8.99));

            Assert.IsTrue(wasUpdated);
        }

        [TestMethod]
        public void DeleteItemByMealNumber()
        {
            bool wasDeleted = _repo.DeleteMenuItemByMealNumber(1);
            Assert.IsTrue(wasDeleted);
        }
    }
}
