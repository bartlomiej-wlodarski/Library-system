using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class TDataRepository : Data.IDataService
    {
        Data.DataContext dataContext = new Data.DataContext();

        public TDataRepository(Data.DataContext context)
        {
            this.dataContext = context;
        }

        public void AddBook(Data.Book book)
        {
            dataContext.books.Books.Add(book.Id, book);
        }

        public void AddClient(Data.Client client)
        {
            dataContext.clients.Clients.Add(client);
        }

        public void AddEvent(Data.Event newEvent)
        {
            dataContext.events.Events.Add(newEvent);
        }

        public bool CheckAvaiability(Data.Book book)
        {
            if (dataContext.books.Books[book.Id].State.GetState() == 1)
            {
                return true;
        }
            return false;
        }

        public bool CheckIfDamaged(Data.Book book)
        {
            if (dataContext.books.Books[book.Id].State.GetState() == 2)
            {
                return true;
            }
            return false;
        }

        public void EditBook(Data.Book book)
        {
            dataContext.books.Books[book.Id].Title = book.Title;
            dataContext.books.Books[book.Id].Author = book.Author;
            dataContext.books.Books[book.Id].Genre = book.Genre;
            dataContext.books.Books[book.Id].Date_of_publication = book.Date_of_publication;
            dataContext.books.Books[book.Id].Pages = book.Pages;
        }

        public void EditClient(Data.Client client)
        {
            dataContext.clients.Clients.Find(x => x.Id == client.Id).Name = client.Name;
            dataContext.clients.Clients.Find(x => x.Id == client.Id).Surname = client.Surname;
            dataContext.clients.Clients.Find(x => x.Id == client.Id).Age = client.Age;
        }

        public void EditEvent(Data.Event newEvent)
        {
            dataContext.events.Events.Find(x => x.Id == newEvent.Id).Client = newEvent.Client;
            dataContext.events.Events.Find(x => x.Id == newEvent.Id).Date = newEvent.Date;
            dataContext.events.Events.Find(x => x.Id == newEvent.Id).Book = newEvent.Book;
        }

        public Data.Book GetBook(int num)
        {
            return dataContext.books.Books[num];
        }

        public Dictionary<int, Data.Book> GetBookCatalog()
        {
            return dataContext.books.Books;
        }

        public Data.Client GetClient(int num)
        {
            return dataContext.clients.Clients.Find(x => x.Id == num);
        }

        public List<Data.Client> GetClientCatalog()
        {
            return dataContext.clients.Clients;
        }

        public Data.Event GetEvent(int num)
        {
            return dataContext.events.Events.Find(x => x.Id == num);
        }

        public List<Data.Event> GetEventCatalog()
        {
            return dataContext.events.Events;
        }

        public void RemoveBook(int num)
        {
            dataContext.books.Books.Remove(num);
        }

        public void RemoveClient(int num)
        {
            dataContext.clients.Clients.RemoveAll(x => x.Id == num);
        }

        public void RemoveEvent(int num)
        {
            dataContext.events.Events.RemoveAll(x => x.Id == num);
        }

        public void ReportDamaged(Data.Book book, Data.Client client, DateTime date)
        {
            dataContext.books.Books[book.Id].State.Damaged(date, client);
        }

        public void ReportRepaired(Data.Book book, Data.Client client, DateTime date)
        {
            dataContext.books.Books[book.Id].State.Avaiable(date, client);
        }

        public Data.State GetState()
        {
            return dataContext.states;
        }

        public int GetBooksNumber()
        {
            return dataContext.books.Books.Count;
        }

        public int GetClientsNumber()
        {
            return dataContext.clients.Clients.Count;
        }

        public int GetEventsNumber()
        {
            return dataContext.events.Events.Count;
        }
    }
}
