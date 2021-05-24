using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IOrder
    {
        int ID { get; set; }
        int? Product_id { get; set; }
        int? Buyer_id { get; set; }
        bool? IsPayed { get; set; }
    }
}
