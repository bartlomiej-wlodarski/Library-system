using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class State
    {
        public BookCatalog Books { get; set; } = new BookCatalog();
        public Dictionary<int, int> BooksInStock { get; set; } = new Dictionary<int, int>();
        /*
         * Let's say for now that:
         * 0 - means it is rented
         * 1 - means it is avaiable
         * 2 - means it is damaged
         */
    }
}
