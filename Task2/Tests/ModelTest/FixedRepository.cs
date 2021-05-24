using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Data;

namespace Tests.ModelTest
{
    class FixedRepository : IRepository
    {

        public IBuyer Transform(Buyers Buyer)
        {
            return new Buyer(Buyer.name, Buyer.surname, Buyer.id, Buyer.phone);
        }
        public IProduct Transform(Products Product)
        {
            return new Product(Product.id, Product.name, Product.model, Product.price, Product.size, Product.producer, Product.season, Product.quantity);
        }
        public IOrder Transform(Orders Order)
        {
            return new Order(Order.id, Order.buyer_id, Order.product_id, Order.is_payed);
        }
        public IEvent Transform(Events Event)
        {
            return new Event(Event.id, Event.date, Event.order_id, Event.type, Event.description);
        }
        public IEnumerable<IBuyer> GetBuyers()
        {
            List<IBuyer> list = new List<IBuyer>();
            list.Add(new Buyer("Szuiram", "testowy", 1, "000000000"));
            list.Add(new Buyer("Michal", "testowy", 2, "111111111"));
            return list;
        }

        public IBuyer GetBuyer(string Phone)
        {
            return new Buyer("Szuiram", "testowy", 1, "000000000");
        }

        public bool AddBuyer(string Name, string Surname, string Phone)
        {
            return true;
        }

        public bool UpdateBuyer(int id, string Name, string Surname, string Phone)
        {
            return true;
        }

        public bool DeleteBuyer(string Phone)
        {
            return true;
        }
        public IEnumerable<IProduct> GetProducts()
        {
            List<IProduct> list = new List<IProduct>();
            list.Add(new Product(1, "SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            list.Add(new Product(2, "SB White", "#343413b", 200, 42, "Nike", "Summer", 20));
            return list;
        }

        public IProduct GetProductById(int id)
        {
            return new Product(1, "SB White", "#343412b", 200, 41, "Nike", "Summer", 20);
        }

        public IEnumerable<IProduct> GetProductByName(string name)
        {
            List<IProduct> list = new List<IProduct>();
            list.Add(new Product(1, "SB White", "#343412b", 200, 41, "Nike", "Summer", 20));
            list.Add(new Product(2, "SB White", "#343413b", 200, 42, "Nike", "Summer", 20));
            return list;
        }

        public IProduct GetProductByModel(string model)
        {
            return new Product(1, "SB White", "#343412b", 200, 41, "Nike", "Summer", 20);
        }
        public bool AddProduct(string name, string model, float price, int size, string producer, string season, int quantity)
        {
            return true;
        }

        public bool UpdateProduct(int id, string name, string model, float price, int size, string producer, string season, int quantity)
        {
            return true;
        }

        public bool UpdateProductQuantity(int id, int quantity)
        {
            return true;
        }

        public bool DeleteProduct(int id)
        {
            return true;
        }

        public IEnumerable<IOrder> GetOrders()
        {
            return null;
        }

        public IOrder GetOrderById(int id)
        {
            return new Order(1, 1, 1, true);
        }

        public IOrder GetLatestOrderByProductAndBuyer(int product_id, int buyer_id)
        {
            return new Order(1, 1, 1, true);
        }

        public IEnumerable<IOrder> GetOrdersByProductId(int product_id)
        {
            return null;
        }

        public bool AddOrder(int product_id, int buyer_id, bool is_payed, string event_description)
        {
            return true;
        }

        public bool UpdateOrder(int id, int buyer_id)
        {
            return true;
        }

        public bool DeleteOrder(int id)
        {
            return true;
        }

        public IEnumerable<IEvent> GetEvents()
        {
            List<IEvent> list = new List<IEvent>();
            list.Add(new Event(1, DateTime.Now, 1, "orderEvent", "test"));
            list.Add(new Event(2, DateTime.Now, 1, "returnEvent", "test"));
            return list;
        }

        public IEvent GetEventById(int id)
        {
            return new Event(2, DateTime.Now, 1, "returnEvent", "test");
        }

        public IEnumerable<IEvent> GetEventsByOrderId(int order_id)
        {
            List<IEvent> list = new List<IEvent>();
            list.Add(new Event(1, DateTime.Now, 1, "orderEvent", "test"));
            list.Add(new Event(2, DateTime.Now, 1, "returnEvent", "test"));
            return list;
        }

        public bool AddEvent(DateTime date, int order_id, string type, string description)
        {
            return true;
        }

        public bool UpdateEvent(int id, string description)
        {
            return true;
        }

        public bool DeleteEvent(int id)
        {
            return true;
        }
    }
}
