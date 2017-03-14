using log4net;
using MaiNguyen.Data.DM_NhaCungCap;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.DM_NhaCungCap;
using MaiNguyen.Service.Interfaces.DM_NhaCungCap;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Implements.DM_NhaCungCap
{
    public class DM_NhaCungCapServices : IDM_NhaCungCapServices
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(DM_NhaCungCapServices));

        public DM_NhaCungCapServices() : base()
        {
        }

        public IPagedList<DM_NhaCungCapModel> DanhSachDM_NhaCungCap(DM_NhaCungCapPagingCriteria objCriteria)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_NhaCungCapDac qlDac = new DM_NhaCungCapDac(unitOfWork);
                    var lstDM_NhaCungCap = qlDac.DanhSachDM_NhaCungCap(objCriteria);
                    return lstDM_NhaCungCap;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return null;
                }
            }
        }
        public bool ThemMoiDM_NhaCungCap(DM_NhaCungCapAddModel model)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_NhaCungCapDac qlDac = new DM_NhaCungCapDac(unitOfWork);
                    bool result = qlDac.ThemMoiDM_NhaCungCap(model);
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
        public DM_NhaCungCapAddModel GetDM_NhaCungCapById(int Id)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_NhaCungCapDac qlDac = new DM_NhaCungCapDac(unitOfWork);
                    var result = qlDac.GetDM_NhaCungCapById(Id);
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
        public bool UpdateDM_NhaCungCap(DM_NhaCungCapAddModel model)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_NhaCungCapDac qlDac = new DM_NhaCungCapDac(unitOfWork);
                    bool result = qlDac.UpdateDM_NhaCungCap(model);
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
        public bool DeleteDM_NhaCungCap(int id, string user)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_NhaCungCapDac qlDac = new DM_NhaCungCapDac(unitOfWork);
                    bool result = qlDac.DeleteDM_NhaCungCap(id, user);
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
