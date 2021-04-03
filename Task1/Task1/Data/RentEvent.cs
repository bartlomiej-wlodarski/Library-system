using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class RentEvent : Event
    {
        public RentEvent(int id, Client client, DateTime date, State state) : base(id, client, date, state)
        {

        }
    }
}
