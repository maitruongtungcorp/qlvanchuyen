using MaiNguyen.Entities.KhachHang;
using PagedList;

namespace MaiNguyen.Service.Interfaces.KhachHang
{
    public interface IKhachHangServices
    {
        IPagedList<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria);
        bool ThemMoiKhachHang(KhachHangAddModel model);
        KhachHangAddModel GetKhachHangById(int Id);
        bool UpdateKhachHang(KhachHangAddModel model);
        bool DeleteKhachHang(int id, string user);
    }
}
