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
            Events events = new Events
            {
                Id = Id,
                ClientId = ClientId,
                Date = Date,
                BookId = BookId
            };
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
            IQueryable<Events> query = from events in context.Events
                                       where events.Id == num select events;

            return query.First();
            //return context.Events.FirstOrDefault(x => x.Id == num);
        }

        public IEnumerable<Events> GetEventsCatalog()
        {
            IQueryable<Events> query = from events in context.Events
                                       select events;

            return query;
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
            IQueryable<Events> query = from events in context.Events
                                       select events;

            return query.Count();
            //return context.Events.Count();
        }
    }
}
