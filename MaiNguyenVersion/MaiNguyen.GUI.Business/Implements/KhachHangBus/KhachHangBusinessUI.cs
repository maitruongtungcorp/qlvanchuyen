using MaiNguyen.Entities.KhachHang;
using MaiNguyen.GUI.Business.Common;
using MaiNguyen.GUI.Business.Interfaces.KhachHangBus;
using MaiNguyen.Service.Implements.KhachHang;
using MaiNguyen.Service.Interfaces.KhachHang;
using PagedList;
using System.Collections.Generic;

namespace MaiNguyen.GUI.Business.Implements.KhachHangBus
{
    public class KhachHangBusinessUI : IKhachHangBusinessUI
    {
        protected IKhachHangServices khachHangService;

        public KhachHangBusinessUI() : base()
        {
        }

        public IPagedList<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria)
        {
            if (!objCriteria.PageNum.HasValue)
            {
                objCriteria.PageNum = 1;
            }
            if (!objCriteria.PageSize.HasValue)
            {
                objCriteria.PageSize = int.Parse(ConfigSettings.ReadSetting("pageSize"));
            }
            khachHangService = new KhachHangServices();
            var listKhachHang = khachHangService.DanhSachKhachHang(objCriteria);
            return listKhachHang;
        }
        public bool ThemMoiKhachHang(KhachHangAddModel model)
        {
            khachHangService = new KhachHangServices();
            bool result = khachHangService.ThemMoiKhachHang(model);
            return result;
        }
        public KhachHangAddModel GetKhachHangById(int Id)
        {
            khachHangService = new KhachHangServices();
            return khachHangService.GetKhachHangById(Id);
        }
        public bool UpdateKhachHang(KhachHangAddModel model)
        {
            khachHangService = new KhachHangServices();
            bool result = khachHangService.UpdateKhachHang(model);
            return result;
        }
        public bool DeleteKhachHang(int id, string user)
        {
            khachHangService = new KhachHangServices();
            bool result = khachHangService.DeleteKhachHang(id, user);
            return result;
        }
    }
}