using MaiNguyen.Service.Implements;
using MaiNguyen.Service.Implements.KhachHang;
using MaiNguyen.Service.Interfaces;
using MaiNguyen.Service.Interfaces.KhachHang;

namespace MaiNguyen.GUI.Business
{
    public class BaseBusiness
    {
        protected ITestService dbContext;
        public BaseBusiness()
        {
            dbContext = new TestService();
        }
    }
    public class KhachHangBusiness
    {
        protected IKhachHangServices dbContext;
        public KhachHangBusiness()
        {
            dbContext = new KhachHangServices();
        }
    }
}
