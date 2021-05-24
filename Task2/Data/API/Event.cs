using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public class Event : IEvent
    {
        public Event(int ID, DateTime? date, int? order_id, string type, string description)
        {
            this.ID = ID;
            this.Date = date;
            this.Order_id = order_id;
            this.Type = type;
            this.Description = description;
        }
        public int ID { get; set; }
        public DateTime? Date { get; set; }
        public int? Order_id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
    }
}
