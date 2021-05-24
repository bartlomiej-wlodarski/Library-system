using Model.ViewModel;
using Service;
using System;
using System.Collections.Generic;
using Data;
using Data.API;
using Model;

namespace Tests.ModelTest
{
    public class ProductViewModelForTests : IProductViewModel
    {
        private ProductService service;
        public ProductViewModelForTests(ProductService service)
        {
            this.service = service;
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                    
            }
        }

        private string model;
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                   
            }
        }

        private float price;
        public float Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                    
            }
        }

        private int size;
        public int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }

        private string producer;
        public string Producer
        {
            get
            {
                return producer;
            }
            set
            {
                producer = value;
            }
        }

        private string season;
        public string Season
        {
            get
            {
                return season;
            }
            set
            {
                season = value;
            }
        }

        private int quantity;
        public int Quantity
        {
            get
            {
                return quantity;
            }
            set
            {
                quantity = value;
            }
        }

        private int id;
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public void AddProduct()
        {
            bool added = service.AddProduct(Name, Model, Price, Size, Producer, Season, Quantity);
            if (added)
            {
                text = "Product added";
            }
            else
            {
                text = "Cannot add Product";
            }
                
        }

        private IProduct currentProduct;
        public IProduct CurrentProduct
        {
            get => currentProduct;
            set
            {
                currentProduct = value;
                   
            }
        }
        public void UpdateProduct()
        {
            bool updated = service.UpdateProduct(ID, Name, Model, Price, Size, Producer, Season, Quantity);
            if (updated)
            {
                text = "Product updated";
            }
            else
            {
                text = "Cannot update Product";
            }
               
        }

        public void UpdateQuantity()
        {
            bool updated = service.UpdateProductQuantity(ID, Quantity);
            if (updated)
            {
                text = "Product quantity updated";
            }
            else
            {
                text = "Cannot update Product quantity";
            }
                
        }

        public void DeleteProduct()
        {
            bool deleted = service.DeleteProduct(ID);
            if (deleted)
            {
                text = "Product deleted";
            }
            else
            {
                text = "Cannot delete Product";
            }
                
        }

        public void RefreshProducts()
        {
            Products = service.GetProducts();
        }

        private IEnumerable<IProduct> products;
        public IEnumerable<IProduct> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                    
            }
        }

        private string text;
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                    
            }
        }
    }
}
