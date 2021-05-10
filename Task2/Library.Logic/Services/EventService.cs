using Library.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Logic.Services
{
    public class EventService
    {
        private readonly LibraryContext context;

        public EventService(LibraryContext context)
        {
            this.context = context;
        }

        public void AddEvent(Event newEvent)
        {
            context.Set<Event>().Add(newEvent);
            context.SaveChanges();
        }

        public void EditEvent(Event newEvent)
        {
            Event @event = context.Set<Event>().FirstOrDefault(x => x.Id.Equals(newEvent.Id));

            if (@event != null)
            {
                @event.Book = newEvent.Book;
                @event.Client = newEvent.Client;
                @event.Date = newEvent.Date;

                context.SaveChanges();
            }
        }

        public Event GetEvent(int num)
        {
            return context.Set<Event>().FirstOrDefault(x => x.Id == num);
        }

        public IEnumerable<Event> GetEventCatalog()
        {
            return context.Set<Event>();
        }

        public void RemoveEvent(int num)
        {
            Event @event = context.Set<Event>().FirstOrDefault(x => x.Id.Equals(num));

            if (@event != null)
            {
                context.Set<Event>().Remove(@event);
                context.SaveChanges();
            }
        }

        public int GetEventsNumber()
        {
            return context.Set<Event>().Count();
        }
    }
}
