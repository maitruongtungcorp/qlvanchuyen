using MaiNguyen.Entities.DM_LyDoThatBai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Interfaces.DM_LyDoThatBaiBus
{
    public interface IDM_LyDoThatBaiBusinessUI
    {
        List<DM_LyDoThatBaiModel> DanhSachDM_LyDoThatBai(DM_LyDoThatBaiPagingCriteria objCriteria);
    }
}
