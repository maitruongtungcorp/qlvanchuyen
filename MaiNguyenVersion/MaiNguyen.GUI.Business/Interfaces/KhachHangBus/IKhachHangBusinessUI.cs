using MaiNguyen.Entities.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MaiNguyen.GUI.Business.Interfaces.KhachHangBus
{
    public interface IKhachHangBusinessUI
    {
        List<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria);
    }
}