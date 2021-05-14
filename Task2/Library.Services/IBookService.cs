using System.Collections.Generic;
using Library.Data;

namespace Library.Services
{
    public interface IBookService
    {
        object Books { get; }

        bool AddBook(string a, string t, int year, string g, int q);
        bool DeleteBook(string title);
        IEnumerable<Book> GetAllBooks();
        Book GetBook(string title, string author);
        Book GetBookById(int id);
        IEnumerable<Book> GetBooksByGenre(string g);
        int GetMaxId();
        bool UpdateBook(int id, string title, string author, int year, string genre, int quantity);
        bool UpdateBookQuantity(int _id, int q);
        void InsertOnSubmit(object obj);
    }
}