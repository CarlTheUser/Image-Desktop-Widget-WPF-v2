using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Core.Data;
using System;

namespace Desk.Aesthetics.PinnedImages.Core.Service
{
    public interface IChangeAppearanceService
    {
        void ChangeAppearance(ImageAppearanceData imageAppearanceData);
    }

    public class ChangeAppearanceService : IChangeAppearanceService
    {
        private readonly IQuery<PinnedImageData, Guid> _pinnedImageDataByIdQuery;
        private readonly IDataWriter<PinnedImageData> _pinnedImageDataWriter;

        public ChangeAppearanceService(IQuery<PinnedImageData, Guid> pinnedImageDataByIdQuery, IDataWriter<PinnedImageData> pinnedImageDataWriter)
        {
            _pinnedImageDataByIdQuery = pinnedImageDataByIdQuery;
            _pinnedImageDataWriter = pinnedImageDataWriter;
        }

        public void ChangeAppearance(ImageAppearanceData imageAppearanceData)
        {
            PinnedImageData existing = _pinnedImageDataByIdQuery.Execute(imageAppearanceData.Image);

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

            pinnedImage.FrameThickness = imageAppearanceData.FrameThickness;
            pinnedImage.RotationAngle = imageAppearanceData.RotationAngle;
            pinnedImage.Caption.IsDisplayed = imageAppearanceData.ShowCaption;
            if(pinnedImage.Caption.Text != imageAppearanceData.Caption)
            {
                pinnedImage.ChangeCaption(imageAppearanceData.Caption);
            }

            pinnedImage.Shadow = new Shadow(
                imageAppearanceData.ShadowOpacity,
                imageAppearanceData.ShadowDepth,
                imageAppearanceData.ShadowDirection,
                imageAppearanceData.ShadowBlurRadius,
                imageAppearanceData.IsShadowHidden);

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
