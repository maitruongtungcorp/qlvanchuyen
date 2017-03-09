var l;

/////////////////////////// LIST METHODS /////////////////////////////
/********************************Load List ****************************/
function LoadList() {
    var jdata = PrepearJasonData('filter-item');
    //alert(JSON.stringify(jdata));
    $('#loading').show();
    $.ajax({
        type: 'POST',
        url: '/DM_LyDoThatBai/List',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(jdata),
        success: function (data) {
            $('#content-box').html(data);
            InitSortingHeader("content-box");
        },
        error: function (e) {
            //alert(e.responseText);
            //l.stop();
        }
    }).done(function () {
        //l.stop();
    });
}

///////////////////////////// FORM METHODS /////////////////////////////
//function InitForm() {
//    //get item id
//    var id = $("#CODE").val();

//    //init select items
//    $(".select2-item").select2();
//    $('.datetimepicker').datetimepicker({
//        pickTime: false,
//        //Default: true,
//        //format: 'DD/MM/YYYY'
//    });
//    if (id > 0) {
//        $("#delete-btn").show();
//        $("#CreatedBy").select2("enable", false);
//        $("#SupplierID").select2("enable", false);
//    }

//    ResetDisplay();
//    LoadItemList();
//}

///************************************************************/
//$('form').submit(function (event) {
//    if ($(this).valid()) { // validation passed
//        // cal your jquery function here
//        event.preventDefault();

//        // Automatically trigger the loading animation on click
//        var l = Ladda.create(document.getElementById("save-btn"));
//        l.start();

//        $(".delete-btn").prop("disabled", true);
//        $("#back-btn").prop("disabled", true);

//        var jsonData = PrepearJasonFormData("main-form");

//        var data = "{'model':" + JSON.stringify(jsonData) + "}";
//        //alert(data); l.stop(); return;
//        $.ajax({
//            type: 'POST',
//            contentType: "application/json; charset=utf-8",
//            url: '/Menu/Save',
//            dataType: 'json',
//            data: data,
//            success: function (data) {
//                $(".delete-btn").prop("disabled", false);
//                $("#back-btn").prop("disabled", false);
//                l.stop();
//                if (data.Result) {
//                    alertify.success(data.Message);
//                    $("#POID").val(data.Id);
//                    InitForm();
//                } else {
//                    alertify.error(data.Message);
//                }
//            },
//            error: function (e) {
//                l.stop
//                $(".delete-btn").prop("disabled", false);
//                $("#back-btn").prop("disabled", false);
//            }
//        });
//    }
//});
///*******************load form ****************************************/
//$("body").on("click", ".load-form", function (event) {
//    event.preventDefault();

//    var orderId = $("#POID").val();

//    if (orderId <= 0) {
//        alertify.error("Please save Order first!");
//        return;
//    }

//    var id = $(this).attr("data-id");
//    var supplierId = $("#SupplierID").val();

//    // Automatically trigger the loading animation on click
//    l = Ladda.create(this);
//    l.start();

//    $.ajax({
//        type: 'POST',
//        url: '/Order/ItemForm/',
//        data: { 'id': id, 'orderId': orderId, 'supplierId': supplierId },
//        success: function (data) {
//            ShowFormModal("ADD PRODUCT", data, "");
//            $.validator.unobtrusive.parse('.item-form');
//            $(".select2-item").select2();
//        },
//        error: function (e) {
//            //alert(e.responseText);
//            l.stop();
//        }
//    }).done(function () {
//        l.stop();
//    });
//});
///*******************delete item *************************************/
//$("body").on("click", ".link-delete", function (event) {
//    event.preventDefault();

//    $("#option-action").val($(this).attr("data-action"));

//    var id = $(this).attr("data-id");
//    var name = $(this).attr("data-name");

//    DeleteConfirmationModal(name, id)
//});
///****************************focus Index********************************/
//$("body").on("focus", "#ZIndex", function (event) {
//    $(this).select();
//});
/****************************search********************************/
$(".filter-item").on("keydown", function (event) {
    if (event.which == 13)
        LoadList();
});