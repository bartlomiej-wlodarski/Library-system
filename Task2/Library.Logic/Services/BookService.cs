using Library.Data;
using System.Collections.Generic;
using System.Linq;

namespace Library.Logic.Services
{
    public class BookService
    {
        private readonly LibraryDataContext context;

        public BookService(LibraryDataContext context)
        {
            this.context = context;
        }

        public void AddBook(int Id, string Title, string Author, int Pages, int Genre, System.DateTime Date)
        {
            Books book = new Books();
            book.Id = Id;
            book.Title = Title;
            book.Author = Author;
            book.Pages = Pages;
            book.Date_of_publication = Date;
            book.Genre = Genre;
            context.Books.InsertOnSubmit(book);
            context.SubmitChanges();
        }

        /*public void AddBook(List<Books> books)
        {
            foreach (Books book in books)
            {
                AddBook(book);
            }
            context.SubmitChanges();
        }*/

        public bool CheckAvaiability(int Id)
        {
            if (context.Books.FirstOrDefault(x => x.Id == Id).State.Value == 1)
            {
                return true;
            }
            return false;
        }

        public Books GetBook(int num)
        {
            return context.Books.FirstOrDefault(x => x.Id == num);
        }

        public bool CheckIfDamaged(int Id)
        {
            if (context.Books.FirstOrDefault(x => x.Id == Id).State.Value == 2)
            {
                return true;
            }
            return false;
        }

        public void EditBook(int Id, string Title, string Author, int Pages, int Genre, System.DateTime Date)
        {
            Books book = context.Books.FirstOrDefault(x => x.Id.Equals(Id));

            if (book != null)
            {
                book.Title = Title;
                book.Author = Author;
                book.Date_of_publication = Date;
                book.Genre = Genre;
                book.Pages = Pages;

                context.SubmitChanges();
            }
        }

        public IEnumerable<Books> GetBookCatalog()
        {
            return context.Books;
        }

        public void RemoveBook(int num)
        {
            Books book = context.Books.FirstOrDefault(x => x.Id.Equals(num));

            if (book != null)
            {
                context.Books.DeleteOnSubmit(book);
                context.SubmitChanges();
            }
        }

        public void ReportDamaged(int Id)
        {
            context.Books.FirstOrDefault(x => x.Id == Id).State.Value = 2;
            context.SubmitChanges();
        }

        public void ReportRepaired(int Id)
        {
            context.Books.FirstOrDefault(x => x.Id == Id).State.Value = 1;
            context.SubmitChanges();
        }

        public void RentEvents(int Id)
        {
            context.Books.FirstOrDefault(x => x.Id == Id).State.Value = 0;
        }

        public void ReturnEvents(int Id)
        {
            context.Books.FirstOrDefault(x => x.Id == Id).State.Value = 1;
        }

        public int GetBooksNumber()
        {
            return context.Books.Count();
        }
    }
}
