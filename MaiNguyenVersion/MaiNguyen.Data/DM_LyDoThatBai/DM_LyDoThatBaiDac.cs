using log4net;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.DM_LyDoThatBai;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
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

        #endregion Dung chung

        #region Method

        public List<DM_LyDoThatBaiModel> DanhSachDM_LyDoThatBai(DM_LyDoThatBaiPagingCriteria objCriteria)
        {
            try
            {
                return _database.ExecuteSprocAccessor<DM_LyDoThatBaiModel>("DanhSachDM_LyDoThatBai", objCriteria.Search, objCriteria.PageNum, objCriteria.PageSize).ToList();
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
