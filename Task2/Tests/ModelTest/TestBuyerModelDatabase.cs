using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data;
using Data.API;
using Model;
using Service;
using Model.ViewModel;
using System.Linq;

namespace Tests.ModelTest
{
    [TestClass]
    public class TestBuyerModelDatabase
    {
        public IRepository repository;
        public BuyerService service;
        public BuyersViewModelForTests model;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            service = new BuyerService(repository);
            model = new BuyersViewModelForTests(service);
        }
        [TestMethod]
        public void TestAddDeleteBuyer()
        {
            model.Name = "test";
            model.Surname = "testowy";
            model.Phone = "111111111";
            model.Text = "test";
            model.AddBuyer();
            model.DeleteBuyer();
            Assert.IsTrue(service.GetBuyers().Count() == 0);
        }
    }
}
