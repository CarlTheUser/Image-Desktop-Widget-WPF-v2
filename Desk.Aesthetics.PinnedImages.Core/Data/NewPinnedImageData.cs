using System;

namespace Desk.Aesthetics.PinnedImages.Core.Data
{
    public class NewPinnedImageData
    {
        public string Filename { get; }
        public double FrameThickness { get; }
        public double RotationAngle { get; }
        public double LocationX { get; }
        public double LocationY { get; }
        public double Width { get; }
        public double Height { get; }
        public double ShadowOpacity { get; }
        public double ShadowDepth { get; }
        public double ShadowDirection { get; }
        public double ShadowBlurRadius { get; }
    }
}
