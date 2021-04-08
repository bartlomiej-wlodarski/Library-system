using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class ClientTest
    {
        private Data.DataContext context;
        private Data.IDataService repository;

        [TestInitialize]
        public void Initialize()
        {
            context = new Data.DataContext();
            repository = new Data.DataRepository(context);

            repository.AddClient(new Data.Client(1, "Bartlomiej", "Wlodarski", 20));
            repository.AddClient(new Data.Client(2, "Maciej", "Wlodarczyk", 21));
            repository.AddClient(new Data.Client(3, "Jan", "Kowalski", 40));
        }
        [TestMethod]
        public void DataRepositoryAddClientTest()
        {
            Assert.AreEqual(3, repository.GetClientsNumber());

            repository.AddClient(new Data.Client(4, "Mateusz", "Owczarek", 22));
            repository.AddClient(new Data.Client(5, "Maciej", "Kopa", 16));
            repository.AddClient(new Data.Client(6, "Monika", "Roksa", 23));

            Assert.AreEqual(6, repository.GetClientsNumber());
        }

        [TestMethod]
        public void DataRepositoryRemoveClientTest()
        {
            Assert.AreEqual(3, repository.GetClientsNumber());

            repository.RemoveClient(1);

            Assert.AreEqual(2, repository.GetClientsNumber());
        }
        
        [TestMethod]
        public void DataRepositoryGetClientTest()
        {
            repository.AddClient(new Data.Client(4, "Marek", "Mostowiak", 45));

            Assert.AreEqual(4, repository.GetClient(4).Id);
            Assert.AreEqual("Marek", repository.GetClient(4).Name);
            Assert.AreEqual("Mostowiak", repository.GetClient(4).Surname);
            Assert.AreEqual(45, repository.GetClient(4).Age);

        }

        [TestMethod]
        public void DataRepositoryGetClientCatalogTest()
        {
            Dictionary<int, Data.Client> catalog = repository.GetClientCatalog();

            Assert.AreEqual(1, repository.GetClient(1).Id);
            Assert.AreEqual("Bartlomiej", repository.GetClient(1).Name);
            Assert.AreEqual("Wlodarski", repository.GetClient(1).Surname);
            Assert.AreEqual(20, repository.GetClient(1).Age);

        }

        [TestMethod]
        public void DataRepositoryEditClientTest()
        {
            repository.EditClient(new Data.Client(1, "Bartlomiej", "Wlodarczyk", 21));

            Assert.AreEqual(1, repository.GetClient(1).Id);
            Assert.AreEqual("Bartlomiej", repository.GetClient(1).Name);
            Assert.AreEqual("Wlodarczyk", repository.GetClient(1).Surname);
            Assert.AreEqual(21, repository.GetClient(1).Age);
        }
    }
}
