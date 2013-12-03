
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

//Click method to switch between side navigation cruds 

var sidenav = function (container) {
    if (container.style("display") === "none") {
        container.style("display", "block");
    }
    else {
        container.style("display", "none");
    }
};

var comCategories = d3.selectAll("div.sideNavElement").on("click", function () {
    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container); 
});

var secCategories = d3.selectAll("div.sideNavSecElement").on("click", function () {
    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

// ||||||||||||||   ***    BASIC SETUP OF PROPERTIES    ***    |||||||||||||||| //

//Setting up the content div

var contentSetup = function (template, editable) {
    var properties = d3.select("div.content")
        .selectAll("div.properties")
        .data(template);

    //Enter
    properties
        .enter()
        .append("div")
        .classed("properties", true)
        .attr("contenteditable", editable);

    //Update
    properties
        .attr("id", function (d) { return d.fieldId })
        .text(function (d) { return d.title })
        .classed("edit", false)
        .classed("add", false)
        .classed("delete", false);

    //Exit
    properties.exit();
};

