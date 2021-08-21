using Desk.Aesthetics.PinnedImages.Presentation.ViewModels;
using System;
using System.Windows;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IApplicationViewComponent<MainWindowViewModel>
    {
        private static MainWindow _instance = null;

        private static readonly object _lock = new object();

        public static MainWindow Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MainWindow();
                        }
                    }
                }
                return _instance;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            
        }

        public MainWindowViewModel GetViewModel()
        {
            return VM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //new PinnedImageWindow().Show();
        }

        private void MainWindowInstance_Closed(object sender, EventArgs e)
        {
            _instance = null;
        }
    }
}
