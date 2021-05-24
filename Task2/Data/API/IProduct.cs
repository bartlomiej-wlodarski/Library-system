using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IProduct
    {
        int ID { get; set; }
        string Name { get; set; }
        string Model { get; set; }
        double? Price { get; set; }
        int? Size { get; set; }
        string Producer { get; set; }
        string Season { get; set; }
        int Quantity { get; set; }
    }
}
