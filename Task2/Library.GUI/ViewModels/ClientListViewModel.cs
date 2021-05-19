using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Library.Logic.Services;
using Library.GUI.Commands;
using Library.Data;

namespace Library.GUI.ViewModels
{
    public class ClientListViewModel : BaseViewModel, IDataErrorInfo
    {
        public bool CanAdd => !(string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Surname));


        public ClientListViewModel()
        {
            Task.Run(() => { Clients = new ObservableCollection<Clients>(_clientService.GetClients()); });
            AddCommand = new RelayCommand(Add, () => CanAdd);
            DeleteCommand = new RelayCommand(Delete, CanExecute);
            EditCommand = new RelayCommand(Edit, CanExecute);
        }

        public bool CanExecute()
        {
            return SelectedClient != null;
        }

        #region private

        private Clients _selectedClient;
        private ClientService _clientService = new ClientService(new LibraryDataContext());
        private ObservableCollection<Clients> _clients;
        private string _name;
        private string _surname;
        private int _age;
        private int _id;

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
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name)) result = "Name cannot be empty";
                        break;
                    case "Surname":
                        if (string.IsNullOrWhiteSpace(Surname)) result = "Surname cannot be empty";
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

        public ObservableCollection<Clients> Clients
        {
            get => _clients;
            set
            {
                _clients = value;
                RaisePropertyChanged(nameof(Clients));
            }
        }

        public Clients SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                RaisePropertyChanged(nameof(SelectedClient));
                DeleteCommand.RaiseCanExecuteChanged();
                EditCommand.RaiseCanExecuteChanged();
            }
        }

        public ClientService ClientService
        {
            get => _clientService;
            set
            {
                _clientService = value;
                Clients = new ObservableCollection<Clients>(value.GetClients());
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged(nameof(Name));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                RaisePropertyChanged(nameof(Surname));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

        #region commands

        public void Delete()
        {
            Task.Factory.StartNew(() => _clientService.RemoveClient(SelectedClient.Id))
                .ContinueWith(t1 => _clientService);

            RaisePropertyChanged(nameof(Clients));
        }

        public void Add()
        {Task.Factory.StartNew(() => _clientService.AddClient(_id, Name, Surname, _age))
                .ContinueWith(t1 =>  _clientService);

            RaisePropertyChanged(nameof(Clients));
        }

        public void Edit()
        {Task.Factory.StartNew(() => _clientService.EditClient(SelectedClient.Id, Name, Surname, _age))
                .ContinueWith(t1 => _clientService);

            RaisePropertyChanged(nameof(Clients));
        }

        #endregion
    }
}