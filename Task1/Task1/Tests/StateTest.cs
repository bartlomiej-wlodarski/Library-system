using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class StateTest
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
            repository.AddBook(new Data.Book(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling", 667, Data.BookGenre.Fantasy, date_2));
            repository.AddBook(new Data.Book(3, "Chrobot", "Tomasz Michniewicz", 320, Data.BookGenre.Personal, date_3));
        }

        [TestMethod]
        public void DataRepositoryCheckAvailabilityTest()
        {
            repository.CheckAvaiability(new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, new DateTime(2016, 12, 24)));

            Assert.AreEqual(1, repository.GetBook(1).Id);
        }
    }
}
