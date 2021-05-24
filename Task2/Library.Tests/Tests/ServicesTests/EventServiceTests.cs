using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Library.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.LogicTests
{
    [TestClass]
    public class EventsServiceTests
    {
        private readonly Eventservice service = new Eventservice(new LibraryDataContext());
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        [TestMethod]
        public void DbserviceAddEventsTest()
        {
            Assert.AreEqual(0, service.GetEventsNumber());

            service.AddEvents(1, 2, date_1, 6);
            service.AddEvents(5, 3, date_2, 54);

            Assert.AreEqual(2, service.GetEventsNumber());
        }

        [TestMethod]
        public void DbserviceRemoveEventsTest()
        {
            service.AddEvents(1, 2, date_1, 6);

            Assert.AreEqual(1, service.GetEventsNumber());

            service.RemoveEvents(1);

            Assert.AreEqual(0, service.GetEventsNumber());
        }

        [TestMethod]
        public void DbserviceGetEventsCatalogTest()
        {
            service.AddEvents(1, 2, date_1, 6);
            Assert.AreEqual(1, service.GetEvents(1).Id);
            Assert.AreEqual(1, service.GetEvents(1).Clients.Id);
            Assert.AreEqual("Bartlomiej", service.GetEvents(1).Clients.Name);
            Assert.AreEqual("Wlodarski", service.GetEvents(1).Clients.Surname);
            Assert.AreEqual(20, service.GetEvents(1).Clients.Age);
            Assert.AreEqual(date_1, service.GetEvents(1).Date);
        }

        [TestMethod]
        public void DbserviceEditEventsTest()
        {
            service.AddEvents(1, 2, date_1, 6);
            service.EditEvents(1, 4, date_3, 4);

            Assert.AreEqual(1, service.GetEvents(1).Id);
            Assert.AreEqual(1, service.GetEvents(1).Clients.Id);
            Assert.AreEqual("Bartosz", service.GetEvents(1).Clients.Name);
            Assert.AreEqual("Wlodarczyk", service.GetEvents(1).Clients.Surname);
            Assert.AreEqual(25, service.GetEvents(1).Clients.Age);
            Assert.AreEqual(date_2, service.GetEvents(1).Date);
        }
        /*
        [TestMethod]
        public void DbserviceRentEventsTest()
        {
            service.AddBooks(new Books(6, "Michal Ksiaze", "Saint-Exupery", 120, BooksGenre.Childrens, date_1));
            service.AddClients(new Clients(6, "Bartosz", "Wlodarski", 20));
            service.RentEvents(1, new Clients(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Books(6, "Michal Ksiaze", "Saint-Exupery", 120, BooksGenre.Childrens, date_1));

            Assert.IsFalse(service.CheckAvaiability(new Books(6, "Michal Ksiaze", "Saint-Exupery", 120, BooksGenre.Childrens, date_1)));
        }

        [TestMethod]
        public void DbserviceReturnEventsTest()
        {
            service.AddBooks(new Books(6, "Michal Ksiaze", "Saint-Exupery", 120, BooksGenre.Childrens, date_1));
            service.AddClients(new Clients(6, "Bartosz", "Wlodarski", 20));
            service.RentEvents(1, new Clients(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Books(6, "Michal Ksiaze", "Saint-Exupery", 120, BooksGenre.Childrens, date_1));

            Assert.IsFalse(service.CheckAvaiability(new Books(6, "Michal Ksiaze", "Saint-Exupery", 120, BooksGenre.Childrens, date_1)));

            service.ReturnEvents(1, new Clients(6, "Bartosz", "Wlodarski", 20), new DateTime(2018, 10, 20), new Books(6, "Michal Ksiaze", "Saint-Exupery", 120, BooksGenre.Childrens, date_1));

            Assert.IsTrue(service.CheckAvaiability(new Books(6, "Michal Ksiaze", "Saint-Exupery", 120, BooksGenre.Childrens, date_1)));
        }*/

        [TestMethod]
        public void DbserviceCatalogTest()
        {
            service.AddEvents(1, 2, date_1, 6);
            IEnumerable<Events> catalog = service.GetEventsCatalog();
            Assert.AreEqual(catalog.FirstOrDefault(x => x.Id == 1), service.GetEvents(1));
        }
    }
}