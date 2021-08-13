using System;

namespace Desk.Aesthetics.PinnedImages.Presentation.Models
{
    public class PinnedImageListItem : BindObservable
    {
        public Guid Id { get; }

        private string _directory;

        public string Directory
        {
            get => _directory;
            set
            {
                _directory = value;
                OnPropertyChanged(nameof(Directory));
            }
        }


        private bool _isDisplayedToDesk;

        public bool IsDisplayedToDesk
        {
            get => _isDisplayedToDesk;
            set
            {
                _isDisplayedToDesk = value;
                OnPropertyChanged(nameof(IsDisplayedToDesk));
            }
        }

        private string _caption;

        public string Caption
        {
            get => _caption;
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }

        public PinnedImageListItem(Guid id, string directory, bool isDisplayedToDesk, string caption)
        {
            Id = id;
            Directory = directory;
            IsDisplayedToDesk = isDisplayedToDesk;
            Caption = caption;
        }
    }
}
