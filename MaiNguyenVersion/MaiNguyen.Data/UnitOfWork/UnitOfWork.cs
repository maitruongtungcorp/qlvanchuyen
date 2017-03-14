using System.Transactions;
using Microsoft.Practices.EnterpriseLibrary.Data;
namespace MaiNguyen.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Members
        private TransactionScope _transactionScope;
        #endregion

        #region Constructor
        public UnitOfWork(bool beginTransaction = true)
        {
            if (beginTransaction)
            {
                _transactionScope = new TransactionScope();
            }
        }
        #endregion

        #region Properties
        private Database _QuanLyVanChuyen;
        public Database QuanLyVanChuyenDatabase
        {
            get { return _QuanLyVanChuyen ?? (_QuanLyVanChuyen = DatabaseFactories.CreateQuanLyVanChuyenDatabase()); }
        }
        public TransactionScope Transaction
        {
            get { return _transactionScope; }
        }
        #endregion

        #region Methods
        public void Dispose()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Dispose();
            }
        }

        public void SaveChanges()
        {
            if (_transactionScope != null)
            {
                _transactionScope.Complete();
            }
        }
        #endregion
    }
}
