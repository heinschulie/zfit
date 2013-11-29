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

var celleditData = [
  { methodName: "community.aspx/editCell", callBack: cellEdited }
];

var celldeleteData = [
  { methodName: "community.aspx/deleteCell", callBack: cellDeleted }
];

//Click method to switch between cruds 

var comCategories = d3.selectAll("div.sideNavElement").on("click", function () {
    var container = d3.select("div#" + this.id + "CrudContainer"); 
    if (container.style("display") === "none") {
        container.style("display", "block"); 
    }
    else {
        container.style("display", "none");
    }
});

var loadCellClick = d3.select("div#loadCell").on("click", function () {
    var properties = d3.select("div.content")
        .selectAll("div.properties");

    properties.data(cellContentTemplate)
        .enter()
        .append("div")       
        .classed("properties", true)
        .attr("contenteditable", "false")
        .attr("id", function (d) { return d.fieldId })
        .text(function (d) { return d.title });

    properties.classed("edit", false)
        .classed("delete", false);

    d3.select("#textFilter")
        .attr("type", "number"); 

    d3.select(".testButton")
        .data(cellloadData)
        .text("Load Cell")
        .on("click", cellcrud);
});

var editCellClick = d3.select("div#editCell").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .attr("contenteditable", "true")
        .classed("delete", false)
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
        .classed("delete", true)
        .attr("contenteditable", "false");

    d3.select(".testButton")
        .data(celldeleteData)
        .text("Delete Cell")
        .on("click", cellcrud);
});