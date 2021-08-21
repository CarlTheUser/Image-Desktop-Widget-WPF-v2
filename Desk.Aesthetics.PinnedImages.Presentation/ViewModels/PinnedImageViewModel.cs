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

        private PinnedImage _pinnedImage;

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

        public ICommand ResizeCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand HideCommand { get; }
        public ICommand ConfigureCommand { get; }
        public ICommand ShowHomeCommand { get; }

        public PinnedImageViewModel(
            PinnedImage pinnedImage, 
            IPinnedImageAppService pinnedImageAppService, 
            IViewLauncher mainWindowLauncher)
        {
            Image = pinnedImage;

            _pinnedImageAppService = pinnedImageAppService;

            _mainWindowLauncher = mainWindowLauncher;

            HideCommand = new RelayCommand(() => PinnedImageDisplayHost?.Close());
        }
    }
}
