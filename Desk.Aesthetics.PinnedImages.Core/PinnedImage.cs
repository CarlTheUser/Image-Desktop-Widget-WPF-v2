using System;

namespace Desk.Aesthetics.PinnedImages.Core
{
    internal class PinnedImage
    {
        public static PinnedImage New(
            ImageDirectory imageDirectory,
            double frameThickness,
            double rotationAngle,
            Location location,
            Dimensions dimensions,
            Caption caption,
            Shadow shadow)
        {
            PinnedImagesCore.Require(() => imageDirectory != null, $"{nameof(imageDirectory)} cannot be null.");
            PinnedImagesCore.Require(() => location != null, $"{nameof(location)} cannot be null.");
            PinnedImagesCore.Require(() => dimensions != null, $"{nameof(dimensions)} cannot be null.");
            PinnedImagesCore.Require(() => caption != null, $"{nameof(caption)} cannot be null.");
            PinnedImagesCore.Require(() => shadow != null, $"{nameof(shadow)} cannot be null.");

            return new PinnedImage(Guid.NewGuid(), imageDirectory, true, frameThickness, rotationAngle, location, dimensions, caption, shadow);
        }

        public static PinnedImage Existing(
            Guid id,
            ImageDirectory imageDirectory,
            bool isDisplayedToDesk,
            double frameThickness,
            double rotationAngle,
            Location location,
            Dimensions dimensions,
            Caption caption,
            Shadow shadow)
        {
            return new PinnedImage(id, imageDirectory, isDisplayedToDesk, frameThickness, rotationAngle, location, dimensions, caption, shadow);
        }

        public Guid Id { get; }
        public ImageDirectory Directory { get; }
        public bool IsDisplayedToDesk { get; set; }
        public double FrameThickness { get; set; }
        public double RotationAngle { get; set; }

        private Location _location;
        public Location Location
        { 
            get => _location;
            set
            {
                PinnedImagesCore.Require(() => value != null, "Location cannot be null.");
                _location = value;
            }
        }

        private Dimensions _dimensions;
        public Dimensions Dimensions
        {
            get => _dimensions;
            set
            {
                PinnedImagesCore.Require(() => value != null, "Dimensions cannot be null.");
                _dimensions = value;
            }
        }

        public Caption Caption { get; private set; }

        private Shadow _shadow;
        public Shadow Shadow
        {
            get => _shadow;
            set
            {
                PinnedImagesCore.Require(() => value != null, "Shadow cannot be null.");
                _shadow = value;
            }
        }

        private PinnedImage(
            Guid id,
            ImageDirectory imageDirectory,
            bool isDisplayedToDesk,
            double frameThickness,
            double rotationAngle,
            Location location,
            Dimensions dimensions,
            Caption caption,
            Shadow shadow)
        {
            Id = id;
            Directory = imageDirectory;
            IsDisplayedToDesk = isDisplayedToDesk;
            FrameThickness = frameThickness;
            RotationAngle = rotationAngle;
            _location = location;
            _dimensions = dimensions;
            Caption = caption;
            _shadow = shadow;
        }

        public void ChangeCaption(string text)
        {
            bool isDisplayed = Caption.IsDisplayed;

            Caption = new Caption(text, isDisplayed);
        }
    }
}
