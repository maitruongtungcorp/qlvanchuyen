using log4net;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaiNguyen.Data.Common
{
    public class CommonDac : DataAccessComponent
    {
        #region Dung chung

        protected static readonly ILog log = LogManager.GetLogger(typeof(CommonDac));

        private Database _database;
        private IUnitOfWork _unitOfWork;

        public CommonDac(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork.QuanLyVanChuyenDatabase;
            _unitOfWork = unitOfWork;
        }

        #endregion Dung chung

        public List<ThanhPhoModel> DanhSachThanhPho()
        {
            try
            {
                var lstKhachHang = _database.ExecuteSprocAccessor<ThanhPhoModel>("DanhSachThanhPho").ToList();
                if (lstKhachHang != null && lstKhachHang.Count > 0)
                {
                    return lstKhachHang;
                }
                return null;
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return null;
            }
        }
    }
}