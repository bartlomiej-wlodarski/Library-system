using System;
using System.Collections.Generic;
using Library.Data;

namespace Library.Logic
{
    public class LibraryLogic : ILibraryLogic
    {
        private readonly IDataService repository;

        public LibraryLogic(IDataService repository)
        {
            this.repository = repository;
            //this.repository = new Data.DataRepository(new Data.DataContext());
        }

        //getters
        public Dictionary<int, Library.Data.Book> GetBookCatalog()
        {
            return repository.GetBookCatalog();
        }

        public Data.Book GetBook(int num)
        {
            return repository.GetBook(num);
        }

        public Data.Client GetClient(int num)
        {
            return repository.GetClient(num);
        }

        public List<Data.Client> GetClientCatalog()
        {
            return repository.GetClientCatalog();
        }

        public Data.Event GetEvent(int num)
        {
            return repository.GetEvent(num);
        }

        public List<Data.Event> GetEventCatalog()
        {
            return repository.GetEventCatalog();
        }
        //books
        public void AddBook(Data.Book book)
        {
            repository.AddBook(book);
        }
        public void AddBook(List<Data.Book> bookList)
        {
            foreach (Data.Book book in bookList)
            {
                repository.AddBook(book);
            }
        }

        public void RemoveBook(int num)
        {
            repository.RemoveBook(num);
        }

        public void EditBook(Data.Book book)
        {
            repository.EditBook(book);
        }
        //clients
        public void AddClient(Data.Client client)
        {
            repository.AddClient(client);
        }

        public void RemoveClient(int num)
        {
            repository.RemoveClient(num);
        }

        public void EditClient(Data.Client client)
        {
            repository.EditClient(client);
        }

        //events
        public void AddEvent(Data.Event newEvent)
        {
            repository.AddEvent(newEvent);
        }

        public void RemoveEvent(int num)
        {
            repository.RemoveEvent(num);
        }

        public void EditEvent(Data.Event newEvent)
        {
            repository.EditEvent(newEvent);
        }

        //states
        public bool CheckAvaiability(Data.Book book)
        {
            return repository.CheckAvaiability(book);
        }

        public void ReportDamaged(Data.Book book, Data.Client client, DateTime date)
        {
            repository.ReportDamaged(book, client, date);
        }

        public void ReportRepaired(Data.Book book, Data.Client client, DateTime date)
        {
            repository.ReportRepaired(book, client, date);
        }

        public bool CheckIfDamaged(Data.Book book)
        {
            return repository.CheckIfDamaged(book);
        }

        public int GetBooksNumber()
        {
            return repository.GetBooksNumber();
        }
        public int GetClientsNumber()
        {
            return repository.GetClientsNumber();
        }
        public int GetEventsNumber()
        {
            return repository.GetEventsNumber();
        }

        public void RentEvent(int id, Data.Client client, DateTime date, Data.Book book)
        {
            repository.RentEvent(id, client, date, book);
        }

        public void ReturnEvent(int id, Data.Client client, DateTime date, Data.Book book)
        {
            repository.ReturnEvent(id, client, date, book);
        }

    }
}
