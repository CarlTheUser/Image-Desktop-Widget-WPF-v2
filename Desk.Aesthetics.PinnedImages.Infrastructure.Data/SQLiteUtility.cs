namespace Desk.Aesthetics.PinnedImages.Infrastructure.Data
{
    internal static class SQLiteConversionUtility
    {
        public static int ToSqliteValue(this bool b)
        {
            return b ? 1 : 0;
        }

        public static bool FromSqliteInt(this long i)
        {
            return i > 0;
        }
    }
}
