﻿using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.Commands;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.ViewModels
{
    public class PinnedImageViewModel : ViewModelBase
    {
        private PinnedImage _pinnedImage;

        public IPinnedImageDisplayHost PinnedImageDisplayHost { get; set; }

        public PinnedImage Image
        {
            get => _pinnedImage;
            set
            {
                _pinnedImage = value;
                OnPropertyChanged(nameof(Image));
            }
        }

        public ICommand RelocateCommand { get; }
        public ICommand ResizeCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand HideCommand { get; }
        public ICommand ConfigureCommand { get; }
        public ICommand ShowHomeCommand { get; }

        public PinnedImageViewModel()
        {
            HideCommand = new RelayCommand(() => PinnedImageDisplayHost?.Close());
        }
    }
}
