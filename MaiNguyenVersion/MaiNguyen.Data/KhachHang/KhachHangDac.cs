using log4net;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.KhachHang;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Linq;
using PagedList;
using System.Data.Common;
using System.Data;

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

        #endregion 

        #region Method
        public IPagedList<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria)
        {
            try
            {
                var lstKhachHang = _database.ExecuteSprocAccessor<KhachHangModel>("DanhSachKhachHang", DataAccessCommon.Entity2ArrObjectValue(objCriteria)).ToList();
                if(lstKhachHang != null && lstKhachHang.Count > 0)
                {
                    return new StaticPagedList<KhachHangModel>(lstKhachHang, objCriteria.PageNum.Value, objCriteria.PageSize.Value, lstKhachHang[0].Total);
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
        public bool ThemMoiKhachHang(KhachHangAddModel model)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Insert_KhachHang"))
                {
                    // Set parameter values.
                    _database.AddInParameter(cmd, "@MaKH", DbType.String, model.MaKH);
                    _database.AddInParameter(cmd, "@TenKH", DbType.String, model.TenKH);
                    _database.AddInParameter(cmd, "@DienThoai", DbType.String, model.DienThoai);
                    _database.AddInParameter(cmd, "@Email", DbType.String, model.Email);
                    _database.AddInParameter(cmd, "@DiaChi", DbType.String, model.DiaChi);
                    _database.AddInParameter(cmd, "@TenCongTy", DbType.String, model.TenCongTy);
                    _database.AddInParameter(cmd, "@Sales", DbType.String, model.Sales);
                    _database.AddInParameter(cmd, "@GhiChu", DbType.String, model.GhiChu);
                    _database.AddInParameter(cmd, "@ThanhPhoID", DbType.Int32, model.ThanhPhoID);
                    _database.AddInParameter(cmd, "@SoDonHang", DbType.Int32, model.SoDonHang);
                    _database.AddInParameter(cmd, "@CreatedBy", DbType.String, model.Sales);
                    if (_database.ExecuteNonQuery(cmd) > 0)
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return false;
            }
        }
        public KhachHangAddModel GetKhachHangById(int Id)
        {
            try
            {
                return _database.ExecuteSprocAccessor<KhachHangAddModel>("GetKhachHangById", Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return null;
            }
        }
        public bool UpdateKhachHang(KhachHangAddModel model)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Update_KhachHang"))
                {
                    // Set parameter values.
                    _database.AddInParameter(cmd, "@Id", DbType.Int32, model.Id);
                    _database.AddInParameter(cmd, "@MaKH", DbType.String, model.MaKH);
                    _database.AddInParameter(cmd, "@TenKH", DbType.String, model.TenKH);
                    _database.AddInParameter(cmd, "@DienThoai", DbType.String, model.DienThoai);
                    _database.AddInParameter(cmd, "@Email", DbType.String, model.Email);
                    _database.AddInParameter(cmd, "@DiaChi", DbType.String, model.DiaChi);
                    _database.AddInParameter(cmd, "@TenCongTy", DbType.String, model.TenCongTy);
                    _database.AddInParameter(cmd, "@Sales", DbType.String, model.Sales);
                    _database.AddInParameter(cmd, "@GhiChu", DbType.String, model.GhiChu);
                    _database.AddInParameter(cmd, "@ThanhPhoID", DbType.Int32, model.ThanhPhoID);
                    _database.AddInParameter(cmd, "@SoDonHang", DbType.Int32, model.SoDonHang);
                    _database.AddInParameter(cmd, "@CreatedBy", DbType.String, model.Sales);
                    if (_database.ExecuteNonQuery(cmd) > 0)
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return false;
            }
        }
        public bool DeleteKhachHang(int id, string user)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Delete_KhachHang"))
                {
                    // Set parameter values.
                    _database.AddInParameter(cmd, "@Id", DbType.Int32, id);
                    _database.AddInParameter(cmd, "@CreatedBy", DbType.String, user);
                    if (_database.ExecuteNonQuery(cmd) > 0)
                    {
                        result = true;
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return false;
            }
        }
        #endregion Method
    }
}