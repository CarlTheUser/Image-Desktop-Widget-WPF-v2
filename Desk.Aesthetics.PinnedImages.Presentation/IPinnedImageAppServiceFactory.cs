using Desk.Aesthetics.PinnedImages.Core.Service;
using Desk.Aesthetics.PinnedImages.Infrastructure.Data.Core;
using Desk.Aesthetics.PinnedImages.Presentation.Application;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public interface IPinnedImageAppServiceFactory
    {
        IPinnedImageAppService Create();
    }

    public class DefaultPinnedImageAppServiceFactory : IPinnedImageAppServiceFactory
    {
        private readonly string _connection;

        public DefaultPinnedImageAppServiceFactory(string connection)
        {
            _connection = connection;
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
                    query,
                    new PinnedImageDataDestoryer(_connection)));
        }
    }
}
