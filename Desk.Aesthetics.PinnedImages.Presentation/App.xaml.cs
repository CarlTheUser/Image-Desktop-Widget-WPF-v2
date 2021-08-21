using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private const string APP_NAME = "PinnedImages";

        private readonly Mutex _mutex;

        private bool _isNewInstance;

        public App() : base()
        {
            _mutex = new Mutex(true, APP_NAME, out _isNewInstance);

            if (!_isNewInstance)
            {
                _ = MessageBox.Show("An instance of the application is already running.", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                Current.Shutdown();
            }

            new DefaultAppInitializer(
                null,
                new MainWindowViewLauncher(),
                new PinnedImageWindowViewLauncher(
                    new DefaultPinnedImageAppServiceFactory(""))
                ).SetupView();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Activated += App_Activated;
        }

        private void App_Activated(object sender, System.EventArgs e)
        {
            IEnumerable<PinnedImageWindow> pinnedImageWindows = Windows.OfType<PinnedImageWindow>();

            if (pinnedImageWindows != null)
            {
                foreach(PinnedImageWindow window in pinnedImageWindows)
                {
                    if (window.WindowState == WindowState.Minimized) window.WindowState = WindowState.Normal;
                    window.Show();
                    window.Visibility = Visibility.Visible;
                }
            }
        }


    }
}
