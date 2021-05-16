using System;
using System.Collections.Generic;
using System.Linq;
using Db;
using Library.Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Library.LogicTests
{
    [TestClass]
    public class EventServiceTests
    {
        private readonly EventService service;
        private readonly Mock<DbSet<Event>> mockEvent;
        private readonly Mock<Db.DbContext> mockLibrary;
        private readonly IQueryable<Event> events;
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        public EventServiceTests()
        {
            events = new List<Event>
            {
                new Db.RentEvent(1, new Db.Client(1, "Bartlomiej", "Wlodarski", 20), date_1, new Db.Book(1, "Maly Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)),
                new Db.RentEvent(2, new Db.Client(2, "Maciej", "Wlodarczyk", 21), date_2, new Db.Book(2, "Maly Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)),
                new Db.ReturnEvent(3, new Db.Client(3, "Jan", "Kowalski", 40), date_3, new Db.Book(3, "Maly Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1))
            }.AsQueryable();

            mockEvent = new Mock<DbSet<Event>>();
            mockEvent.As<IQueryable<Event>>().Setup(m => m.Provider).Returns(events.Provider);
            mockEvent.As<IQueryable<Event>>().Setup(m => m.Expression).Returns(events.Expression);
            mockEvent.As<IQueryable<Event>>().Setup(m => m.ElementType).Returns(events.ElementType);
            mockEvent.As<IQueryable<Event>>().Setup(m => m.GetEnumerator()).Returns(events.GetEnumerator());
            mockLibrary = new Mock<Db.DbContext>();
            mockLibrary.Setup(x => x.Set<Event>()).Returns(mockEvent.Object);

            service = new EventService(mockLibrary.Object);
        }

        [TestMethod]
        public void DbserviceAddEventTest()
        {
            Assert.AreEqual(3, service.GetEventsNumber());

            service.AddEvent(new Db.RentEvent(4, new Db.Client(4, "Monika", "Roksa", 23), date_1, new Db.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)));
            service.AddEvent(new Db.RentEvent(5, new Db.Client(5, "Anna", "Przystanska", 34), date_3, new Db.Book(5, "Maly Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)));

            mockLibrary.Verify(x => x.SaveChanges(), Times.Exactly(2));
        }

        [TestMethod]
        public void DbserviceRemoveEventTest()
        {
            Assert.AreEqual(3, service.GetEventsNumber());

            service.RemoveEvent(1);

            mockLibrary.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DbserviceGetEventCatalogTest()
        {
            Assert.AreEqual(1, service.GetEvent(1).Id);
            Assert.AreEqual(1, service.GetEvent(1).Client.Id);
            Assert.AreEqual("Bartlomiej", service.GetEvent(1).Client.Name);
            Assert.AreEqual("Wlodarski", service.GetEvent(1).Client.Surname);
            Assert.AreEqual(20, service.GetEvent(1).Client.Age);
            Assert.AreEqual(date_1, service.GetEvent(1).Date);
        }

        [TestMethod]
        public void DbserviceEditEventTest()
        {
            service.EditEvent(new Db.RentEvent(1, new Db.Client(1, "Bartosz", "Wlodarczyk", 25), date_2, new Db.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)));

            Assert.AreEqual(1, service.GetEvent(1).Id);
            Assert.AreEqual(1, service.GetEvent(1).Client.Id);
            Assert.AreEqual("Bartosz", service.GetEvent(1).Client.Name);
            Assert.AreEqual("Wlodarczyk", service.GetEvent(1).Client.Surname);
            Assert.AreEqual(25, service.GetEvent(1).Client.Age);
            Assert.AreEqual(date_2, service.GetEvent(1).Date);

            service.EditEvent(new Db.DamagedEvent(2, new Db.Client(2, "Marco", "Murinho", 37), date_1, new Db.Book(4, "Maly Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)));

            Assert.AreEqual(2, service.GetEvent(2).Id);
            Assert.AreEqual(2, service.GetEvent(2).Client.Id);
            Assert.AreEqual("Marco", service.GetEvent(2).Client.Name);
            Assert.AreEqual("Murinho", service.GetEvent(2).Client.Surname);
            Assert.AreEqual(37, service.GetEvent(2).Client.Age);
            Assert.AreEqual(date_1, service.GetEvent(2).Date);
        }
        /*
        [TestMethod]
        public void DbserviceRentEventTest()
        {
            service.AddBook(new Db.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1));
            service.AddClient(new Db.Client(6, "Bartosz", "Wlodarski", 20));
            service.RentEvent(1, new Db.Client(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Db.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1));

            Assert.IsFalse(service.CheckAvaiability(new Db.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)));
        }

        [TestMethod]
        public void DbserviceReturnEventTest()
        {
            service.AddBook(new Db.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1));
            service.AddClient(new Db.Client(6, "Bartosz", "Wlodarski", 20));
            service.RentEvent(1, new Db.Client(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Db.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1));

            Assert.IsFalse(service.CheckAvaiability(new Db.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)));

            service.ReturnEvent(1, new Db.Client(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Db.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1));

            Assert.IsTrue(service.CheckAvaiability(new Db.Book(6, "Michal Ksiaze", "Saint-Exupery", 120, Db.BookGenre.Childrens, date_1)));
        }*/

        [TestMethod]
        public void DbserviceCatalogTest()
        {
            IEnumerable<Event> catalog = service.GetEventCatalog();
            Assert.AreEqual(catalog.FirstOrDefault(x => x.Id == 1), service.GetEvent(1));
        }
    }
}