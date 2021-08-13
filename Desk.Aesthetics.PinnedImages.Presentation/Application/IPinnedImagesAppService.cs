using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Core.Data;
using Desk.Aesthetics.PinnedImages.Core.Service;
using Desk.Aesthetics.PinnedImages.Data.Display;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using System;
using System.Collections.Generic;

namespace Desk.Aesthetics.PinnedImages.Presentation.Application
{
    public interface IPinnedImagesAppService
    {
        IEnumerable<PinnedImageListItem> Query(RecordQueryOptions options);

        PinnedImage PinNewImageWithDefaults(string filepath);

        void HideFromDesk(Guid pinnedImage);

        void DisplayToDesk(Guid pinnedImage);
    }

    public class PinnedImagesAppService : IPinnedImagesAppService
    {
        //private readonly IQuery<IEnumerable<PinnedImageListItemData>, RecordQueryOptions>> _

        private readonly PagedDataSource<PinnedImageListItemData> _pinnedImageListItemDataDataSource;

        private readonly IPinNewImageService _pinNewImageService;

        private readonly ISetDeskDisplayService _setDeskDisplayService;

        public IEnumerable<PinnedImageListItem> Query(RecordQueryOptions options)
        {
            throw new System.NotImplementedException();
        }

        public PinnedImage PinNewImageWithDefaults(string filepath)
        {
            throw new System.NotImplementedException();
        }

        public void HideFromDesk(Guid pinnedImage)
        {
            _setDeskDisplayService.SetDeskDisplay(new DeskDisplayData(pinnedImage, false));
        }

        public void DisplayToDesk(Guid pinnedImage)
        {
            _setDeskDisplayService.SetDeskDisplay(new DeskDisplayData(pinnedImage, true));
        }
    }
}
