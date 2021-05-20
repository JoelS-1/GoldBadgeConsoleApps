using ClaimsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace RepoTest
{
    [TestClass]
    public class RepoUnitTestClass
    {
        private Claim _claim;
        private ClaimRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _claim = new Claim(1, ClaimType.Car, "Car Accident", 400.00, new DateTime(2020, 4, 25), new DateTime(2020, 4, 30));
            _repo = new ClaimRepo();
            _repo.AddNewClaim(_claim);
        }

        [TestMethod]
        public void AddItem()
        {
            bool addResult = _repo.AddNewClaim(_claim);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void SeeClaims()
        {
            Queue<Claim> testRepo = _repo.SeeAllClaims();
            bool wasAdded = (testRepo.Contains(_claim));
            Assert.IsTrue(wasAdded);
        }

        [TestMethod]
        public void DeleteClaim()
        {
            bool wasRemoved = _repo.DeleteNextClaimInQueue();
            Assert.IsTrue(wasRemoved);
        }

        [TestMethod]
        public void PeekAtClaim()
        {
            Claim nextClaim = _repo.PeekAtNextClaim();
            bool wasFound = (nextClaim == _claim);
            Assert.IsTrue(wasFound);
        }
    }
}
