using log4net;
using MaiNguyen.Data.DM_DonViGiaoHang;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.DM_DonViGiaoHang;
using MaiNguyen.Service.Interfaces.DM_DonViGiaoHang;
using PagedList;
using System;

namespace MaiNguyen.Service.Implements.DM_DonViGiaoHang
{
    public class DM_DonViGiaoHangServices : IDM_DonViGiaoHangServices
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(DM_DonViGiaoHangServices));

        public DM_DonViGiaoHangServices() : base()
        {
        }

        public IPagedList<DM_DonViGiaoHangModel> DanhSachDM_DonViGiaoHang(DM_DonViGiaoHangPagingCriteria objCriteria)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_DonViGiaoHangDac qlDac = new DM_DonViGiaoHangDac(unitOfWork);
                    var lstDM_DonViGiaoHang = qlDac.DanhSachDM_DonViGiaoHang(objCriteria);
                    return lstDM_DonViGiaoHang;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return null;
                }
            }
        }

        public bool ThemMoiDM_DonViGiaoHang(DM_DonViGiaoHangAddModel model)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_DonViGiaoHangDac qlDac = new DM_DonViGiaoHangDac(unitOfWork);
                    bool result = qlDac.ThemMoiDM_DonViGiaoHang(model);
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

        public DM_DonViGiaoHangAddModel GetDM_DonViGiaoHangById(int Id)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_DonViGiaoHangDac qlDac = new DM_DonViGiaoHangDac(unitOfWork);
                    var result = qlDac.GetDM_DonViGiaoHangById(Id);
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

        public bool UpdateDM_DonViGiaoHang(DM_DonViGiaoHangAddModel model)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_DonViGiaoHangDac qlDac = new DM_DonViGiaoHangDac(unitOfWork);
                    bool result = qlDac.UpdateDM_DonViGiaoHang(model);
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

        public bool DeleteDM_DonViGiaoHang(int id, string user)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    DM_DonViGiaoHangDac qlDac = new DM_DonViGiaoHangDac(unitOfWork);
                    bool result = qlDac.DeleteDM_DonViGiaoHang(id, user);
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