using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutingsClassLibrary;
using System;
using System.Collections.Generic;
using static OutingsClassLibrary.Outing;

namespace OutingsTests
{
    [TestClass]
    public class OutingsRepoTests
    {
        private Outing _outing;
        private Outing _outingTwo;
        private OutingRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            _outing = new Outing(1, EventType.Bowling, 12, new DateTime(2020, 4, 27), 300.00);
            _outingTwo = new Outing(2, EventType.AmusmentPark, 10, new DateTime(2020, 4, 28), 500.00);
            _repo = new OutingRepo();
            _repo.AddOuting(_outing);
            _repo.AddOuting(_outingTwo);
        }

        [TestMethod]
        public void AddOutingTest()
        {
            bool wasAdded = _repo.AddOuting(_outing);
            Assert.IsTrue(wasAdded);
        }

        //[TestMethod]
        //public void GetOutingIdentifierTest()
        //{
        //    Outing outingGetTest = _repo.GetOutingByIdentifier(1);
        //    bool isOuting = (outingGetTest == _outing);
        //    Assert.IsTrue(isOuting);
        //}

        //[TestMethod]
        //public void UpdateOutingTest()
        //{
        //    bool wasUpdated = _repo.UpdateOuting(1, new Outing(3, EventType.AmusmentPark, 10, new DateTime(2020, 4, 28), 500.00));
        //    Assert.IsTrue(wasUpdated);
        //}

        [TestMethod]
        public void GetAllOutingsTest()
        {
            List<Outing> outingGetTest = _repo.GetAllOutings();
            bool hasOuting = outingGetTest.Contains(_outing);
            Assert.IsTrue(hasOuting);
        }

        //[TestMethod]
        //public void DeleteOutingTest()
        //{
        //    bool wasDeleted = _repo.DeleteOuting(1);
        //    Assert.IsTrue(wasDeleted);
        //}

        [TestMethod]
        public void CostOfAllOutingsTest()
        {
            double totalCost = _repo.CostOfAllOutings();
            Assert.AreEqual(totalCost, 800.00);
        }

        [TestMethod]
        public void CostOfOutingTypeTest()
        {
            double totalCostByType = _repo.CostOfEventType(EventType.AmusmentPark);
            Assert.AreEqual(totalCostByType, 500.00);
        }
    }
}
