using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Library.GUI.Commands;
using Library.UI.ViewModels;

namespace Library.GUI.ViewModels
{
    public class MainViewModel : BaseViewModel

    {
        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }

        public MainViewModel()
        {
            UpdateViewCommand = new UpdateMainViewCommand(this);
        }
    }
}
