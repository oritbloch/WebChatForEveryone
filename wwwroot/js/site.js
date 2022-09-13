// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



$(document).ready(function () {
    
    setInterval(getAllTextRequest, 5000); //pull requests from server every 5 minutes
    
});

function getAllTextRequest() {

    $.ajax({
        type: "get",
        url: AllTexturl
    }).done(function (res) {
        $("#allText").html(res);
    });;
}


function onSignIn(x) { //google api signin function
        
    //$("#username").val(some info from google?);
    $(".display - 4").html("Welcome " + $("#username").val());
    $("#g_id_onload").hide();
    
    $("#Screen").show();
}

