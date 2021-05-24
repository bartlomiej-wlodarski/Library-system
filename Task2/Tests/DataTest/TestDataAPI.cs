using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data.API;
using System.Linq;

namespace Tests.DataTest
{
    [TestClass]
    public class TestDataAPI
    {
        public IRepository repository;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
        }


        [TestMethod]
        public void AddBuyerToDatabaseTest()
        {
            Assert.IsTrue(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.AreEqual(repository.GetBuyer("696 969 696").Name, "Jan");
            Assert.AreEqual(repository.GetBuyer("696 969 696").Surname, "Kowalski");
            Assert.AreEqual(repository.GetBuyer("696 969 696").Phone, "696 969 696");

            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void UpdateBuyerTest()
        {
            Assert.IsTrue(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(repository.UpdateBuyer(repository.GetBuyer("696 969 696").ID, "Jann", "Kowalskii", "696 969 696"));

            Assert.AreEqual(repository.GetBuyer("696 969 696").Name, "Jann");
            Assert.AreEqual(repository.GetBuyer("696 969 696").Surname, "Kowalskii");
            Assert.AreEqual(repository.GetBuyer("696 969 696").Phone, "696 969 696");

            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void AddSameBuyerTest()
        {
            Assert.IsTrue(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsFalse(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));

            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void AddEventToDatabaseTest()
        {
            Assert.IsTrue(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(repository.AddOrder(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.IsTrue(repository.AddEvent(DateTime.Now, repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID, "returnEvent", "test"));

            Assert.AreEqual(repository.GetEventsByOrderId(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID).Count(), 2);

            Assert.IsTrue(repository.DeleteOrder(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void AddReturnEventToDatabaseTest()
        {
            Assert.IsTrue(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(repository.AddOrder(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.AreEqual(repository.GetProductByModel("#343412b").Quantity, 19);

            Assert.IsTrue(repository.AddEvent(DateTime.Now, repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID, "returnEvent", "test"));

            Assert.AreEqual(repository.GetEventsByOrderId(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID).ElementAt(1).Type, "returnEvent");

            Assert.AreEqual(repository.GetEventsByOrderId(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID).Count(), 2);

            Assert.AreEqual(repository.GetProductByModel("#343412b").Quantity, 20);

            Assert.IsTrue(repository.DeleteOrder(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void UpdateEvent()
        {
            Assert.IsTrue(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(repository.AddOrder(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.AreEqual(repository.GetProductByModel("#343412b").Quantity, 19);

            Assert.IsTrue(repository.AddEvent(DateTime.Now, repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID, "returnEvent", "test"));

            Assert.IsTrue(repository.UpdateEvent(repository.GetEventsByOrderId(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID).ElementAt(1).ID, "Wrong size"));

            Assert.AreEqual(repository.GetEventsByOrderId(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID).ElementAt(1).Description, "Wrong size");

            Assert.AreEqual(repository.GetEventsByOrderId(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID).Count(), 2);

            Assert.AreEqual(repository.GetProductByModel("#343412b").Quantity, 20);

            Assert.IsTrue(repository.DeleteOrder(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void AddOrderToDatabaseTest()
        {
            Assert.IsTrue(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(repository.AddOrder(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.IsTrue(repository.DeleteOrder(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void GetAllOrdersForProductTest()
        {
            Assert.IsTrue(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(repository.AddOrder(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));
            Assert.IsTrue(repository.AddOrder(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.IsTrue(repository.GetOrdersByProductId(repository.GetProductByModel("#343412b").ID).Count() == 2);

            Assert.IsTrue(repository.DeleteOrder(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(repository.DeleteOrder(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void UpdateOrderTest()
        {
            Assert.IsTrue(repository.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(repository.AddBuyer("Jesika", "Kowalski", "696 969 697"));
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(repository.AddOrder(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.IsTrue(repository.UpdateOrder(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 696").ID).ID, repository.GetBuyer("696 969 697").ID));

            Assert.AreEqual(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 697").ID).Buyer_id, repository.GetBuyer("696 969 697").ID);

            Assert.IsTrue(repository.DeleteOrder(repository.GetLatestOrderByProductAndBuyer(repository.GetProductByModel("#343412b").ID, repository.GetBuyer("696 969 697").ID).ID));
            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 696").Phone));
            Assert.IsTrue(repository.DeleteBuyer(repository.GetBuyer("696 969 697").Phone));
        }

        [TestMethod]
        public void AddProductToDatabaseTest()
        {
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            Assert.AreEqual(repository.GetProductByModel("#343412b").Name, "SB White");
            Assert.AreEqual(repository.GetProductByModel("#343412b").Model, "#343412b");
            Assert.AreEqual(repository.GetProductByModel("#343412b").Price, 200);
            Assert.AreEqual(repository.GetProductByModel("#343412b").Size, 41);
            Assert.AreEqual(repository.GetProductByModel("#343412b").Producer, "Nike");
            Assert.AreEqual(repository.GetProductByModel("#343412b").Season, "Summer");
            Assert.AreEqual(repository.GetProductByModel("#343412b").Quantity, 20);

            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
        }

        [TestMethod]
        public void AddSameProductToDatabaseTest()
        {
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            Assert.IsFalse(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
        }

        [TestMethod]
        public void GetProductsByName()
        {
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            Assert.IsTrue(repository.AddProduct("SB White", "#343413b", 200, 42, "Nike", "Summer", 20));

            Assert.IsTrue(repository.GetProductByName("SB White").Count() == 2);

            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343413b").ID));
        }

        [TestMethod]
        public void UpdateProductQuantity()
        {
            Assert.IsTrue(repository.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(repository.UpdateProductQuantity(repository.GetProductByModel("#343412b").ID, 30));

            Assert.AreEqual(repository.GetProductByModel("#343412b").Quantity, 30);

            Assert.IsTrue(repository.DeleteProduct(repository.GetProductByModel("#343412b").ID));
        }
    }
}
