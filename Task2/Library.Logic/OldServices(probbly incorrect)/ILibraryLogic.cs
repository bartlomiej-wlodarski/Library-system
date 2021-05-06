using System;
using System.Collections.Generic;

namespace Library.Logic
{
    public interface ILibraryLogic
    {

        void AddBook(Library.Data.Book book);
        void RemoveBook(int num);
        Library.Data.Book GetBook(int num);
        Dictionary<int, Library.Data.Book> GetBookCatalog();
        void AddClient(Library.Data.Client client);
        void EditClient(Library.Data.Client client);
        void EditBook(Library.Data.Book book);
        void EditEvent(Library.Data.Event newEvent);
        void RemoveClient(int num);
        Library.Data.Client GetClient(int num);
        List<Library.Data.Client> GetClientCatalog();
        void AddEvent(Library.Data.Event newEvent);
        void RemoveEvent(int num);
        Library.Data.Event GetEvent(int num);
        List<Library.Data.Event> GetEventCatalog();
        bool CheckAvaiability(Library.Data.Book book);
        void ReportDamaged(Library.Data.Book book, Library.Data.Client client, DateTime date);
        void ReportRepaired(Library.Data.Book book, Library.Data.Client client, DateTime date);
        bool CheckIfDamaged(Library.Data.Book book);

        int GetBooksNumber();
        int GetClientsNumber();
        int GetEventsNumber();

        void RentEvent(int id, Library.Data.Client client, DateTime date, Library.Data.Book book);

        void ReturnEvent(int id, Library.Data.Client client, DateTime date, Library.Data.Book book);

    }
}