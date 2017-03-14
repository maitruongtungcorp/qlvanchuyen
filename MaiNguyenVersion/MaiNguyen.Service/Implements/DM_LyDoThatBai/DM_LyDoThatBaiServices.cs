using log4net;
using MaiNguyen.Data.DM_LyDoThatBai;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.DM_LyDoThatBai;
using MaiNguyen.Service.Interfaces.DM_LyDoThatBai;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Implements.DM_LyDoThatBai
{
    public class DM_LyDoThatBaiServices : IDM_LyDoThatBaiServices
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(DM_LyDoThatBaiServices));

        public DM_LyDoThatBaiServices() : base()
        {
        }

        public IPagedList<DM_LyDoThatBaiModel> DanhSachDM_LyDoThatBai(DM_LyDoThatBaiPagingCriteria objCriteria)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_LyDoThatBaiDac qlDac = new DM_LyDoThatBaiDac(unitOfWork);
                    var lstDM_LyDoThatBai = qlDac.DanhSachDM_LyDoThatBai(objCriteria);
                    return lstDM_LyDoThatBai;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return null;
                }
            }
        }
        public bool ThemMoiDM_LyDoThatBai(DM_LyDoThatBaiAddModel model)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_LyDoThatBaiDac qlDac = new DM_LyDoThatBaiDac(unitOfWork);
                    bool result = qlDac.ThemMoiDM_LyDoThatBai(model);
                    return result;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return false;
                }
            }
        }
        public DM_LyDoThatBaiAddModel GetDM_LyDoThatBaiById(int Id)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_LyDoThatBaiDac qlDac = new DM_LyDoThatBaiDac(unitOfWork);
                    var result = qlDac.GetDM_LyDoThatBaiById(Id);
                    return result;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return null;
                }
            }
        }
        public bool UpdateDM_LyDoThatBai(DM_LyDoThatBaiAddModel model)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_LyDoThatBaiDac qlDac = new DM_LyDoThatBaiDac(unitOfWork);
                    bool result = qlDac.UpdateDM_LyDoThatBai(model);
                    return result;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return false;
                }
            }
        }
        public bool DeleteDM_LyDoThatBai(int id, string user)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_LyDoThatBaiDac qlDac = new DM_LyDoThatBaiDac(unitOfWork);
                    bool result = qlDac.DeleteDM_LyDoThatBai(id, user);
                    return result;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return false;
                }
            }
        }
    }
}
