// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Displays feedback to the user with a server response message regarding log in.
// Expects the id of an HTML element to display the message in, i.e. "#myId".
function LoginResponse(elementId, data) {
    $(elementId).html(data.message);
    $("#LoginUserUserName").val("");
    $("#LoginUserPassWord").val("");

    if (data.success == true) {

        setTimeout(function () {
            $(elementId).text("");
            $("#LoginUserModal").modal('hide');
            $("#LoginPartialView").load($("#LoginPartialViewUrl").val());
            window.location = data.action;
        }, 3000);

        
    }
    else {
        setTimeout(function () {
            $(elementId).text("");

        }, 3000);
    };

}
