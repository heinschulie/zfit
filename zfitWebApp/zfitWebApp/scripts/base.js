
var ajaxCall = function ajaxData(methodname, aThing, callback) {

    $.ajax({
        type: "POST",
        url: "" + methodname,
        data: JSON.stringify(aThing),
        contentType: "application/json; charset=utf-8",
        async: false,
        dataType: "json"
    })
        .done(function (msg) {
            if (msg.d.aTransactionStatus.TransactionResult === 1) {
                callback(msg.d.AnObject);
            }
            else {
                alert(msg.d.aTransactionStatus.Message);
            }
        })
        .fail(function (msg, jqXHR, textStatus) {
            //alert("Request failed: " + textStatus + msg.d.TransactionResult);
            alert("Request failed: " + msg.responseText);
        })
};
