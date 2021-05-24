using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.API;

namespace Service
{
    public class ProductService
    {
        private IRepository repository;
        public ProductService(IRepository repository)
        {
            this.repository = repository;
        }
        public ProductService()
        {
            this.repository = new Repository();
        }
        public IEnumerable<IProduct> GetProducts()
        {
            return repository.GetProducts();
        }

        public IProduct GetProductById(int id)
        {
            return repository.GetProductById(id);
        }

        public IEnumerable<IProduct> GetProductByName(string name)
        {
            return repository.GetProductByName(name);
        }

        public IProduct GetProductByModel(string model)
        {
            return repository.GetProductByModel(model);
        }
        public bool AddProduct(string name, string model, float price, int size, string producer, string season, int quantity)
        {
            return repository.AddProduct(name, model, price, size, producer, season, quantity);
        }

        public bool UpdateProduct(int id, string name, string model, float price, int size, string producer, string season, int quantity)
        {
            return repository.UpdateProduct(id, name, model, price, size, producer, season, quantity);
        }

        public bool UpdateProductQuantity(int id, int quantity)
        {
            return repository.UpdateProductQuantity(id, quantity);
        }

        public bool DeleteProduct(int id)
        {
            return repository.DeleteProduct(id);
        }
    }
}
