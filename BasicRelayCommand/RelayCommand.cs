using System;
using System.Windows.Input;

namespace MvvmCommands
{
    public interface IRelayCommand
    {
        void Execute(object parameter);
        bool CanExecute(object parameter);
        event EventHandler CanExecuteChanged;
        void RaiseCanExecuteChanged();
    }

    class RelayCommand : IRelayCommand, ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;
    
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null) 
                handler(this, EventArgs.Empty);
        }
    }
}