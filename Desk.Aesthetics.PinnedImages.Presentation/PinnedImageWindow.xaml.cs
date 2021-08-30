using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using Desk.Aesthetics.PinnedImages.Presentation.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    /// <summary>
    /// Interaction logic for PinnedImageWindow.xaml
    /// </summary>
    public partial class PinnedImageWindow : Window, IApplicationViewComponent<PinnedImageViewModel>, IPinnedImageDisplayHost
    {
        public PinnedImageViewModel VM { get; }

        public PinnedImageWindow(PinnedImageViewModel viewModel)
        {
            InitializeComponent();
            VM = viewModel;
            VM.PinnedImageDisplayHost = this;
            DataContext = VM;
        }

        public PinnedImageViewModel GetViewModel()
        {
            return VM;
        }

        private void PinnedImageDisplayHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void This_Closed(object sender, System.EventArgs e)
        {
            VM.SaveFrameLocationAndDimension();
        }
    }
}
