using Desk.Aesthetics.PinnedImages.Core.Service;
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
            return new PinnedImageAppService(
                new ChangeAppearanceService(
                    null,
                    null),
                new UpdatePinnedImageHostDisplayParameters(
                    null,
                    null),
                new DeletePinnedImageService(
                    null,
                    null));
        }
    }
}
