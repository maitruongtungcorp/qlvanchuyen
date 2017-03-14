using log4net;
using MaiNguyen.Data.KhachHang;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.KhachHang;
using MaiNguyen.Service.Interfaces.KhachHang;
using PagedList;
using System;
using System.Collections.Generic;

namespace MaiNguyen.Service.Implements.KhachHang
{
    public class KhachHangServices : IKhachHangServices
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(KhachHangServices));

        public KhachHangServices() : base()
        {
        }

        public IPagedList<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    KhachHangDac qlDac = new KhachHangDac(unitOfWork);
                    var lstKhachHang = qlDac.DanhSachKhachHang(objCriteria);
                    return lstKhachHang;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return null;
                }
            }
        }
        public bool ThemMoiKhachHang(KhachHangAddModel model)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    KhachHangDac qlDac = new KhachHangDac(unitOfWork);
                    bool result = qlDac.ThemMoiKhachHang(model);
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
        public KhachHangAddModel GetKhachHangById(int Id)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    KhachHangDac qlDac = new KhachHangDac(unitOfWork);
                    var result = qlDac.GetKhachHangById(Id);
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
        public bool UpdateKhachHang(KhachHangAddModel model)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    KhachHangDac qlDac = new KhachHangDac(unitOfWork);
                    bool result = qlDac.UpdateKhachHang(model);
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
        public bool DeleteKhachHang(int id, string user)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                try
                {
                    KhachHangDac qlDac = new KhachHangDac(unitOfWork);
                    bool result = qlDac.DeleteKhachHang(id, user);
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