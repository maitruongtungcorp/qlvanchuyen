using MaiNguyen.GUI.Business.Implements.KhachHangBus;
using MaiNguyen.GUI.Business.Interfaces.KhachHangBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiNguyen.GUI.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: KhachHang
        IKhachHangBusinessUI bus = new KhachHangBusinessUI();
        public ActionResult Index()
        {
            return View();
        }
    }
}