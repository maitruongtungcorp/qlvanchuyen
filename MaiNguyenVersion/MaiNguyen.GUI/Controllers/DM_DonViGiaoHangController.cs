using log4net;
using MaiNguyen.Entities.DM_DonViGiaoHang;
using MaiNguyen.GUI.Business.Common;
using MaiNguyen.GUI.Business.Implements.CommonBus;
using MaiNguyen.GUI.Business.Implements.DM_DonViGiaoHang;
using MaiNguyen.GUI.Business.Interfaces.CommonBus;
using MaiNguyen.GUI.Business.Interfaces.DM_DonViGiaoHang;
using MaiNguyen.GUI.Business.ViewModel.DM_DonViGiaoHang;
using System;
using System.Web;
using System.Web.Mvc;

namespace MaiNguyen.GUI.Controllers
{
    [Authorize]
    public class DM_DonViGiaoHangController : Controller
    {
        #region dung chung

        private IDM_DonViGiaoHangBusinessUI _DM_DonViGiaoHangBusGui;
        private ICommonBusinessUI _commonBusGui;
        protected static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion dung chung
        public DM_DonViGiaoHangController()
        {
            ViewBag.DVGiaoHang = "current-page";
        }
        // GET: DM_LyDoThatBai
        public ActionResult Index()
        {
            var result = new DM_DonViGiaoHangViewModel();
            try
            {
                _DM_DonViGiaoHangBusGui = new DM_DonViGiaoHangBusinessUI();
                var search = new DM_DonViGiaoHangPagingCriteria();
                var tempList = _DM_DonViGiaoHangBusGui.DanhSachDM_DonViGiaoHang(search);
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
        public ActionResult Index(DM_DonViGiaoHangViewModel model)
        {
            try
            {
                _DM_DonViGiaoHangBusGui = new DM_DonViGiaoHangBusinessUI();
                var temp = _DM_DonViGiaoHangBusGui.DanhSachDM_DonViGiaoHang(model.SearchModel);
                var result = new DM_DonViGiaoHangViewModel();
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
                var result = new DM_DonViGiaoHangViewModel();
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
            var result = new DM_DonViGiaoHangAddModel();
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    _DM_DonViGiaoHangBusGui = new DM_DonViGiaoHangBusinessUI();
                    int idDM = Int32.Parse(id);
                    result = _DM_DonViGiaoHangBusGui.GetDM_DonViGiaoHangById(idDM);
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
        public ActionResult Update(DM_DonViGiaoHangAddModel model)
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
                    _DM_DonViGiaoHangBusGui = new DM_DonViGiaoHangBusinessUI();
                    if (model.Id > 0)
                    {
                        model.ModifiedBy = name;
                        bool result = _DM_DonViGiaoHangBusGui.UpdateDM_DonViGiaoHang(model);
                        if (result)
                            return RedirectToAction("Index").WithSuccess(ThongBaoHeThong.SuccessUpdate); ;
                    }
                    else
                    {
                        model.CreatedBy = name;
                        bool result = _DM_DonViGiaoHangBusGui.ThemMoiDM_DonViGiaoHang(model);
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
                _DM_DonViGiaoHangBusGui = new DM_DonViGiaoHangBusinessUI();
                if (string.IsNullOrEmpty(id))
                    return Json(false);
                int idKhach = Int32.Parse(id);
                bool result = _DM_DonViGiaoHangBusGui.DeleteDM_DonViGiaoHang(idKhach, "ThanhNguyen");
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