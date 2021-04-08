using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class BookTest
    {
        private Data.DataContext context;
        private Data.IDataService repository;
        DateTime date_1 = new DateTime(1943, 4, 6);
        DateTime date_2 = new DateTime(1997, 6, 26);
        DateTime date_3 = new DateTime(2018, 10, 20);

        [TestInitialize]
        public void Initialize()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);

            repository.AddBook(new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));
            repository.AddBook(new Data.Book(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling",  667, Data.BookGenre.Fantasy, date_2));
            repository.AddBook(new Data.Book(3, "Chrobot", "Tomasz Michniewicz", 320, Data.BookGenre.Personal, date_3));
        }

        
        [TestMethod]
        public void DataRepositoryAddMovieTest()
        {
            Assert.AreEqual(3, repository.GetBooksNumber());

            repository.AddBook(new Data.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)));
            repository.AddBook(new Data.Book(5, "Krolestwo", "Szczepan Twardoch", 380, Data.BookGenre.Horror, new DateTime(2017, 11, 20)));
            repository.AddBook(new Data.Book(6, "Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24)));

            Assert.AreEqual(6, repository.GetBooksNumber());
        }

        [TestMethod]
        public void DataRepositoryRemoveMovieTest()
        {
            Assert.AreEqual(3, repository.GetBooksNumber());

            repository.RemoveBook(1);

            Assert.AreEqual(2, repository.GetBooksNumber());
        }

        [TestMethod]
        public void DataRepositoryGetBookTest()
        {
            repository.AddBook(new Data.Book(4, "Nie ma", "Mariusz Szczygiel", 332, Data.BookGenre.Personal, new DateTime(2018, 6, 12)));

            Assert.AreEqual(4, repository.GetBook(4).Id);
            Assert.AreEqual("Nie ma", repository.GetBook(4).Title);
            Assert.AreEqual("Mariusz Szczygiel", repository.GetBook(4).Author);
            Assert.AreEqual(332, repository.GetBook(4).Pages);
            Assert.AreEqual(Data.BookGenre.Personal, repository.GetBook(4).Genre);
            Assert.AreEqual(new DateTime(2018, 6, 12), repository.GetBook(4).Date_of_publication);
        }

        [TestMethod]
        public void DataRepositoryGetBookCatalogTest()
        {
            Dictionary<int, Data.Book> catalog = repository.GetBookCatalog();

            Assert.AreEqual(1, repository.GetBook(1).Id);
            Assert.AreEqual("Maly Ksiaze", repository.GetBook(1).Title);
            Assert.AreEqual("Saint-Exupery", repository.GetBook(1).Author);
            Assert.AreEqual(120, repository.GetBook(1).Pages);
            Assert.AreEqual(Data.BookGenre.Childrens, repository.GetBook(1).Genre);
            Assert.AreEqual(date_1, repository.GetBook(1).Date_of_publication);
        }

        [TestMethod]
        public void DataRepositoryEditBookTest()
        {
            repository.EditBook(new Data.Book(1, "Duzy Krol", "Szczepan Twardoch", 350, Data.BookGenre.Horror, new DateTime(2016, 12, 24)));

            Assert.AreEqual(1, repository.GetBook(1).Id);
            Assert.AreEqual("Duzy Krol", repository.GetBook(1).Title);
            Assert.AreEqual("Szczepan Twardoch", repository.GetBook(1).Author);
            Assert.AreEqual(350, repository.GetBook(1).Pages);
            Assert.AreEqual(Data.BookGenre.Horror, repository.GetBook(1).Genre);
            Assert.AreEqual(new DateTime(2016, 12, 24), repository.GetBook(1).Date_of_publication);
        }
    }
}
