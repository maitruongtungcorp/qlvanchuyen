using System;
using System.Transactions;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MaiNguyen.Data.UnitOfWork
{
    public interface IUnitOfWork: IDisposable
    {
        Database QuanLyVanChuyenDatabase { get; }
        void SaveChanges();
        TransactionScope Transaction { get; }
    }
}
