using Library.Data;
using System.Collections.Generic;
using System.Linq;

namespace Library.Services
{
    public class Bookervice
    {
        public IEnumerable<Book> GetAllBook()
        {
            using (var context = new LibraryDataContext())
            {
                var result = context.Book.ToList();
                return result;
            }
        }

        static public Book GetBook(string Title, string Author)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Book b in context.Book.ToList())
                {
                    if (b.Title.Equals(Title) && b.Author.Equals(Author))
                    {
                        return b;
                    }
                }
                return null; 
            }
        }

        public Book GetBookById(int id)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Book b in context.Book.ToList())
                {
                    if(b.Id.Equals(id))
                    {
                        return b;
                    }
                }
                return null;
            }
        }

        static public IEnumerable<Book> GetBookByGenre(string g)
        {
            using (var context = new LibraryDataContext())
            {
                return context.Book.Where(book => book.Genre.Equals(g)).ToList();
            }
        }

        static public bool AddBook(string a, string t, System.DateTime date, string g, int q)
        {
            using (var context = new LibraryDataContext())
            {
                if (GetBook(t, a) == null && q >= 0)
                {
                    Book newBook = new Book
                    {
                        Author = a,
                        Title = t,
                        Date_of_publication = date,
                        Genre = g,
                        //quantity = q
                    };
                    context.Book.InsertOnSubmit(newBook);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool UpdateBookQuantity(int _id, int q)
        {
            using (var context = new LibraryDataContext())
            {
                if (q >= 0)
                {
                    Book book = context.Book.SingleOrDefault(i => i.Id == _id);
                    //book.quantity = q;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public int GetMaxId()
        {
            using (var context = new LibraryDataContext())
            {
                if (context.Book.Count() == 0)
                    return 0;
                else
                    return context.Book.OrderByDescending(b => b.Id).First().Id;
            }
        }

        static public bool UpdateBook(int id, string Title, string Author,
            System.DateTime date, string genre, int quantity)
        {
            using (var context = new LibraryDataContext())
            {
                Book book = context.Book.SingleOrDefault(b => b.Id == id);
                if (GetBook(Title, Author) == null)
                {
                    book.Title = Title;
                    book.Author = Author;
                    book.Date_of_publication = date;
                    book.Genre = genre;
                    //book.quantity = quantity;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        static public bool DeleteBook(string Title)
        {
            using (var context = new LibraryDataContext())
            {
                Book book = context.Book.FirstOrDefault(i => i.Title == Title);
                Eventervice.DeleteEventForBook(book.Id);
                context.Book.DeleteOnSubmit(book);
                context.SubmitChanges();
                return true;
            }
        }
    }
}
