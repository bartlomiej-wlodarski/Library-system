using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data
{
    public class BookCatalog
    {
        public Dictionary<int, Book> Books { get; set; } = new Dictionary<int, Book>();
    }
}
