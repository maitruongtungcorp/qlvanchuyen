using MaiNguyen.Entities.DM_LyDoThatBai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Interfaces.DM_LyDoThatBai
{
    public interface IDM_LyDoThatBaiServices
    {
        List<DM_LyDoThatBaiModel> DanhSachDM_LyDoThatBai(DM_LyDoThatBaiPagingCriteria objCriteria);
    }
}
