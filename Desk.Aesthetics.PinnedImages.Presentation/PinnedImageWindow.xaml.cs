using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    /// <summary>
    /// Interaction logic for PinnedImageWindow.xaml
    /// </summary>
    public partial class PinnedImageWindow : Window, IApplicationViewComponent<PinnedImageViewModel>, IPinnedImageDisplayHost
    {
        public PinnedImageWindow(PinnedImageViewModel viewModel)
        {
            InitializeComponent();
            VM = viewModel;
            VM.PinnedImageDisplayHost = this;
        }

        public PinnedImageViewModel GetViewModel()
        {
            return VM;
        }

        private void PinnedImageDisplayHost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.ClearFocus();
            if (e.ChangedButton == MouseButton.Left) DragMove();
        }
    }
}
