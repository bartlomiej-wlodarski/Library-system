using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;

namespace Tests.DataTest
{
    [TestClass]
    public class TestDatabase
    {
        [TestMethod]
        public void AddProductToDatabase()
        {
            using (var db = new ShopDataContext())
            {
                Products Product1 = new Products();
                Product1.name = "SB Black";
                Product1.model = "#343412a";
                Product1.price = 200.00;
                Product1.size = 40;
                Product1.producer = "Nike";
                Product1.season = "Summer";
                Product1.quantity = 20;

                db.Products.InsertOnSubmit(Product1);
                db.SubmitChanges();

                Products Product2 = db.Products.FirstOrDefault(p => p.name.Equals("SB Black"));
                Assert.IsNotNull(Product2);
                Assert.AreEqual(Product2.name, "SB Black");
                Assert.AreEqual(Product2.model, "#343412a");
                Assert.AreEqual(Product2.price, 200.00);
                Assert.AreEqual(Product2.size, 40);
                Assert.AreEqual(Product2.producer, "Nike");
                Assert.AreEqual(Product2.season, "Summer");
                Assert.AreEqual(Product2.quantity, 20);
            }
        }

        [TestMethod]
        public void DeleteProductFromDatabase()
        {
            using (var db = new ShopDataContext())
            {
                Products Product = db.Products.FirstOrDefault(p => p.model.Equals("#343412a"));
                Assert.IsNotNull(Product);
                db.Products.DeleteOnSubmit(Product);
                db.SubmitChanges();
            }
        }

        [TestMethod]
        public void SelectProductWhichNotExists()
        {
            using (var db = new ShopDataContext())
            {
                Products product = db.Products.FirstOrDefault(p => p.model.Equals("a1337"));
                Assert.IsNull(product);
            }
        }

    }
}
