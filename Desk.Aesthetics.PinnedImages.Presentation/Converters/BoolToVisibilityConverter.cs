using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Desk.Aesthetics.PinnedImages.Presentation.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (value.GetType() == typeof(bool))
                {
                    return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
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
