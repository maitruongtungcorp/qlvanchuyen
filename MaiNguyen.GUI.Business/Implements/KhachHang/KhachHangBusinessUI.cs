using AutoMapper;
using MaiNguyen.Entities.KhachHang;
using MaiNguyen.GUI.Business.Interfaces.KhachHang;
using MaiNguyen.GUI.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Implements.KhachHang
{
    public class KhachHangBusinessUI : KhachHangBusiness, IKhachHangBusinessUI
    {
        public KhachHangBusinessUI() : base() { }
        public List<KhachHangViewModel> GetTest()
        {
            var temp = dbContext.GetTest();
            var list = Mapper.Map<List<KhachHangModel>, List<KhachHangViewModel>>(temp);
            return list;
        }
    }
}
