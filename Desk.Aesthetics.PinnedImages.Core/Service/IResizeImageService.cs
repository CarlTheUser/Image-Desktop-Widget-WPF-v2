using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Core.Data;
using System;

namespace Desk.Aesthetics.PinnedImages.Core.Service
{
    public interface IResizeImageService
    {
        void Resize(ResizedImageData resizedImageData);
    }

    public class ResizeImageService : IResizeImageService
    {
        private readonly IQuery<PinnedImageData, Guid> _pinnedImageDataByIdQuery;
        private readonly IDataWriter<PinnedImageData> _pinnedImageDataWriter;

        public void Resize(ResizedImageData resizedImageData)
        {
            PinnedImageData existing = _pinnedImageDataByIdQuery.Execute(resizedImageData.Image);

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

            pinnedImage.Dimensions = new Dimensions(resizedImageData.Width, resizedImageData.Height);

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
