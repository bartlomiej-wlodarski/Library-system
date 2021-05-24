using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IRepository
    {
        IBuyer Transform(Buyers Buyer);
        IEnumerable<IBuyer> GetBuyers();
        IBuyer GetBuyer(string Phone);
        bool AddBuyer(string Name, string Surname, string Phone);
        bool UpdateBuyer(int id, string Name, string Surname, string Phone);
        bool DeleteBuyer(string Phone);

        IProduct Transform(Products Product);
        IEnumerable<IProduct> GetProducts();
        IProduct GetProductById(int id);
        IEnumerable<IProduct> GetProductByName(string name);
        IProduct GetProductByModel(string model);
        bool AddProduct(string name, string model, float price, int size, string producer, string season, int quantity);
        bool UpdateProduct(int id, string name, string model, float price, int size, string producer, string season, int quantity);
        bool UpdateProductQuantity(int id, int quantity);
        bool DeleteProduct(int id);

        IOrder Transform(Orders Order);
        IEnumerable<IOrder> GetOrders();
        IOrder GetOrderById(int id);
        IOrder GetLatestOrderByProductAndBuyer(int product_id, int buyer_id);
        IEnumerable<IOrder> GetOrdersByProductId(int product_id);
        bool AddOrder(int product_id, int buyer_id, bool is_payed, string event_description);
        bool UpdateOrder(int id, int buyer_id);
        bool DeleteOrder(int id);

        IEvent Transform(Events Event);
        IEnumerable<IEvent> GetEvents();
        IEvent GetEventById(int id);
        IEnumerable<IEvent> GetEventsByOrderId(int order_id);
        bool AddEvent(DateTime date, int order_id, string type, string description);
        bool UpdateEvent(int id, string description);
        bool DeleteEvent(int id); 
    }
}
