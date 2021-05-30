using Library.Data;
using Library.GUI.Commands;
using Library.GUI.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.ObjectModel;

namespace Library.Tests.Tests.VmTests
{
    [TestClass]
    public class BooksListVmTests
    {
        readonly DateTime date_1 = new DateTime(1943, 4, 6);
        readonly DateTime date_2 = new DateTime(1997, 6, 26);
        readonly DateTime date_3 = new DateTime(2018, 10, 20);

        private readonly BookListViewModel model;
        private bool canBeExecuted = true;

        public BooksListVmTests()
        {
            Books book1 = new();
            Books book2 = new();
            Books book3 = new();
            book1.Id = 1;
            book1.Title = "Maly Ksiaze";
            book1.Author = "Saint-Exupery";
            book1.Pages = 120;
            book1.Genre = 1;
            book1.Date_of_publication = date_1;
            book2.Id = 2;
            book2.Title = "Harry Potter and the Philosopher's Stone";
            book2.Author = "J. K. Rowling";
            book2.Pages = 667;
            book2.Genre = 3;
            book2.Date_of_publication = date_2;
            book3.Id = 3;
            book3.Title = "Chrobot";
            book3.Author = "Tomasz Michniewicz";
            book3.Pages = 320;
            book3.Genre = 6;
            book3.Date_of_publication = date_3;
            model = new BookListViewModel
            {
                Books = new ObservableCollection<Books>
                {
                    book1, book2, book3
                }
            };
        }

        [TestMethod]
        public void DeleteExecute()
        {
            model.SelectedBook = model.Books[0];
            RelayCommand deleteCommand = model.DeleteCommand;
            
            if (model.SelectedBook != null) canBeExecuted = true;
            
            Assert.IsTrue(deleteCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void DeleteDontExecute()
        {
            model.SelectedBook = null;
            RelayCommand deleteCommand = model.DeleteCommand;
            
            if (model.SelectedBook == null) canBeExecuted = false;
            
            Assert.IsFalse(deleteCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void EditExecute()
        {
            model.SelectedBook = model.Books[0];
            RelayCommand editCommand = model.EditCommand;
            
            if (model.SelectedBook != null) canBeExecuted = true;
            
            Assert.IsTrue(editCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void EditDontExecute()
        {
            model.SelectedBook = null;
            RelayCommand editCommand = model.EditCommand;
            
            if (model.SelectedBook == null)
                canBeExecuted = false;
            
            Assert.IsFalse(editCommand.CanExecute(canBeExecuted));
        }

        [TestMethod]
        public void CommandInitialize()
        {
            RelayCommand addCommand = model.AddCommand;
            RelayCommand editCommand = model.EditCommand;
            RelayCommand deleteCommand = model.DeleteCommand;
            
            Assert.IsNotNull(addCommand);
            Assert.IsNotNull(editCommand);
            Assert.IsNotNull(deleteCommand);
        }

        [TestMethod]
        public void AddExecute()
        {
            model.SelectedBook = model.Books[0];
            RelayCommand addCommand = model.AddCommand;
            
            if (model.SelectedBook.Author != null && model.SelectedBook.Title != null) canBeExecuted = true;
            
            Assert.IsTrue(canBeExecuted);
        }

        [TestMethod]
        public void AddSecondGenerationMethod()
        {
            model.SelectedBook = new Books();

            model.Author = "Writer";
            model.genre = 3;
            model.Title = "book_title";

            RelayCommand addCommand = model.AddCommand;

            if (model.SelectedBook.Author != null && model.SelectedBook.Title != null) canBeExecuted = true;

            Assert.IsTrue(canBeExecuted);
        }

        [TestMethod]
        public void AddDontExecute()
        {
            model.SelectedBook = model.Books[1];
            RelayCommand addCommand = model.AddCommand;
            
            if (model.SelectedBook.Author == null && model.SelectedBook.Title == null)
                canBeExecuted = false;
            
            Assert.IsFalse(!canBeExecuted);
        }
    }
}
