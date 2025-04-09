using System.Windows.Input;

namespace GameStoreManager.Client.Core
{
    public class RelayCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private Action<object> _executeAction { get; set; }

        private Predicate<object> _canExecutePredicate { get; set; }

        public RelayCommand(Action<object> exectue, Predicate<object> canExecute)
        {
            _executeAction = exectue;

            _canExecutePredicate = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecutePredicate(parameter);
        }

        public void Execute(object? parameter)
        {
            _executeAction(parameter);
        }
    }
}
