using MaiNguyen.Entities.DM_LyDoThatBai;
using MaiNguyen.GUI.Business.Interfaces.DM_LyDoThatBaiBus;
using MaiNguyen.Service.Implements.DM_LyDoThatBai;
using MaiNguyen.Service.Interfaces.DM_LyDoThatBai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Implements.DM_LyDoThatBaiBus
{
    public class DM_LyDoThatBaiBusinessUI : IDM_LyDoThatBaiBusinessUI
    {
        protected IDM_LyDoThatBaiServices DM_LyDoThatBaiService;
        public DM_LyDoThatBaiBusinessUI() : base() { }
        public List<DM_LyDoThatBaiModel> DanhSachDM_LyDoThatBai(DM_LyDoThatBaiPagingCriteria objCriteria)
        {
            DM_LyDoThatBaiService = new DM_LyDoThatBaiServices();
            var listDM_LyDoThatBai = DM_LyDoThatBaiService.DanhSachDM_LyDoThatBai(objCriteria);
            return listDM_LyDoThatBai;
        }
    }
}
