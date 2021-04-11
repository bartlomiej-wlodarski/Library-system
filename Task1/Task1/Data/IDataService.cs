using System;
using System.Collections.Generic;

namespace Data
{
    public interface IDataService
    {
        void AddBook(Book book);
        void AddBook(List<Book> bookList);
        void RemoveBook(int num);
        Book GetBook(int num);
        Dictionary<int, Book> GetBookCatalog();
        void AddClient(Client client);
        void EditClient(Client client);
        void EditBook(Book book);
        void EditEvent(Event newEvent);
        void RemoveClient(int num);
        Client GetClient(int num);
        List<Client> GetClientCatalog();
        void AddEvent(Event newEvent);
        void RemoveEvent(int num);
        Event GetEvent(int num);
        List<Event> GetEventCatalog();
        bool CheckAvaiability(Book book);
        void ReportDamaged(Book book, Client client, DateTime date);
        void ReportRepaired(Book book, Client client, DateTime date);
        bool CheckIfDamaged(Book book);

        int GetBooksNumber();
        int GetClientsNumber();
        int GetEventsNumber();

        void RentEvent(int id, Client client, DateTime date, Book book);

        void ReturnEvent(int id, Client client, DateTime date, Book book);



    }
}
