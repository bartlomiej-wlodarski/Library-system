using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data;
using Data.API;
using Model;
using Service;
using System.Linq;

namespace Tests.ModelTest
{
    [TestClass]
    public class TestProductModelDatabase
    {
        public IRepository repository;
        public ProductService service;
        public ProductViewModelForTests model;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            service = new ProductService(repository);
            model = new ProductViewModelForTests(service);
        }
        [TestMethod]
        public void TestAddDeleteProduct()
        {
            model.Name = "test";
            model.Model = "testowy";
            model.Producer = "111111111";
            model.Size = 19;
            model.Price = 100;
            model.Quantity = 20;
            model.Season = "summer";
            model.AddProduct();
            model.ID = service.GetProductByModel("testowy").ID;
            model.DeleteProduct();
            Assert.IsTrue(service.GetProducts().Count() == 0);
        }
    }
}
