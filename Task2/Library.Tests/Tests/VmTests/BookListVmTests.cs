using Db;
using Library.GUI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;

namespace Library.Tests.Tests.VmTests
{
    [TestClass]
    public class BookListVmTests
    {
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        private readonly BookListViewModel model;
        private bool canBeExecuted = true;

        public BookListVmTests()
        {
            model = new BookListViewModel
            {
                Books = new ObservableCollection<Book>
                {
                    new Book(1, "Maly Ksiaze", "Saint-Exupery", 120, BookGenre.Childrens, date_1),
                    new Book(2, "Harry Potter and the Philosopher's Stone", "J. K. Rowling", 667, BookGenre.Fantasy, date_2),
                    new Book(3, "Chrobot", "Tomasz Michniewicz", 320, BookGenre.Personal, date_3)
                }
            };
        }

        [TestMethod]
        public void DeleteExecute()
        {
            model.SelectedBook = model.Books[0];
            var deleteCommand = model.DeleteCommand;
            
            if (model.SelectedBook != null) canBeExecuted = true;
            
            Assert.IsTrue(deleteCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void DeleteDontExecute()
        {
            model.SelectedBook = null;
            var deleteCommand = model.DeleteCommand;
            
            if (model.SelectedBook == null) canBeExecuted = false;
            
            Assert.IsFalse(deleteCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void EditExecute()
        {
            model.SelectedBook = model.Books[0];
            var editCommand = model.EditCommand;
            
            if (model.SelectedBook != null) canBeExecuted = true;
            
            Assert.IsTrue(editCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void EditDontExecute()
        {
            model.SelectedBook = null;
            var editCommand = model.EditCommand;
            
            if (model.SelectedBook == null)
                canBeExecuted = false;
            
            Assert.IsFalse(editCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void ReturnClient()
        {
            Book book = new Book(7, "Chrobot", "Saint-Exupery", 320, BookGenre.Personal, date_3);
            
            var books = model.Books;
            
            Assert.AreEqual(book.Author, books[0].Author);
        }

        [TestMethod]
        public void CommandInitialize()
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
            model.SelectedBook = model.Books[0];
            var addCommand = model.AddCommand;
            
            if (model.SelectedBook.Author != null && model.SelectedBook.Title != null) canBeExecuted = true;
            
            Assert.IsTrue(canBeExecuted);
        }

        [TestMethod]
        public void AddDontExecute()
        {
            model.SelectedBook = model.Books[1];
            var addCommand = model.AddCommand;
            
            if (model.SelectedBook.Author == null && model.SelectedBook.Title == null)
                canBeExecuted = false;
            
            Assert.IsFalse(!canBeExecuted);
        }
    }
}
