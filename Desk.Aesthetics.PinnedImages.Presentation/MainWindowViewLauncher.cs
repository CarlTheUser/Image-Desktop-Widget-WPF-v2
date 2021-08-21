namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public class MainWindowViewLauncher : IViewLauncher
    {
        public void Launch()
        {
            MainWindow.Instance.Show();
        }
    }
}
