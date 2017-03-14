using MaiNguyen.Entities.DM_LyDoThatBai;
using PagedList;
using System;

namespace MaiNguyen.GUI.Business.ViewModel.DM_LyDoThatBai
{
    public class DM_LyDoThatBaiViewModel
    {
        public DM_LyDoThatBaiPagingCriteria SearchModel { get; set; }
        public IPagedList<DM_LyDoThatBaiModel> Items { get; set; }
    }
}