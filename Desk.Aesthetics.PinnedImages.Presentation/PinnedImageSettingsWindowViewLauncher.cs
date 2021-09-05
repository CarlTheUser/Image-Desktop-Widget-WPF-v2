using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using Desk.Aesthetics.PinnedImages.Presentation.ViewModels;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public class PinnedImageSettingsViewLauncherParameter
    {
        public PinnedImage Image { get; }
        public IPinnedImageAppService AppService { get; }

        public PinnedImageSettingsViewLauncherParameter(PinnedImage image, IPinnedImageAppService appService)
        {
            Image = image;
            AppService = appService;
        }
    }

    public class PinnedImageSettingsViewLauncher : IViewLauncher<PinnedImageSettingsViewLauncherParameter>
    {
        public void Launch(PinnedImageSettingsViewLauncherParameter parameter)
        {
            new PinnedImageSettingsWindow(
                new PinnedImageSettingsViewModel(
                    parameter.Image, 
                    parameter.AppService)).Show();
        }
    }
}
