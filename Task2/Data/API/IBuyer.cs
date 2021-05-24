using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IBuyer
    {
        int ID { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Phone { get; set; }
    }
}
