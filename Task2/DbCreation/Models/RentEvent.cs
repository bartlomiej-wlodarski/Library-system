using System;
using System.Collections.Generic;
using System.Text;

namespace Db
{
    public class RentEvent : Event
    {
        public RentEvent(int id, Client client, DateTime date, Book book) : base(id, client, date, book)
        {
            book.State.Rented(date, client);
        }
    }
}
