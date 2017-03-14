using MaiNguyen.Entities.DM_DonViGiaoHang;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Interfaces.DM_DonViGiaoHang
{
    public interface IDM_DonViGiaoHangBusinessUI
    {
        IPagedList<DM_DonViGiaoHangModel> DanhSachDM_DonViGiaoHang(DM_DonViGiaoHangPagingCriteria objCriteria);
        bool ThemMoiDM_DonViGiaoHang(DM_DonViGiaoHangAddModel model);
        DM_DonViGiaoHangAddModel GetDM_DonViGiaoHangById(int Id);
        bool UpdateDM_DonViGiaoHang(DM_DonViGiaoHangAddModel model);
        bool DeleteDM_DonViGiaoHang(int id, string user);
    }
}
