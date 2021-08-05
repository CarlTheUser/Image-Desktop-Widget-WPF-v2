using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Effects;
using System.Windows.Media;
using Desk.Aesthetics.PinnedImages.Presentation.Models;

namespace Desk.Aesthetics.PinnedImages.Presentation.Converters
{
    public class ShadowToDropShadowEffectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(Shadow))
            {
                Shadow shadow = (Shadow)value;

                return shadow.Visible
                    ? new DropShadowEffect()
                    {
                        Opacity = shadow.Opacity,
                        ShadowDepth = shadow.Depth,
                        Direction = shadow.Direction,
                        BlurRadius = shadow.BlurRadius,
                        Color = Colors.Black
                    }
                    : null;
            }
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
