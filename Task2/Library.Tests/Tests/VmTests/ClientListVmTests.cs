using System.Collections.ObjectModel;
using Db;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Library.GUI.ViewModels;

namespace Library.Tests.Tests.VmTests
{
    [TestClass]
    public class ClientListVmTests
    {
        private readonly ClientListViewModel model;
        private bool canBeExecuted = true;

        public ClientListVmTests()
        {
            model = new ClientListViewModel
            {
                Clients = new ObservableCollection<Client>
                {
                    new Db.Client(1, "Bartlomiej", "Wlodarski", 20),
                    new Db.Client(2, "Maciej", "Wlodarczyk", 21),
                    new Db.Client(3, "Jan", "Kowalski", 40)
                }
            };
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
        public void ReturnClient()
        {
            Client client = new Db.Client(25, "Bartlomiej", "Wlodarski", 20);

            var Clients = model.Clients;

            Assert.AreEqual(client.Name, Clients[0].Name);
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
