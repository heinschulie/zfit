
// ||||||||||||||   ***    CELL CRUD    ***    |||||||||||||||| // 

//Callbacks for CRUD 
var populateCellFields = function (aCell) {
    d3.select("#CellName").text(aCell.CellName);
    d3.select("#FanKey").text(aCell.FanKey);
    d3.select("#FanName").text(aCell.FanName);
    d3.select("#FedKey").text(aCell.FedKey);
};

var cellLoaded = function (aCell) {
    populateCellFields(aCell);
};

var cellAdded = function (aCell) {
    populateCellFields(aCell);
};

var cellEdited = function (aCell) {
    populateCellFields(aCell);
};

var cellDeleted = function (aCell) {
    alert("Cell Deleted"); 
};

//Method for fan crud 

var cellcrud = function cellData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aCell = {};
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number")
        aCell.CelKey = filter.node().value;
    else
        aCell.CelKey = parseInt(filter.text());

    aCell.CellName = d3.select("#CellName").text();    
    aCell.FanKey = 2; //Just a fixed value to avoid complicating html at this stage 
    aCell.FanName = d3.select("#FanName").text();
    aCell.CellAvatar = null;
    var Cell = { 'aCell': aCell };
    ajaxCall(methodname, Cell, callback);
}

//Data Arrays for Cell Crud Methods 
var cellContentTemplate = [
    { title: "Cell Name", fieldId: "CellName" },
    { title: "Cell Owner Key", fieldId: "FanKey" },
    { title: "Cell Owner Name", fieldId: "FanName"}
];

var cellloadData = [
  { methodName: "community.aspx/loadCell", callBack: cellLoaded }
];

var celladdData = [
  { methodName: "community.aspx/addCell", callBack: cellAdded }
];

var celleditData = [
  { methodName: "community.aspx/editCell", callBack: cellEdited }
];

var celldeleteData = [
  { methodName: "community.aspx/deleteCell", callBack: cellDeleted }
];

var loadCellClick = d3.select("div#loadCell").on("click", function () {
    var properties = d3.select("div.content")
        .selectAll("div.properties")
        .data(cellContentTemplate);

    //Enter
    properties
        .enter()
        .append("div")
        .classed("properties", true)
        .attr("contenteditable", "false");
        
    //Update
    properties
        .attr("id", function (d) { return d.fieldId })
        .text(function (d) { return d.title })
        .classed("edit", false)
        .classed("add", false)
        .classed("delete", false);

    //Exit
    properties.exit(); 

    d3.select("#textFilter")
        .attr("type", "number"); 

    d3.select(".testButton")
        .data(cellloadData)
        .text("Load Cell")
        .on("click", cellcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var addCellClick = d3.select("div#addCell").on("click", function () {
    var properties = d3.select("div.content")
        .selectAll("div.properties")
        .data(cellContentTemplate);

    //Enter
    properties
        .enter()
        .append("div")
        .classed("properties", true)
        .classed("add", true)
        .attr("contenteditable", "true");

    //Update
    properties
        .attr("id", function (d) { return d.fieldId })
        .text(function (d) { return d.title })
        .classed("delete", false)
        .classed("edit", false);

    //Exit
    properties.exit();

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(celladdData)
        .text("Add Cell")
        .on("click", cellcrud);
});

var editCellClick = d3.select("div#editCell").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .attr("contenteditable", "true")
        .classed("delete", false)
        .classed("add", false)
        .classed("edit", true);

    d3.select(".testButton")
        .data(celleditData)
        .text("Edit Cell")
        .on("click", cellcrud);
});

var deleteCellClick = d3.select("div#deleteCell").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .classed("edit", false)
        .classed("add", false)
        .classed("delete", true)
        .attr("contenteditable", "false");

    d3.select(".testButton")
        .data(celldeleteData)
        .text("Delete Cell")
        .on("click", cellcrud);
});


// ||||||||||||||   ***    FED CRUD    ***    |||||||||||||||| // 

//Callbacks for CRUD 
var populateFedFields = function (aFed) {
    d3.select("#FedName").text(aFed.FedName);
    d3.select("#FanKey").text(aFed.FanKey);
    d3.select("#FanName").text(aFed.FanName);
    d3.select("#FedKey").text(aFed.FedKey);
};

var fedLoaded = function (aFed) {
    populateFedFields(aFed);
};

var fedAdded = function (aFed) {
    populateFedFields(aFed);
};

var fedEdited = function (aFed) {
    populateFedFields(aFed);
};

var fedDeleted = function (aFed) {
    alert("Fed Deleted");
};

//Method for fan crud 

var fedcrud = function fedData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aFed = {};
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number")
        aFed.FeddKey = filter.node().value;
    else
        aFed.FeddKey = 1; 

    aFed.FedName = d3.select("#FedName").text();
    aFed.FanKey = 2; //Just a fixed value to avoid complicating html at this stage 
    aFed.FanName = d3.select("#FanName").text();
    aFed.FedAvatar = null;
    var Fed = { 'aFed': aFed };
    ajaxCall(methodname, Fed, callback);
}

//Data Arrays for Fed Crud Methods 
var fedContentTemplate = [
    { title: "Fed Name", fieldId: "FedName" },
    { title: "Fed Owner Key", fieldId: "FanKey" },
    { title: "Fed Owner Name", fieldId: "FanName" }
];

var fedloadData = [
  { methodName: "community.aspx/loadFed", callBack: fedLoaded }
];

var fedaddData = [
  { methodName: "community.aspx/addFed", callBack: fedAdded }
];

var fededitData = [
  { methodName: "community.aspx/editFed", callBack: fedEdited }
];

var feddeleteData = [
  { methodName: "community.aspx/deleteFed", callBack: fedDeleted }
];

var loadFedClick = d3.select("div#loadFed").on("click", function () {

    var properties = d3.select("div.content")
        .selectAll("div.properties")
        .data(fedContentTemplate);

    //Enter
    properties
        .enter()
        .append("div")
        .classed("properties", true)
        .attr("contenteditable", "false");

    //Update
    properties
        .attr("id", function (d) { return d.fieldId })
        .text(function (d) { return d.title })
        .classed("edit", false)
        .classed("add", false)
        .classed("delete", false);

    //Exit
    properties.exit();

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fedloadData)
        .text("Load Fed")
        .on("click", fedcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});


var addFedClick = d3.select("div#addFed").on("click", function () {
    var properties = d3.select("div.content")
        .selectAll("div.properties")
        .data(fedContentTemplate);

    //Enter
    properties
        .enter()
        .append("div")
        .classed("properties", true)
        .classed("add", true)
        .attr("contenteditable", "true");

    //Update
    properties
        .attr("id", function (d) { return d.fieldId })
        .text(function (d) { return d.fieldId })
        .classed("delete", false)
        .classed("edit", false);

    //Exit
    properties.exit();

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fedaddData)
        .text("Add Fed")
        .on("click", fedcrud);
});

var editFedClick = d3.select("div#editFed").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .attr("contenteditable", "true")
        .classed("delete", false)
        .classed("add", false)
        .classed("edit", true);

    d3.select(".testButton")
        .data(fededitData)
        .text("Edit Fed")
        .on("click", fedcrud);
});

var deleteFedClick = d3.select("div#deleteFed").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .classed("edit", false)
        .classed("add", false)
        .classed("delete", true)
        .attr("contenteditable", "false");

    d3.select(".testButton")
        .data(feddeleteData)
        .text("Delete Fed")
        .on("click", fedcrud);
});