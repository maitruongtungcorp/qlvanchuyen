using MaiNguyen.Entities.DM_DonViGiaoHang;
using PagedList;

namespace MaiNguyen.GUI.Business.ViewModel.DM_DonViGiaoHang
{
    public class DM_DonViGiaoHangViewModel
    {
        public DM_DonViGiaoHangPagingCriteria SearchModel { get; set; }
        public IPagedList<DM_DonViGiaoHangModel> Items { get; set; }
    }
}