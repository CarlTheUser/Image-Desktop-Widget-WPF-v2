using Desk.Aesthetics.PinnedImages.Presentation.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Desk.Aesthetics.PinnedImages.Presentation.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page, IApplicationViewComponent<SettingsPageViewModel>
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        public SettingsPageViewModel GetViewModel()
        {
            return VM;
        }

        private void SettingsPageInstance_Loaded(object sender, RoutedEventArgs e)
        {
            VM.LoadColors();
        }
    }
}
