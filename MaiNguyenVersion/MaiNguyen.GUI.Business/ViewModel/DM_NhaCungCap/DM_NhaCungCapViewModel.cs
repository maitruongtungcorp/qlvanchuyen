using MaiNguyen.Entities.DM_NhaCungCap;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaiNguyen.GUI.Business.ViewModel.DM_NhaCungCap
{
    public class DM_NhaCungCapViewModel
    {
        public DM_NhaCungCapPagingCriteria SearchModel { get; set; }
        public IPagedList<DM_NhaCungCapModel> Items { get; set; }
    }
}
