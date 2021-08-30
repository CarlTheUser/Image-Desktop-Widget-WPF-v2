using Desk.Aesthetics.PinnedImages.Infrastructure.Data.Display;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Xml.Linq;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private const string APP_NAME = "PinnedImages";

        public App() : base()
        {
            _ = new Mutex(true, APP_NAME, out bool isNewInstance);

            if (!isNewInstance)
            { 
                MessageBoxResult result = MessageBox.Show("An instance of the application is already running.", System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
                
                if(result == MessageBoxResult.OK)
                {
                    Current.Shutdown();
                }
            }
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string connection = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;

            new DefaultAppInitializer(
                new AllDisplayedToDeskPinnedImageDataQuery(connection),
                new MainWindowViewLauncher(),
                new PinnedImageWindowViewLauncher(
                    new DefaultPinnedImageAppServiceFactory(connection))
                ).SetupView();

            Activated += App_Activated;
        }

        private void App_Activated(object sender, System.EventArgs e)
        {
            IEnumerable<PinnedImageWindow> pinnedImageWindows = Windows.OfType<PinnedImageWindow>();

            if (pinnedImageWindows != null)
            {
                foreach(PinnedImageWindow window in pinnedImageWindows)
                {
                    if (window.WindowState == WindowState.Minimized)
                    {
                        window.WindowState = WindowState.Normal;
                        window.Show();
                        window.Visibility = Visibility.Visible;
                    }
                }
            }
        }

    }
}
