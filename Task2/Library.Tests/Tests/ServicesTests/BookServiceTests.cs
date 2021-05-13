using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace Library.LogicTests
{
    [TestClass]
    public class BookServiceTest
    {
        [TestMethod]
        public void Test()
        {
            Book book = new();
        }
    }
}
/*namespace Library.LogicTests
{
    [TestClass]
    public class BookerviceTests
    {
        private readonly Bookervice service;
        private readonly Mock<DbSet<Book>> mockBook;
        private readonly Mock<LibraryContext> mockLibrary;
        private readonly IQueryable<Book> Book;
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        public BookerviceTests()
        {
            Book = new List<Book>
            {
                new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1),
                new Data.Book(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling", 667, Data.BookGenre.Fantasy, date_2),
                new Data.Book(3, "Chrobot", "Tomasz Michniewicz", 320, Data.BookGenre.Personal, date_3)
            }.AsQueryable();

            mockBook = new Mock<DbSet<Book>>();
            mockBook.As<IQueryable<Book>>().Setup(m => m.Provider).Returns(Book.Provider);
            mockBook.As<IQueryable<Book>>().Setup(m => m.Expression).Returns(Book.Expression);
            mockBook.As<IQueryable<Book>>().Setup(m => m.ElementType).Returns(Book.ElementType);
            mockBook.As<IQueryable<Book>>().Setup(m => m.GetEnumerator()).Returns(Book.GetEnumerator());
            mockLibrary = new Mock<LibraryContext>();
            mockLibrary.Setup(x => x.Set<Book>()).Returns(mockBook.Object);

            service = new Bookervice(mockLibrary.Object);
        }

        [TestMethod]
        public void DataRepositoryAddBookTest()
        {
            Assert.AreEqual(3, service.GetBookNumber());

            service.AddBook(new Data.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)));
            service.AddBook(new Data.Book(5, "Krolestwo", "Szczepan Twardoch", 380, Data.BookGenre.Horror, new DateTime(2017, 11, 20)));
            service.AddBook(new Data.Book(6, "Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24)));

            mockLibrary.Verify(x => x.SaveChanges(), Times.Exactly(3));
        }

        [TestMethod]
        public void DataRepositoryAddBookListTest()
        {
            List<Data.Book> listOfBook = new List<Data.Book>
            {
                new Data.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)),
                new Data.Book(5, "Krolestwo", "Szczepan Twardoch", 380, Data.BookGenre.Horror, new DateTime(2017, 11, 20)),
                new Data.Book(6, "Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24))
            };
            service.AddBook(listOfBook);

            mockLibrary.Verify(x => x.SaveChanges(), Times.Exactly(4));
        }

        [TestMethod]
        public void DataRepositoryRemoveBookTest()
        {
            Assert.AreEqual(3, service.GetBookNumber());

            service.RemoveBook(1);

            mockLibrary.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DataRepositoryGetBookCatalogTest()
        {
            Assert.AreEqual(1, service.GetBook(1).Id);
            Assert.AreEqual("Maly Ksiaze", service.GetBook(1).Title);
            Assert.AreEqual("Saint-Exupery", service.GetBook(1).Author);
            Assert.AreEqual(120, service.GetBook(1).Pages);
            Assert.AreEqual(Data.BookGenre.Childrens, service.GetBook(1).Genre);
            Assert.AreEqual(date_1, service.GetBook(1).Date_of_publication);
        }

        [TestMethod]
        public void DataRepositoryEditBookTest()
        {
            service.EditBook(new Data.Book(1, "Duzy Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24)));

            Assert.AreEqual(1, service.GetBook(1).Id);
            Assert.AreEqual("Duzy Krol", service.GetBook(1).Title);
            Assert.AreEqual("Szczepan Twardoch", service.GetBook(1).Author);
            Assert.AreEqual(350, service.GetBook(1).Pages);
            Assert.AreEqual(Data.BookGenre.Horror, service.GetBook(1).Genre);
            Assert.AreEqual(new DateTime(2016, 12, 24), service.GetBook(1).Date_of_publication);
        }

        [TestMethod]
        public void DataRepositoryCatalogTest()
        {
            IEnumerable<Book> catalog = service.GetBookCatalog();
            Assert.IsTrue(catalog.Contains(service.GetBook(1)));
        }
    }
}*/