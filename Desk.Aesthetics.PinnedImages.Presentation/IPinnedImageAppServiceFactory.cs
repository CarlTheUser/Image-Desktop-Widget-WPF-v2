using Desk.Aesthetics.PinnedImages.Core.Service;
using Desk.Aesthetics.PinnedImages.Infrastructure.Data.Core;
using Desk.Aesthetics.PinnedImages.Presentation.Application;
using System.Configuration;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public interface IPinnedImageAppServiceFactory
    {
        IPinnedImageAppService Create();
    }

    public class DefaultPinnedImageAppServiceFactory : IPinnedImageAppServiceFactory
    {
        private readonly string _connection;
        private readonly string _pinnedImageDirectory;

        public DefaultPinnedImageAppServiceFactory(string connection, string pinnedImageDirectory)
        {
            _connection = connection;
            _pinnedImageDirectory = pinnedImageDirectory;
        }

        public IPinnedImageAppService Create()
        {
            PinnedImageDataByIdQuery query = new PinnedImageDataByIdQuery(_connection);
            PinnedImageDataWriter dataWriter = new PinnedImageDataWriter(_connection);

            return new PinnedImageAppService(
                new ChangeAppearanceService(
                    query,
                    dataWriter),
                new UpdatePinnedImageHostDisplayParameters(
                    query,
                    dataWriter),
                new DeletePinnedImageService(
                    _pinnedImageDirectory,
                    query,
                    new PinnedImageDataDestoryer(_connection)));
        }
    }
}
