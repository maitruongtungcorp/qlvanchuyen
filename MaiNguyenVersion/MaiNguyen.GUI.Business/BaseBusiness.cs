using MaiNguyen.Service.Implements;
using MaiNguyen.Service.Implements.KhachHang;
using MaiNguyen.Service.Implements.Login;
using MaiNguyen.Service.Interfaces;
using MaiNguyen.Service.Interfaces.KhachHang;
using MaiNguyen.Service.Interfaces.Login;

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
    public class LoginBusiness
    {
        protected ILoginServices dbContext;
        public LoginBusiness()
        {
            dbContext = new LoginServices();
        }
    }
}
