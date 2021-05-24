using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IEvent
    {
        int ID { get; set; }
        DateTime? Date { get; set; }
        int? Order_id { get; set; }
        string Type { get; set; }
        string Description { get; set; }
    }
}
