using System;

namespace Desk.Aesthetics.PinnedImages.Core.Data
{
    public class ResizedImageData
    {
        public Guid Image { get; }
        public double Width { get; }
        public double Height { get; }

        public ResizedImageData(Guid image, double width, double height)
        {
            Image = image;
            Width = width;
            Height = height;
        }
    }
}
