using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Logic.Services
{
    public class BookService
    {
        private readonly LibraryDataContext context;

        public BookService(LibraryContext context)
        {
            this.context = context;
        }

        public void AddBook(Book book)
        {
            context.Set<Book>().Add(book);
            context.SaveChanges();
        }

        public void AddBook(List<Book> books)
        {
            foreach (Book book in books)
            {
                AddBook(book);
            }
            context.SaveChanges();
        }

        public bool CheckAvaiability(Book book)
        {
            if (context.Set<Book>().FirstOrDefault(x => x.Id == book.Id).State.GetState() == 1)
            {
                return true;
            }
            return false;
        }

        public Book GetBook(int num)
        {
            return context.Set<Book>().FirstOrDefault(x => x.Id == num);
        }

        public bool CheckIfDamaged(Book book)
        {
            if (context.Set<Book>().FirstOrDefault(x => x.Id == book.Id).State.GetState() == 2)
            {
                return true;
            }
            return false;
        }

        public void EditBook(Book book)
        {
            Book _book = context.Set<Book>().FirstOrDefault(x => x.Id.Equals(book.Id));

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Author = book.Author;
                _book.Date_of_publication = book.Date_of_publication;
                _book.Genre = book.Genre;
                _book.Pages = book.Pages;

                context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetBookCatalog()
        {
            return context.Set<Book>();
        }

        public void RemoveBook(int num)
        {
            Book book = context.Set<Book>().FirstOrDefault(x => x.Id.Equals(num));

            if (book != null)
            {
                context.Set<Book>().Remove(book);
                context.SaveChanges();
            }
        }

        public void ReportDamaged(Book book, Client client, DateTime date)
        {
            context.Set<Book>().FirstOrDefault(x => x.Id == book.Id).State.Damaged(date, client);
            context.SaveChanges();
        }

        public void ReportRepaired(Book book, Client client, DateTime date)
        {
            context.Set<Book>().FirstOrDefault(x => x.Id == book.Id).State.Avaiable(date, client);
            context.SaveChanges();
        }

        public void RentEvent(int id, Client client, DateTime date, Book book)
        {
            context.Set<Book>().FirstOrDefault(x => x.Id == book.Id).State.Rented(date, client);
        }

        public void ReturnEvent(int id, Client client, DateTime date, Book book)
        {
            context.Set<Book>().FirstOrDefault(x => x.Id == book.Id).State.Avaiable(date, client);
        }

        public int GetBooksNumber()
        {
            return context.Set<Book>().Count();
        }
    }
}
