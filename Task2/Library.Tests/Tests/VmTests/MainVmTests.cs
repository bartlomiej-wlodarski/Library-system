using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.GUI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.Tests.Tests.VmTests
{
    [TestClass]
    public class MainVmTests
    {
        public void ShouldBeInitializedWithBookListView()
        {
            //Arrange
            var mainViewModel = new MainViewModel();

            //Act
            mainViewModel.UpdateViewCommand.Execute("Books");

            //Assert
            Assert.IsType<BookListViewModel>(mainViewModel.SelectedViewModel);
        }
    }
}
