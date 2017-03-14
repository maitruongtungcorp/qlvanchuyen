using MaiNguyen.Service.Implements;
using MaiNguyen.Service.Implements.DM_DonViGiaoHang;
using MaiNguyen.Service.Implements.DM_LyDoThatBai;
using MaiNguyen.Service.Implements.DM_NhaCungCap;
using MaiNguyen.Service.Implements.KhachHang;
using MaiNguyen.Service.Interfaces;
using MaiNguyen.Service.Interfaces.DM_DonViGiaoHang;
using MaiNguyen.Service.Interfaces.DM_LyDoThatBai;
using MaiNguyen.Service.Interfaces.DM_NhaCungCap;
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

    public class DM_LyDoThatBaiBusiness
    {
        protected IDM_LyDoThatBaiServices dbContext;

        public DM_LyDoThatBaiBusiness()
        {
            dbContext = new DM_LyDoThatBaiServices();
        }
    }

    public class DM_NhaCungCapBusiness
    {
        protected IDM_NhaCungCapServices dbContext;

        public DM_NhaCungCapBusiness()
        {
            dbContext = new DM_NhaCungCapServices();
        }
    }

    public class DM_DonViGiaoHangBusiness
    {
        protected IDM_DonViGiaoHangServices dbContext;

        public DM_DonViGiaoHangBusiness()
        {
            dbContext = new DM_DonViGiaoHangServices();
        }
    }
}