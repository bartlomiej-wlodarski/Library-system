using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Library.Logic;
using Library.Data;

namespace Tests
{
    [TestClass]
    public class StateTest
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
            repository.AddBook(new Book(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling", 667, BookGenre.Fantasy, date_2));
            repository.AddBook(new Book(3, "Chrobot", "Tomasz Michniewicz", 320, BookGenre.Personal, date_3));
        }


        [TestMethod]
        public void DataRepositoryCheckAvailabilityTest()
        {
            repository.AddBook(new Book(4, "Michal Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1));

            Assert.IsTrue(repository.CheckAvaiability(new Book(4, "Michal Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1)));
        }

        [TestMethod]
        public void DataRepositoryCheckIfDamagedTest()
        {
            repository.AddBook(new Book(5, "Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1));
            repository.ReportDamaged(new Book(5, "Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1), new Client(1, "Bartlomiej", "Wlodarski", 20), new DateTime(2018, 10, 20));

            Assert.IsTrue(repository.CheckIfDamaged(new Book(5, "Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1)));
        }

        [TestMethod]
        public void DataRepositoryCheckIfRepairdTest()
        {
            repository.AddBook(new Book(5, "Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1));
            repository.ReportDamaged(new Book(5, "Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1), new Client(1, "Bartlomiej", "Wlodarski", 20), new DateTime(2018, 10, 20));
            Assert.IsTrue(repository.CheckIfDamaged(new Book(5, "Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1)));
            repository.ReportRepaired(new Book(5, "Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1), new Client(1, "Bartlomiej", "Wlodarski", 20), new DateTime(2018, 10, 20));

            Assert.IsTrue(repository.CheckAvaiability(new Book(5, "Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1)));
        }
    }
}
