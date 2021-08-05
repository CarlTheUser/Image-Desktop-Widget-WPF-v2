using Desk.Aesthetics.PinnedImages.Presentation.ViewModels;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public interface IApplicationViewComponent<TViewModel> where TViewModel : ViewModelBase
    {
        TViewModel GetViewModel();
    }
}
