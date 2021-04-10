using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class EventTest
    {
        private Data.DataContext context;
        private Data.IDataService repository;
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        [TestInitialize]
        public void Initialize()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);

            repository.AddEvent(new Data.RentEvent(1, new Data.Client(1, "Bartlomiej", "Wlodarski", 20), date_1, new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
            repository.AddEvent(new Data.RentEvent(2, new Data.Client(2, "Maciej", "Wlodarczyk", 21), date_2, new Data.Book(2, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
            repository.AddEvent(new Data.ReturnEvent(3, new Data.Client(3, "Jan", "Kowalski", 40), date_3, new Data.Book(3, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
        }

        [TestMethod]
        public void DataRepositoryAddEventTest()
        {
            Assert.AreEqual(3, repository.GetEventsNumber());

            repository.AddEvent(new Data.RentEvent(4, new Data.Client(4, "Monika", "Roksa", 23), date_1, new Data.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
            repository.AddEvent(new Data.RentEvent(5, new Data.Client(5, "Anna", "Przystanska", 34), date_3, new Data.Book(5, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));

            Assert.AreEqual(5, repository.GetEventsNumber());
        }

        [TestMethod]
        public void DataRepositoryRemoveEventTest()
        {
            Assert.AreEqual(3, repository.GetEventsNumber());

            repository.RemoveEvent(1);

            Assert.AreEqual(2, repository.GetEventsNumber());
        }

        [TestMethod]
        public void DataRepositoryGetEventCatalogTest()
        {
            List<Data.Event> catalog = repository.GetEventCatalog();

            Assert.AreEqual(1, repository.GetEvent(1).Id);
            Assert.AreEqual(1, repository.GetEvent(1).Client.Id);
            Assert.AreEqual("Bartlomiej", repository.GetEvent(1).Client.Name);
            Assert.AreEqual("Wlodarski", repository.GetEvent(1).Client.Surname);
            Assert.AreEqual(20, repository.GetEvent(1).Client.Age);
            //Assert.AreEqual(repository.GetState().Books, repository.GetEvent(1).State.Books);
            //Assert.AreEqual(repository.GetState().BooksInStock, repository.GetEvent(1).State.BooksInStock);
            Assert.AreEqual(date_1, repository.GetEvent(1).Date);
        }

        [TestMethod]
        public void DataRepositoryEditEventTest()
        {
            repository.EditEvent(new Data.RentEvent(1, new Data.Client(1, "Bartosz", "Wlodarczyk", 25), date_2, new Data.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));

            Assert.AreEqual(1, repository.GetEvent(1).Id);
            Assert.AreEqual(1, repository.GetEvent(1).Client.Id);
            Assert.AreEqual("Bartosz", repository.GetEvent(1).Client.Name);
            Assert.AreEqual("Wlodarczyk", repository.GetEvent(1).Client.Surname);
            Assert.AreEqual(25, repository.GetEvent(1).Client.Age);
            //Assert.AreEqual(repository.GetState().Books, repository.GetEvent(1).State.Books);
            //Assert.AreEqual(repository.GetState().BooksInStock, repository.GetEvent(1).State.BooksInStock);
            Assert.AreEqual(date_2, repository.GetEvent(1).Date);

            repository.EditEvent(new Data.RentEvent(2, new Data.Client(2, "Marco", "Murinho", 37), date_1, new Data.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
         
            Assert.AreEqual(2, repository.GetEvent(2).Id);
            Assert.AreEqual(2, repository.GetEvent(2).Client.Id);
            Assert.AreEqual("Marco", repository.GetEvent(2).Client.Name);
            Assert.AreEqual("Murinho", repository.GetEvent(2).Client.Surname);
            Assert.AreEqual(37, repository.GetEvent(2).Client.Age);
            //Assert.AreEqual(repository.GetState().Books, repository.GetEvent(2).State.Books);
            //Assert.AreEqual(repository.GetState().BooksInStock, repository.GetEvent(2).State.BooksInStock);
            Assert.AreEqual(date_1, repository.GetEvent(2).Date);
        }

    }
}
