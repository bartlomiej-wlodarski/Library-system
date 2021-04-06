using System;
using System.Collections.Generic;

namespace Data
{
    public interface IDataService
    {
        void AddBook(Book book);
        void RemoveBook(int num);
        Book GetBook(int num);
        Dictionary<int, Book> GetBookCatalog();
        void AddClient(Client client);
        void EditClient(Client client);
        void EditBook(Book book);
        void EditEvent(Event newEvent);
        void RemoveClient(int num);
        Client GetClient(int num);
        Dictionary<int, Client> GetClientCatalog();
        void AddEvent(Event newEvent);
        void RemoveEvent(int num);
        Event GetEvent(int num);
        Dictionary<int, Event> GetEventCatalog();
        bool CheckAvaiability(Book book);
        void ReportDamaged(Book book);
        void ReportRepaired(Book book);
        bool CheckIfDamaged(Book book);
    }
}
