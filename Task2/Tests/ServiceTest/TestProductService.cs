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
    public class TestProductService
    {
        public IRepository repository;
        public ProductService service;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            service = new ProductService(repository);
        }
        [TestMethod]
        public void AddProductToDatabaseTest()
        {
            Assert.IsTrue(service.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            Assert.AreEqual(service.GetProductByModel("#343412b").Name, "SB White");
            Assert.AreEqual(service.GetProductByModel("#343412b").Model, "#343412b");
            Assert.AreEqual(service.GetProductByModel("#343412b").Price, 200);
            Assert.AreEqual(service.GetProductByModel("#343412b").Size, 41);
            Assert.AreEqual(service.GetProductByModel("#343412b").Producer, "Nike");
            Assert.AreEqual(service.GetProductByModel("#343412b").Season, "Summer");
            Assert.AreEqual(service.GetProductByModel("#343412b").Quantity, 20);

            Assert.IsTrue(service.DeleteProduct(service.GetProductByModel("#343412b").ID));
        }

        [TestMethod]
        public void AddSameProductToDatabaseTest()
        {
            Assert.IsTrue(service.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            Assert.IsFalse(service.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(service.DeleteProduct(service.GetProductByModel("#343412b").ID));
        }

        [TestMethod]
        public void GetProductsByName()
        {
            Assert.IsTrue(service.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            Assert.IsTrue(service.AddProduct("SB White", "#343413b", 200, 42, "Nike", "Summer", 20));

            Assert.IsTrue(service.GetProductByName("SB White").Count() == 2);

            Assert.IsTrue(service.DeleteProduct(service.GetProductByModel("#343412b").ID));
            Assert.IsTrue(service.DeleteProduct(service.GetProductByModel("#343413b").ID));
        }

        [TestMethod]
        public void UpdateProductQuantity()
        {
            Assert.IsTrue(service.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(service.UpdateProductQuantity(service.GetProductByModel("#343412b").ID, 30));

            Assert.AreEqual(service.GetProductByModel("#343412b").Quantity, 30);

            Assert.IsTrue(service.DeleteProduct(service.GetProductByModel("#343412b").ID));
        }
    }
}
