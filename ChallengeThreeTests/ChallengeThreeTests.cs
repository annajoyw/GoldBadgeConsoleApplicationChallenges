using System;
using ChallengeThreeRepo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThreeTests
{
    [TestClass]
    public class ChallengeThreeTests
    {
        private BadgeRepo _badgeRepo;
        private Badge _badge;

        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();
            _badge = new Badge(1, new System.Collections.Generic.List<string> { "door a2" });
            _badgeRepo.AddBadgeToDictionary(_badge);
        }

        [TestMethod]
        public void UpdateBadge_ShouldNotGetNull()
        {
            Arrange();
            Badge badge = new Badge(1, new System.Collections.Generic.List<string> { "door a1" });
            //badge.ListOfDoors = new System.Collections.Generic.List<string> {"door a1"};
            //BadgeRepo repo = new BadgeRepo();
            bool wasDoorAdded = _badgeRepo.UpdateExistingBadge(1, badge);
            Assert.IsTrue(wasDoorAdded);
        }
        [TestMethod]
        public void DeleteBadge_ShouldReturnTrue()
        {
            Arrange();
            bool deleteResult = _badgeRepo.DeleteBadge(_badge.BadgeId);
            Assert.IsTrue(deleteResult);
        }
        [TestMethod]
        public void AddBadgeToDict_ShouldNotGetNull()
        {
            Arrange();
            Badge addBadge = new Badge();
            addBadge.BadgeId = 4;
            _badgeRepo.AddBadgeToDictionary(addBadge);
            Badge badgeFromDict = _badgeRepo.GetBadgeByID(4);
            Assert.IsNotNull(badgeFromDict);
        }
    }
}
