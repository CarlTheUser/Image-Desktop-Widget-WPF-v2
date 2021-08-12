using System;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.Commands
{
    public class ParameterizedRelayCommand<TParameter> : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        readonly Action<TParameter> Command;

        readonly Predicate<TParameter> IsExecutable;

        public ParameterizedRelayCommand(Action<TParameter> commandAction) : this(commandAction, null) { }

        public ParameterizedRelayCommand(Action<TParameter> commandAction, Predicate<TParameter> isExecutable)
        {
            if (commandAction == null) throw new ArgumentNullException(nameof(commandAction));

            Command = commandAction;
            IsExecutable = isExecutable;
        }

        public bool CanExecute(object parameter)
        {
            return IsExecutable == null || IsExecutable.Invoke((TParameter)parameter);
        }

        public void Execute(object parameter)
        {
            Command.Invoke((TParameter)parameter);
        }
    }
}
