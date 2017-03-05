using log4net;
using MaiNguyen.Data.KhachHang;
using MaiNguyen.Data.UnitOfWork;
using MaiNguyen.Entities.KhachHang;
using MaiNguyen.Service.Interfaces.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Implements.KhachHang
{
    public class KhachHangServices : IKhachHangServices
    {
        protected static readonly ILog log = LogManager.GetLogger(typeof(TestService));
        public KhachHangServices() : base() { }
        public List<KhachHangModel> GetTest()
        {
            using (var unitOfWork = new UnitOfWork(false))
            {
                var lstTest = new List<KhachHangModel>();
                try
                {
                    KhachHangDac qlDac = new KhachHangDac(unitOfWork);
                    lstTest = qlDac.GetTest();
                    return lstTest;
                }
                catch (Exception ex)
                {
                    log4net.Config.XmlConfigurator.Configure();
                    log.Error(ex.Message);
                    return lstTest;
                }
            }

        }
    }
}
