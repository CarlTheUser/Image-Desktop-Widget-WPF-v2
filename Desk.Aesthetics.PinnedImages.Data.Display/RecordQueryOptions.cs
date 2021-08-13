namespace Desk.Aesthetics.PinnedImages.Data.Display
{
    public class RecordQueryOptions
    {
        public int PageSize { get; }
        public int Page { get; }
        public RecordQueryOptions(int pageSize, int page)
        {
            PageSize = pageSize;
            Page = page;
        }
    }
}
