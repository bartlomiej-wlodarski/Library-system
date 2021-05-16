using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Library.Data;
using Library.GUI.ViewModels;
using Db;
using Library.Logic;
using Library.Logic.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Library.Tests.Tests.VmTests
{
    public class ClientListVmTests
    {
        private readonly ClientService service;
        private readonly Mock<DbSet<Client>> mockClient;
        private readonly Mock<Db.DbContext> mockLibrary;
        private readonly IQueryable<Client> clients;

        public ClientListVmTests()
        {
            _userListViewModel = new UserListViewModel
            {
                clients = new List<Client>
                {
                    new Db.Client(1, "Bartlomiej", "Wlodarski", 20),
                    new Db.Client(2, "Maciej", "Wlodarczyk", 21),
                    new Db.Client(3, "Jan", "Kowalski", 40)
                }.AsQueryable();
        }
        }

        private readonly UserListViewModel _userListViewModel;
        private bool canBeExecuted = true;

        [TestClass]
        public void DeleteCmdShouldBeExecuted()
        {
            //Arrange
            _userListViewModel.SelectedUser = _userListViewModel.Users[0];
            var deleteCommand = _userListViewModel.DeleteCommand;

            //Act
            if (_userListViewModel.SelectedUser != null)
                canBeExecuted = true;

            //Assert
            Assert.True(deleteCommand.CanExecute(canBeExecuted));
        }
    }
