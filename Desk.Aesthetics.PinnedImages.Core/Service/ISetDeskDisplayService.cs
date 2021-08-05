using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Core.Data;
using System;

namespace Desk.Aesthetics.PinnedImages.Core.Service
{
    public interface ISetDeskDisplayService
    {
        void SetDeskDisplay(DeskDisplayData deskDisplayData);
    }

    public class SetDeskDisplayService : ISetDeskDisplayService
    {
        private readonly IQuery<PinnedImageData, Guid> _pinnedImageDataByIdQuery;
        private readonly IDataWriter<PinnedImageData> _pinnedImageDataWriter;

        public SetDeskDisplayService(IQuery<PinnedImageData, Guid> pinnedImageDataByIdQuery, IDataWriter<PinnedImageData> pinnedImageDataWriter)
        {
            _pinnedImageDataByIdQuery = pinnedImageDataByIdQuery;
            _pinnedImageDataWriter = pinnedImageDataWriter;
        }

        public void SetDeskDisplay(DeskDisplayData deskDisplayData)
        {
            PinnedImageData existing = _pinnedImageDataByIdQuery.Execute(deskDisplayData.Image);

            PinnedImagesCore.Require(() => existing != null, "Image not found.");

            PinnedImage pinnedImage = PinnedImage.Existing(
                existing.Id,
                new ImageDirectory(existing.ImageDirectory),
                existing.IsDisplayedToDesk,
                existing.FrameThickness,
                existing.RotationAngle,
                new Location(existing.LocationX, existing.LocationY),
                new Dimensions(existing.Width, existing.Height),
                new Caption(existing.CaptionText, existing.IsCaptionDisplayed),
                new Shadow(
                    existing.ShadowOpacity,
                    existing.ShadowDepth,
                    existing.ShadowDirection,
                    existing.ShadowBlurRadius,
                    existing.IsShadowHidden));

            pinnedImage.IsDisplayedToDesk = deskDisplayData.IsDisplayedToDesk;

            _pinnedImageDataWriter.Write(
                new PinnedImageData(
                    pinnedImage.Id,
                    pinnedImage.Directory.Name,
                    pinnedImage.IsDisplayedToDesk,
                    pinnedImage.FrameThickness,
                    pinnedImage.RotationAngle,
                    pinnedImage.Location.X,
                    pinnedImage.Location.Y,
                    pinnedImage.Dimensions.Width,
                    pinnedImage.Dimensions.Height,
                    pinnedImage.Caption.Text,
                    pinnedImage.Caption.IsDisplayed,
                    pinnedImage.Shadow.Opacity,
                    pinnedImage.Shadow.Depth,
                    pinnedImage.Shadow.Direction,
                    pinnedImage.Shadow.BlurRadius,
                    pinnedImage.Shadow.IsHidden));
        }
    }
}
