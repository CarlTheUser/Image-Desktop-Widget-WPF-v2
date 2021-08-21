using Desk.Aesthetics.PinnedImages.Core.Data;
using Desk.Aesthetics.PinnedImages.Core.Service;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using System;

namespace Desk.Aesthetics.PinnedImages.Presentation.Application
{
    public interface IPinnedImagesAppService
    {
        PinnedImage PinNewImageWithDefaults(string filepath);

        void HideFromDesk(Guid pinnedImage);

        void DisplayToDesk(Guid pinnedImage);
    }

    public class PinnedImagesAppService : IPinnedImagesAppService
    {
        private readonly IPinNewImageService _pinNewImageService;

        private readonly ISetDeskDisplayService _setDeskDisplayService;

        public PinnedImagesAppService(IPinNewImageService pinNewImageService, ISetDeskDisplayService setDeskDisplayService)
        {
            _pinNewImageService = pinNewImageService;
            _setDeskDisplayService = setDeskDisplayService;
        }

        public PinnedImage PinNewImageWithDefaults(string filepath)
        {
            PinnedImageData data = _pinNewImageService.PinNewImage(
                new NewPinnedImageData(
                    filepath,
                    10,
                    0,
                    50,
                    50,
                    300,
                    225,
                    0.4,
                    3,
                    270,
                    6));

            return new PinnedImage(
                data.Id,
                data.ImageDirectory,
                new Dimension(data.Width, data.Height),
                new Location(data.LocationX, data.LocationY),
                data.FrameThickness,
                data.RotationAngle,
                new Caption(data.CaptionText, data.IsCaptionDisplayed),
                new Shadow(
                    data.ShadowOpacity,
                    data.ShadowDepth,
                    data.ShadowDirection,
                    data.ShadowBlurRadius,
                    !data.IsShadowHidden));
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
