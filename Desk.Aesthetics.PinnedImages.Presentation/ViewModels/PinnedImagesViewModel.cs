using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Core.Service;
using Desk.Aesthetics.PinnedImages.Data.Display;
using Desk.Aesthetics.PinnedImages.Infrastructure.Data.Core;
using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.Commands;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using Desk.Aesthetics.PinnedImages.Presentation.View.Misc;
using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Common;
using System.IO;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.ViewModels
{
    public class PinnedImagesViewModel : ViewModelBase
    {
        private readonly IPinnedImagesAppService _pinnedImagesAppService;

        private readonly IOneWayDataSource<PinnedImageListItemData> _pinnedImageListItemDataDataSource;

        private readonly IUserPrompt<string, OpenFileDialogPromptParameter> _openFileDialogPrompt;

        private readonly IViewLauncher<PinnedImageWindowViewLauncherParameter> _pinnedImageWindowViewLauncher;

        private readonly IViewLauncher _mainWindowViewLauncher;

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
            string connection = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;

            PinnedImageDataByIdQuery query = new PinnedImageDataByIdQuery(connection);
            PinnedImageDataWriter dataWriter = new PinnedImageDataWriter(connection);

            string pinnedImagesDirectory = ConfigurationManager.AppSettings["PinnedImages.Directory"];

            _pinnedImagesAppService = new PinnedImagesAppService(
                new PinNewImageService(
                    pinnedImagesDirectory,
                    ConfigurationManager.AppSettings["PinnedImages.OutputExtension"],
                    dataWriter),
                new SetDeskDisplayService(
                    query,
                    dataWriter),
                new DeletePinnedImageService(
                    pinnedImagesDirectory,
                    query,
                    new PinnedImageDataDestoryer(connection)));

            _mainWindowViewLauncher = new MainWindowViewLauncher();

            _pinnedImageWindowViewLauncher = new PinnedImageWindowViewLauncher(
                    new DefaultPinnedImageAppServiceFactory(connection, pinnedImagesDirectory));

            _openFileDialogPrompt = new OpenFileDialogPrompt();

            PinNewImageCommand = new RelayCommand(PinNewImmage);

            RemoveImageCommand = new AsyncParameterizedRelayCommand<PinnedImageListItem>(
                RemoveImage,
                null,
                (e) =>
                {

                });

            ToggleDisplayToDeskCommand = new AsyncParameterizedRelayCommand<PinnedImageListItem>(
                ToggleImageDisplay,
                null,
                (e) =>
                {

                });
        }

        private void PinNewImmage()
        {
            string filepath = _openFileDialogPrompt.Prompt(
                new OpenFileDialogPromptParameter("Select Image", "All supported graphics|*.jpg;*.jpeg;*.png|JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|Portable Network Graphic (*.png)|*.png"));

            if (!string.IsNullOrWhiteSpace(filepath))
            {
                _pinnedImageWindowViewLauncher.Launch(
                    new PinnedImageWindowViewLauncherParameter(
                        _pinnedImagesAppService.PinNewImageWithDefaults(filepath),
                        _mainWindowViewLauncher));
            }
        }

        private void RemoveImage(PinnedImageListItem image)
        {
            _pinnedImagesAppService.RemoveImage(image.Id);
        }

        private void ToggleImageDisplay(PinnedImageListItem image)
        {
            Guid id = image.Id;

            if (image.IsDisplayedToDesk)
            {
                _pinnedImagesAppService.HideFromDesk(id);
            }
            else
            {
                _pinnedImagesAppService.DisplayToDesk(id);
            }
        }
    }
}
