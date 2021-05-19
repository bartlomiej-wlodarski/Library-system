using System;
using System.Collections.Generic;
using System.Linq;
using Db;
using Library.Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Library.LogicTests
{
    [TestClass]
    public class BookServiceTests
    {
        private readonly BookService service = new BookService();
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        public BookServiceTests()
        {
            List<Book> books = new List<Db.Book>
            {
                new Db.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1),
                new Db.Book(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling", 667, Db.BookGenre.Fantasy, date_2),
                new Db.Book(3, "Chrobot", "Tomasz Michniewicz", 320, Db.BookGenre.Personal, date_3)
            };
            service.AddBook(books);
        }

        [TestMethod]
        public void DbRepositoryAddBookTest()
        {
            Assert.AreEqual(3, service.GetBooksNumber());

            service.AddBook(new Db.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Db.BookGenre.Personal, new DateTime(2018, 6, 12)));
            service.AddBook(new Db.Book(5, "Krolestwo", "Szczepan Twardoch", 380, Db.BookGenre.Horror, new DateTime(2017, 11, 20)));
            service.AddBook(new Db.Book(6, "Krol", "Szczepan Twardoch", 350, Db.BookGenre.Horror, new DateTime(2016, 12, 24)));

            Assert.AreEqual(6, service.GetBooksNumber());
        }

        [TestMethod]
        public void DbRepositoryAddBookListTest()
        {
            List<Db.Book> listOfBooks = new List<Db.Book>
            {
                new Db.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Db.BookGenre.Personal, new DateTime(2018, 6, 12)),
                new Db.Book(5, "Krolestwo", "Szczepan Twardoch", 380, Db.BookGenre.Horror, new DateTime(2017, 11, 20)),
                new Db.Book(6, "Krol", "Szczepan Twardoch", 350, Db.BookGenre.Horror, new DateTime(2016, 12, 24))
            };
            service.AddBook(listOfBooks);

            Assert.AreEqual(6, service.GetBooksNumber());
        }

        [TestMethod]
        public void DbRepositoryRemoveBookTest()
        {
            Assert.AreEqual(3, service.GetBooksNumber());

            service.RemoveBook(1);

            Assert.AreEqual(2, service.GetBooksNumber());
        }

        [TestMethod]
        public void DbRepositoryGetBookCatalogTest()
        {
            Assert.AreEqual(1, service.GetBook(1).Id);
            Assert.AreEqual("Maly Ksiaze", service.GetBook(1).Title);
            Assert.AreEqual("Saint-Exupery", service.GetBook(1).Author);
            Assert.AreEqual(120, service.GetBook(1).Pages);
            Assert.AreEqual(Db.BookGenre.Childrens, service.GetBook(1).Genre);
            Assert.AreEqual(date_1, service.GetBook(1).Date_of_publication);
        }

        [TestMethod]
        public void DbRepositoryEditBookTest()
        {
            service.EditBook(new Db.Book(1, "Duzy Krol", "Szczepan Twardoch", 350, Db.BookGenre.Horror, new DateTime(2016, 12, 24)));

            Assert.AreEqual(1, service.GetBook(1).Id);
            Assert.AreEqual("Duzy Krol", service.GetBook(1).Title);
            Assert.AreEqual("Szczepan Twardoch", service.GetBook(1).Author);
            Assert.AreEqual(350, service.GetBook(1).Pages);
            Assert.AreEqual(Db.BookGenre.Horror, service.GetBook(1).Genre);
            Assert.AreEqual(new DateTime(2016, 12, 24), service.GetBook(1).Date_of_publication);
        }

        [TestMethod]
        public void DbRepositoryCatalogTest()
        {
            IEnumerable<Book> catalog = service.GetBookCatalog();
            Assert.IsTrue(catalog.Contains(service.GetBook(1)));
        }

        [TestMethod]
        public void CheckAvaiabilityTest()
        {
            
            Assert.IsTrue(service.CheckAvaiability(new Db.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)));
          
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "check damage of non-existent book")]
        public void CheckIfDamagedTest()
        {
            service.CheckIfDamaged(new Db.Book(5, "Krolestwo", "Szczepan Twardoch", 380, Db.BookGenre.Horror, new DateTime(2017, 11, 20)));
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "report damage of null client for null book")]
        public void ReportDamagedTest()
        {
            service.ReportDamaged(null, null, date_1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "report rapaired of null client for null book")]
        public void ReportRepairedTest()
        {
            service.ReportRepaired(null, null, date_1);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "rent null book")]
        public void RentBookTest()
        {
            service.RentEvent(1, null, date_1, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException), "return null book")]
        public void ReturntBookTest()
        {
            service.ReturnEvent(1, null, date_1, null);
        }
    }
}