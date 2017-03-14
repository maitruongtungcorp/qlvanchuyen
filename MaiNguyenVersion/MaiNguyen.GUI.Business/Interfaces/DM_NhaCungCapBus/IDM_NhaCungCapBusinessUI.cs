using MaiNguyen.Entities.DM_NhaCungCap;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Interfaces.DM_NhaCungCapBus
{
    public interface IDM_NhaCungCapBusinessUI
    {
        IPagedList<DM_NhaCungCapModel> DanhSachDM_NhaCungCap(DM_NhaCungCapPagingCriteria objCriteria);
        bool ThemMoiDM_NhaCungCap(DM_NhaCungCapAddModel model);
        DM_NhaCungCapAddModel GetDM_NhaCungCapById(int Id);
        bool UpdateDM_NhaCungCap(DM_NhaCungCapAddModel model);
        bool DeleteDM_NhaCungCap(int id, string user);
    }
}
