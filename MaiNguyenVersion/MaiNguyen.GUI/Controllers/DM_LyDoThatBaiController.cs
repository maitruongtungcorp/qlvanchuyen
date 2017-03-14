using log4net;
using MaiNguyen.Entities.DM_LyDoThatBai;
using MaiNguyen.GUI.Business.Common;
using MaiNguyen.GUI.Business.Implements.CommonBus;
using MaiNguyen.GUI.Business.Implements.DM_LyDoThatBaiBus;
using MaiNguyen.GUI.Business.Interfaces.CommonBus;
using MaiNguyen.GUI.Business.Interfaces.DM_LyDoThatBaiBus;
using MaiNguyen.GUI.Business.ViewModel.DM_LyDoThatBai;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaiNguyen.GUI.Controllers
{
    [Authorize]
    public class DM_LyDoThatBaiController : Controller
    {
        #region dung chung
        private IDM_LyDoThatBaiBusinessUI _dm_LyDoThatBaiBusGui;
        private ICommonBusinessUI _commonBusGui;
        protected static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        #endregion
        public DM_LyDoThatBaiController()
        {
            ViewBag.LDThatBai = "current-page";
        }
        // GET: DM_LyDoThatBai
        public ActionResult Index()
        {
            var result = new DM_LyDoThatBaiViewModel();
            try
            {
                _dm_LyDoThatBaiBusGui = new DM_LyDoThatBaiBusinessUI();
                var search = new DM_LyDoThatBaiPagingCriteria();
                var tempList = _dm_LyDoThatBaiBusGui.DanhSachDM_LyDoThatBai(search);
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
        public ActionResult Index(DM_LyDoThatBaiViewModel model)
        {
            try
            {
                _dm_LyDoThatBaiBusGui = new DM_LyDoThatBaiBusinessUI();
                var temp = _dm_LyDoThatBaiBusGui.DanhSachDM_LyDoThatBai(model.SearchModel);
                var result = new DM_LyDoThatBaiViewModel();
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
                var result = new DM_LyDoThatBaiViewModel();
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
            var result = new DM_LyDoThatBaiAddModel();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    _dm_LyDoThatBaiBusGui = new DM_LyDoThatBaiBusinessUI();
                    int idDM = Int32.Parse(id);
                    result = _dm_LyDoThatBaiBusGui.GetDM_LyDoThatBaiById(idDM);
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
        public ActionResult Update(DM_LyDoThatBaiAddModel model)
        {
            string name = "";
            HttpCookie userCookie = Request.Cookies["_nsinfo"];
            if (userCookie != null)
            {
                name = userCookie["name"].ToString();
            }
            try
            {
                if (ModelState.IsValid)
                {
                    _dm_LyDoThatBaiBusGui = new DM_LyDoThatBaiBusinessUI();
                    //Sửa
                    if (model.Id > 0)
                    {
                        model.ModifiedBy = name;
                        bool result = _dm_LyDoThatBaiBusGui.UpdateDM_LyDoThatBai(model);
                        if (result)
                            return RedirectToAction("Index").WithSuccess(ThongBaoHeThong.SuccessUpdate); ;
                    }
                    //Thêm mới
                    else
                    {
                        model.CreatedBy = name;
                        bool result = _dm_LyDoThatBaiBusGui.ThemMoiDM_LyDoThatBai(model);
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
                _dm_LyDoThatBaiBusGui = new DM_LyDoThatBaiBusinessUI();
                if (string.IsNullOrEmpty(id))
                    return Json(false);
                int idKhach = Int32.Parse(id);
                bool result = _dm_LyDoThatBaiBusGui.DeleteDM_LyDoThatBai(idKhach, "ThanhNguyen");
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