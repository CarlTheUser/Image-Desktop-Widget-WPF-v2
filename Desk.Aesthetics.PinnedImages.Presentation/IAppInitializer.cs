using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Core.Data;
using Desk.Aesthetics.PinnedImages.Presentation.Models;
using System.Collections.Generic;
using System.Linq;

namespace Desk.Aesthetics.PinnedImages.Presentation
{
    public interface IAppInitializer
    {
        void SetupView();
    }

    public class DefaultAppInitializer : IAppInitializer
    {
        private readonly IQuery<IEnumerable<PinnedImageData>> _displayedPinnedImagesQuery;
        private readonly IViewLauncher _mainWindowViewLauncher;
        private readonly IViewLauncher<PinnedImageWindowViewLauncherParameter> _pinnedImageWindowViewLauncher;

        public DefaultAppInitializer(
            IQuery<IEnumerable<PinnedImageData>> displayedPinnedImagesQuery, 
            IViewLauncher mainWindowViewLauncher, 
            IViewLauncher<PinnedImageWindowViewLauncherParameter> pinnedImageWindowViewLauncher)
        {
            _displayedPinnedImagesQuery = displayedPinnedImagesQuery;
            _mainWindowViewLauncher = mainWindowViewLauncher;
            _pinnedImageWindowViewLauncher = pinnedImageWindowViewLauncher;
        }

        public void SetupView()
        {
            try
            {
                IEnumerable<PinnedImageData> pinnedImages = _displayedPinnedImagesQuery.Execute();

                if (pinnedImages.FirstOrDefault() != null)
                {
                    foreach(PinnedImageData image in pinnedImages)
                    {
                        _pinnedImageWindowViewLauncher.Launch(
                            new PinnedImageWindowViewLauncherParameter(
                                new PinnedImage(
                                    image.Id,
                                    image.ImageDirectory,
                                    new Dimension(image.Width, image.Height),
                                    new Location(image.LocationX, image.LocationY),
                                    image.FrameThickness,
                                    image.RotationAngle,
                                    new Caption(image.CaptionText, image.IsCaptionDisplayed),
                                    new Shadow(
                                        image.ShadowOpacity,
                                        image.ShadowDepth,
                                        image.ShadowDirection,
                                        image.ShadowBlurRadius,
                                        !image.IsShadowHidden)),
                                _mainWindowViewLauncher));
                    }
                }
                else
                {
                    _mainWindowViewLauncher.Launch();
                }
            }
            catch
            {
                _mainWindowViewLauncher.Launch();

                throw;
            }
        }
    }

}
