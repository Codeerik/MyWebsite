// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//Javascript for filling the output select boxes on CV page
$("#SelectCvFunction").change(function () {
    //$("#CvCompany").val("change");
    var actionUrl = $("#CvGetActionUrl").val();
    var info = $("#SelectCvFunction").val();

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        data: { functionId: info },
        success: function (data) {

            $('#CvCompany').text(data.bedrijf);
            $('#CvStartDate').text(data.start);
            $('#CvEndDate').text(data.finish);
            $('#CvWebsite').text(data.website);
            $('#CvFunctionContent').text(data.werkzaamheden);
        }
    });
});

// CV page dropdown select box interactivity
$('.dropdown-el').click(function (e) {
    e.preventDefault();
    e.stopPropagation();
    $(this).toggleClass('expanded');
    $('#' + $(e.target).attr('for')).prop('checked', true);
});
$(document).click(function () {
    $('.dropdown-el').removeClass('expanded');
});