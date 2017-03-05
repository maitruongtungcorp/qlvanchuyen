using log4net;
using MaiNguyen.Data.UnitOfWork;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MaiNguyen.Data.KhachHang
{
    /// <summary>
    /// Khach hang data access component.
    /// </summary>
    public class KhachHangDac : DataAccessComponent
    {
        #region Dung chung

        protected static readonly ILog log = LogManager.GetLogger(typeof(KhachHangDac));

        private Database _database;
        private IUnitOfWork _unitOfWork;

        public KhachHangDac(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork.QuanLyVanChuyenDatabase;
            _unitOfWork = unitOfWork;
        }
        #endregion Dung chung
    }
}