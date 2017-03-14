using log4net;
using MaiNguyen.Entities.KhachHang;
using MaiNguyen.GUI.Business.Common;
using MaiNguyen.GUI.Business.Implements.KhachHangBus;
using MaiNguyen.GUI.Business.Interfaces.KhachHangBus;
using System;
using System.Web.Mvc;
using PagedList;
using MaiNguyen.GUI.Business.ViewModel.KhachHang;
using MaiNguyen.GUI.Business.Interfaces.CommonBus;
using MaiNguyen.GUI.Business.Implements.CommonBus;
namespace MaiNguyen.GUI.Controllers
{
    public class KhachHangController : Controller
    {
        #region dung chung
        private IKhachHangBusinessUI _khachHangBusGui;
        private ICommonBusinessUI _commonBusGui;
        protected static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        public KhachHangController()
        {
            ViewBag.KhachHang = "current-page";
        }
        // GET: KhachHang
        public ActionResult Index()
        {
            var result = new KhachHangViewModel();
            try
            {
                _khachHangBusGui = new KhachHangBusinessUI();
                var search = new KhachHangPagingCriteria();
                var tempList = _khachHangBusGui.DanhSachKhachHang(search);
                result.Items = tempList;
                result.SearchModel = search;
                return View(result);
            }
            catch (Exception ex)
            {
                log4net.Config.XmlConfigurator.Configure();
                _log.Error(ex.Message);
                return View(result);
            }
        }
        [HttpPost]
        public ActionResult Index(KhachHangViewModel model)
        {
            try
            {
                _khachHangBusGui = new KhachHangBusinessUI();
                var temp = _khachHangBusGui.DanhSachKhachHang(model.SearchModel);
                var result = new KhachHangViewModel();
                result.Items = temp;
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_IndexPartialView", result);
                }
                return View(result);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                var result = new KhachHangViewModel();
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_IndexPartialView", result);
                }
                return View(result);
            }
        }
        [HttpGet]
        public ActionResult Update(string id)
        {
            var result = new KhachHangAddModel();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    _khachHangBusGui = new KhachHangBusinessUI();
                    int idKhach = Int32.Parse(id);
                    result = _khachHangBusGui.GetKhachHangById(idKhach);
                }
                _commonBusGui = new CommonBusinessUI();
                ViewData["ListThanhPho"] = _commonBusGui.DanhSachThanhPho();
                ViewBag.TenDangNhap = "ThanhNguyen";
                return View(result);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return View(result);
            }
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult Update(KhachHangAddModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _khachHangBusGui = new KhachHangBusinessUI();
                    model.Sales = "ThanhNguyen";
                    if(model.Id > 0)
                    {
                        bool result = _khachHangBusGui.UpdateKhachHang(model);
                        if (result)
                            return RedirectToAction("Index").WithSuccess(ThongBaoHeThong.SuccessUpdate); ;
                    }
                    else
                    {
                        model.SoDonHang = 0;
                        bool result = _khachHangBusGui.ThemMoiKhachHang(model);
                        if (result)
                            return RedirectToAction("Index").WithSuccess(ThongBaoHeThong.SuccessCreate); ;
                    }
                    return View("Update", model);
                }
                else
                {
                    ModelState.AddModelError("", "Lỗi: Dữ liệu không đầy đủ!");
                }
                return View("Update", model).WithWarning(ThongBaoHeThong.WarningData);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return View("Update", model).WithError(ThongBaoHeThong.ErrorCatch);
            }
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            try
            {
                _khachHangBusGui = new KhachHangBusinessUI();
                if (string.IsNullOrEmpty(id))
                    return Json(false);
                int idKhach = Int32.Parse(id);
                bool result = _khachHangBusGui.DeleteKhachHang(idKhach, "ThanhNguyen");
                return Json(result);
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
                return Json(false);
            }
        }
    }
}