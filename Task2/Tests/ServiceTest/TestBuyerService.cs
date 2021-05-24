using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service;
using Data.API;

namespace Tests.ServiceTest
{
    [TestClass]
    public class TestBuyerService
    {
        public IRepository repository;
        public BuyerService service;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            service = new BuyerService(repository);
        }

        [TestMethod]
        public void AddBuyerToDatabaseTest()
        {
            Assert.IsTrue(service.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.AreEqual(service.GetBuyer("696 969 696").Name, "Jan");
            Assert.AreEqual(service.GetBuyer("696 969 696").Surname, "Kowalski");
            Assert.AreEqual(service.GetBuyer("696 969 696").Phone, "696 969 696");

            Assert.IsTrue(service.DeleteBuyer(service.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void UpdateBuyerTest()
        {
            Assert.IsTrue(service.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(service.UpdateBuyer(service.GetBuyer("696 969 696").ID, "Jan", "Kowalski", "696 969 696"));

            Assert.AreEqual(service.GetBuyer("696 969 696").Name, "Jan");
            Assert.AreEqual(service.GetBuyer("696 969 696").Surname, "Kowalski");
            Assert.AreEqual(service.GetBuyer("696 969 696").Phone, "696 969 696");

            Assert.IsTrue(service.DeleteBuyer(service.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void AddSameBuyerTest()
        {
            Assert.IsTrue(service.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsFalse(service.AddBuyer("Jan", "Kowalski", "696 969 696"));

            Assert.IsTrue(service.DeleteBuyer(service.GetBuyer("696 969 696").Phone));
        }
    }
}
