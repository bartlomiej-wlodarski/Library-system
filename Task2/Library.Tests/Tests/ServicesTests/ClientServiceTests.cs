﻿using System;
using System.Collections.Generic;
using System.Linq;
using Db;
using Library.Logic;
using Library.Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Library.LogicTests
{
    [TestClass]
    public class ClientServiceTests
    {
        private readonly ClientService service;
        private readonly Mock<DbSet<Client>> mockClient;
        private readonly Mock<Db.DbContext> mockLibrary;
        private readonly IQueryable<Client> clients;

        public ClientServiceTests()
        {
            clients = new List<Client>
            {
                new Db.Client(1, "Bartlomiej", "Wlodarski", 20),
                new Db.Client(2, "Maciej", "Wlodarczyk", 21),
                new Db.Client(3, "Jan", "Kowalski", 40)
            }.AsQueryable();

            mockClient = new Mock<DbSet<Client>>();
            mockClient.As<IQueryable<Client>>().Setup(m => m.Provider).Returns(clients.Provider);
            mockClient.As<IQueryable<Client>>().Setup(m => m.Expression).Returns(clients.Expression);
            mockClient.As<IQueryable<Client>>().Setup(m => m.ElementType).Returns(clients.ElementType);
            mockClient.As<IQueryable<Client>>().Setup(m => m.GetEnumerator()).Returns(clients.GetEnumerator());
            mockLibrary = new Mock<Db.DbContext>();
            mockLibrary.Setup(x => x.Set<Client>()).Returns(mockClient.Object);

            service = new ClientService(mockLibrary.Object);
        }

        [TestMethod]
        public void DbserviceAddClientTest()
        {
            Assert.AreEqual(3, service.GetClientsNumber());

            service.AddClient(new Db.Client(4, "Mateusz", "Owczarek", 22));
            service.AddClient(new Db.Client(5, "Maciej", "Kopa", 16));
            service.AddClient(new Db.Client(6, "Monika", "Roksa", 23));

            mockLibrary.Verify(x => x.SaveChanges(), Times.Exactly(3));
        }

        [TestMethod]
        public void DbserviceRemoveClientTest()
        {
            Assert.AreEqual(3, service.GetClientsNumber());

            service.RemoveClient(1);

            mockLibrary.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DbserviceGetClientCatalogTest()
        {
            Assert.AreEqual(1, service.GetClient(1).Id);
            Assert.AreEqual("Bartlomiej", service.GetClient(1).Name);
            Assert.AreEqual("Wlodarski", service.GetClient(1).Surname);
            Assert.AreEqual(20, service.GetClient(1).Age);

        }

        [TestMethod]
        public void DbserviceEditClientTest()
        {
            service.EditClient(new Db.Client(1, "Bartlomiej", "Wlodarczyk", 21));

            Assert.AreEqual(1, service.GetClient(1).Id);
            Assert.AreEqual("Bartlomiej", service.GetClient(1).Name);
            Assert.AreEqual("Wlodarczyk", service.GetClient(1).Surname);
            Assert.AreEqual(21, service.GetClient(1).Age);
        }

        [TestMethod]
        public void DbserviceCatalogTest()
        {
            IEnumerable<Client> catalog = service.GetClientCatalog();
            Assert.AreEqual(catalog.FirstOrDefault(x => x.Id == 1), service.GetClient(1));
        }
    }
}