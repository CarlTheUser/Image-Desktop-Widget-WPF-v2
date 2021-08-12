using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Desk.Aesthetics.PinnedImages.Presentation.Converters
{
    public class MaximizedOrNormalWindowStateToDrawingGroupConverter : IValueConverter
    {
        public DrawingGroup MaximizedValue { get; set; }
        public DrawingGroup NormalValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null)
            {
                if(value.GetType() == typeof(WindowState))
                {
                    return ((WindowState)value) == WindowState.Normal ? MaximizedValue : NormalValue;
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
