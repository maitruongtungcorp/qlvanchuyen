var DM_NhaCungCap = function (options) {
    for (var property in options) {
        this[property] = options[property];
    }
    return this.Initialize(options);
}
DM_NhaCungCap.prototype = {
    Initialize: function (options) {
        this.RegisterEvent();
    },
    RegisterEvent: function () {
        this.IsPaging = false;
        var that = this;
        if (!Common.Empty(Common.DM_NhaCungCap)) {
            that = Common.DM_NhaCungCap;
        }
        $("#ThanhPhoID").select2();
        //keyup hoten khach
        $("#form-update-khachhang").find("input[name='TenKH']").unbind("keyup").keyup(function () {
            var maKhachHang = Common.DM_NhaCungCap.CreateCodeKhachHang(Common.DM_NhaCungCap.TenDangNhap, $(this).val(), $("#form-update-khachhang").find("input[name='DienThoai']").val());
            if (!Common.Empty(maKhachHang)) {
                $("#form-update-khachhang").find("input[name='MaKH']").val(maKhachHang);
            }
        });
        $("#khachhang-search-form").find("select[name='SearchModel.PageSize']").unbind("change").change(function () {
            Common.DM_NhaCungCap.SubmitForm();
        })
        $(".delete-dm_nhacungcap").unbind("click").click(function () {
            event.preventDefault();
            var id = $(this).data("value");
            if (Common.Empty(id)) {
                Common.ShowAlert("Thông báo", "Dữ liệu cần xóa không tồn tại!!!", {
                    Close: { Display: true },
                }, "close");
                return false;
            }
            Common.ShowAlert("Thông báo", "Xóa dữ liệu đang chọn?", {
                Close: { Display: true },
                Items: {
                    Cancel: {
                        Name: "Cancel",
                        Data: $(this),
                        Class: "btn-info ",
                        OnClick: function (target) {
                            Common.HideAlert();
                            Common.Ajax({
                                type: "POST",
                                url: Common.DM_NhaCungCap.Url.Delete,
                                async: false,
                                cache: false,
                                data: {
                                    id: id
                                }
                            }, function (data) {
                                if (data == true) {
                                    Common.HideAlert();
                                    Common.DM_NhaCungCap.SubmitForm();
                                }
                                else {
                                    Common.ShowAlert("Thông báo", "Xóa không thành công.", {
                                        Close: { Display: true },
                                    }, "close");
                                    return false;
                                }
                            });
                        },
                        Value: "Xóa"
                    }
                }
            }, "Cancel");
            return false;
        });
    },
    CreateCodeKhachHang: function (tenDangNhap, tenKhachHang, sodienthoai) {
        var maKhachHang = "";
        if (!Common.Empty(tenKhachHang) && !Common.Empty(tenDangNhap) && !Common.Empty(sodienthoai)) {
            var arrKh = $.trim(tenKhachHang).split(" ");
            var tempTenKh = arrKh.pop();
            var tempSoDienThoai = sodienthoai.replace(/\s/g, "");
            maKhachHang = tenDangNhap + "-" + tempTenKh + "-" + tempSoDienThoai.substr(tempSoDienThoai.length - 3)
        }
        return maKhachHang;
    },
    Paging: function (page) {
        $("#khachhang-search-form").find("input[name='SearchModel.PageNum']").val(page);
        Common.DM_NhaCungCap.SubmitForm();
        return false;
    },
    GetCurrentPage: function (target) {
        try {
            page = 1;
            if (parseInt($(target).text()) > 0) {
                page = parseInt($(target).text());
            } else {
                page = parseInt($(".paging-top .pagination ul li.active").filter(function () { return !($(this).hasClass("previous") || $(this).hasClass("next")); }).text());
                if ($(target).closest("li").hasClass("previous")) {
                    page -= 1;
                } else {
                    page += 1;
                }
            }

            if (page > 0) {
            } else {
                page = 1;
            }
        } catch (ex) {
            page = 1;
        }

        return page;
    },
    BeforeSend: function () {
        Common.ShowLoading(true);
        if (this.nodeName == "A") {
            page = Common.DM_NhaCungCap.GetCurrentPage($(this));
            $("#khachhang-search-form").find("input[name='SearchModel.PageNum']").val(page);
            Common.DM_NhaCungCap.SubmitForm();
            return false;
        }
        else {
            $("#khachhang-search-form").find("input[name='SearchModel.PageNum']").val(1);
        }
    },
    Error: function () {
        Common.ShowAlert("Thông báo", "Có lỗi xảy ra khi lấy dữ liệu. Xin vui lòng thử lại.", {
            Close: { Display: true },
        }, "close");
    },
    SubmitForm: function () {
        $("#khachhang-search-form").submit();
    },
    Success: function () {
        Common.ShowLoading(false);
        Common.DM_NhaCungCap.RegisterEvent();
    }
};
// create DM_LyDoThatBai Object
var DM_NhaCungCap = DM_NhaCungCap;
DM_NhaCungCap.constructor = DM_NhaCungCap;

