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

        public NewPinnedImageData(
            string filename, 
            double frameThickness, 
            double rotationAngle, 
            double locationX, 
            double locationY, 
            double width, 
            double height, 
            double shadowOpacity, 
            double shadowDepth, 
            double shadowDirection, 
            double shadowBlurRadius)
        {
            Filename = filename;
            FrameThickness = frameThickness;
            RotationAngle = rotationAngle;
            LocationX = locationX;
            LocationY = locationY;
            Width = width;
            Height = height;
            ShadowOpacity = shadowOpacity;
            ShadowDepth = shadowDepth;
            ShadowDirection = shadowDirection;
            ShadowBlurRadius = shadowBlurRadius;
        }
    }
}
