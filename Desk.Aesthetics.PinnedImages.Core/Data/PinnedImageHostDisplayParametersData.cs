using System;

namespace Desk.Aesthetics.PinnedImages.Core.Data
{
    public class PinnedImageHostDisplayParametersData
    {
        public Guid Image { get; }
        public double LocationX { get; }
        public double LocationY { get; }
        public double Width { get; }
        public double Height { get; }

        public PinnedImageHostDisplayParametersData(Guid image, double locationX, double locationY, double width, double height)
        {
            Image = image;
            LocationX = locationX;
            LocationY = locationY;
            Width = width;
            Height = height;
        }
    }
}
