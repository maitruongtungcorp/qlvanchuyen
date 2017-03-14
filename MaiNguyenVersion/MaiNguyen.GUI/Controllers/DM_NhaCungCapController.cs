using log4net;
using MaiNguyen.Entities.DM_NhaCungCap;
using MaiNguyen.GUI.Business.Common;
using MaiNguyen.GUI.Business.Implements.CommonBus;
using MaiNguyen.GUI.Business.Implements.DM_NhaCungCapBus;
using MaiNguyen.GUI.Business.Interfaces.CommonBus;
using MaiNguyen.GUI.Business.Interfaces.DM_NhaCungCapBus;
using MaiNguyen.GUI.Business.ViewModel.DM_NhaCungCap;
using System;
using System.Web;
using System.Web.Mvc;

namespace MaiNguyen.GUI.Controllers
{
    [Authorize]
    public class DM_NhaCungCapController : Controller
    {
        #region dung chung

        private IDM_NhaCungCapBusinessUI _dm_NhaCungCapBusGui;
        private ICommonBusinessUI _commonBusGui;
        protected static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion dung chung
        public DM_NhaCungCapController()
        {
            ViewBag.NhaCC = "current-page";
        }
        // GET: DM_LyDoThatBai
        public ActionResult Index()
        {
            var result = new DM_NhaCungCapViewModel();
            try
            {
                _dm_NhaCungCapBusGui = new DM_NhaCungCapBusinessUI();
                var search = new DM_NhaCungCapPagingCriteria();
                var tempList = _dm_NhaCungCapBusGui.DanhSachDM_NhaCungCap(search);
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
        public ActionResult Index(DM_NhaCungCapViewModel model)
        {
            try
            {
                _dm_NhaCungCapBusGui = new DM_NhaCungCapBusinessUI();
                var temp = _dm_NhaCungCapBusGui.DanhSachDM_NhaCungCap(model.SearchModel);
                var result = new DM_NhaCungCapViewModel();
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
                var result = new DM_NhaCungCapViewModel();
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
            var result = new DM_NhaCungCapAddModel();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    _dm_NhaCungCapBusGui = new DM_NhaCungCapBusinessUI();
                    int idDM = Int32.Parse(id);
                    result = _dm_NhaCungCapBusGui.GetDM_NhaCungCapById(idDM);
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
        public ActionResult Update(DM_NhaCungCapAddModel model)
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
                    _dm_NhaCungCapBusGui = new DM_NhaCungCapBusinessUI();
                    if (model.Id > 0)
                    {
                        model.ModifiedBy = name;
                        bool result = _dm_NhaCungCapBusGui.UpdateDM_NhaCungCap(model);
                        if (result)
                            return RedirectToAction("Index").WithSuccess(ThongBaoHeThong.SuccessUpdate); ;
                    }
                    else
                    {
                        model.CreatedBy = name;
                        bool result = _dm_NhaCungCapBusGui.ThemMoiDM_NhaCungCap(model);
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
                _dm_NhaCungCapBusGui = new DM_NhaCungCapBusinessUI();
                if (string.IsNullOrEmpty(id))
                    return Json(false);
                int idKhach = Int32.Parse(id);
                bool result = _dm_NhaCungCapBusGui.DeleteDM_NhaCungCap(idKhach, "ThanhNguyen");
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