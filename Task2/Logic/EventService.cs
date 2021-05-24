using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Data.API;

namespace Service
{
    public class EventService
    {
        private IRepository repository;
        public EventService(IRepository repository)
        {
            this.repository = repository;
        }
        public EventService()
        {
            this.repository = new Repository();
        }
        public IEnumerable<IEvent> GetEvents()
        {
            return repository.GetEvents();
        }

        public IEvent GetEventById(int id)
        {
            return repository.GetEventById(id);
        }

        public IEnumerable<IEvent> GetEventsByOrderId(int order_id)
        {
            return repository.GetEventsByOrderId(order_id);
        }

        public bool AddEvent(DateTime date, int order_id, string type, string description)
        {
            return repository.AddEvent(date, order_id, type, description);
        }

        public bool UpdateEvent(int id , string description)
        {
            return repository.UpdateEvent(id, description);
        }

        public bool DeleteEvent(int id)
        {
            return repository.DeleteEvent(id);
        }
    }
}
