using System;
using System.Threading.Tasks;

namespace Desk.Aesthetics.PinnedImages.Presentation.Commands
{
    public class AsyncRelayCommand : AsyncCommandBase
    {
        private readonly Action _relayedCommand;

        public AsyncRelayCommand(
             Action relayedCommand,
             Func<object, bool> isExecutable,
             Action<Exception> exceptionCallback) : base(isExecutable, exceptionCallback)
        {
            _relayedCommand = relayedCommand;
        }

        protected override Task ExecuteAsync(object parameter)
        {
            return Task.Run(() => _relayedCommand.Invoke());
        }
    }


}
