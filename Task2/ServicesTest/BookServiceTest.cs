using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.Data;
using Library.Services;
using System.Linq;
using System.Collections.Generic;
using Moq;
using System.Data.Linq;

namespace ServicesTest
{
    [TestClass]
    public class BookServiceTest
    {
        private readonly BookService service;
        public BookServiceTest()
        {
            service = new BookService(new TestDbDataSet());
            /*IQueryable<Book> books = new List<Book>
            {
                //new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1),
                //new Data.Book(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling", 667, Data.BookGenre.Fantasy, date_2),
                //new Data.Book(3, "Chrobot", "Tomasz Michniewicz", 320, Data.BookGenre.Personal, date_3)
            }.AsQueryable();*/

            /*Mock<Table<Book>> mockBook = new Mock<Table<Book>>();
            mockBook.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(books.Provider);
            mockBook.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(books.Expression);
            mockBook.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(books.ElementType);
            mockBook.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(books.GetEnumerator());
            Mock<LibraryDataContext> mockLibrary = new Mock<LibraryDataContext>();
            mockLibrary.Setup(x => x.Table<Book>()).Returns(mockBook.Object);

            service = new BookService(mockLibrary.Object);*/

            //Mock<LibraryDataContext> context = new Mock<LibraryDataContext>();
            //context.Setup(x => x.Books).Returns((Table<Book>)books.AsEnumerable());
            //context.Setup(x => x.Books).Returns((Table<Book>)books.AsEnumerable());
        }

        [TestMethod]
        public void AddBookToDatabaseTest()
        {
            service.AddBook("J.K. Rowling", "Harry ------ Potter", 1997, "Fantasy", 5);
            /*Assert.IsTrue(BookService.AddBook("J.K. Rowling", "Harry ------ Potter", 1997, "Fantasy", 5));
            Assert.AreEqual(BookService.GetBook("Harry ------ Potter", "J.K. Rowling").author, "J.K. Rowling");
            Assert.AreEqual(BookService.GetBook("Harry ------ Potter", "J.K. Rowling").title, "Harry ------ Potter");
            Assert.AreEqual(BookService.GetBook("Harry ------ Potter", "J.K. Rowling").publishment_year, 1997);
            Assert.AreEqual(BookService.GetBook("Harry ------ Potter", "J.K. Rowling").genre, "Fantasy");
            Assert.AreEqual(BookService.GetBook("Harry ------ Potter", "J.K. Rowling").quantity, 5);

            //delete to restore original db
            Assert.IsTrue(BookService.DeleteBook("Harry ------ Potter"));*/
        }


        /*[TestMethod]
        public void AddBookToDatabaseTheSameTitleTest()
        {
            Assert.IsFalse(BookService.AddBook("J.K. Rowling", "Harry Potter", 1997, "Fantasy", 5));
        }

        [TestMethod]
        public void AddBookToDatabaseWrongQuantityTest()
        {
            Assert.IsFalse(BookService.AddBook("J.K. Rowling", "Harry Potter", 1997, "Fantasy", -5));
        }

        [TestMethod]
        public void GetBookByTitleTest()
        {
            Book book = BookService.GetBook("Harry Potter", "J.K. Rowling");
            Assert.AreEqual(book.title, "Harry Potter");
            Assert.AreEqual(book.author, "J.K. Rowling");
            Assert.AreEqual(book.publishment_year, 1997);
            Assert.AreEqual(book.genre, "Fantasy");
        }

        [TestMethod]
        public void DeleteBookByTitleTest()
        {
            Assert.IsTrue(BookService.AddBook("J.K. Rowling", "Harry ------ Potter", 1997, "Fantasy", 5));

            //delete to restore original db
            Assert.IsTrue(BookService.DeleteBook("Harry ------ Potter"));
        }

        [TestMethod]
        public void UpdateBookQuantityTest()
        {
            Assert.IsTrue(BookService.AddBook("J.K. Rowling", "Harry ------ Potter", 1997, "Fantasy", 5));
            Book book = BookService.GetBook("Harry ------ Potter", "J.K. Rowling");

            Assert.IsTrue(BookService.UpdateBookQuantity(book.book_id, 10));
            Book book1 = BookService.GetBook("Harry ------ Potter", "J.K. Rowling");
            Assert.AreEqual(book1.quantity, 10);

            //update to restore original db
            Assert.IsTrue(BookService.DeleteBook("Harry ------ Potter"));
        }

        [TestMethod]
        public void UpdateBookTest()
        {
            Assert.IsTrue(BookService.AddBook("J.K. Rowling", "Harry ------ Potter", 1997, "Fantasy", 5));
            Book book = BookService.GetBook("Harry ------ Potter", "J.K. Rowling");
            Assert.IsTrue(BookService.UpdateBook(book.book_id, "Harry", "Rowling", 1997, "Fantasy", 5));
            Assert.IsNull(BookService.GetBook("Harry ------ Potter", "J.K. Rowling"));
            Book book1 = BookService.GetBook("Harry", "Rowling");
            Assert.IsNotNull(book1);
            Assert.AreEqual(book1.author, "Rowling");
            Assert.AreEqual(book1.title, "Harry");
            Assert.AreEqual(book1.quantity, 5);
            Assert.AreEqual(book1.publishment_year, 1997);
            Assert.AreEqual(book1.genre, "Fantasy");

            //restore original db
            Assert.IsTrue(BookService.DeleteBook("Harry"));
        }*/
    }
}
