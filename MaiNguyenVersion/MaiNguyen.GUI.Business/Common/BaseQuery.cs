using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaiNguyen.GUI.Business.Common
{
    public class BaseQuery
    {
        //Get danh sách Số dòng hiển thị
        public static IEnumerable<SelectListItem> GetBinaryPageEntries()
        {
            return new List<SelectListItem>()
                   {
                       new SelectListItem()
                       {
                           Text = "10",
                           Value = "10"
                       },
                       new SelectListItem()
                       {
                           Text = "25",
                           Value = "25"
                       },
                       new SelectListItem()
                       {
                         Text = "50",
                         Value = "50"
                       },
                       new SelectListItem()
                       {
                         Text = "100",
                         Value = "100"
                       },
                   };
        }

    }
}
