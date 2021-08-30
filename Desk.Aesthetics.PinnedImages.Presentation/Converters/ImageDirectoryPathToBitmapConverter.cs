using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Desk.Aesthetics.PinnedImages.Presentation.Converters
{
    public class ImageDirectoryPathToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value.GetType() == typeof(string))
            {
                string imageDirectory = value as string;

                if (!string.IsNullOrWhiteSpace(imageDirectory))
                {
                    //I'll need to do this if I want to delete the image
                    //otherwise it'll throw an exception from an unreleased resource
                    BitmapImage bitmap = new BitmapImage();

                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.UriSource = new Uri(
                        Path.Combine(
                            ConfigurationManager.AppSettings["PinnedImages.Directory"],
                            imageDirectory,
                            $"original{ConfigurationManager.AppSettings["PinnedImages.OutputExtension"]}"),
                        UriKind.RelativeOrAbsolute);
                    bitmap.EndInit();

                    return bitmap;
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