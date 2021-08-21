using Data.Common.Contracts;
using Desk.Aesthetics.PinnedImages.Data.Display;
using System.Collections.Generic;

namespace Desk.Aesthetics.PinnedImages.Infrastructure.Data.Display
{
    public class AllDisplayedToDeskPinnedImageDataQuery : IQuery<IEnumerable<PinnedImageData>>
    {
        private readonly string _connection;

        public AllDisplayedToDeskPinnedImageDataQuery(string connection)
        {
            _connection = connection;
        }

        public IEnumerable<PinnedImageData> Execute()
        {
            return new PinnedImageDataSqlQuery(_connection)
                .Filter(PinnedImageDataSqlQuery.IsDisplayedToDeskFilter(true))
                .Execute();
        }
    }
}
