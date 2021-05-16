using Db;
using Library.Logic.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Library.GUI.Commands;
using Library.UI.ViewModels;

namespace Library.GUI.ViewModels
{
    public class BookListViewModel : BaseViewModel, IDataErrorInfo
    {
        private bool CanAdd => !(string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Author));

        public BookListViewModel()
        {
            Task.Run(() => { Books = new ObservableCollection<Book>(_bookService.GetBookCatalog()); });
            //AddCommand = new RelayCommand(Add, () => CanAdd);
            //DeleteCommand = new RelayCommand(Delete, CanExecute);
            ///EditCommand = new RelayCommand(Edit, CanExecute);
        }

        private bool CanExecute()
        {
            return SelectedBook != null;
        }

        #region private

        private Book _selectedBook;
        private BookService _bookService = new BookService(new DbContext());
        private ObservableCollection<Book> _books;
        private string _title;
        private string _author;

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
        /*
        public BookGenre genre
        {
            get => _BookGenre;
            set
            {
                _genre = value;
                RaisePropertyChanged(nameof(BookGenre));
            }
        }
        
        #endregion

        #region commands

        public void Delete()
        {
            Task.Factory.StartNew(() => _bookService.DeleteBook(SelectedBook.Id))
                .ContinueWith(t1 => BookService = _bookService);

            RaisePropertyChanged(nameof(Books));
        }

        public void AddBook()
        {
            var book = new Book
            {
                Id = id;
                Title = title;
                Author = author;
                Pages = pages;
                Genre = genre;
                Date_of_publication = date_of_publication;
        };

            Task.Factory.StartNew(() => _bookService.AddBook(book))
                .ContinueWith(t1 => BookService = _bookService);

            RaisePropertyChanged(nameof(Books));
        }

        public void Edit()
        {
            var book = new Book
            {
                Id = _id;
                Title = Title;
                Author = Author;
                Pages = Pages;
                BookGenre = BookGenre;
                Date_of_publication = Date_of_publication;
    };

            Task.Factory.StartNew(() => _bookService.EditBook(book))
                .ContinueWith(t1 => BookService = _bookService);

            RaisePropertyChanged(nameof(Books));
        }
        */
        #endregion
    }
}