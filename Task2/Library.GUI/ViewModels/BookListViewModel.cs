using Db;
using Library.Logic.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Library.GUI.Commands;
using System;

namespace Library.GUI.ViewModels
{
    public class BookListViewModel : BaseViewModel, IDataErrorInfo
    {
        private bool CanAdd => !(string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Author));

        public BookListViewModel()
        {
            Task.Run(() => { Books = new ObservableCollection<Book>(_bookService.GetBookCatalog()); });
            AddCommand = new RelayCommand(Add, () => CanAdd);
            DeleteCommand = new RelayCommand(Delete, CanExecute);
            EditCommand = new RelayCommand(Edit, CanExecute);
        }

        private bool CanExecute()
        {
            return SelectedBook != null;
        }

        #region private

        private Book _selectedBook;
        private BookService _bookService = new BookService();
        private ObservableCollection<Book> _books;
        private string _title;
        private string _author;
        private int _id;
        private int pages;
        private DateTime date_of_publication;

        #endregion

        #region properties

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public Dictionary<string, string> ErrorCollection { get; } = new Dictionary<string, string>();

        #endregion

        #region errors

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case "Title":
                        if (string.IsNullOrWhiteSpace(Title)) result = "Title cannot be empty";
                        break;
                    case "Author":
                        if (string.IsNullOrWhiteSpace(Author)) result = "Author cannot be empty";
                        break;
                }

                if (ErrorCollection.ContainsKey(columnName))
                    ErrorCollection[columnName] = result;
                else if (result != null) ErrorCollection.Add(columnName, result);

                RaisePropertyChanged(nameof(ErrorCollection));
                return result;
            }
        }

        #endregion

        #region implementedProperties

        public ObservableCollection<Book> Books
        {
            get => _books;
            set
            {
                _books = value;
                RaisePropertyChanged(nameof(Books));
            }
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                RaisePropertyChanged(nameof(SelectedBook));
                DeleteCommand.RaiseCanExecuteChanged();
                EditCommand.RaiseCanExecuteChanged();
            }
        }

        public BookService Service
        {
            get => _bookService;
            set
            {
                _bookService = value;
                Books = new ObservableCollection<Book>(value.GetBookCatalog());
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged(nameof(Title));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                RaisePropertyChanged(nameof(Author));
                AddCommand.RaiseCanExecuteChanged();
            }
        }
        
        public BookGenre genre
        {
            get => genre;
            set
            {
                genre = value;
                RaisePropertyChanged(nameof(BookGenre));
            }
        }
        
        #endregion

        #region commands

        public void Delete()
        {
            Task.Factory.StartNew(() => _bookService.RemoveBook(SelectedBook.Id))
                .ContinueWith(t1 => _bookService);

            RaisePropertyChanged(nameof(Books));
        }

        public void Add()
        {
            Book book = new Db.Book(_id, Title, Author, pages, Db.BookGenre.Childrens, date_of_publication);

            Task.Factory.StartNew(() => _bookService.AddBook(book))
                .ContinueWith(t1 => _bookService);

            RaisePropertyChanged(nameof(Books));
        }

        public void Edit()
        {
            Book book = new Db.Book(_id, Title, Author, pages, Db.BookGenre.Childrens, date_of_publication);

            Task.Factory.StartNew(() => _bookService.EditBook(book))
                .ContinueWith(t1 =>  _bookService);

            RaisePropertyChanged(nameof(Books));
        }
        
        #endregion
    }
}