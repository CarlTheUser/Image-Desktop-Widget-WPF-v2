namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public interface IViewLauncher
    {
        void Launch();
    }

    public interface IViewLauncher<TParameter>
    {
        void Launch(TParameter parameter);
    }
}
