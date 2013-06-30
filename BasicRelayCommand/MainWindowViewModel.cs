using System.ComponentModel;
using MvvmCommands.Annotations;

namespace MvvmCommands
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int _counter;

        public MainWindowViewModel()
        {
            IncrementCommand = new RelayCommand(() => Counter++, () => _counter < 10);
            DecrementCommand = new RelayCommand(() => Counter--, () => _counter > -5);
        }

        public IRelayCommand IncrementCommand { get; private set; }
        public IRelayCommand DecrementCommand { get; private set; }

        public int Counter
        {
            get { return _counter; }
            set
            {
                _counter = value;
                OnPropertyChanged("Counter");
                IncrementCommand.RaiseCanExecuteChanged();
                DecrementCommand.RaiseCanExecuteChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}