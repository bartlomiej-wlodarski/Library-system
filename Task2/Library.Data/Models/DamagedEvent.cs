using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data
{
    public class DamagedEvent : Event
    {
        public DamagedEvent(int id, Client client, DateTime date, Book book) : base(id, client, date, book)
        {
            book.State.Damaged(date, client);
        }
    }
}
