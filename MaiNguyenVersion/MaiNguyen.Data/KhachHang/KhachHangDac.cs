using log4net;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.KhachHang;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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

        #region Method

        public List<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria)
        {
            try
            {
                return _database.ExecuteSprocAccessor<KhachHangModel>("DanhSachKhachHang", objCriteria).ToList();
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return null;
            }
        }

        #endregion Method
    }
}