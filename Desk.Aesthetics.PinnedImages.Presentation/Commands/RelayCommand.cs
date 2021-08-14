using System;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.Commands
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        readonly Action Command;

        readonly Func<bool> IsExecutable;

        public RelayCommand(Action commandAction) : this(commandAction, null) { }

        public RelayCommand(Action commandAction, Func<bool> isExecutable)
        {
            if (commandAction == null) throw new ArgumentNullException(nameof(commandAction));

            Command = commandAction;
            IsExecutable = isExecutable;
        }

        public bool CanExecute(object parameter)
        {
            return IsExecutable == null || IsExecutable.Invoke();
        }

        public void Execute(object parameter)
        {
            Command.Invoke();
        }
    }
}
