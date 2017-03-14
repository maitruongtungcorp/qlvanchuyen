using log4net;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.DM_DonViGiaoHang;
using Microsoft.Practices.EnterpriseLibrary.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Data.DM_DonViGiaoHang
{
    public class DM_DonViGiaoHangDac : DataAccessComponent
    {
        #region Dung chung
        protected static readonly ILog log = LogManager.GetLogger(typeof(DM_DonViGiaoHangDac));

        private Database _database;
        private IUnitOfWork _unitOfWork;

        public DM_DonViGiaoHangDac(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork.QuanLyVanChuyenDatabase;
            _unitOfWork = unitOfWork;
        }

        #endregion 

        #region Method
        public IPagedList<DM_DonViGiaoHangModel> DanhSachDM_DonViGiaoHang(DM_DonViGiaoHangPagingCriteria objCriteria)
        {
            try
            {
                var lstDM_DonViGiaoHang = _database.ExecuteSprocAccessor<DM_DonViGiaoHangModel>("DanhSachDM_DonViGiaoHang", DataAccessCommon.Entity2ArrObjectValue(objCriteria)).ToList();
                if (lstDM_DonViGiaoHang != null && lstDM_DonViGiaoHang.Count > 0)
                {
                    return new StaticPagedList<DM_DonViGiaoHangModel>(lstDM_DonViGiaoHang, objCriteria.PageNum.Value, objCriteria.PageSize.Value, lstDM_DonViGiaoHang[0].Total);
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
        public bool ThemMoiDM_DonViGiaoHang(DM_DonViGiaoHangAddModel model)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Insert_DM_DonViGiaoHang"))
                {
                    // Set parameter values.
                    //_database.AddInParameter(cmd, "@Id", DbType.String, model.Id);
                    _database.AddInParameter(cmd, "@Ten", DbType.String, model.Ten);
                    _database.AddInParameter(cmd, "@Deleted", DbType.String, model.Deleted);
                    _database.AddInParameter(cmd, "@CreatedBy", DbType.String, model.CreatedBy);
                    _database.AddInParameter(cmd, "@CreatedDate", DbType.String, DateTime.Now);
                    _database.AddInParameter(cmd, "@ModifiedBy", DbType.String, model.ModifiedBy);
                    _database.AddInParameter(cmd, "@ModifiedDate", DbType.String, DateTime.Now);
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
        public DM_DonViGiaoHangAddModel GetDM_DonViGiaoHangById(int Id)
        {
            try
            {
                return _database.ExecuteSprocAccessor<DM_DonViGiaoHangAddModel>("GetDM_DonViGiaoHangById", Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return null;
            }
        }
        public bool UpdateDM_DonViGiaoHang(DM_DonViGiaoHangAddModel model)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Update_DM_DonViGiaoHang"))
                {
                    // Set parameter values.
                    _database.AddInParameter(cmd, "@Id", DbType.Int32, model.Id);
                    _database.AddInParameter(cmd, "@Ten", DbType.String, model.Ten);
                    _database.AddInParameter(cmd, "@Deleted", DbType.String, model.Deleted);
                    _database.AddInParameter(cmd, "@CreatedBy", DbType.String, model.CreatedBy);
                    _database.AddInParameter(cmd, "@CreatedDate", DbType.String, DateTime.Now);
                    _database.AddInParameter(cmd, "@ModifiedBy", DbType.String, model.ModifiedBy);
                    _database.AddInParameter(cmd, "@ModifiedDate", DbType.String, DateTime.Now);
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
        public bool DeleteDM_DonViGiaoHang(int id, string user)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Delete_DM_DonViGiaoHang"))
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
