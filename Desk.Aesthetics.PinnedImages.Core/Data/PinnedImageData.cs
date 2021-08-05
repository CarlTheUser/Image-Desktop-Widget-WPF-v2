using System;

namespace Desk.Aesthetics.PinnedImages.Core.Data
{
    public class PinnedImageData
    {
        public Guid Id { get; }
        public string ImageDirectory { get; }
        public bool IsDisplayedToDesk { get; }
        public double FrameThickness { get; }
        public double RotationAngle { get; }
        public double LocationX { get; }
        public double LocationY { get; }
        public double Width { get; }
        public double Height { get; }
        public string CaptionText { get; }
        public bool IsCaptionDisplayed { get; }
        public double ShadowOpacity { get; }
        public double ShadowDepth { get; }
        public double ShadowDirection { get; }
        public double ShadowBlurRadius { get; }
        public bool IsShadowHidden { get; }

        public PinnedImageData(Guid id, string imageDirectory, bool isDisplayedToDesk, double frameThickness, double rotationAngle, double locationX, double locationY, double width, double height, string captionText, bool isCaptionDisplayed, double shadowOpacity, double shadowDepth, double shadowDirection, double shadowBlurRadius, bool isShadowHidden)
        {
            Id = id;
            ImageDirectory = imageDirectory;
            IsDisplayedToDesk = isDisplayedToDesk;
            FrameThickness = frameThickness;
            RotationAngle = rotationAngle;
            LocationX = locationX;
            LocationY = locationY;
            Width = width;
            Height = height;
            CaptionText = captionText;
            IsCaptionDisplayed = isCaptionDisplayed;
            ShadowOpacity = shadowOpacity;
            ShadowDepth = shadowDepth;
            ShadowDirection = shadowDirection;
            ShadowBlurRadius = shadowBlurRadius;
            IsShadowHidden = isShadowHidden;
        }
    }
}
