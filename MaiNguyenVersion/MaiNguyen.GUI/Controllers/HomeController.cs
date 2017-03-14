using MaiNguyen.GUI.Business.Implements;
using MaiNguyen.GUI.Business.Implements.KhachHangBus;
using MaiNguyen.GUI.Business.Interfaces;
using MaiNguyen.GUI.Business.Interfaces.KhachHangBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiNguyen.GUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ITestBusinessUI bus = new TestBusinessUI();
        IKhachHangBusinessUI bus1 = new KhachHangBusinessUI();
        public ActionResult Index()
        {

            var test = bus.GetTest();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}