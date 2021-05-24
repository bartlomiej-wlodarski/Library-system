using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public class Order : IOrder
    {
        public Order(int ID, int? buyer_id, int? product_id, bool? isPayed)
        {
            this.ID = ID;
            this.Buyer_id = buyer_id;
            this.Product_id = product_id;
            this.IsPayed = isPayed;
        }
        public int ID { get; set; }
        public int? Product_id { get; set; }
        public int? Buyer_id { get; set; }
        public bool? IsPayed { get; set; }
    }
}
