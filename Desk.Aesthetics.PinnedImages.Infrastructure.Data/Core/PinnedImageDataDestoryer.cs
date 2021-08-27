using Data.Common.Contracts;
using Data.Sql;
using Data.Sql.Provider;
using System;
using System.Data;
using System.Linq;

namespace Desk.Aesthetics.PinnedImages.Infrastructure.Data.Core
{
    public class PinnedImageDataDestoryer : IDataDestroyer<Guid>
    {
        private readonly ISqlCaller _caller;

        private readonly ISqlProvider _provider;

        private readonly FlattenedPinnedImagesRowDao _dao = new FlattenedPinnedImagesRowDao();

        public PinnedImageDataDestoryer(string connection)
        {
            _caller = new SqlCaller(_provider = new SQLiteProvider(connection));
        }

        public void Destroy(Guid item)
        {
            SqlTransaction transaction = default;

            try
            {
                transaction = _caller.CreateScopedTransaction(IsolationLevel.ReadCommitted);

                FlattenedPinnedImagesRow existing = _dao.Find(
                    new FlattenedPinnedImagesRowIdFilter(item),
                    _provider,
                    transaction).FirstOrDefault();

                if (existing != null)
                {
                    _dao.DeleteItem(
                        existing,
                        _provider,
                        transaction);
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}
