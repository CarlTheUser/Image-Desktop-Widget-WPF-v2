using System;

namespace Desk.Aesthetics.PinnedImages.Presentation.Models
{
    public class PinnedImage : BindObservable
    {
        private double _frameThickness;
        private double _rotationAngle;

        public PinnedImage(Guid id, string directory, Dimension dimension, Location location, double frameThickness, double rotationAngle, Caption caption, Shadow shadow)
        {
            Id = id;
            Directory = directory;
            Dimension = dimension;
            Location = location;
            FrameThickness = frameThickness;
            RotationAngle = rotationAngle;
            Caption = caption;
            Shadow = shadow;
        }

        public Guid Id { get; }
        public string Directory { get; }
        public Dimension Dimension{ get; }
        public Location Location { get; }
        public double FrameThickness
        {
            get => _frameThickness;
            set
            {
                _frameThickness = value;
                OnPropertyChanged(nameof(FrameThickness));
            }
        }
        public double RotationAngle
        {
            get => _rotationAngle;
            set
            {
                _rotationAngle = value;
                OnPropertyChanged(nameof(RotationAngle));
            }
        }
        public Caption Caption { get; }
        public Shadow Shadow { get; }

    }
}
