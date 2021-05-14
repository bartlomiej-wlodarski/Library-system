using System;
using Library.Logic.Services;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            BookService service = new BookService(new Db.DbContext());
            service.AddBook(new Db.Book(1, "d", "sd", 13, Db.BookGenre.Adventure, DateTime.Now));
        }
    }
}
