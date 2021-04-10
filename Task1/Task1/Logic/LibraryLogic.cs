using System;
using System.Collections.Generic;

namespace Logic
{
    public class LibraryLogic : ILibraryLogic
    {
        private readonly Data.IDataService repository;

        public LibraryLogic(Data.IDataService repository)
        {
            this.repository = repository;
        }
        //getters
        public Dictionary<int, Data.Book> GetBookCatalog()
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

        public Data.State GetState()
        {
            return repository.GetState();
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
    }
}
