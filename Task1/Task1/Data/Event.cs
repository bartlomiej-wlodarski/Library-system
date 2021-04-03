using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class Event
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public DateTime Date { get; set; }
        public State State { get; set; }

        protected Event(int id, Client client, DateTime date, State state)
        {
            Id = id;
            Client = client;
            Date = date;
            State = state;
        }
    }
}
