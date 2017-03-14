using MaiNguyen.Entities.Common;
using MaiNguyen.GUI.Business.Interfaces.CommonBus;
using MaiNguyen.Service.Implements.Common;
using MaiNguyen.Service.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaiNguyen.GUI.Business.Implements.CommonBus
{
    public class CommonBusinessUI: ICommonBusinessUI
    {
        protected ICommonService commonService;

        public CommonBusinessUI() : base()
        {
        }
        public IEnumerable<SelectListItem> DanhSachThanhPho()
        {
            commonService = new CommonService();
            var tempThanhPho = commonService.DanhSachThanhPho();
            if (tempThanhPho != null && tempThanhPho.Count > 0)
            {
                return tempThanhPho.Select(x => new SelectListItem { Text = x.Ten, Value = x.Id.ToString() });
            }
            return null;
        }
    }
}
