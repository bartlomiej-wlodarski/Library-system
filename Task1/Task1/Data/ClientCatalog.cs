using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class ClientCatalog
    {
        public Dictionary<int, Client> Clients { get; set; } = new Dictionary<int, Client>();
    }
}
