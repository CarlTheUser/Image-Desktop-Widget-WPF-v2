using Desk.Aesthetics.PinnedImages.Core.Data;
using Desk.Aesthetics.PinnedImages.Core.Service;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using System;

namespace Desk.Aesthetics.PinnedImages.Presentation.Application
{
    public interface IPinnedImageAppService
    {
        void ApplyAppearance(PinnedImage pinnedImage);
        void SaveCurrentDisplayHostParameters(PinnedImage pinnedImage);
        void DeletePinnedImage(Guid pinnedImage);
    }

    public class PinnedImageAppService : IPinnedImageAppService
    {
        private readonly IChangeAppearanceService _changeAppearanceService;
        private readonly IUpdatePinnedImageDisplayHostParametersService _updatePinnedImageDisplayHostParametersService;
        private readonly IDeletePinnedImageService _deletePinnedImageService;

        public PinnedImageAppService(
            IChangeAppearanceService changeAppearanceService, 
            IUpdatePinnedImageDisplayHostParametersService updatePinnedImageDisplayHostParametersService, 
            IDeletePinnedImageService deletePinnedImageService)
        {
            _changeAppearanceService = changeAppearanceService;
            _updatePinnedImageDisplayHostParametersService = updatePinnedImageDisplayHostParametersService;
            _deletePinnedImageService = deletePinnedImageService;
        }

        public void ApplyAppearance(PinnedImage pinnedImage)
        {
            _changeAppearanceService.ChangeAppearance(
                new ImageAppearanceData(
                    pinnedImage.Id,
                    pinnedImage.FrameThickness,
                    pinnedImage.RotationAngle,
                    pinnedImage.Caption.Text,
                    pinnedImage.Caption.Visible,
                    pinnedImage.Shadow.Opacity,
                    pinnedImage.Shadow.Depth,
                    pinnedImage.Shadow.Direction,
                    pinnedImage.Shadow.BlurRadius,
                    !pinnedImage.Shadow.Visible));
        }

        public void SaveCurrentDisplayHostParameters(PinnedImage pinnedImage)
        {
            _updatePinnedImageDisplayHostParametersService.UpdateDisplayParameters(
                new PinnedImageHostDisplayParametersData(
                    pinnedImage.Id,
                    pinnedImage.Location.X,
                    pinnedImage.Location.Y,
                    pinnedImage.Dimension.Width,
                    pinnedImage.Dimension.Height));
        }

        public void DeletePinnedImage(Guid pinnedImage)
        {
            _deletePinnedImageService.Delete(pinnedImage);
        }
    }
}
