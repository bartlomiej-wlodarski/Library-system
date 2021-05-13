using Library.Data;
using Library.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Library.UI.ViewModels
{
    public class BookListViewModel : BaseViewModel, IDataErrorInfo
    {
        private bool CanAdd => !(string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Author));

        public BookListViewModel()
        {
            //Task.Run(() => { Book = new ObservableCollection<Book>(_Bookervice.GetBookCatalog()); });
            /*AddCommand = new RelayCommand(Add, () => CanAdd);
            DeleteCommand = new RelayCommand(Delete, CanExecute);
            EditCommand = new RelayCommand(Edit, CanExecute);*/
        }

        private bool CanExecute()
        {
            return SelectedBook != null;
        }

        #region private

        private Book _selectedBook;
        //private Bookervice _Bookervice = new Bookervice(new LibraryContext());
        private ObservableCollection<Book> _Book;
        private string _Title;
        private string _Author;

        #endregion

        #region properties

        //public RelayCommand DeleteCommand { get; set; }
        //public RelayCommand AddCommand { get; set; }
        //public RelayCommand EditCommand { get; set; }
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

        public ObservableCollection<Book> Book
        {
            get => _Book;
            set
            {
                _Book = value;
                RaisePropertyChanged(nameof(Book));
            }
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                _selectedBook = value;
                RaisePropertyChanged(nameof(SelectedBook));
                //DeleteCommand.RaiseCanExecuteChanged();
                //EditCommand.RaiseCanExecuteChanged();
            }
        }

        /*public Bookervice Service
        {
            get => _Bookervice;
            set
            {
                _Bookervice = value;
                Book = new ObservableCollection<Book>(value.GetBookCatalog());
            }
        }*/

        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                RaisePropertyChanged(nameof(Title));
                //AddCommand.RaiseCanExecuteChanged();
            }
        }

        public string Author
        {
            get => _Author;
            set
            {
                _Author = value;
                RaisePropertyChanged(nameof(Author));
                //AddCommand.RaiseCanExecuteChanged();
            }
        }

        /*public BookEnum BookGenre
        {
            get => _bookGenre;
            set
            {
                _bookGenre = value;
                RaisePropertyChanged(nameof(BookGenre));
            }
        }*/

        #endregion

        #region commands

        public void Delete()
        {
            /*Task.Factory.StartNew(() => _Bookervice.DeleteBook(SelectedBook.Id))
                .ContinueWith(t1 => Bookervice = _Bookervice);

            RaisePropertyChanged(nameof(Book));*/
        }

        public void Add()
        {
            /*var book = new Book
            {
                Title = Title,
                Author = Author,
                BookGenre = BookGenre
            };

            Task.Factory.StartNew(() => _Bookervice.AddBook(book))
                .ContinueWith(t1 => Bookervice = _Bookervice);

            RaisePropertyChanged(nameof(Book));*/
        }

        public void Edit()
        {
            /*var book = new Book
            {
                Id = SelectedBook.Id,
                Title = Title,
                Author = Author,
                BookGenre = BookGenre
            };

            Task.Factory.StartNew(() => _Bookervice.EditBook(book))
                .ContinueWith(t1 => Bookervice = _Bookervice);

            RaisePropertyChanged(nameof(Book));*/
        }

        #endregion
    }
}