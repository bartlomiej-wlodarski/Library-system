using System;
using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Logic;
using Library.Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.LogicTests
{
    [TestClass]
    public class BookServiceTests
    {
        private BookService service;
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        [TestInitialize]
        public void Initialize()
        {
            service = new BookService(new LibraryContext());

            service.AddBook(new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));
            service.AddBook(new Data.Book(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling", 667, Data.BookGenre.Fantasy, date_2));
            service.AddBook(new Data.Book(3, "Chrobot", "Tomasz Michniewicz", 320, Data.BookGenre.Personal, date_3));
        }


        [TestMethod]
        public void DataRepositoryAddBookTest()
        {
            Assert.AreEqual(3, service.GetBooksNumber());

            service.AddBook(new Data.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)));
            service.AddBook(new Data.Book(5, "Krolestwo", "Szczepan Twardoch", 380, Data.BookGenre.Horror, new DateTime(2017, 11, 20)));
            service.AddBook(new Data.Book(6, "Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24)));

            Assert.AreEqual(6, service.GetBooksNumber());
        }

        [TestMethod]
        public void DataRepositoryAddBookListTest()
        {
            List<Data.Book> listOfBooks = new List<Data.Book>
            {
                new Data.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)),
                new Data.Book(5, "Krolestwo", "Szczepan Twardoch", 380, Data.BookGenre.Horror, new DateTime(2017, 11, 20)),
                new Data.Book(6, "Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24))
            };
            service.AddBook(listOfBooks);

            Assert.AreEqual(6, service.GetBooksNumber());
        }

        [TestMethod]
        public void DataRepositoryRemoveBookTest()
        {
            Assert.AreEqual(3, service.GetBooksNumber());

            service.RemoveBook(1);

            Assert.AreEqual(2, service.GetBooksNumber());
        }

        [TestMethod]
        public void DataRepositoryGetBookTest()
        {
            service.AddBook(new Data.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)));

            Assert.AreEqual(4, service.GetBook(4).Id);
            Assert.AreEqual("Nie ma", service.GetBook(4).Title);
            Assert.AreEqual("Mariusz Szczygiel", service.GetBook(4).Author);
            Assert.AreEqual(332, service.GetBook(4).Pages);
            Assert.AreEqual(Data.BookGenre.Personal, service.GetBook(4).Genre);
            Assert.AreEqual(new DateTime(2018, 6, 12), service.GetBook(4).Date_of_publication);
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
}