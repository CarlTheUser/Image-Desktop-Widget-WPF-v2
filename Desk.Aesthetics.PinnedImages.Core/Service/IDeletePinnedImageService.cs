using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Core.Data;
using System;
using System.IO;

namespace Desk.Aesthetics.PinnedImages.Core.Service
{
    public interface IDeletePinnedImageService
    {
        void Delete(Guid image);
    }

    public class DeletePinnedImageService : IDeletePinnedImageService
    {
        private readonly string _imageDirectory;
        private readonly IQuery<PinnedImageData, Guid> _pinnedImageDataByIdQuery;
        private readonly IDataDestroyer<Guid> _pinnedImageDataDestroyer;

        public DeletePinnedImageService(
            string imageDirectory,
            IQuery<PinnedImageData, Guid> pinnedImageDataByIdQuery, 
            IDataDestroyer<Guid> pinnedImageDataDestroyer)
        {
            _imageDirectory = imageDirectory;
            _pinnedImageDataByIdQuery = pinnedImageDataByIdQuery;
            _pinnedImageDataDestroyer = pinnedImageDataDestroyer;
        }

        public void Delete(Guid image)
        {
            PinnedImageData existing = _pinnedImageDataByIdQuery.Execute(image);

            PinnedImagesCore.Require(() => existing != null, "Item not found.");

            _pinnedImageDataDestroyer.Destroy(image);

            Directory.Delete(Path.Combine(_imageDirectory, existing.ImageDirectory), true);
        }
    }
}
