using System;
using ChallengeOneCafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOneCafeTests
{
    [TestClass]
    public class CafeMenuRepoTests
    {
        private CafeMenuRepo _menuRepo;
        private MenuItem _item;

        [TestInitialize]
        public void Arrange()
        {
            _menuRepo = new CafeMenuRepo();
            _item = new MenuItem(1, "PB & J", "Peanutbutter and jelly on bread", new System.Collections.Generic.List<string> { "pb" ,"jelly","bread"}, 2.99);
            _menuRepo.AddItemToDirectory(_item);
        }

        [TestMethod]
        public void AddNewItem_ShouldNotGetNull()
        {
            //arrange
            MenuItem item = new MenuItem();
            item.MealNumber = 1;
            CafeMenuRepo repo = new CafeMenuRepo();
            //act
            repo.AddItemToDirectory(item);
            MenuItem itemFromDirectory = repo.GetItemByNumber(1);
            //assert
            Assert.IsNotNull(itemFromDirectory);
        }

        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        public void UpdateExistingItem_ShouldMatchGivenBool(int originalNumber, bool shouldUpdate)
        {
            MenuItem newItem = new MenuItem(1, "PB & J", "Peanutbutter and jelly on bread", new System.Collections.Generic.List<string> { "pb", "jelly", "bread" }, 3.99);
            bool updateResult = _menuRepo.UpdateMenuItem(originalNumber, newItem);
            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            Arrange();
            bool deleteResult = _menuRepo.RemoveItemFromMenu(_item.MealNumber);
            Assert.IsTrue(deleteResult);
        }
        
    }
}
