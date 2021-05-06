using System;
using System.Collections.Generic;
using System.Text;
using Library.Data;

namespace Library.Logic
{
    public class DataContext
    {
        public BookCatalog books = new BookCatalog();
        public ClientCatalog clients = new ClientCatalog();
        public EventCatalog events = new EventCatalog();
        public State states = new State();
    }
}
