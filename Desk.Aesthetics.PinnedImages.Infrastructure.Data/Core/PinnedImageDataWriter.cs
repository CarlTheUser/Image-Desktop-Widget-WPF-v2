﻿using Data.Common.Contracts;
using Data.Sql;
using Data.Sql.Provider;
using Desk.Aesthetics.PinnedImages.Core.Data;
using System.Data;
using System.Linq;

namespace Desk.Aesthetics.PinnedImages.Infrastructure.Data.Core
{
    public class PinnedImageDataWriter : IDataWriter<PinnedImageData>
    {
        private readonly ISqlCaller _caller;

        private readonly ISqlProvider _provider;

        private readonly FlattenedPinnedImagesRowDao _dao = new FlattenedPinnedImagesRowDao();

        public PinnedImageDataWriter(string connection)
        {
            _caller = new SqlCaller(_provider = new SQLiteProvider(connection));
        }

        public void Write(PinnedImageData data)
        {
            SqlTransaction transaction = default;

            try
            {
                transaction = _caller.CreateScopedTransaction(IsolationLevel.ReadCommitted);

                FlattenedPinnedImagesRow existing = _dao.Find(
                    new FlattenedPinnedImagesRowIdFilter(data.Id),
                    _provider,
                    transaction).FirstOrDefault();

                if(existing != null)
                {
                    existing.ImageDirectory = data.ImageDirectory;
                    existing.IsDisplayedToDesk = data.IsDisplayedToDesk;
                    existing.FrameThickness = data.FrameThickness;
                    existing.RotationAngle = data.RotationAngle;
                    existing.LocationX = data.LocationX;
                    existing.LocationY = data.LocationY;
                    existing.Width = data.Width;
                    existing.Height = data.Height;
                    existing.CaptionText = data.CaptionText;
                    existing.IsCaptionDisplayed = data.IsCaptionDisplayed;
                    existing.ShadowOpacity = data.ShadowOpacity;
                    existing.ShadowDepth = data.ShadowDepth;
                    existing.ShadowDirection = data.ShadowDirection;
                    existing.ShadowBlurRadius = data.ShadowBlurRadius;
                    existing.IsShadowHidden = data.IsShadowHidden;

                    _dao.UpdateItem(
                        existing,
                        _provider,
                        transaction);
                }
                else
                {
                    _dao.InsertItem(
                        new FlattenedPinnedImagesRow
                        {
                            Id = data.Id,
                            ImageDirectory = data.ImageDirectory,
                            IsDisplayedToDesk = data.IsDisplayedToDesk,
                            FrameThickness = data.FrameThickness,
                            RotationAngle = data.RotationAngle,
                            LocationX = data.LocationX,
                            LocationY = data.LocationY,
                            Width = data.Width,
                            Height = data.Height,
                            CaptionText = data.CaptionText,
                            IsCaptionDisplayed = data.IsCaptionDisplayed,
                            ShadowOpacity = data.ShadowOpacity,
                            ShadowDepth = data.ShadowDepth,
                            ShadowDirection = data.ShadowDirection,
                            ShadowBlurRadius = data.ShadowBlurRadius,
                            IsShadowHidden = data.IsShadowHidden
                        },
                        _provider,
                        transaction);
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
        }
    }
}
