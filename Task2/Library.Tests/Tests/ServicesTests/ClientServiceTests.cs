using System.Collections.Generic;
using System.Linq;
using Library.Data;
using Library.Logic.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.LogicTests
{
    [TestClass]
    public class ClientsServiceTests
    {
        private readonly ClientService service = new ClientService(new LibraryDataContext());
        /*private readonly Mock<DbSet<Clients>> mockClients;
        private readonly Mock<DbContext> mockLibrary;
        private readonly IQueryable<Clients> Clientss;

        public ClientsServiceTests()
        {
            Clientss = new List<Clients>
            {
                new Clients(1, "Bartlomiej", "Wlodarski", 20),
                new Clients(2, "Maciej", "Wlodarczyk", 21),
                new Clients(3, "Jan", "Kowalski", 40)
            }.AsQueryable();

            mockClients = new Mock<DbSet<Clients>>();
            mockClients.As<IQueryable<Clients>>().Setup(m => m.Provider).Returns(Clientss.Provider);
            mockClients.As<IQueryable<Clients>>().Setup(m => m.Expression).Returns(Clientss.Expression);
            mockClients.As<IQueryable<Clients>>().Setup(m => m.ElementType).Returns(Clientss.ElementType);
            mockClients.As<IQueryable<Clients>>().Setup(m => m.GetEnumerator()).Returns(Clientss.GetEnumerator());
            mockLibrary = new Mock<DbContext>();
            mockLibrary.Setup(x => x.Set<Clients>()).Returns(mockClients.Object);

            service = new ClientsService(mockLibrary.Object);
        }*/

        [TestMethod]
        public void DbserviceAddClientsTest()
        {
            Assert.AreEqual(0, service.GetClientsNumber());

            service.AddClient(4, "Mateusz", "Owczarek", 22);
            service.AddClient(5, "Maciej", "Kopa", 16);
            service.AddClient(6, "Monika", "Roksa", 23);

            Assert.AreEqual(3, service.GetClientsNumber());
        }

        [TestMethod]
        public void DbserviceRemoveClientsTest()
        {
            service.AddClient(4, "Mateusz", "Owczarek", 22);

            Assert.AreEqual(1, service.GetClientsNumber());

            service.RemoveClient(4);

            Assert.AreEqual(0, service.GetClientsNumber());
        }

        [TestMethod]
        public void DbserviceGetClientsCatalogTest()
        {
            service.AddClient(1, "Bartlomiej", "Wlodarski", 20);

            Assert.AreEqual(1, service.GetClient(1).Id);
            Assert.AreEqual("Bartlomiej", service.GetClient(1).Name);
            Assert.AreEqual("Wlodarski", service.GetClient(1).Surname);
            Assert.AreEqual(20, service.GetClient(1).Age);

        }

        [TestMethod]
        public void DbserviceEditClientsTest()
        {
            service.AddClient(1, "Bartlomiej", "Wlodarski", 20);
            service.EditClient(1, "Bartlomiej", "Wlodarczyk", 21);

            Assert.AreEqual(1, service.GetClient(1).Id);
            Assert.AreEqual("Bartlomiej", service.GetClient(1).Name);
            Assert.AreEqual("Wlodarczyk", service.GetClient(1).Surname);
            Assert.AreEqual(21, service.GetClient(1).Age);
        }

        [TestMethod]
        public void DbserviceCatalogTest()
        {
            service.AddClient(1, "Bartlomiej", "Wlodarski", 20);
            IEnumerable<Clients> catalog = service.GetClients();
            Assert.AreEqual(catalog.FirstOrDefault(x => x.Id == 1), service.GetClient(1));
        }
    }
}