using BadgesClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static BadgesClassLibrary.Badge;

namespace BadgesTestLibrary
{
    [TestClass]
    public class BadgeRepoTest
    {
        private Badge _badge;
        private BadgeRepo _badgeRepo;

        [TestInitialize]
        public void Arrange()
        {
            _badge = new Badge(123, new List<string> { "A1", "B1" });
            _badgeRepo = new BadgeRepo();
            _badgeRepo.AddNewBadge(_badge);
        }

        [TestMethod]
        public void AddBadgeTest()
        {
            Badge testBadge = new Badge(456, new List<string> { "A5" });
            bool wasAdded = _badgeRepo.AddNewBadge(testBadge);
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void ShowAllBadgesTest()
        {
            List<int> badgesToDisplay = _badgeRepo.ShowAllBadgesId();
            bool wasAdded = badgesToDisplay.Count > 0;
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void ShowBadgeByIdTest()
        {
            List<string> showBadgeDoors = _badgeRepo.ShowBadgeById(123);
            Assert.IsNotNull(showBadgeDoors);
        }

        [TestMethod]
        public void UpdateBadgeTest()
        {
            bool wasUpdated = _badgeRepo.UpdateBadge(123, "A2");
            Assert.IsTrue(wasUpdated);
        }

        [TestMethod]
        public void DeleteDoorTest()
        {
            bool wasDeleted = _badgeRepo.DeleteDoor(123, "A1");
            Assert.IsTrue(wasDeleted);
        }
    }
}
