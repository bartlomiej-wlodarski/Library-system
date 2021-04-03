using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class EventCatalog
    {
        public Dictionary<int, Event> Events { get; set; } = new Dictionary<int, Event>();
    }
}
