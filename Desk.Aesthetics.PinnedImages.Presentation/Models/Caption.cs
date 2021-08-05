namespace Desk.Aesthetics.PinnedImages.Presentation.Models
{
    public class Caption : BindObservable
    {
        private string _text;
        private bool _visible;

        public Caption(string text, bool visible)
        {
            _text = text;
            _visible = visible;
        }

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
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
