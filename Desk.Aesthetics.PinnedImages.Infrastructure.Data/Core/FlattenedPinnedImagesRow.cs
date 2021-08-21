using System;

namespace Desk.Aesthetics.PinnedImages.Infrastructure.Data.Core
{
    internal class FlattenedPinnedImagesRow
    {
        public Guid Id { get; set; }
        public string ImageDirectory { get; set; }
        public bool IsDisplayedToDesk { get; set; }
        public double FrameThickness { get; set; }
        public double RotationAngle { get; set; }
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string CaptionText { get; set; }
        public bool IsCaptionDisplayed { get; set; }
        public double ShadowOpacity { get; set; }
        public double ShadowDepth { get; set; }
        public double ShadowDirection { get; set; }
        public double ShadowBlurRadius { get; set; }
        public bool IsShadowHidden { get; set; }
    }
}
