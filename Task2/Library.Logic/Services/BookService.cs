using Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Logic.Services
{
    public class BookService
    {
        /*private readonly DbContext context;

        public BookService(DbContext context)
        {
            this.context = context;
        }*/

        public void AddBook(Book book)
        {
            var id = book.Id;
            var title = book.Title;
            var author = book.Author;
            var pages = book.Pages;
            var date = book.Date_of_publication;
            var genre = book.Genre;
            var state = book.State;

            string sql = @"insert into dbo.Books (Id, Title, Author, Pages, Genre, Date_of_publication, State)
                                             values (@id, @title, @author, @pages, @genre, @date, @state);";

            DataAccess.SaveData(sql, book);

            //context.Set<Book>().Add(book);
            //context.SaveChanges();
        }

        public void AddBook(List<Book> books)
        {
            foreach (Book book in books)
            {
                AddBook(book);
            }
            //context.SaveChanges();
        }

        public bool CheckAvaiability(Book book)
        {
            string sql = @"select Id, Title, Author, Pages, Genre, Date_of_publication, State
                            from dbo.Books;";

            List<Book> books = DataAccess.LoadData<Book>(sql);

            if (books.FirstOrDefault(x => x.Id == book.Id).State.GetState() == 1)
            {
                return true;
            }
            return false;
        }

        public Book GetBook(int num)
        {
            string sql = @"select Id, Title, Author, Pages, Genre, Date_of_publication, State
                            from dbo.Books;";

            List<Book> books =  DataAccess.LoadData<Book>(sql);

            return books.FirstOrDefault(x => x.Id == num);
            //return context.Set<Book>().FirstOrDefault(x => x.Id == num);
        }

        public bool CheckIfDamaged(Book book)
        {
            string sql = @"select Id, Title, Author, Pages, Genre, Date_of_publication, State
                            from dbo.Books;";

            List<Book> books = DataAccess.LoadData<Book>(sql);

            if (books.FirstOrDefault(x => x.Id == book.Id).State.GetState() == 2)
            {
                return true;
            }
            return false;
        }

        public void EditBook(Book book)
        {
            string sql = @"select Id, Title, Author, Pages, Genre, Date_of_publication, State
                            from dbo.Books;";

            List<Book> books = DataAccess.LoadData<Book>(sql);

            Book _book = books.FirstOrDefault(x => x.Id.Equals(book.Id));

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Author = book.Author;
                _book.Date_of_publication = book.Date_of_publication;
                _book.Genre = book.Genre;
                _book.Pages = book.Pages;

                sql = @"update dbo.Books set Title = @book.Title, Author = @book.Author, Date_of_publication = @book.Date_of_publication,
                        Genre = @book.Genre, Pages = @book.Pages where Id = @book.Id;";

                DataAccess.SaveData(sql, book);
            }
        }

        public IEnumerable<Book> GetBookCatalog()
        {
            string sql = @"select Id, Title, Author, Pages, Genre, Date_of_publication, State
                            from dbo.Books;";
            return DataAccess.LoadData<Book>(sql);
            //return context.Set<Book>();
        }

        public void RemoveBook(int num)
        {
            string sql = @"select Id, Title, Author, Pages, Genre, Date_of_publication, State
                            from dbo.Books;";

            List<Book> books = DataAccess.LoadData<Book>(sql);

            Book book = books.FirstOrDefault(x => x.Id.Equals(num));

            if (book != null)
            {
                sql = @"delete from dbo.Books where Id == @num;";

                DataAccess.SaveData(sql, book);
            }
        }

        public void ReportDamaged(Book book, Client client, DateTime date)
        {
            State state = new State(0);
            state.Damaged(date, client);

            string sql = @"update dbo.Books set State = @state where Id = @book.Id;";

            DataAccess.SaveData(sql, book);
        }

        public void ReportRepaired(Book book, Client client, DateTime date)
        {
            State state = new State(0);
            state.Avaiable(date, client);

            string sql = @"update dbo.Books set State = @state where Id = @book.Id;";

            DataAccess.SaveData(sql, book);
        }

        public void RentEvent(int id, Client client, DateTime date, Book book)
        {
            State state = new State(0);
            state.Rented(date, client);

            string sql = @"update dbo.Books set State = @state where Id = @book.Id;";

            DataAccess.SaveData(sql, book);
        }

        public void ReturnEvent(int id, Client client, DateTime date, Book book)
        {
            State state = new State(0);
            state.Avaiable(date, client);

            string sql = @"update dbo.Books set State = @state where Id = @book.Id;";

            DataAccess.SaveData(sql, book);
        }

        public int GetBooksNumber()
        {
            IEnumerable<Book> books = GetBookCatalog();
            return books.Count();
        }
    }
}
