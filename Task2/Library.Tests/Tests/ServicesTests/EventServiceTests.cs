using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

/*namespace Library.LogicTests
{
    [TestClass]
    public class EventerviceTests
    {
        private readonly Eventervice service;
        private readonly Mock<DbSet<Event>> mockEvent;
        private readonly Mock<LibraryContext> mockLibrary;
        private readonly IQueryable<Event> Event;
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        public EventerviceTests()
        {
            Event = new List<Event>
            {
                new Data.RentEvent(1, new Data.Client(1, "Bartlomiej", "Wlodarski", 20), date_1, new Data.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)),
                new Data.RentEvent(2, new Data.Client(2, "Maciej", "Wlodarczyk", 21), date_2, new Data.Book(2, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)),
                new Data.ReturnEvent(3, new Data.Client(3, "Jan", "Kowalski", 40), date_3, new Data.Book(3, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1))
            }.AsQueryable();

            mockEvent = new Mock<DbSet<Event>>();
            mockEvent.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(Event.Provider);
            mockEvent.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(Event.Expression);
            mockEvent.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(Event.ElementType);
            mockEvent.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(Event.GetEnumerator());
            mockLibrary = new Mock<LibraryContext>();
            mockLibrary.Setup(x => x.Set<Event>()).Returns(mockEvent.Object);

            service = new Eventervice(mockLibrary.Object);
        }

        [TestMethod]
        public void DataserviceAddEventTest()
        {
            Assert.AreEqual(3, service.GetEventNumber());

            service.AddEvent(new Data.RentEvent(4, new Data.Client(4, "Monika", "Roksa", 23), date_1, new Data.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
            service.AddEvent(new Data.RentEvent(5, new Data.Client(5, "Anna", "Przystanska", 34), date_3, new Data.Book(5, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));

            mockLibrary.Verify(x => x.SaveChanges(), Times.Exactly(2));
        }

        [TestMethod]
        public void DataserviceRemoveEventTest()
        {
            Assert.AreEqual(3, service.GetEventNumber());

            service.RemoveEvent(1);

            mockLibrary.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DataserviceGetEventCatalogTest()
        {
            Assert.AreEqual(1, service.GetEvent(1).Id);
            Assert.AreEqual(1, service.GetEvent(1).Client.Id);
            Assert.AreEqual("Bartlomiej", service.GetEvent(1).Client.Name);
            Assert.AreEqual("Wlodarski", service.GetEvent(1).Client.Surname);
            Assert.AreEqual(20, service.GetEvent(1).Client.Age);
            Assert.AreEqual(date_1, service.GetEvent(1).Date);
        }

        [TestMethod]
        public void DataserviceEditEventTest()
        {
            service.EditEvent(new Data.RentEvent(1, new Data.Client(1, "Bartosz", "Wlodarczyk", 25), date_2, new Data.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));

            Assert.AreEqual(1, service.GetEvent(1).Id);
            Assert.AreEqual(1, service.GetEvent(1).Client.Id);
            Assert.AreEqual("Bartosz", service.GetEvent(1).Client.Name);
            Assert.AreEqual("Wlodarczyk", service.GetEvent(1).Client.Surname);
            Assert.AreEqual(25, service.GetEvent(1).Client.Age);
            Assert.AreEqual(date_2, service.GetEvent(1).Date);

            service.EditEvent(new Data.DamagedEvent(2, new Data.Client(2, "Marco", "Murinho", 37), date_1, new Data.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));

            Assert.AreEqual(2, service.GetEvent(2).Id);
            Assert.AreEqual(2, service.GetEvent(2).Client.Id);
            Assert.AreEqual("Marco", service.GetEvent(2).Client.Name);
            Assert.AreEqual("Murinho", service.GetEvent(2).Client.Surname);
            Assert.AreEqual(37, service.GetEvent(2).Client.Age);
            Assert.AreEqual(date_1, service.GetEvent(2).Date);
        }



        /*[TestMethod]
        public void DataserviceRentEventTest()
        {
            service.AddBook(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));
            service.AddClient(new Data.Client(6, "Bartosz", "Wlodarski", 20));
            service.RentEvent(1, new Data.Client(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));

            Assert.IsFalse(service.CheckAvaiability(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
        }

        [TestMethod]
        public void DataserviceReturnEventTest()
        {
            service.AddBook(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));
            service.AddClient(new Data.Client(6, "Bartosz", "Wlodarski", 20));
            service.RentEvent(1, new Data.Client(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));

            Assert.IsFalse(service.CheckAvaiability(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));

            service.ReturnEvent(1, new Data.Client(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1));

            Assert.IsTrue(service.CheckAvaiability(new Data.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Data.BookGenre.Childrens, date_1)));
        }

        [TestMethod]
        public void DataserviceCatalogTest()
        {
            IEnumerable<Event> catalog = service.GetEventCatalog();
            Assert.AreEqual(catalog.FirstOrDefault(x => x.Id == 1), service.GetEvent(1));
        }
    }
}*/