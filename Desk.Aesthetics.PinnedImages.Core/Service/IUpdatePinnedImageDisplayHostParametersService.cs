using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Core.Data;
using System;

namespace Desk.Aesthetics.PinnedImages.Core.Service
{
    public interface IUpdatePinnedImageDisplayHostParametersService
    {
        void UpdateDisplayParameters(PinnedImageHostDisplayParametersData parametersData);
    }

    public class UpdatePinnedImageHostDisplayParameters : IUpdatePinnedImageDisplayHostParametersService
    {
        private readonly IQuery<PinnedImageData, Guid> _pinnedImageDataByIdQuery;
        private readonly IDataWriter<PinnedImageData> _pinnedImageDataWriter;

        public UpdatePinnedImageHostDisplayParameters(IQuery<PinnedImageData, Guid> pinnedImageDataByIdQuery, IDataWriter<PinnedImageData> pinnedImageDataWriter)
        {
            _pinnedImageDataByIdQuery = pinnedImageDataByIdQuery;
            _pinnedImageDataWriter = pinnedImageDataWriter;
        }

        public void UpdateDisplayParameters(PinnedImageHostDisplayParametersData parametersData)
        {
            PinnedImageData existing = _pinnedImageDataByIdQuery.Execute(parametersData.Image);

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

            pinnedImage.Location = new Location(parametersData.LocationX, parametersData.LocationY);
            pinnedImage.Dimensions = new Dimensions(parametersData.Width, parametersData.Height);

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
