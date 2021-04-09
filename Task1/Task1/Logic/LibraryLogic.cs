using System;
using System.Collections.Generic;

namespace Logic
{
    public class LibraryLogic
    {
        private Data.IDataService repository;

        public LibraryLogic(Data.IDataService repository)
        {
            this.repository = repository;
        }
        //getters
        Dictionary<int, Data.Book> GetBookCatalog()
        {
            return repository.GetBookCatalog();
        }

        Data.Book GetBook(int num)
        {
            return repository.GetBook(num);
        }

        Data.Client GetClient(int num)
        {
            return repository.GetClient(num);
        }

        List<Data.Client> GetClientCatalog()
        {
            return repository.GetClientCatalog();
        }

        Data.Event GetEvent(int num)
        {
            return repository.GetEvent(num);
        }

        List<Data.Event> GetEventCatalog()
        {
            return repository.GetEventCatalog();
        }
        //books
        void AddBook(Data.Book book)
        {
            repository.AddBook(book);
        }

        void RemoveBook(int num)
        {
            repository.RemoveBook(num);
        }

        void EditBook(Data.Book book)
        {
            repository.EditBook(book);
        }
        //clients
        void AddClient(Data.Client client)
        {
            repository.AddClient(client);
        }

        void RemoveClient(int num)
        {
            repository.RemoveClient(num);
        }

        void EditClient(Data.Client client)
        {
            repository.EditClient(client);
        }

        //events
        void AddEvent(Data.Event newEvent)
        {
            repository.AddEvent(newEvent);
        }

        void RemoveEvent(int num)
        {
            repository.RemoveEvent(num);
        }

        void EditEvent(Data.Event newEvent)
        {
            repository.EditEvent(newEvent);
        }

        //states
        bool CheckAvaiability(Data.Book book)
        {
            return repository.CheckAvaiability(book);
        }

        void ReportDamaged(Data.Book book)
        {
            repository.ReportDamaged(book);
        }

        void ReportRepaired(Data.Book book)
        {
            repository.ReportRepaired(book);
        }

        bool CheckIfDamaged(Data.Book book)
        {
            return repository.CheckIfDamaged(book);
        }
    }
}
