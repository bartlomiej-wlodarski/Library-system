using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Library.Data
{
    public class ClientCatalog
    {
        public ICollection<Client> Clients { get; set; } = new List<Client>();

        [Key] public int ClientCatalogId { get; set; }
    }
}
