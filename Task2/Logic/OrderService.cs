using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.API;

namespace Service
{
    public class OrderService
    {
        private IRepository repository;
        public OrderService(IRepository repository)
        {
            this.repository = repository;
        }
        public OrderService()
        {
            this.repository = new Repository();
        }
        public IEnumerable<IOrder> GetOrder()
        {
            return repository.GetOrders();
        }

        public IOrder GetOrderById(int id)
        {
            return repository.GetOrderById(id);
        }

        public IOrder GetLatestOrderByProductAndBuyer(int product_id, int buyer_id)
        {
            return repository.GetLatestOrderByProductAndBuyer(product_id, buyer_id);
        }

        public IEnumerable<IOrder> GetOrdersByProductId(int product_id)
        {
            return repository.GetOrdersByProductId(product_id);
        }

        public bool AddOrder(int product_id, int buyer_id, bool is_payed, string event_description)
        {
            return repository.AddOrder(product_id, buyer_id, is_payed, event_description);
        }

        public bool UpdateOrder(int id, int buyer_id)
        {
            return repository.UpdateOrder(id, buyer_id);
        }

        public bool DeleteOrder(int id)
        {
            return repository.DeleteOrder(id);
        }
    }
}
