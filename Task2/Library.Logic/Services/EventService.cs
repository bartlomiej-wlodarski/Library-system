using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Logic.Services
{
    public class Eventservice
    {
        private readonly LibraryDataContext context;

        public Eventservice(LibraryDataContext context)
        {
            this.context = context;
        }

        public void AddEvents(int Id, int ClientId, System.DateTime Date, int BookId)
        {
            Events events = new Events();
            events.Id = Id;
            events.ClientId = ClientId;
            events.Date = Date;
            events.BookId = BookId;
            context.Events.InsertOnSubmit(events);
            context.SubmitChanges();
        }

        public void EditEvents(int Id, int ClientId, System.DateTime Date, int BookId)
        {
            Events @Events = context.Events.FirstOrDefault(x => x.Id.Equals(Id));

            if (@Events != null)
            {
                @Events.BookId = BookId;
                @Events.ClientId = ClientId;
                @Events.Date = Date;

                context.SubmitChanges();
            }
        }

        public Events GetEvents(int num)
        {
            return context.Events.FirstOrDefault(x => x.Id == num);
        }

        public IEnumerable<Events> GetEventsCatalog()
        {
            return context.Events;
        }

        public void RemoveEvents(int num)
        {
            Events @Events = context.Events.FirstOrDefault(x => x.Id.Equals(num));

            if (@Events != null)
            {
                context.Events.DeleteOnSubmit(@Events);
                context.SubmitChanges();
            }
        }

        public int GetEventsNumber()
        {
            return context.Events.Count();
        }
    }
}
