using Desk.Aesthetics.PinnedImages.Presentation.Pages;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Desk.Aesthetics.PinnedImages.Presentation.Converters
{
    public class ApplicationPageToPageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value.GetType() == typeof(ApplicationPage))
            {

                switch((ApplicationPage)value)
                {
                    case ApplicationPage.MainPage: return new PinnedImagesPage();
                    case ApplicationPage.SettingsPage: return new SettingsPage();
                }
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
