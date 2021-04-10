using System;

namespace Data
{
    public class ReturnEvent : Event
    {
        public ReturnEvent(int id, Client client, DateTime date, Book book) : base(id, client, date, book)
        {
            book.State.Avaiable(date, client);
        }
    }
}
