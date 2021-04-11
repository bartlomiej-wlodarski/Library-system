using System;
using System.Collections.Generic;

namespace Logic
{
    public interface ILibraryLogic
    {

        void AddBook(Data.Book book);
        void RemoveBook(int num);
        Data.Book GetBook(int num);
        Dictionary<int, Data.Book> GetBookCatalog();
        void AddClient(Data.Client client);
        void EditClient(Data.Client client);
        void EditBook(Data.Book book);
        void EditEvent(Data.Event newEvent);
        void RemoveClient(int num);
        Data.Client GetClient(int num);
        List<Data.Client> GetClientCatalog();
        void AddEvent(Data.Event newEvent);
        void RemoveEvent(int num);
        Data.Event GetEvent(int num);
        List<Data.Event> GetEventCatalog();
        bool CheckAvaiability(Data.Book book);
        void ReportDamaged(Data.Book book, Data.Client client, DateTime date);
        void ReportRepaired(Data.Book book, Data.Client client, DateTime date);
        bool CheckIfDamaged(Data.Book book);

        int GetBooksNumber();
        int GetClientsNumber();
        int GetEventsNumber();

        void RentEvent(int id, Data.Client client, DateTime date, Data.Book book);

        void ReturnEvent(int id, Data.Client client, DateTime date, Data.Book book);

    }
}