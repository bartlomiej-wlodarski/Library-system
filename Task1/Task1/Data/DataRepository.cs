using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataRepository : IDataService
    {
        DataContext dataContext;

        public DataRepository(DataContext context)
        {
            this.dataContext = context;
        }

        public void AddBook(Book book)
        {
            dataContext.books.Books.Add(book.Id, book);
        }

        public void AddClient(Client client)
        {
            dataContext.clients.Clients.Add(client.Id, client);
        }

        public void AddEvent(Event newEvent)
        {
            dataContext.events.Events.Add(newEvent.Id, newEvent);
        }

        public bool CheckAvaiability(Book book)
        {
            return (dataContext.states.BooksInStock[book.Id] == 1);
        }

        public bool CheckIfDamaged(Book book)
        {
            return (dataContext.states.BooksInStock[book.Id] == 2);
        }

        public void EditBook(Book book)
        {
            dataContext.books.Books[book.Id].Title = book.Title;
            dataContext.books.Books[book.Id].Author = book.Author;
            dataContext.books.Books[book.Id].Genre = book.Genre;
            dataContext.books.Books[book.Id].Date_of_publication = book.Date_of_publication;
            dataContext.books.Books[book.Id].Pages = book.Pages;
        }

        public void EditClient(Client client)
        {
            dataContext.clients.Clients[client.Id].Name = client.Name;
            dataContext.clients.Clients[client.Id].Surname = client.Surname;
            dataContext.clients.Clients[client.Id].Age = client.Age;
        }

        public void EditEvent(Event newEvent)
        {
            dataContext.events.Events[newEvent.Id].Client = newEvent.Client;
            dataContext.events.Events[newEvent.Id].Date = newEvent.Date;
            dataContext.events.Events[newEvent.Id].State = newEvent.State;
        }

        public Book GetBook(int num)
        {
            return dataContext.books.Books[num];
        }

        public Dictionary<int, Book> GetBookCatalog()
        {
            return dataContext.books.Books;
        }

        public Client GetClient(int num)
        {
            return dataContext.clients.Clients[num];
        }

        public Dictionary<int, Client> GetClientCatalog()
        {
            return dataContext.clients.Clients;
        }

        public Event GetEvent(int num)
        {
            return dataContext.events.Events[num];
        }

        public Dictionary<int, Event> GetEventCatalog()
        {
            return dataContext.events.Events;
        }

        public void RemoveBook(int num)
        {
            dataContext.books.Books.Remove(num);
        }

        public void RemoveClient(int num)
        {
            dataContext.clients.Clients.Remove(num);
        }

        public void RemoveEvent(int num)
        {
            dataContext.events.Events.Remove(num);
        }

        public void ReportDamaged(Book book)
        {
            dataContext.states.BooksInStock[book.Id] = 2;
        }

        public void ReportRepaired(Book book)
        {
            dataContext.states.BooksInStock[book.Id] = 1;
        }

        public State GetState()
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
