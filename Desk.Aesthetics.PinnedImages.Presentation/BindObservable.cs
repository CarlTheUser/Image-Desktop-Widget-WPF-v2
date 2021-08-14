using System.ComponentModel;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public abstract class BindObservable : INotifyPropertyChanged
    {
        //public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
