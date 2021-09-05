using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.Commands;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.ViewModels
{
    public class PinnedImageViewModel : ViewModelBase
    {
        private readonly IPinnedImageAppService _pinnedImageAppService;

        private readonly IViewLauncher _mainWindowLauncher;

        private readonly IViewLauncher<PinnedImageSettingsViewLauncherParameter> _settingsViewLauncher;

        private PinnedImage _pinnedImage;

        private bool _isDeleted = false;

        public IPinnedImageDisplayHost PinnedImageDisplayHost { get; set; }

        public PinnedImage Image
        {
            get => _pinnedImage;
            set
            {
                _pinnedImage = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public ICommand DeleteCommand { get; }
        public ICommand HideCommand { get; }
        public ICommand ConfigureCommand { get; }
        public ICommand ShowHomeCommand { get; }

        public PinnedImageViewModel(
            PinnedImage pinnedImage, 
            IPinnedImageAppService pinnedImageAppService, 
            IViewLauncher mainWindowLauncher,
            IViewLauncher<PinnedImageSettingsViewLauncherParameter> settingsViewLauncher)
        {
            Image = pinnedImage;

            _pinnedImageAppService = pinnedImageAppService;

            _mainWindowLauncher = mainWindowLauncher;

            _settingsViewLauncher = settingsViewLauncher;

            DeleteCommand = new RelayCommand(Delete);

            HideCommand = new RelayCommand(() => PinnedImageDisplayHost?.Close());

            ConfigureCommand = new RelayCommand(() => _settingsViewLauncher.Launch(new PinnedImageSettingsViewLauncherParameter(Image, _pinnedImageAppService)));

            ShowHomeCommand = new RelayCommand(() => _mainWindowLauncher.Launch());
        }

        private void Delete()
        {
            _pinnedImageAppService.DeletePinnedImage(Image.Id);
            _isDeleted = true;
            PinnedImageDisplayHost?.Close();
        }

        public void SaveFrameLocationAndDimension()
        {
            if (!_isDeleted)
            {
                _pinnedImageAppService.SaveCurrentDisplayHostParameters(Image);
            }
        }
    }
}
