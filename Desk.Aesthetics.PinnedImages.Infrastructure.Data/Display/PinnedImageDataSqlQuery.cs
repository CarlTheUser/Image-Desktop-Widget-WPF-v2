using Data.Sql.Provider;
using Data.Sql;
using Data.Sql.Querying;
using Desk.Aesthetics.PinnedImages.Data.Display;
using System;
using System.Collections.Generic;
using Data.Sql.Mapping;
using System.Data.Common;
using System.Data;
using System.Linq;

namespace Desk.Aesthetics.PinnedImages.Infrastructure.Data.Display
{
    internal class PinnedImageDataSqlQuery : SqlQuery<PinnedImageData>
    {
        private const string BASE_QUERY = "Select F.Id,F.ImageDirectory,F.FrameThickness,F.RotationAngle,F.LocationX,F.LocationY,F.Width,F.Height,F.CaptionText,F.IsCaptionDisplayed,F.ShadowOpacity,F.ShadowDepth,F.ShadowDirection,F.ShadowBlurRadius,F.IsShadowHidden From FlattenedPinnedImages F ";

        private readonly ISqlCaller _caller;

        private readonly ISqlProvider _provider;

        public PinnedImageDataSqlQuery(string connection)
        {
            _caller = new SqlCaller(_provider = new SQLiteProvider(connection));
        }

        public override IEnumerable<PinnedImageData> Execute()
        {
            string query = BASE_QUERY;

            bool usesParameter = false;

            DbParameter[] parameters = null;

            if (_filter != null)
            {
                usesParameter = _filter.UsesParameter;

                query += $"Where {_filter.ToSqlClause()} ";

                parameters = _filter.GetParameters();
            }

            DbCommand command = usesParameter ? _provider.CreateCommand(query, CommandType.Text, parameters) : _provider.CreateCommand(query);

            IEnumerable<DataHolder> items = _caller.Get(new ReflectionDataMapper<DataHolder>(), command);

            return from item in items
                   select new PinnedImageData(
                        item.Id,
                        item.ImageDirectory,
                        item.FrameThickness,
                        item.RotationAngle,
                        item.LocationX,
                        item.LocationY,
                        item.Width,
                        item.Height,
                        item.CaptionText,
                        item.IsCaptionDisplayed,
                        item.ShadowOpacity,
                        item.ShadowDepth,
                        item.ShadowDirection,
                        item.ShadowBlurRadius,
                        item.IsShadowHidden);
        }

        private class DataHolder
        {
            public Guid Id { get; set; }
            public string ImageDirectory { get; set; }
            public double FrameThickness { get; set; }
            public double RotationAngle { get; set; }
            public double LocationX { get; set; }
            public double LocationY { get; set; }
            public double Width { get; set; }
            public double Height { get; set; }
            public string CaptionText { get; set; }
            public bool IsCaptionDisplayed { get; set; }
            public double ShadowOpacity { get; set; }
            public double ShadowDepth { get; set; }
            public double ShadowDirection { get; set; }
            public double ShadowBlurRadius { get; set; }
            public bool IsShadowHidden { get; set; }
        }

        private class IsDisplayedToDeskFilter : QueryFilter
        {
            public bool IsDisplayedToDesk { get; set; }

            public IsDisplayedToDeskFilter()
            {

            }

            public IsDisplayedToDeskFilter(bool isDisplayedToDesk)
            {
                IsDisplayedToDesk = isDisplayedToDesk;
            }

            public override string ToSqlClause()
            {
                return $"F.IsDisplayedToDesk = {IsDisplayedToDesk.ToSqliteValue()} ";
            }
        }
    }
}
