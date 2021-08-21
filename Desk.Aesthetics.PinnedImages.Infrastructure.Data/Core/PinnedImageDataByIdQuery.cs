using Data.Common.Contracts;
using Data.Sql.Provider;
using Data.Sql;
using Desk.Aesthetics.PinnedImages.Core.Data;
using System;
using System.Data;
using System.Linq;

namespace Desk.Aesthetics.PinnedImages.Infrastructure.Data.Core
{
    public class PinnedImageDataByIdQuery : IQuery<PinnedImageData, Guid>
    {
        private readonly ISqlCaller _caller;

        private readonly ISqlProvider _provider;

        private readonly FlattenedPinnedImagesRowDao _dao = new FlattenedPinnedImagesRowDao();

        public PinnedImageDataByIdQuery(string connection)
        {
            _caller = new SqlCaller(_provider = new SQLiteProvider(connection));
        }

        public PinnedImageData Execute(Guid parameter)
        {
            SqlTransaction transaction = default;

            try
            {
                transaction = _caller.CreateScopedTransaction(IsolationLevel.ReadCommitted);

                FlattenedPinnedImagesRow existing = _dao.Find(
                    new FlattenedPinnedImagesRowIdFilter(parameter),
                    _provider,
                    transaction).FirstOrDefault();

                if (existing != null)
                {
                    return new PinnedImageData(
                        existing.Id,
                        existing.ImageDirectory,
                        existing.IsDisplayedToDesk,
                        existing.FrameThickness,
                        existing.RotationAngle,
                        existing.LocationX,
                        existing.LocationY,
                        existing.Width,
                        existing.Height,
                        existing.CaptionText,
                        existing.IsCaptionDisplayed,
                        existing.ShadowOpacity,
                        existing.ShadowDepth,
                        existing.ShadowDirection,
                        existing.ShadowBlurRadius,
                        existing.IsShadowHidden);
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            finally
            {
                transaction?.Dispose();
            }

            return null;
        }
    }
}
