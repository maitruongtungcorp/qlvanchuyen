using MaiNguyen.Entities.KhachHang;
using PagedList;

namespace MaiNguyen.GUI.Business.Interfaces.KhachHangBus

{
    public interface IKhachHangBusinessUI
    {
        IPagedList<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria);
        bool ThemMoiKhachHang(KhachHangAddModel model);
        KhachHangAddModel GetKhachHangById(int Id);
        bool UpdateKhachHang(KhachHangAddModel model);
        bool DeleteKhachHang(int id, string user);
    }
}