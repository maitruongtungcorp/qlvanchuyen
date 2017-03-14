using MaiNguyen.Entities.Common;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MaiNguyen.GUI.Business.Interfaces.CommonBus
{
    public interface ICommonBusinessUI
    {
        IEnumerable<SelectListItem> DanhSachThanhPho();
    }
}