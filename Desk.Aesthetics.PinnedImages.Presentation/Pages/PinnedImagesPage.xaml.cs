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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desk.Aesthetics.PinnedImages.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for PinnedImagesPage.xaml
    /// </summary>
    public partial class PinnedImagesPage : Page, IApplicationViewComponent<PinnedImagesViewModel>
    {
        public PinnedImagesPage()
        {
            InitializeComponent();
        }

        public PinnedImagesViewModel GetViewModel()
        {
            return VM;
        }
    }
}
