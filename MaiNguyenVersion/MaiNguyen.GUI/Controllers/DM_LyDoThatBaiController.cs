using MaiNguyen.Entities.DM_LyDoThatBai;
using MaiNguyen.GUI.Business.Implements.DM_LyDoThatBaiBus;
using MaiNguyen.GUI.Business.Interfaces.DM_LyDoThatBaiBus;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiNguyen.GUI.Controllers
{
    public class DM_LyDoThatBaiController : Controller
    {
        IDM_LyDoThatBaiBusinessUI bus = new DM_LyDoThatBaiBusinessUI();
        // GET: DM_LyDoThatBai
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List(string name = "", int page = 1, int size = 10, string sort = "id", string direction = "desc")
        {
            DM_LyDoThatBaiPagingCriteria objCriteria = new DM_LyDoThatBaiPagingCriteria();
            objCriteria.Search = name;
            objCriteria.PageNum = page;
            objCriteria.PageSize = size;
            var list = bus.DanhSachDM_LyDoThatBai(objCriteria);
            ViewBag.TotalPage = (int)Math.Ceiling((decimal)list[0].total / list.Count);
            return PartialView(list.ToPagedList(page, size));
        }
    }
}