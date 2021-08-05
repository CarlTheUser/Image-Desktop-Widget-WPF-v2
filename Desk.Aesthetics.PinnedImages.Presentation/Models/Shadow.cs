namespace Desk.Aesthetics.PinnedImages.Presentation.Models
{
    public class Shadow : BindObservable
    {
        private double _opacity;
        private double _depth;
        private double _direction;
        private double _blurRadius;
        private bool _visible;

        public Shadow(double opacity, double depth, double direction, double blurRadius, bool visible)
        {
            _opacity = opacity;
            _depth = depth;
            _direction = direction;
            _blurRadius = blurRadius;
            _visible = visible;
        }

        public double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                OnPropertyChanged(nameof(Opacity));
            }
        }
        public double Depth
        {
            get => _depth;
            set
            {
                _depth= value;
                OnPropertyChanged(nameof(Depth));
            }
        }
        public double Direction
        {
            get => _direction;
            set
            {
                _direction = value;
                OnPropertyChanged(nameof(Direction));
            }
        }
        public double BlurRadius
        {
            get => _blurRadius;
            set
            {
                _blurRadius = value;
                OnPropertyChanged(nameof(BlurRadius));
            }
        }
        public bool Visible
        {
            get => _visible;
            set
            {
                _visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }
    }
}
