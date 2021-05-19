﻿using Library.GUI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests.Tests.VmTests
{
    [TestClass]
    public class MainVmTests
    {
        [TestMethod]
        public void BooksListViewType()
        {
            var mainViewModel = new MainViewModel();
            mainViewModel.UpdateViewCommand.Execute("Bookss");
            Assert.AreEqual(mainViewModel.SelectedViewModel.GetType(), typeof(BookListViewModel));
        }

        [TestMethod]
        public void MainViewType()
        {
            var mainViewModel = new MainViewModel();
            mainViewModel.UpdateViewCommand.Execute("Main");
            Assert.AreEqual(mainViewModel.SelectedViewModel.GetType(), typeof(MainViewModel));
        }

        [TestMethod]
        public void ListViewType()
        {
            var mainViewModel = new MainViewModel();
            mainViewModel.UpdateViewCommand.Execute("Clientss");
            Assert.AreEqual(mainViewModel.SelectedViewModel.GetType(), typeof(ClientListViewModel));
        }
    }
}
