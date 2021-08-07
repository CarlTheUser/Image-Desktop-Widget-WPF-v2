using System;
using System.Windows;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.Commands
{
    public class CloseWindowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (typeof(Window).IsAssignableFrom(parameter.GetType())) (parameter as Window).Close();
        }
    }
}
