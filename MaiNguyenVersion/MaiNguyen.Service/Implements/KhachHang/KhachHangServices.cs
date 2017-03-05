using log4net;
using MaiNguyen.Data.KhachHang;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.KhachHang;
using MaiNguyen.Service.Interfaces.KhachHang;
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

        public List<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria)
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                var lstKhachHang = new List<KhachHangModel>();
                try
                {
                    KhachHangDac qlDac = new KhachHangDac(unitOfWork);
                    lstKhachHang = qlDac.DanhSachKhachHang(objCriteria);
                    return lstKhachHang;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return lstKhachHang;
                }
            }
        }
    }
}