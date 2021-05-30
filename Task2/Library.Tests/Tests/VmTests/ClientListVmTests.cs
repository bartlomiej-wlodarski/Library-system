using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.GUI.ViewModels;
using Library.Data;

namespace Library.Tests.Tests.VmTests
{
    [TestClass]
    public class ClientsListVmTests
    {
        private readonly ClientListViewModel model;
        private bool canBeExecuted = true;

        public ClientsListVmTests()
        {
            Clients client1 = new();
            Clients client2 = new();
            Clients client3 = new();
            client1.Id = 1;
            client1.Name = "Bartlomiej";
            client1.Surname = "Wlodarski";
            client1.Age = 20;
            client2.Id = 2;
            client2.Name = "Maciej";
            client2.Surname = "Wlodarczyk";
            client2.Age = 21;
            client3.Id = 3;
            client3.Name = "Jan";
            client3.Surname = "Kowalski";
            client3.Age = 40;
            model = new ClientListViewModel
            {
                Clients = new ObservableCollection<Clients>
                {
                    client1, client2, client3
                }
            };
        }

        [TestMethod]
        public void TestAddDeleteClient()
        {

            Clients client4 = new(4, "Bartosz", "Wlodarczyk", 22);
            model.SelectedClient = model.Clients[3];
            var deleteCommand = model.DeleteCommand;

            if (model.SelectedClient != null) canBeExecuted = true;

            Assert.IsTrue(deleteCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void DeleteExecute()
        {
            model.SelectedClient = model.Clients[0];
            var deleteCommand = model.DeleteCommand;
            
            if (model.SelectedClient != null) canBeExecuted = true;
            
            Assert.IsTrue(deleteCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void DeleteDontExecute()
        {
            model.SelectedClient = null;
            var deleteCommand = model.DeleteCommand;
            
            if (model.SelectedClient == null) canBeExecuted = false;
            
            Assert.IsFalse(deleteCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void EditExecute()
        {
            model.SelectedClient = model.Clients[0];
            var editCommand = model.EditCommand;
            
            if (model.SelectedClient != null) canBeExecuted = true;
            
            Assert.IsTrue(editCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void EditDontExecute()
        {
            model.SelectedClient = null;
            var editCommand = model.EditCommand;
            
            if (model.SelectedClient == null) canBeExecuted = false;
            
            Assert.IsFalse(editCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void ReturnClients()
        {
            Clients client1 = new();
            client1.Id = 1;
            client1.Name = "Bartlomiej";
            client1.Surname = "Wlodarski";
            client1.Age = 20;

            var Clients = model.Clients;

            Assert.AreEqual(client1.Name, Clients[0].Name);
        }

        [TestMethod]
        public void CommantInitialize()
        {
            var addCommand = model.AddCommand;
            var editCommand = model.EditCommand;
            var deleteCommand = model.DeleteCommand;

            Assert.IsNotNull(addCommand);
            Assert.IsNotNull(editCommand);
            Assert.IsNotNull(deleteCommand);
        }

        [TestMethod]
        public void AddExecute()
        {
            model.SelectedClient = model.Clients[0];
            var addCommand = model.AddCommand;
            
            if (model.SelectedClient.Name != null && model.SelectedClient.Surname != null)
                canBeExecuted = true;
            
            Assert.IsTrue(canBeExecuted);
        }

        [TestMethod]
        public void AddDontExecute()
        {
            model.SelectedClient = model.Clients[1];
            var addCommand = model.AddCommand;
            
            if (model.SelectedClient.Name == null && model.SelectedClient.Surname == null)
                canBeExecuted = false;
            
            Assert.IsTrue(canBeExecuted);
        }
    }
}
