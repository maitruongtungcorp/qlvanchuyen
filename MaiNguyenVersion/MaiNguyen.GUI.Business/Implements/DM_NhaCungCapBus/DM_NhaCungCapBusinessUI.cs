using MaiNguyen.Entities.DM_NhaCungCap;
using MaiNguyen.GUI.Business.Common;
using MaiNguyen.GUI.Business.Interfaces.DM_NhaCungCapBus;
using MaiNguyen.Service.Implements.DM_NhaCungCap;
using MaiNguyen.Service.Interfaces.DM_NhaCungCap;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.Implements.DM_NhaCungCapBus
{
    public class DM_NhaCungCapBusinessUI : IDM_NhaCungCapBusinessUI
    {
        protected IDM_NhaCungCapServices DM_NhaCungCapService;

        public DM_NhaCungCapBusinessUI() : base()
        {
        }

        public IPagedList<DM_NhaCungCapModel> DanhSachDM_NhaCungCap(DM_NhaCungCapPagingCriteria objCriteria)
        {
            if (!objCriteria.PageNum.HasValue)
            {
                objCriteria.PageNum = 1;
            }
            if (!objCriteria.PageSize.HasValue)
            {
                objCriteria.PageSize = int.Parse(ConfigSettings.ReadSetting("pageSize"));
            }
            DM_NhaCungCapService = new DM_NhaCungCapServices();
            var listDM_NhaCungCap = DM_NhaCungCapService.DanhSachDM_NhaCungCap(objCriteria);
            return listDM_NhaCungCap;
        }
        public bool ThemMoiDM_NhaCungCap(DM_NhaCungCapAddModel model)
        {
            DM_NhaCungCapService = new DM_NhaCungCapServices();
            bool result = DM_NhaCungCapService.ThemMoiDM_NhaCungCap(model);
            return result;
        }
        public DM_NhaCungCapAddModel GetDM_NhaCungCapById(int Id)
        {
            DM_NhaCungCapService = new DM_NhaCungCapServices();
            return DM_NhaCungCapService.GetDM_NhaCungCapById(Id);
        }
        public bool UpdateDM_NhaCungCap(DM_NhaCungCapAddModel model)
        {
            DM_NhaCungCapService = new DM_NhaCungCapServices();
            bool result = DM_NhaCungCapService.UpdateDM_NhaCungCap(model);
            return result;
        }
        public bool DeleteDM_NhaCungCap(int id, string user)
        {
            DM_NhaCungCapService = new DM_NhaCungCapServices();
            bool result = DM_NhaCungCapService.DeleteDM_NhaCungCap(id, user);
            return result;
        }
    }
}
