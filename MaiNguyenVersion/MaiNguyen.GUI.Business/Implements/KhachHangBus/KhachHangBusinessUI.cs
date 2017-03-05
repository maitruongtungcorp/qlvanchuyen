using MaiNguyen.Entities.KhachHang;
using MaiNguyen.GUI.Business.Interfaces.KhachHangBus;
using MaiNguyen.Service.Implements.KhachHang;
using MaiNguyen.Service.Interfaces.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Implements.KhachHangBus
{
    public class KhachHangBusinessUI: IKhachHangBusinessUI
    {
        protected IKhachHangServices khachHangService;
        public KhachHangBusinessUI() : base() { }
        public List<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria)
        {
            khachHangService = new KhachHangServices();
            var listKhachHang = khachHangService.DanhSachKhachHang(objCriteria);
            return listKhachHang;
        }
    }
}
