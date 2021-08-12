using System;
using System.Windows;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.Commands
{
    public class MaximizeRestoreWindowCommand : ICommand
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
            if (typeof(Window).IsAssignableFrom(parameter.GetType()))
            {
                Window window = (Window) parameter;
                switch (window.WindowState)
                {
                    case WindowState.Maximized: window.WindowState = WindowState.Normal;
                        break;
                    case WindowState.Normal: window.WindowState = WindowState.Maximized;
                        break;
                }
            }
        }
    }
}
