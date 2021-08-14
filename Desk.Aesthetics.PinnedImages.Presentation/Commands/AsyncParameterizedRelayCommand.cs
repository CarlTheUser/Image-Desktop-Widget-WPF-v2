using System;
using System.Threading.Tasks;

namespace Desk.Aesthetics.PinnedImages.Presentation.Commands
{
    public class AsyncParameterizedRelayCommand<TParameter> : AsyncCommandBase
    {
        private readonly Action<TParameter> _relayedCommand;

        public AsyncParameterizedRelayCommand(
             Action<TParameter> relayedCommand,
             Func<object, bool> isExecutable,
             Action<Exception> exceptionCallback) : base(isExecutable, exceptionCallback)
        {
            _relayedCommand = relayedCommand ?? throw new ArgumentNullException(nameof(relayedCommand));
        }

        protected override Task ExecuteAsync(object parameter)
        {
            return Task.Run(() => _relayedCommand.Invoke((TParameter)parameter));
        }
    }


}
