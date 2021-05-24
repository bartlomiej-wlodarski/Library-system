using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.GUI.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Func<bool> _targetCanExecuteMethod;
        private readonly Action _targetExecuteMethod;

        public RelayCommand(Action executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod != null) return _targetCanExecuteMethod();

            return _targetExecuteMethod != null;
        }

        public void Execute(object parameter)
        {
            _targetExecuteMethod();
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}