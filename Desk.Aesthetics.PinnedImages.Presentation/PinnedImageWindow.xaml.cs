using Desk.Aesthetics.PinnedImages.Presentation.Application;
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
    /// Interaction logic for PinnedImageWindow.xaml
    /// </summary>
    public partial class PinnedImageWindow : Window, IApplicationViewComponent<PinnedImageViewModel>, IPinnedImageDisplayHost
    {
        public PinnedImageWindow()
        {
            InitializeComponent();
            
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
