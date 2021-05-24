using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public class Product : IProduct
    {
        public Product(int ID, string name, string model, double? price, int? size, string producer, string season, int quantity)
        {
            this.ID = ID;
            this.Name = name;
            this.Model = model;
            this.Price = price;
            this.Size = size;
            this.Producer = producer;
            this.Season = season;
            this.Quantity = quantity;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public double? Price { get; set; }
        public int? Size { get; set; }
        public string Producer { get; set; }
        public string Season { get; set; }
        public int Quantity { get; set; }
    }
}
