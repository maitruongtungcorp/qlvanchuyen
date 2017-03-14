using MaiNguyen.GUI.Business.Implements.Login;
using MaiNguyen.GUI.Business.Interfaces.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MaiNguyen.GUI.Controllers
{
    public class LoginController : Controller
    {
        ILoginBusinessUI bus = new LoginBusinessUI();
        // GET: Login
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("", "home");
            }
            else
            {
                return RedirectToAction("login");
            }
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public JsonResult Login(string username, string password, string returnUrl, bool rememberMe = false)
        {
            try
            {
                var model = bus.Login(username, password);

                if (model != null)
                //if (true)
                {
                    //string cs = model.Id + " " + model.LastName + " " + model.Password;
                    HttpCookie cookie = new HttpCookie("_nsinfo");
                    //cookie["cs"] = DSB.Core.Helpers.CryptoHelpers.EncryptStringAES(cs, DSB.Core.Constants.SHARED_SECRET);
                    //cookie["store"] = model.LastName;
                    cookie["name"] = model.LastName;
                    cookie["storeId"] = model.Id.ToString();
                    //cookie["storeAddress"] = model.Address;
                    cookie["address"] = model.Address;
                    cookie["phone"] = model.Phone.ToString();
                    cookie.Expires = DateTime.Today.AddDays(1);
                    Response.Cookies.Add(cookie);

                    FormsAuthentication.SetAuthCookie(username, rememberMe);

                    return Json(new { Result = true, Url = returnUrl });
                }
                else
                {
                    return Json(new { Result = false, Message = "Tài khoản hoặc mật khẩu chưa đúng" });
                }
            }
            catch
            {
                return Json(new { Result = false, Message = "Tài khoản hoặc mật khẩu chưa đúng" });
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login", "Login");
        }
    }
}