using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Core.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace Desk.Aesthetics.PinnedImages.Core.Service
{
    public interface IPinNewImageService
    {
        PinnedImageData PinNewImage(NewPinnedImageData newPinnedImageData);
    }

    public class PinNewImageService : IPinNewImageService
    {
        private readonly string _imageDirectory;
        private readonly IDataWriter<PinnedImageData> _pinnedImageDataWriter;

        public PinNewImageService(string imageDirectory, IDataWriter<PinnedImageData> pinnedImageDataWriter)
        {
            _imageDirectory = imageDirectory;
            _pinnedImageDataWriter = pinnedImageDataWriter;
        }

        public PinnedImageData PinNewImage(NewPinnedImageData newPinnedImageData)
        {
            string filename = newPinnedImageData.Filename;

            FileStream imageFileStream = default;

            Bitmap pinnedImageBitmap = default;

            Bitmap thumbnail = default;

            Graphics graphics = default;

            try
            {
                imageFileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                PinnedImagesCore.Require(() => IsImage(imageFileStream), "Cannot pin this item.");

                pinnedImageBitmap = new Bitmap(imageFileStream);

                string extension = Path.GetExtension(filename);

                string imageDirectoryName = Guid.NewGuid().ToString();

                string dumpDir = Path.Combine(_imageDirectory, imageDirectoryName);

                PinnedImage pinnedImage = PinnedImage.New(
                new ImageDirectory(imageDirectoryName),
                newPinnedImageData.FrameThickness,
                newPinnedImageData.RotationAngle,
                new Location(newPinnedImageData.LocationX, newPinnedImageData.LocationY),
                new Dimensions(newPinnedImageData.Width, newPinnedImageData.Height),
                new Caption(string.Empty, false),
                new Shadow(
                    newPinnedImageData.ShadowOpacity,
                    newPinnedImageData.ShadowDepth,
                    newPinnedImageData.ShadowDirection,
                    newPinnedImageData.ShadowBlurRadius, false));

                //pinnedImageBitmap.Save(Path.Combine(dumpDir, "original" + extension));
                pinnedImageBitmap.Save(Path.Combine(dumpDir, "original"));

                const int maxThumbnailWidth = 1280;
                const int maxThumbnailHeight = 720;

                double thumbnailWidth = pinnedImageBitmap.Width,
                    thumbnailHeight = pinnedImageBitmap.Height,
                    getWidthByHeightRatio = thumbnailWidth / thumbnailHeight,
                    getHeightByWidthRatio = thumbnailHeight / thumbnailWidth;

                if (thumbnailWidth > maxThumbnailWidth)
                {
                    thumbnailWidth = maxThumbnailWidth;

                    thumbnailHeight = thumbnailWidth * getHeightByWidthRatio;
                }

                if (thumbnailHeight > maxThumbnailHeight)
                {
                    thumbnailHeight = maxThumbnailHeight;

                    thumbnailWidth = thumbnailHeight * getWidthByHeightRatio;
                }

                thumbnail = new Bitmap((int)thumbnailWidth, maxThumbnailHeight);

                thumbnail.SetResolution(pinnedImageBitmap.HorizontalResolution, pinnedImageBitmap.VerticalResolution);

                graphics = Graphics.FromImage(thumbnail);

                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(pinnedImageBitmap, 0, 0, (int)thumbnailWidth, (int)thumbnailHeight);

                //thumbnail.Save(Path.Combine(Path.Combine(dumpDir, "thumb" + extension)));
                thumbnail.Save(Path.Combine(Path.Combine(dumpDir, "thumb")));

                PinnedImageData pinnedImageData = new PinnedImageData(
                pinnedImage.Id,
                pinnedImage.Directory.Name,
                pinnedImage.IsDisplayedToDesk,
                pinnedImage.FrameThickness,
                pinnedImage.RotationAngle,
                pinnedImage.Location.X,
                pinnedImage.Location.Y,
                pinnedImage.Dimensions.Width,
                pinnedImage.Dimensions.Height,
                pinnedImage.Caption.Text,
                pinnedImage.Caption.IsDisplayed,
                pinnedImage.Shadow.Opacity,
                pinnedImage.Shadow.Depth,
                pinnedImage.Shadow.Direction,
                pinnedImage.Shadow.BlurRadius,
                pinnedImage.Shadow.IsHidden,
                DateTime.Now);

                _pinnedImageDataWriter.Write(pinnedImageData);

                return pinnedImageData;

            }
            finally
            {
                graphics?.Dispose();
                thumbnail?.Dispose();
                pinnedImageBitmap?.Dispose();
                imageFileStream?.Dispose();
            }
        }

        //https://stackoverflow.com/questions/670546/determine-if-file-is-an-image
        private static bool IsImage(Stream stream)
        {
            _ = stream.Seek(0, SeekOrigin.Begin);

            IEnumerable<string> jpg = new string[] { "FF", "D8" };
            IEnumerable<string> bmp = new string[] { "42", "4D" };
            IEnumerable<string> gif = new string[] { "47", "49", "46" };
            IEnumerable<string> png = new string[] { "89", "50", "4E", "47", "0D", "0A", "1A", "0A" };

            IEnumerable<IEnumerable<string>> imgTypes = new List<IEnumerable<string>>() { jpg, bmp, gif, png };

            List<string> bytesIterated = new List<string>();

            for (int i = 0; i < 8; ++i)
            {
                string bit = stream.ReadByte().ToString("X2");

                bytesIterated.Add(bit);

                bool isImage = imgTypes.Any(img => !img.Except(bytesIterated).Any());

                if (isImage)
                {
                    _ = stream.Seek(0, SeekOrigin.Begin);
                    return true;
                }
            }
            _ = stream.Seek(0, SeekOrigin.Begin);
            return false;
        }
    }
}
