using System;
using System.Collections.Generic;
using Library.Data;
using System.Linq;

namespace Library.Services
{
    public class Eventervice
	{
        static public IEnumerable<Event> GetEvent()
        {
            using (var context = new LibraryDataContext())
            {
                return context.Event.ToList();
            }
        }
 
        static public IEnumerable<Event> GetEventForClientByName(string fName, string lName)
        {
            using (var context = new LibraryDataContext())
            {
                Client Client = ClientService.GetClient(fName, lName);

                if (Client == null)
                {
                    return null;
                }

                List<Event> result = new List<Event>();
                foreach (Event e in context.Event.ToList())
                {
                    if (e.client == Client.Id)
                    {
                        result.Add(e);
                    }
                }
                return result;
            }
        }
        public IEnumerable<Event> GetEventForBookByTitle(string Title)
        {
            using (var context = new LibraryDataContext())
            {
                Book book = context.Book.SingleOrDefault(b => b.Title.Equals(Title));

                List<Event> result = new List<Event>();
                foreach (Event e in context.Event.ToList())
                {
                    if (e.book == book.Id)
                    {
                        result.Add(e);
                    }
                }
                return result;
            }
        }

        static public IEnumerable<Event> GetBorrowingEvent()
        {
            using (var context = new LibraryDataContext())
            {
                List<Event> result = new List<Event>();
                foreach (Event e in context.Event.ToList())
                {
                    if (true) //wrong
                    {
                        result.Add(e);
                    }
                }
                return result;
            }
        }

        static public IEnumerable<Event> GetReturningEvent()
        {
            using (var context = new LibraryDataContext())
            {
                List<Event> result = new List<Event>();
                foreach (Event e in context.Event.ToList())
                {
                    if (false) //wrong
                    {
                        result.Add(e);
                    }
                }
                return result;
            }
        }

      
        static public IEnumerable<Event> GetEventByDate(DateTime date)
        {
            using (var context = new LibraryDataContext())
            {
                List<Event> Event = new List<Event>();
                foreach (Event ev in context.Event.ToList())
                {
                    if (ev.Date == date)
                    {
                        Event.Add(ev);
                    }
                }
                return Event;
            }
        }

        
        static public bool AddEvent(DateTime time, bool isBorrowingEvent, int bookId, int ClientId)
        {
            using (var context = new LibraryDataContext())
            {
                if (context.Client.SingleOrDefault(r => r.Id.Equals(ClientId)) != null &&
                        context.Book.SingleOrDefault(b => b.Id.Equals(bookId)) != null )
                {
                    Event newEvent = new Event
                    {
                        Date = time,
                        // = isBorrowingEvent,
                        book = bookId,
                        client = ClientId
                    };
                    context.Event.InsertOnSubmit(newEvent);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool DeleteEvent(int ClientId, int bookId)
        {
            using (var context = new LibraryDataContext())
            {
                Event ev = context.Event.FirstOrDefault(e => e.client == ClientId && e.book == bookId);
                if (ev != null)
                {
                    context.Event.DeleteOnSubmit(ev);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }


        static public void DeleteEventForClient(int ClientId)
        {
            using (var context = new LibraryDataContext())
            {
                IEnumerable<Event> Event = context.Event.Where(e => e.client == ClientId);
                foreach (Event e in Event)
                {
                    context.Event.DeleteOnSubmit(e);
                    context.SubmitChanges();
                }
            }
        }

        static public void DeleteEventForBook(int bookId)
        {
            using (var context = new LibraryDataContext())
            {
                IEnumerable<Event> Event = context.Event.Where(e => e.book == bookId);
                foreach (Event e in Event)
                {
                    context.Event.DeleteOnSubmit(e);
                    context.SubmitChanges();
                }
            }
        }


        public bool UpdateEventTime(int id, DateTime time)
        {
            using (var context = new LibraryDataContext())
            {
                Event ev = context.Event.SingleOrDefault(e => e.Id == id);
                ev.Date = time;
                context.SubmitChanges();
                return true;
            }
        }

        public bool UpdateEventType(int id)
        {
            using (var context = new LibraryDataContext())
            {
                Event ev = context.Event.SingleOrDefault(e => e.Id == id);
                //ev.is_borrowing_event = !ev.is_borrowing_event;
                context.SubmitChanges();
                return true;
            }
        }

        static public bool BorrowBookForClient(Book book, Client Client)
        {
            using (var context = new LibraryDataContext())
            {
                if (book != null && Client != null)
                {
                    /*if (book.quantity > 0)
                    {
                        AddEvent(DateTime.Today, true, book.Id, Client.Id);
                        book.quantity -= 1;
                        Bookervice.UpdateBookQuantity(book.Id, (int)book.quantity);
                        return true;
                    }/*/
                }
            }
            return false;
        }

        static public bool ReturnBookByClient(Book book, Client Client)
        {
            using (var context = new LibraryDataContext())
            {
                if (book != null && Client != null)
                {
                    /*if (CheckEventForBookAndClient(Client.Id, book.Id))
                    {
                        AddEvent(DateTime.Today, false, book.Id, Client.Id);
                        book.quantity += 1;
                        Bookervice.UpdateBookQuantity(book.Id, (int)book.quantity);
                        return true;
                    }*/
                }
                return false;
            }
        }

        static public bool CheckEventForBookAndClient(int ClientId, int bookId)
        {
            using (var context = new LibraryDataContext())
            {
                /*Book book = context.Book.SingleOrDefault(b => b.Id.Equals(bookId));
                Client Client = context.Clients.SingleOrDefault(r => r.Id.Equals(ClientId));

                List<Event> bEvent = new List<Event>();
                List<Event> rEvent = new List<Event>();
                foreach (Event e in context.Event.ToList())
                {
                    if (e.book == book.Id && e.Client == ClientId && e.is_borrowing_event)
                    {
                        bEvent.Add(e);
                    }
                    else if (e.book == book.Id && e.Client == ClientId && !e.is_borrowing_event)
                    {
                        rEvent.Add(e);
                    }
                }
                return bEvent.Count() > rEvent.Count();*/
            }
            return false;
        }


    }
}
