using Desk.Aesthetics.PinnedImages.Presentation.Commands;
using Desk.Aesthetics.PinnedImages.Presentation.Pages;
using System.Windows.Input;

namespace Desk.Aesthetics.PinnedImages.Presentation.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ApplicationPage _currentPage;

        public ApplicationPage CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public ICommand NavigateToPageCommand { get; }

        public MainWindowViewModel()
        {
            _currentPage = ApplicationPage.MainPage;

            NavigateToPageCommand = new ParameterizedRelayCommand<ApplicationPage>(NavigateToPage);
        }

        private void NavigateToPage(ApplicationPage target)
        {
            if(target != _currentPage)
            {
                CurrentPage = target;
            }
        }
    }
}
