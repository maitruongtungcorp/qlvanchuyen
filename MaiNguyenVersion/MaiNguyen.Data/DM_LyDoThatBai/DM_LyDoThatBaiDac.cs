using log4net;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.DM_LyDoThatBai;
using Microsoft.Practices.EnterpriseLibrary.Data;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Data.DM_LyDoThatBai
{
    public class DM_LyDoThatBaiDac : DataAccessComponent
    {
        #region Dung chung
        protected static readonly ILog log = LogManager.GetLogger(typeof(DM_LyDoThatBaiDac));

        private Database _database;
        private IUnitOfWork _unitOfWork;

        public DM_LyDoThatBaiDac(IUnitOfWork unitOfWork)
        {
            _database = unitOfWork.QuanLyVanChuyenDatabase;
            _unitOfWork = unitOfWork;
        }

        #endregion 

        #region Method
        public IPagedList<DM_LyDoThatBaiModel> DanhSachDM_LyDoThatBai(DM_LyDoThatBaiPagingCriteria objCriteria)
        {
            try
            {
                var lstDM_LyDoThatBai = _database.ExecuteSprocAccessor<DM_LyDoThatBaiModel>("DanhSachDM_LyDoThatBai", DataAccessCommon.Entity2ArrObjectValue(objCriteria)).ToList();
                if (lstDM_LyDoThatBai != null && lstDM_LyDoThatBai.Count > 0)
                {
                    return new StaticPagedList<DM_LyDoThatBaiModel>(lstDM_LyDoThatBai, objCriteria.PageNum.Value, objCriteria.PageSize.Value, lstDM_LyDoThatBai[0].Total);
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
        public bool ThemMoiDM_LyDoThatBai(DM_LyDoThatBaiAddModel model)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Insert_DM_LyDoThatBai"))
                {
                    // Set parameter values.
                    //_database.AddInParameter(cmd, "@Id", DbType.String, model.Id);
                    _database.AddInParameter(cmd, "@LyDo", DbType.String, model.LyDo);
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
        public DM_LyDoThatBaiAddModel GetDM_LyDoThatBaiById(int Id)
        {
            try
            {
                return _database.ExecuteSprocAccessor<DM_LyDoThatBaiAddModel>("GetDM_LyDoThatBaiById", Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                log.Error(ex.Message);
                return null;
            }
        }
        public bool UpdateDM_LyDoThatBai(DM_LyDoThatBaiAddModel model)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Update_DM_LyDoThatBai"))
                {
                    // Set parameter values.
                    _database.AddInParameter(cmd, "@Id", DbType.Int32, model.Id);
                    _database.AddInParameter(cmd, "@LyDo", DbType.String, model.LyDo);
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
        public bool DeleteDM_LyDoThatBai(int id, string user)
        {
            try
            {
                bool result = false;
                Database _database = DatabaseFactory.CreateDatabase(QLVANCHUYEN_CONNECTION);
                using (DbCommand cmd = _database.GetStoredProcCommand("Delete_DM_LyDoThatBai"))
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
