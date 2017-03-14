using MaiNguyen.Entities.DM_DonViGiaoHang;
using MaiNguyen.GUI.Business.Common;
using MaiNguyen.GUI.Business.Interfaces.DM_DonViGiaoHang;
using MaiNguyen.Service.Implements.DM_DonViGiaoHang;
using MaiNguyen.Service.Interfaces.DM_DonViGiaoHang;
using PagedList;

namespace MaiNguyen.GUI.Business.Implements.DM_DonViGiaoHang
{
    public class DM_DonViGiaoHangBusinessUI : IDM_DonViGiaoHangBusinessUI
    {
        protected IDM_DonViGiaoHangServices DM_DonViGiaoHangService;

        public DM_DonViGiaoHangBusinessUI() : base()
        {
        }

        public IPagedList<DM_DonViGiaoHangModel> DanhSachDM_DonViGiaoHang(DM_DonViGiaoHangPagingCriteria objCriteria)
        {
            if (!objCriteria.PageNum.HasValue)
            {
                objCriteria.PageNum = 1;
            }
            if (!objCriteria.PageSize.HasValue)
            {
                objCriteria.PageSize = int.Parse(ConfigSettings.ReadSetting("pageSize"));
            }
            DM_DonViGiaoHangService = new DM_DonViGiaoHangServices();
            var listDM_DonViGiaoHang = DM_DonViGiaoHangService.DanhSachDM_DonViGiaoHang(objCriteria);
            return listDM_DonViGiaoHang;
        }

        public bool ThemMoiDM_DonViGiaoHang(DM_DonViGiaoHangAddModel model)
        {
            DM_DonViGiaoHangService = new DM_DonViGiaoHangServices();
            bool result = DM_DonViGiaoHangService.ThemMoiDM_DonViGiaoHang(model);
            return result;
        }

        public DM_DonViGiaoHangAddModel GetDM_DonViGiaoHangById(int Id)
        {
            DM_DonViGiaoHangService = new DM_DonViGiaoHangServices();
            return DM_DonViGiaoHangService.GetDM_DonViGiaoHangById(Id);
        }

        public bool UpdateDM_DonViGiaoHang(DM_DonViGiaoHangAddModel model)
        {
            DM_DonViGiaoHangService = new DM_DonViGiaoHangServices();
            bool result = DM_DonViGiaoHangService.UpdateDM_DonViGiaoHang(model);
            return result;
        }

        public bool DeleteDM_DonViGiaoHang(int id, string user)
        {
            DM_DonViGiaoHangService = new DM_DonViGiaoHangServices();
            bool result = DM_DonViGiaoHangService.DeleteDM_DonViGiaoHang(id, user);
            return result;
        }
    }
}