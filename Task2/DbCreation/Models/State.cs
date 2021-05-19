using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Db
{
    public class State
    {
        [Key] public int Id { get; set; }
        private int stateValue;
        private DateTime date;
        private Client client;

        public State(int id)
        {
            this.stateValue = 1;
            this.date = DateTime.Now;
            this.client = new Client(0, "new_book", "new_book", 0);
            this.Id = id;
        }

        public void Damaged(DateTime date, Client client)
        {
            this.stateValue = 2;
            this.client = client;
            this.date = date;
        }

        public void Rented(DateTime date, Client client)
        {
            stateValue = 0;
            this.client = client;
            this.date = date;
        }

        public void Avaiable(DateTime date, Client client)
        {
            stateValue = 1;
            this.client = client;
            this.date = date;
        }

        public int GetState()
        {
            return stateValue;
        }
        public DateTime GetDate()
        {
            return date;
        }

        public Client GetClient()
        {
            return client;
        }
        
        //public BookCatalog Books { get; set; } = new BookCatalog();
        //public Dictionary<int, int> BooksInStock { get; set; } = new Dictionary<int, int>();
        /*
         * Let's say for now that:
         * 0 - means it is rented
         * 1 - means it is avaiable
         * 2 - means it is damaged
         */
    }
}
