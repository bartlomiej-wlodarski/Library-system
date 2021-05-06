using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Library.Data;
using Library.Logic;

namespace Tests
{
    [TestClass]
    public class BookTest
    {
        private DataContext context;
        private IDataService repository;
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        [TestInitialize]
        public void Initialize()
        {
            context = new DataContext();
            repository = new DataRepository(context);

            repository.AddBook(new Book(1, "Maly Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1));
            repository.AddBook(new Book(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling",  667, BookGenre.Fantasy, date_2));
            repository.AddBook(new Book(3, "Chrobot", "Tomasz Michniewicz", 320, BookGenre.Personal, date_3));
        }

        
        [TestMethod]
        public void DataRepositoryAddBookTest()
        {
            Assert.AreEqual(3, repository.GetBooksNumber());

            repository.AddBook(new Book(4, "Nie ma", "Mariusz Szczygiel", 332, BookGenre.Personal, new DateTime(2018, 6, 12)));
            repository.AddBook(new Book(5, "Krolestwo", "Szczepan Twardoch", 380, BookGenre.Horror, new DateTime(2017, 11, 20)));
            repository.AddBook(new Book(6, "Krol", "Szczepan Twardoch", 350, BookGenre.Horror, new DateTime(2016, 12, 24)));

            Assert.AreEqual(6, repository.GetBooksNumber());
        }

        [TestMethod]
        public void DataRepositoryAddBookListTest()
        {
            List<Book> listOfBooks = new List<Book>
            {
                new Book(4, "Nie ma", "Mariusz Szczygiel", 332, BookGenre.Personal, new DateTime(2018, 6, 12)),
                new Book(5, "Krolestwo", "Szczepan Twardoch", 380, BookGenre.Horror, new DateTime(2017, 11, 20)),
                new Book(6, "Krol", "Szczepan Twardoch", 350, BookGenre.Horror, new DateTime(2016, 12, 24))
            };
            repository.AddBook(listOfBooks);

            Assert.AreEqual(6, repository.GetBooksNumber());
        }

        [TestMethod]
        public void DataRepositoryRemoveBookTest()
        {
            Assert.AreEqual(3, repository.GetBooksNumber());

            repository.RemoveBook(1);

            Assert.AreEqual(2, repository.GetBooksNumber());
        }

        [TestMethod]
        public void DataRepositoryGetBookTest()
        {
            repository.AddBook(new Book(4, "Nie ma", "Mariusz Szczygiel", 332, BookGenre.Personal, new DateTime(2018, 6, 12)));

            Assert.AreEqual(4, repository.GetBook(4).Id);
            Assert.AreEqual("Nie ma", repository.GetBook(4).Title);
            Assert.AreEqual("Mariusz Szczygiel", repository.GetBook(4).Author);
            Assert.AreEqual(332, repository.GetBook(4).Pages);
            Assert.AreEqual(BookGenre.Personal, repository.GetBook(4).Genre);
            Assert.AreEqual(new DateTime(2018, 6, 12), repository.GetBook(4).Date_of_publication);
        }

        [TestMethod]
        public void DataRepositoryGetBookCatalogTest()
        {
            Assert.AreEqual(1, repository.GetBook(1).Id);
            Assert.AreEqual("Maly Ksiaze", repository.GetBook(1).Title);
            Assert.AreEqual("Saint-Exupery", repository.GetBook(1).Author);
            Assert.AreEqual(120, repository.GetBook(1).Pages);
            Assert.AreEqual(BookGenre.Childrens, repository.GetBook(1).Genre);
            Assert.AreEqual(date_1, repository.GetBook(1).Date_of_publication);
        }

        [TestMethod]
        public void DataRepositoryEditBookTest()
        {
            repository.EditBook(new Book(1, "Duzy Krol", "Szczepan Twardoch", 350, BookGenre.Horror, new DateTime(2016, 12, 24)));

            Assert.AreEqual(1, repository.GetBook(1).Id);
            Assert.AreEqual("Duzy Krol", repository.GetBook(1).Title);
            Assert.AreEqual("Szczepan Twardoch", repository.GetBook(1).Author);
            Assert.AreEqual(350, repository.GetBook(1).Pages);
            Assert.AreEqual(BookGenre.Horror, repository.GetBook(1).Genre);
            Assert.AreEqual(new DateTime(2016, 12, 24), repository.GetBook(1).Date_of_publication);
        }

        [TestMethod]
        public void DataRepositoryCatalogTest()
        {
            Dictionary<int, Book> catalog = repository.GetBookCatalog();
            Assert.IsTrue(catalog.ContainsValue(repository.GetBook(1)));
        }
    }
}
