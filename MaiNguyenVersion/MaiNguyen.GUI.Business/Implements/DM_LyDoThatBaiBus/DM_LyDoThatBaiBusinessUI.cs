using MaiNguyen.Entities.DM_LyDoThatBai;
using MaiNguyen.GUI.Business.Common;
using MaiNguyen.GUI.Business.Interfaces.DM_LyDoThatBaiBus;
using MaiNguyen.Service.Implements.DM_LyDoThatBai;
using MaiNguyen.Service.Interfaces.DM_LyDoThatBai;
using PagedList;
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

        public DM_LyDoThatBaiBusinessUI() : base()
        {
        }

        public IPagedList<DM_LyDoThatBaiModel> DanhSachDM_LyDoThatBai(DM_LyDoThatBaiPagingCriteria objCriteria)
        {
            if (!objCriteria.PageNum.HasValue)
            {
                objCriteria.PageNum = 1;
            }
            if (!objCriteria.PageSize.HasValue)
            {
                objCriteria.PageSize = int.Parse(ConfigSettings.ReadSetting("pageSize"));
            }
            DM_LyDoThatBaiService = new DM_LyDoThatBaiServices();
            var listDM_LyDoThatBai = DM_LyDoThatBaiService.DanhSachDM_LyDoThatBai(objCriteria);
            return listDM_LyDoThatBai;
        }
        public bool ThemMoiDM_LyDoThatBai(DM_LyDoThatBaiAddModel model)
        {
            DM_LyDoThatBaiService = new DM_LyDoThatBaiServices();
            bool result = DM_LyDoThatBaiService.ThemMoiDM_LyDoThatBai(model);
            return result;
        }
        public DM_LyDoThatBaiAddModel GetDM_LyDoThatBaiById(int Id)
        {
            DM_LyDoThatBaiService = new DM_LyDoThatBaiServices();
            return DM_LyDoThatBaiService.GetDM_LyDoThatBaiById(Id);
        }
        public bool UpdateDM_LyDoThatBai(DM_LyDoThatBaiAddModel model)
        {
            DM_LyDoThatBaiService = new DM_LyDoThatBaiServices();
            bool result = DM_LyDoThatBaiService.UpdateDM_LyDoThatBai(model);
            return result;
        }
        public bool DeleteDM_LyDoThatBai(int id, string user)
        {
            DM_LyDoThatBaiService = new DM_LyDoThatBaiServices();
            bool result = DM_LyDoThatBaiService.DeleteDM_LyDoThatBai(id, user);
            return result;
        }
    }
}
