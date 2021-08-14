using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Presentation.Application;
using Desk.Aesthetics.PinnedImages.Presentation.Commands;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Windows.Input;
using System.Windows.Media;

namespace Desk.Aesthetics.PinnedImages.Presentation.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        private const string APP_KEY = "Pinned Images";

        private const string PATH_REGISTRY_RUN = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        private ObservableCollection<Color> _colors = new ObservableCollection<Color>();

        public ObservableCollection<Color> Colors
        {
            get => _colors;
            set
            {
                _colors = value;
                OnPropertyChanged(nameof(Colors));
            }
        }

        private bool _hasAdministratorRights;

        public bool HasAdministratorRights
        {
            get => _hasAdministratorRights;
            set
            {
                _hasAdministratorRights = value;
                OnPropertyChanged(nameof(HasAdministratorRights));
            }
        }

        private bool _startWithWindows;

        public bool StartWithWindows
        {
            get => _startWithWindows;
            set
            {
                _startWithWindows = value;
                OnPropertyChanged(nameof(StartWithWindows));
            }
        }

        public ICommand SetStartupBehaviorCommand { get; }

        public ICommand SetAccentColorCommand { get; }

        public SettingsPageViewModel()
        {
            SetStartupBehaviorCommand = new AsyncParameterizedRelayCommand<bool>(
                SetStartupBehavior,
                null,
                (e) => { }) ;

            SetAccentColorCommand = new AsyncParameterizedRelayCommand<Color>(
                SetColor,
                null,
                (e) => { });
        }

        private void SetStartupBehavior(bool startWithWindows)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(PATH_REGISTRY_RUN, true))
            {
                if (startWithWindows)
                {
                    key.SetValue(APP_KEY, "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\"");
                }
                else
                {
                    key.DeleteValue(APP_KEY, false);
                }
            }
        }

        private void SetColor(Color value)
        {
            if (value != null)
            {
                Properties.Settings.Default.AccentColor = value;
                Properties.Settings.Default.Save();
            }
        }

        public void CheckStartupBehavior()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            HasAdministratorRights = principal.IsInRole(WindowsBuiltInRole.Administrator);

            using(RegistryKey key = Registry.CurrentUser.OpenSubKey(PATH_REGISTRY_RUN, true))
            {
                StartWithWindows = key.GetValue(APP_KEY) != null;
            }
        }

        public void LoadColors()
        {
            IQuery<IEnumerable<Color>, string> colorsFromJsonFileQuery = new ColorsFromJsonFileQuery();

            IEnumerable<Color> colors = colorsFromJsonFileQuery.Execute(ConfigurationManager.AppSettings["Colors.Json"]);

            if(colors.FirstOrDefault() != null)
            {
                Colors = new ObservableCollection<Color>(colors);
            }
            else
            {
                Colors = new ObservableCollection<Color>(GetFallbackColors());
            }
        }

        private IEnumerable<Color> GetFallbackColors()
        {
            return new Color[]
            {
                (Color)ColorConverter.ConvertFromString("#202020"),
                (Color)ColorConverter.ConvertFromString("#535353"),
                (Color)ColorConverter.ConvertFromString("#f44236"),
                (Color)ColorConverter.ConvertFromString("#ff0000"),
                (Color)ColorConverter.ConvertFromString("#ea1e63"),
                (Color)ColorConverter.ConvertFromString("#e74856"),
                (Color)ColorConverter.ConvertFromString("#9c28b1"),
                (Color)ColorConverter.ConvertFromString("#881798"),
                (Color)ColorConverter.ConvertFromString("#744da9"),
                (Color)ColorConverter.ConvertFromString("#673bb7"),
                (Color)ColorConverter.ConvertFromString("#3f51b5"),
                (Color)ColorConverter.ConvertFromString("#0398fc"),
                (Color)ColorConverter.ConvertFromString("#00bcd5"),
                (Color)ColorConverter.ConvertFromString("#009788"),
                (Color)ColorConverter.ConvertFromString("#008000"),
                (Color)ColorConverter.ConvertFromString("#4cb050"),
                (Color)ColorConverter.ConvertFromString("#847545"),
                (Color)ColorConverter.ConvertFromString("#ffeb3c"),
                (Color)ColorConverter.ConvertFromString("#fec107"),
                (Color)ColorConverter.ConvertFromString("#00cc6a"),
                (Color)ColorConverter.ConvertFromString("#ff9700"),
                (Color)ColorConverter.ConvertFromString("#fe5722"),
                (Color)ColorConverter.ConvertFromString("#607d8b"),
                (Color)ColorConverter.ConvertFromString("#FFEF7B")
            };
        }
    }
}
