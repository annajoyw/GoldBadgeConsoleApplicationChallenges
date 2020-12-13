using System;
using ChallengeOneCafeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOneCafeTests
{
    [TestClass]
    public class CafeMenuRepoTests
    {
        private CafeMenuRepo _repo;
        private CafeMenu _item;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeMenuRepo();
            _item = new CafeMenu(1, "PB & J", "Peanutbutter and jelly on bread", "PB, Jelly, Bread", 2.99);
            _repo.AddNewMenuItem(_item);
        }

        [TestMethod]
        public void AddNewItem_ShouldNotGetNull()
        {
            //arrange
            CafeMenu item = new CafeMenu();
            item.MealNumber = 1;
            CafeMenuRepo repo = new CafeMenuRepo();
            //act
            repo.AddNewMenuItem(item);
            CafeMenu itemFromDirectory = repo.GetItemByNumber(1);
            //assert
            Assert.IsNotNull(itemFromDirectory);
        }

        [TestMethod]
     
        public void UpdateMenu_ShouldReturnTrue()
        {
            CafeMenu newItem = new CafeMenu(1, "PB & J", "Peanutbutter and jelly on bread", "PB, Jelly, Whole Wheat Bread", 3.99);
            bool updateResult = _repo.UpdateMenuItem(1, newItem);
            Assert.IsTrue(updateResult);
        }
        [DataTestMethod]
        [DataRow(1, true)]
        [DataRow(2, false)]
        public void UpdateExistingItem_ShouldMatchGivenBool(int originalNumber, bool shouldUpdate)
        {
            CafeMenu newItem = new CafeMenu(1, "PB & J", "Peanutbutter and jelly on bread", "PB, Jelly, Whole Wheat Bread", 3.99);
            bool updateResult = _repo.UpdateMenuItem(originalNumber, newItem);
            Assert.AreEqual(shouldUpdate, updateResult);
        }
        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveItemFromMenu(_item.MealNumber);
            Assert.IsTrue(deleteResult);
        }
        [TestMethod]
        public void helperMethod_Test()
        {

        }
       

    }
}
