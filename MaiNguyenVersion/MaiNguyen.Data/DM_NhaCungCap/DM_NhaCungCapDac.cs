using log4net;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.DM_NhaCungCap;
using Microsoft.Practices.EnterpriseLibrary.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Data.DM_NhaCungCap
{
    public class DM_NhaCungCapDac : DataAccessComponent
    {
        #region Dung chung
        protected static readonly ILog log = LogManager.GetLogger(typeof(DM_NhaCungCapDac));

        private Database _database;
        private IUnitOfWork _unitOfWork;

        public DM_NhaCungCapDac(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork.QuanLyVanChuyenDatabase;
            _unitOfWork = unitOfWork;
        }

        #endregion 

        #region Method
        public IPagedList<DM_NhaCungCapModel> DanhSachDM_NhaCungCap(DM_NhaCungCapPagingCriteria objCriteria)
        {
            try
            {
                var lstDM_NhaCungCap = _database.ExecuteSprocAccessor<DM_NhaCungCapModel>("DanhSachDM_NhaCungCap", DataAccessCommon.Entity2ArrObjectValue(objCriteria)).ToList();
                if (lstDM_NhaCungCap != null && lstDM_NhaCungCap.Count > 0)
                {
                    return new StaticPagedList<DM_NhaCungCapModel>(lstDM_NhaCungCap, objCriteria.PageNum.Value, objCriteria.PageSize.Value, lstDM_NhaCungCap[0].Total);
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
        public bool ThemMoiDM_NhaCungCap(DM_NhaCungCapAddModel model)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Insert_DM_NhaCungCap"))
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
        public DM_NhaCungCapAddModel GetDM_NhaCungCapById(int Id)
        {
            try
            {
                return _database.ExecuteSprocAccessor<DM_NhaCungCapAddModel>("GetDM_NhaCungCapById", Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return null;
            }
        }
        public bool UpdateDM_NhaCungCap(DM_NhaCungCapAddModel model)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Update_DM_NhaCungCap"))
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
        public bool DeleteDM_NhaCungCap(int id, string user)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Delete_DM_NhaCungCap"))
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
