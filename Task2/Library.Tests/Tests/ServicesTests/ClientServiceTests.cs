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
    public class ClientServiceTests
    {
        private ClientService service;

        [TestInitialize]
        public void Initialize()
        {
            service = new ClientService(new LibraryContext());

            service.AddClient(new Data.Client(1, "Bartlomiej", "Wlodarski", 20));
            service.AddClient(new Data.Client(2, "Maciej", "Wlodarczyk", 21));
            service.AddClient(new Data.Client(3, "Jan", "Kowalski", 40));
        }
        [TestMethod]
        public void DataserviceAddClientTest()
        {
            Assert.AreEqual(3, service.GetClientsNumber());

            service.AddClient(new Data.Client(4, "Mateusz", "Owczarek", 22));
            service.AddClient(new Data.Client(5, "Maciej", "Kopa", 16));
            service.AddClient(new Data.Client(6, "Monika", "Roksa", 23));

            Assert.AreEqual(6, service.GetClientsNumber());
        }

        [TestMethod]
        public void DataserviceRemoveClientTest()
        {
            Assert.AreEqual(3, service.GetClientsNumber());

            service.RemoveClient(1);

            Assert.AreEqual(2, service.GetClientsNumber());
        }

        [TestMethod]
        public void DataserviceGetClientTest()
        {
            service.AddClient(new Data.Client(4, "Marek", "Mostowiak", 45));

            Assert.AreEqual(4, service.GetClient(4).Id);
            Assert.AreEqual("Marek", service.GetClient(4).Name);
            Assert.AreEqual("Mostowiak", service.GetClient(4).Surname);
            Assert.AreEqual(45, service.GetClient(4).Age);

        }

        [TestMethod]
        public void DataserviceGetClientCatalogTest()
        {
            Assert.AreEqual(1, service.GetClient(1).Id);
            Assert.AreEqual("Bartlomiej", service.GetClient(1).Name);
            Assert.AreEqual("Wlodarski", service.GetClient(1).Surname);
            Assert.AreEqual(20, service.GetClient(1).Age);

        }

        [TestMethod]
        public void DataserviceEditClientTest()
        {
            service.EditClient(new Data.Client(1, "Bartlomiej", "Wlodarczyk", 21));

            Assert.AreEqual(1, service.GetClient(1).Id);
            Assert.AreEqual("Bartlomiej", service.GetClient(1).Name);
            Assert.AreEqual("Wlodarczyk", service.GetClient(1).Surname);
            Assert.AreEqual(21, service.GetClient(1).Age);
        }

        [TestMethod]
        public void DataserviceCatalogTest()
        {
            IEnumerable<Client> catalog = service.GetClientCatalog();
            Assert.AreEqual(catalog.FirstOrDefault(x => x.Id == 1), service.GetClient(1));
        }
    }
}