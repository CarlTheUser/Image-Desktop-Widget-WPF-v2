using Desk.Aesthetics.PinnedImages.Presentation.Models;
using Desk.Aesthetics.PinnedImages.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    /// <summary>
    /// Interaction logic for PinnedImageSettingsWindow.xaml
    /// </summary>
    public partial class PinnedImageSettingsWindow : Window, IApplicationViewComponent<PinnedImageSettingsViewModel>
    {
        public PinnedImageSettingsViewModel VM { get; private set; }

        public PinnedImageSettingsWindow(PinnedImageSettingsViewModel pinnedImageSettingsViewModel)
        {
            InitializeComponent();
            DataContext = VM = pinnedImageSettingsViewModel;
            Top = VM.Image.Location.Y + Height;
            Left = VM.Image.Location.X;
        }

        public PinnedImageSettingsViewModel GetViewModel()
        {
            return VM;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            VM.ApplyChanges();
        }

        private (double, double) CalculateInitialPositionRelativeToScreen(Location location)
        {
            return (0, 0);
        }
    }
}
