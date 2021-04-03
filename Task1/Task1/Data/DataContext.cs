using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataContext
    {
        public BookCatalog books = new BookCatalog();
        public ClientCatalog clients = new ClientCatalog();
        public EventCatalog events = new EventCatalog();
        public State states = new State();
    }
}
