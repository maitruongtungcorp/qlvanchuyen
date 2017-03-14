//var l = null;

/**********************click on filter button***************************/
$("body").on("click", "#filter-btn", function (event) {
    event.preventDefault();

    $("#page-number").val("1");
    l = Ladda.create(this);
    l.start();
    LoadList();
});

/*******************delete option item *********************************/
//$("body").on("click", ".common-list .link-delete", function (event) {
//    event.preventDefault();
//    $("#option-action").val($(this).attr("data-action"));//the current action for
//    DeleteConfirmationModal($(this).attr("data-name"), $(this).attr("data-id"));
//});
/*******************change page size***********************************/
$('body').on("change", ".common-list #select-page-size", function (event) {
    $('#page-number').val("1");
    $('#page-size').val($(this).val());
    LoadList();
});
/*******************click on pagination number*************************/
$('body').on("click", ".common-list .pagination a", function (event) {
    event.preventDefault();
    var link = $(this).attr("href");
    $('#page-number').val(link.replace("/?page=", ""));
    LoadList();
});

/******************call on sort click, from common.js ****************/
function LoadTableData() {
    LoadList();
}
