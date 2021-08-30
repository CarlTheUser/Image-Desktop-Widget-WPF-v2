using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.Models;

namespace Desk.Aesthetics.PinnedImages.Presentation.ViewModels
{
    public class PinnedImageSettingsViewModel : ViewModelBase
    {
        private readonly IPinnedImageAppService _pinnedImageAppService;

        private PinnedImage _pinnedImage;
        public PinnedImage Image
        {
            get => _pinnedImage;
            set
            {
                _pinnedImage = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public PinnedImageSettingsViewModel(PinnedImage pinnedImage, IPinnedImageAppService pinnedImageAppService)
        {
            _pinnedImage = pinnedImage;
            _pinnedImageAppService = pinnedImageAppService;
        }

        public void ApplyChanges()
        {
            _pinnedImageAppService.ApplyAppearance(_pinnedImage);
        }
    }
}
