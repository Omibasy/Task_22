using System;
using System.Windows.Input;

namespace Wpf_Task_22.Controller
{
    internal class Command : ICommand
    {
        public Action<object> execute { get; }
        public Func<object, bool> canExecute { get; }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            canExecute.Invoke(parameter);

            return true;
        }

        public void Execute(object parameter)
        {
            execute.Invoke(parameter);
        }

        public Command(Action<object> executeAction) : this(executeAction, null)
        { }

        public Command(Action<object> executeAction, Func<object, bool> canExecute)
        {
            this.execute = executeAction;
            this.canExecute = canExecute;
        }
    }
}
