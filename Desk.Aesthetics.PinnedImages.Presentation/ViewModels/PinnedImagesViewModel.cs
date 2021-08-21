using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Data.Display;
using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.ViewModels
{
    public class PinnedImagesViewModel : ViewModelBase
    {
        private readonly IPinnedImagesAppService _pinnedImagesAppService;

        private readonly IOneWayDataSource<PinnedImageListItemData> _pinnedImageListItemDataDataSource;

        private ObservableCollection<PinnedImageListItem> _pinnedImageListItems;

        public ObservableCollection<PinnedImageListItem> PinnedImageListItems
        {
            get => _pinnedImageListItems;
            set
            {
                _pinnedImageListItems = value;
                OnPropertyChanged(nameof(PinnedImageListItems));
            }
        }

        public ICommand PinNewImageCommand { get; }
        public ICommand RemoveImageCommand { get; }
        public ICommand ToggleDisplayToDeskCommand { get; }

        public PinnedImagesViewModel()
        {

        }
    }
}
