
//Callbacks for CRUD 

var fanLoaded = function (aFan) {
    d3.select("#fanUserID").text(aFan.FanUserID);
    d3.select("#fanPassword").text(aFan.FanPassword);
    d3.select("#fanName").text(aFan.FanName);
    d3.select("#fanSurname").text(aFan.FanSurname);
    d3.select("#fanEmail").text(aFan.FanEmail);
    d3.select("#fanAvatar").text(aFan.FanAvatar);

    //alert("Funky Music! " + aFan.aTransactionStatus.Message);
};

var fanEdited = function (aFan) {
    alert("Edited");
};

var fanDeleted = function (aFan) {
    alert("Fan Deleted!");
    window.location = "default.aspx"; 
};

//Method and click event for fan crud 

var fancrud = function fanData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack; 
    var aFan = {};
    aFan.FanUserID = d3.select("#fanUserID").text();
    aFan.FanPassword = d3.select("#fanPassword").text();
    aFan.FanName = d3.select("#fanName").text();
    aFan.FanSurname = d3.select("#fanSurname").text();
    aFan.FanEmail = d3.select("#fanEmail").text();
    aFan.FanAvatar = null;
    var Fan = { 'aFan': aFan };
    ajaxCall(methodname, Fan, callback);
}

//Data Arrays for Fan Crud Methods 

var fanloadData = [
  { methodName: "profile.aspx/loadFan", callBack: fanLoaded }
];
var faneditData = [
    { methodName: "profile.aspx/editFan", callBack: fanEdited }
];
var fandeleteData = [
    { methodName: "profile.aspx/deleteFan", callBack: fanDeleted }
];

//Click method to switch between cruds 

var loadButton = d3.select("div#loadFan").on("click", function () {
    d3.selectAll("div.properties")
    .attr("contenteditable", "false")
    .style("background-color", "#6699FF");

    d3.select(".testButton")
        .data(fanloadData)
        .text("Load Fan")
        .on("click", fancrud);
});

var editButton = d3.select("div#editFan").on("click", function () {
    d3.selectAll("div.properties")
        .attr("contenteditable", "true")
        .style("background-color", "yellow");

    d3.select(".testButton")
        .data(faneditData)
        .text("Edit Fan")
        .on("click", fancrud);
});

var deleteButton = d3.select("div#deleteFan").on("click", function () {
    d3.selectAll("div.properties")
        .attr("contenteditable", "false")
        .style("background-color", "red");

    d3.select(".testButton")
        .data(fandeleteData)
        .text("Delete Fan")
        .on("click", fancrud);
});





