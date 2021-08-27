using Data.Sql;
using Data.Sql.Mapping;
using Data.Sql.Querying;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace Desk.Aesthetics.PinnedImages.Infrastructure.Data.Core
{

    internal class FlattenedPinnedImagesRowDao : IDao<FlattenedPinnedImagesRow>
    {

        public void InsertItem(FlattenedPinnedImagesRow row, ISqlProvider provider, SqlTransaction transaction)
        {
            _ = transaction.ExecuteNonQuery(
                provider.CreateCommand(
                    "Insert Into FlattenedPinnedImages(Id,ImageDirectory,IsDisplayedToDesk,FrameThickness,RotationAngle,LocationX,LocationY,Width,Height,CaptionText,IsCaptionDisplayed,ShadowOpacity,ShadowDepth,ShadowDirection,ShadowBlurRadius,IsShadowHidden,Created) Values (@Id,@ImageDirectory,@IsDisplayedToDesk,@FrameThickness,@RotationAngle,@LocationX,@LocationY,@Width,@Height,@CaptionText,@IsCaptionDisplayed,@ShadowOpacity,@ShadowDepth,@ShadowDirection,@ShadowBlurRadius,@IsShadowHidden,@Created);",
                    CommandType.Text,
                    provider.CreateInputParameters(
                        new
                        {
                            row.Id,
                            row.ImageDirectory,
                            row.IsDisplayedToDesk,
                            row.FrameThickness,
                            row.RotationAngle,
                            row.LocationX,
                            row.LocationY,
                            row.Width,
                            row.Height,
                            row.CaptionText,
                            row.IsCaptionDisplayed,
                            row.ShadowOpacity,
                            row.ShadowDepth,
                            row.ShadowDirection,
                            row.ShadowBlurRadius,
                            row.IsShadowHidden,
                            row.Created
                        }, "@")));
        }

        public void UpdateItem(FlattenedPinnedImagesRow row, ISqlProvider provider, SqlTransaction transaction)
        {
            _ = transaction.ExecuteNonQuery(
                provider.CreateCommand(
                    "Update FlattenedPinnedImages Set ImageDirectory=@ImageDirectory,IsDisplayedToDesk=@IsDisplayedToDesk,FrameThickness=@FrameThickness,RotationAngle=@RotationAngle,LocationX=@LocationX,LocationY=@LocationY,Width=@Width,Height=@Height,CaptionText=@CaptionText,IsCaptionDisplayed=@IsCaptionDisplayed,ShadowOpacity=@ShadowOpacity,ShadowDepth=@ShadowDepth,ShadowDirection=@ShadowDirection,ShadowBlurRadius=@ShadowBlurRadius,IsShadowHidden=@IsShadowHidden,Created=@Created Where Id=@Id;",
                    CommandType.Text,
                    provider.CreateInputParameters(
                        new
                        {
                            row.Id,
                            row.ImageDirectory,
                            row.IsDisplayedToDesk,
                            row.FrameThickness,
                            row.RotationAngle,
                            row.LocationX,
                            row.LocationY,
                            row.Width,
                            row.Height,
                            row.CaptionText,
                            row.IsCaptionDisplayed,
                            row.ShadowOpacity,
                            row.ShadowDepth,
                            row.ShadowDirection,
                            row.ShadowBlurRadius,
                            row.IsShadowHidden,
                            row.Created
                        }, "@")));
        }

        public void DeleteItem(FlattenedPinnedImagesRow row, ISqlProvider provider, SqlTransaction transaction)
        {
            _ = transaction.ExecuteNonQuery(
                provider.CreateCommand(
                    "Delete From FlattenedPinnedImages Where Id=@Id;",
                    CommandType.Text,
                    provider.CreateInputParameters(
                        new
                        {
                            row.Id
                        }, "@")));
        }

        public IEnumerable<FlattenedPinnedImagesRow> Find(QueryFilter filter, ISqlProvider provider, SqlTransaction transaction)
        {
            DbCommand command = provider.CreateCommand(
                "Select Id,ImageDirectory,IsDisplayedToDesk,FrameThickness,RotationAngle,LocationX,LocationY,Width,Height,CaptionText,IsCaptionDisplayed,ShadowOpacity,ShadowDepth,ShadowDirection,ShadowBlurRadius,IsShadowHidden,Created From FlattenedPinnedImages Where " + filter.ToSqlClause(),
                CommandType.Text,
                filter.GetParameters());

            return transaction.Get(new ReflectionDataMapper<FlattenedPinnedImagesRow>(), command);
        }
    }
}
