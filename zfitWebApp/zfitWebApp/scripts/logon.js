
var testFunction = function (data) {
    alert("TestFunction: " + data.d.TransactionResult); 
};


var ajaxCall = function ajaxData(methodname, aThing) {

    $.ajax({
        type: "POST",
        url: "default.aspx/" + methodname,
        data: JSON.stringify(aThing),
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json"
    })
        .done(function (msg) {
            if (msg.d.TransactionResult === 1) {
                document.location = "http://www.google.com"; 
                //window.location.href = msg.d.TargetUrl;
            }
            else {
                alert(msg.d.Message);
            }
        })
        .fail(function (msg, jqXHR, textStatus) {
            alert("Request failed: " + textStatus + msg.d.TransactionResult);
        })
        //.always(function (jqXHR) {
        //    alert("Always alert: " + jqXHR.status);
        //})
};

//Method and click event for user logon 

var logonuser = function () {
    var message = "";
    var aUser = {};
    aUser.UsrID = d3.select("input#username").node().value;
    aUser.UsrPassword = d3.select("input#password").node().value;
    var User = { 'aUser': aUser };
    ajaxCall("userLogon", User);
}

var logonuserClick = d3.select("input#btnUsrLogon")
                .on("click", logonuser);

//Method and click event for fan logon 

var logonfan = function () {
    var message = "";
        var aFan = {};
        aFan.FanID = d3.select("input#username").node().value;
        aFan.FanPassword = d3.select("input#password").node().value;
        var Fan = { 'aFan': aFan };
        ajaxCall("fanLogon", Fan); 
    }

    var logonClick = d3.select("input#btnLogon")
                    .on("click", logonfan);

//Method and click event for registering 

var register = function () {

    var aFan = {};
    aFan.FanID = d3.select("input#emailsignup").node().value;
    aFan.FanEmail = d3.select("input#emailsignup").node().value;
    aFan.FanPassword = d3.select("input#passwordsignup").node().value;
    var Fan = { 'aFan': aFan };
    ajaxCall('fanRegister', Fan);
}

var registerClick = d3.select("input#btnRegister")
                .on("click", register);
