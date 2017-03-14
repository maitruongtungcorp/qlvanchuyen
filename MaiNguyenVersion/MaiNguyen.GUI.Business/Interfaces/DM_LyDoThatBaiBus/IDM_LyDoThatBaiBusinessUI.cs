using MaiNguyen.Entities.DM_LyDoThatBai;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Interfaces.DM_LyDoThatBaiBus
{
    public interface IDM_LyDoThatBaiBusinessUI
    {
        IPagedList<DM_LyDoThatBaiModel> DanhSachDM_LyDoThatBai(DM_LyDoThatBaiPagingCriteria objCriteria);
        bool ThemMoiDM_LyDoThatBai(DM_LyDoThatBaiAddModel model);
        DM_LyDoThatBaiAddModel GetDM_LyDoThatBaiById(int Id);
        bool UpdateDM_LyDoThatBai(DM_LyDoThatBaiAddModel model);
        bool DeleteDM_LyDoThatBai(int id, string user);
    }
}
