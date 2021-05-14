using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Library.GUI.ViewModels;
using Library.UI.ViewModels;

namespace Library.GUI.Commands
{
    public class UpdateMainViewCommand : ICommand
    {
        private readonly MainViewModel _viewModel;

        public UpdateMainViewCommand(MainViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /*if (parameter.ToString() == "Clients")
                _viewModel.SelectedViewModel = new ClientListViewModel();
            else if (parameter.ToString() == "Books")
                _viewModel.SelectedViewModel = new BookListViewModel();
            else
                _viewModel.SelectedViewModel = new MainViewModel();*/

        }

    }
}
