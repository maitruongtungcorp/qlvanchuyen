using MaiNguyen.Entities.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Interfaces.KhachHang
{
    public interface IKhachHangServices
    {
        List<KhachHangModel> DanhSachKhachHang(KhachHangPagingCriteria objCriteria);
    }
}
