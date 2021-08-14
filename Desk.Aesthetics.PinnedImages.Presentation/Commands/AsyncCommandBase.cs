using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.Commands
{
    public abstract class AsyncCommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly Func<object, bool> _isExecutable;

        private readonly Action<Exception> _exceptionCallback;

        private bool _isExecuting = false;

        protected AsyncCommandBase(Func<object, bool> isExecutable, Action<Exception> exceptionCallback)
        {
            _isExecutable = isExecutable;
            _exceptionCallback = exceptionCallback;
        }

        public bool CanExecute(object parameter)
        {
            return !_isExecuting && (_isExecutable == null || _isExecutable.Invoke(parameter));
        }

        public async void Execute(object parameter)
        {
            try
            {
                _isExecuting = true;

                await ExecuteAsync(parameter);
            }
            catch (Exception ex)
            {
                _exceptionCallback?.Invoke(ex);
            }
            finally
            {
                _isExecuting = false;
            }
        }

        protected abstract Task ExecuteAsync(object parameter);
    }

}
