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
    public class TestEventService
    {
        public IRepository repository;
        public BuyerService buyerService;
        public ProductService productService;
        public OrderService orderService;
        public EventService eventService;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            buyerService = new BuyerService();
            productService = new ProductService();
            orderService = new OrderService();
            eventService = new EventService();
        }

        [TestMethod]
        public void AddEventToDatabaseTest()
        {
            Assert.IsTrue(buyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(productService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(orderService.AddOrder(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.IsTrue(eventService.AddEvent(DateTime.Now, orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID, "returnEvent", "test"));

            Assert.AreEqual(eventService.GetEventsByOrderId(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID).Count(), 2);
  
            Assert.IsTrue(orderService.DeleteOrder(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(productService.DeleteProduct(productService.GetProductByModel("#343412b").ID));
            Assert.IsTrue(buyerService.DeleteBuyer(buyerService.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void AddReturnEventToDatabaseTest()
        {
            Assert.IsTrue(buyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(productService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(orderService.AddOrder(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.AreEqual(productService.GetProductByModel("#343412b").Quantity, 19);

            Assert.IsTrue(eventService.AddEvent(DateTime.Now, orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID, "returnEvent", "test"));

            Assert.AreEqual(eventService.GetEventsByOrderId(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID).ElementAt(1).Type, "returnEvent");

            Assert.AreEqual(eventService.GetEventsByOrderId(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID).Count(), 2);

            Assert.AreEqual(productService.GetProductByModel("#343412b").Quantity, 20);

            Assert.IsTrue(orderService.DeleteOrder(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(productService.DeleteProduct(productService.GetProductByModel("#343412b").ID));
            Assert.IsTrue(buyerService.DeleteBuyer(buyerService.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void UpdateEvent()
        {
            Assert.IsTrue(buyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(productService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(orderService.AddOrder(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.AreEqual(productService.GetProductByModel("#343412b").Quantity, 19);

            Assert.IsTrue(eventService.AddEvent(DateTime.Now, orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID, "returnEvent", "test"));

            Assert.IsTrue(eventService.UpdateEvent(eventService.GetEventsByOrderId(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID).ElementAt(1).ID, "Wrong size"));

            Assert.AreEqual(eventService.GetEventsByOrderId(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID).ElementAt(1).Description, "Wrong size");

            Assert.AreEqual(eventService.GetEventsByOrderId(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID).Count(), 2);

            Assert.AreEqual(productService.GetProductByModel("#343412b").Quantity, 20);

            Assert.IsTrue(orderService.DeleteOrder(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(productService.DeleteProduct(productService.GetProductByModel("#343412b").ID));
            Assert.IsTrue(buyerService.DeleteBuyer(buyerService.GetBuyer("696 969 696").Phone));
        }
    }
}
