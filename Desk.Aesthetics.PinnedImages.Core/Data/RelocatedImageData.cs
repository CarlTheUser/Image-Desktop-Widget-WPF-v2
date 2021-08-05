using System;

namespace Desk.Aesthetics.PinnedImages.Core.Data
{
    public class RelocatedImageData
    {
        public Guid Image { get; }
        public double LocationX { get; }
        public double LocationY { get; }

        public RelocatedImageData(Guid image, double locationX, double locationY)
        {
            Image = image;
            LocationX = locationX;
            LocationY = locationY;
        }
    }
}
