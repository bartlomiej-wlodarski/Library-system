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
    public class TestOrderService
    {
        public IRepository repository;
        public BuyerService buyerService;
        public ProductService productService;
        public OrderService orderService;

        [TestInitialize]
        public void Initialize()
        {
            repository = new Repository();
            buyerService = new BuyerService();
            productService = new ProductService();
            orderService = new OrderService();
        }
        [TestMethod]
        public void AddOrderToDatabaseTest()
        {
            Assert.IsTrue(buyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(productService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(orderService.AddOrder(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.IsTrue(orderService.DeleteOrder(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(productService.DeleteProduct(productService.GetProductByModel("#343412b").ID));
            Assert.IsTrue(buyerService.DeleteBuyer(buyerService.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void GetAllOrdersForProductTest()
        {
            Assert.IsTrue(buyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(productService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(orderService.AddOrder(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));
            Assert.IsTrue(orderService.AddOrder(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.IsTrue(orderService.GetOrdersByProductId(productService.GetProductByModel("#343412b").ID).Count() == 2);

            Assert.IsTrue(orderService.DeleteOrder(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(orderService.DeleteOrder(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID));
            Assert.IsTrue(productService.DeleteProduct(productService.GetProductByModel("#343412b").ID));
            Assert.IsTrue(buyerService.DeleteBuyer(buyerService.GetBuyer("696 969 696").Phone));
        }

        [TestMethod]
        public void UpdateOrderTest()
        {
            Assert.IsTrue(buyerService.AddBuyer("Jan", "Kowalski", "696 969 696"));
            Assert.IsTrue(buyerService.AddBuyer("Jesika", "Kowalski", "696 969 697"));
            Assert.IsTrue(productService.AddProduct("SB White", "#343412b", 200, 41, "Nike", "Summer", 20));

            Assert.IsTrue(orderService.AddOrder(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID, true, "All good, buyer happy"));

            Assert.IsTrue(orderService.UpdateOrder(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 696").ID).ID, buyerService.GetBuyer("696 969 697").ID));

            Assert.AreEqual(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 697").ID).Buyer_id, buyerService.GetBuyer("696 969 697").ID);

            Assert.IsTrue(orderService.DeleteOrder(orderService.GetLatestOrderByProductAndBuyer(productService.GetProductByModel("#343412b").ID, buyerService.GetBuyer("696 969 697").ID).ID));
            Assert.IsTrue(productService.DeleteProduct(productService.GetProductByModel("#343412b").ID));
            Assert.IsTrue(buyerService.DeleteBuyer(buyerService.GetBuyer("696 969 696").Phone));
            Assert.IsTrue(buyerService.DeleteBuyer(buyerService.GetBuyer("696 969 697").Phone));
        }
    }
}
