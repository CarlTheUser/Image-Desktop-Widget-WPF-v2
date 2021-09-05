using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using Desk.Aesthetics.PinnedImages.Presentation.ViewModels;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public class PinnedImageWindowViewLauncherParameter
    {
        public PinnedImage Image{ get; }
        public IViewLauncher MainWindowViewLauncher { get; }

        public PinnedImageWindowViewLauncherParameter(PinnedImage image, IViewLauncher mainWindowViewLauncher)
        {
            Image = image;
            MainWindowViewLauncher = mainWindowViewLauncher;
        }
    }

    public class PinnedImageWindowViewLauncher : IViewLauncher<PinnedImageWindowViewLauncherParameter>
    {
        private readonly IPinnedImageAppServiceFactory _pinnedImageAppServiceFactory;

        public PinnedImageWindowViewLauncher(IPinnedImageAppServiceFactory pinnedImageAppServiceFactory)
        {
            _pinnedImageAppServiceFactory = pinnedImageAppServiceFactory;
        }

        public void Launch(PinnedImageWindowViewLauncherParameter parameter)
        {
            new PinnedImageWindow(
                new PinnedImageViewModel(
                    parameter.Image,
                    _pinnedImageAppServiceFactory.Create(),
                    parameter.MainWindowViewLauncher,
                    new PinnedImageSettingsViewLauncher())).Show();
        }
    }
}
