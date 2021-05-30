using Library.GUI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests.Tests.VmTests
{
    [TestClass]
    public class MainVmTests
    {
        [TestMethod]
        public void BooksListViewType()
        {
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.UpdateViewCommand.Execute("Books");
            Assert.AreEqual(mainViewModel.SelectedViewModel.GetType(), typeof(BookListViewModel));
        }

        [TestMethod]
        public void MainViewType()
        {
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.UpdateViewCommand.Execute("Main");
            Assert.AreEqual(mainViewModel.SelectedViewModel.GetType(), typeof(MainViewModel));
        }

        [TestMethod]
        public void ListViewType()
        {
            MainViewModel mainViewModel = new MainViewModel();
            mainViewModel.UpdateViewCommand.Execute("Clients");
            Assert.AreEqual(mainViewModel.SelectedViewModel.GetType(), typeof(ClientListViewModel));
        }
    }
}
