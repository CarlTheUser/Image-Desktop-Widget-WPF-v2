using Data.Sql.Querying;
using Desk.Aesthetics.PinnedImages.Utilities.Misc;
using System;

namespace Desk.Aesthetics.PinnedImages.Infrastructure.Data.Core
{
    internal class FlattenedPinnedImagesRowIdFilter : QueryFilter
    {
        public Guid Id { get; set; }

        public FlattenedPinnedImagesRowIdFilter()
        {

        }

        public FlattenedPinnedImagesRowIdFilter(Guid id)
        {
            Id = id;
        }

        public override string ToSqlClause()
        {
            return $"Id = = X'{Id.ToByteArray().FormatBytesString()}'";
        }
    }
}
