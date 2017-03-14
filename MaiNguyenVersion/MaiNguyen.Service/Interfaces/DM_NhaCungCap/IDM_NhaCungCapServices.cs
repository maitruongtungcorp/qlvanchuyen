using MaiNguyen.Entities.DM_NhaCungCap;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.Service.Interfaces.DM_NhaCungCap
{
    public interface IDM_NhaCungCapServices
    {
        IPagedList<DM_NhaCungCapModel> DanhSachDM_NhaCungCap(DM_NhaCungCapPagingCriteria objCriteria);
        bool ThemMoiDM_NhaCungCap(DM_NhaCungCapAddModel model);
        DM_NhaCungCapAddModel GetDM_NhaCungCapById(int Id);
        bool UpdateDM_NhaCungCap(DM_NhaCungCapAddModel model);
        bool DeleteDM_NhaCungCap(int id, string user);
    }
}
