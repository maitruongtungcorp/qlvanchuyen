using MaiNguyen.Entities.KhachHang;
using PagedList;

namespace MaiNguyen.GUI.Business.ViewModel.KhachHang
{
    public class KhachHangViewModel
    {
        public KhachHangPagingCriteria SearchModel { get; set; }
        public IPagedList<KhachHangModel> Items { get; set; }
    }
}