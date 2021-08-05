namespace Desk.Aesthetics.PinnedImages.Presentation.Models
{
    public class Location : BindObservable
    {
        private double _x;
        private double _y;

        public Location(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged(nameof(X));
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged(nameof(Y));
            }
        }
    }
}
