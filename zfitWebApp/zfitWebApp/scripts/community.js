
// ||||||||||||||   ***    BASIC SETUP FOR COMMUNITY JS    ***    |||||||||||||||| //

//Setting up the content div

//var contentSetup = function (template, editable) {
//    var properties = d3.select("div.content")
//        .selectAll("div.properties")
//        .data(template);

//    //Enter
//    properties
//        .enter()
//        .append("div")
//        .classed("properties", true)
//        .attr("contenteditable", "" + editable);

//    //Update
//    properties
//        .attr("id", function (d) { return d.fieldId })
//        .text(function (d) { return d.title })
//        .classed("edit", false)
//        .classed("add", false)
//        .classed("delete", false);

//    //Exit
//    properties.exit();
//};


// ||||||||||||||   ***    CELL CRUD    ***    |||||||||||||||| // 

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

// CELL Methods and Events  

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

    contentSetup(cellContentTemplate, false);

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
    
    contentSetup(cellContentTemplate, true);

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

//Callbacks for Fed CRUD 
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

// FED Methods and Events  

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

    contentSetup(fedContentTemplate, false); 
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
    
    contentSetup(fedContentTemplate, true); 

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



// ||||||||||||||   ***    CELLFAN CRUD    ***    |||||||||||||||| //

//Callbacks for CELLFAN CRUD 

var populateCollectionFields = function (anArray, cellfan) {

    //Select & data
    var elements = d3.select("div.content")
        .selectAll("div.properties")
        .data(anArray);

    //Enter
    elements
        .enter()
        .append("div")
        .classed("properties", true);

    //Update
    if (cellfan === "fan") {
        elements.text(function (d) { return d.CellName });
    }
    else {
        elements.text(function (d) { return d.FanName });
    }

    //Exit
    elements
        .exit()
        .remove();
};

var fanCellCollectionLoaded = function (aCellFanCollection) {
    populateCollectionFields(aCellFanCollection.CellFanList, "fan");
};

var fanCellCollectionEdited = function (aCellFanCollection) {
    populateCollectionFields(aCellFanCollection.CellFanList, "fan");
};

var cellFanCollectionLoaded = function (aCellFanCollection) {
    populateCollectionFields(aCellFanCollection.CellFanList, "cell");
};

var cellFanCollectionEdited = function (aCellFanCollection) {
    populateCollectionFields(aCellFanCollection.CellFanList, "cell");
};

// CELLFAN Methods and Events  

var cellfancrud = function cellfanData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aCellFanCollection = { CellFanFilter: { CellfanFilter: {} } };
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number") {
        aCellFanCollection.isFiltered = true;
        if (d.filtertype === "fan")
            aCellFanCollection.CellFanFilter.CellfanFilter.FanKey = filter.node().value;
        else
            aCellFanCollection.CellFanFilter.CellfanFilter.CelKey = filter.node().value;
    }
    else {
        aCellFanCollection.isFiltered = true;
        if (d.filtertype === "fan")
            aCellFanCollection.CellFanFilter.CellfanFilter.FanName = filter.text();
        else
            aCellFanCollection.CellFanFilter.CellfanFilter.CellName = filter.text();
    }

    //Remove the cellfans that are have checkboxes that are checked 
    if (d.crudtype === "edit") {
        aCellFanCollection.CellFanList = [];
        var chkboxes = d3.selectAll("input.chkbox");
        chkboxes.each(function (d, i) {
            if (chkboxes[0][i].checked === false) {
                var CellFan = {};
                var thiscellfan = chkboxes[0][i].__data__;
                CellFan.CelKey = thiscellfan.CelKey;
                //CellFan.CellFanDateJoined = thiscellfan.CellFanDateJoined;
                CellFan.CellName = thiscellfan.CellName;
                CellFan.FanDisplayName = thiscellfan.FanDisplayName;
                CellFan.FanKey = thiscellfan.FanKey;
                CellFan.FanName = thiscellfan.FanName;
                CellFan.FanSurname = thiscellfan.FanSurname;
                CellFan.HashValue = thiscellfan.HashValue;
                CellFan.ObjectState = thiscellfan.ObjectState;

                aCellFanCollection.CellFanList.push(CellFan);
            }
        });
    }

    var CellFanCollection = { 'aCellFanCollection': aCellFanCollection };
    ajaxCall(methodname, CellFanCollection, callback);
}

//Data Arrays for CellFan Crud Methods 
var cellfanContentTemplate = [
    { title: "Cell Key", fieldId: "CelKey" },
    { title: "Cell Name", fieldId: "CellName" },
    { title: "Cell Owner Key", fieldId: "FanKey" },
    { title: "Cell Owner Name", fieldId: "FanName" }
];

// Fan viewing his/her cells 
var fanscellsloadData = [
  { methodName: "community.aspx/loadCellFanCollection", callBack: fanCellCollectionLoaded, filtertype: "fan" }
];
// Fan editing his/her cells 
var fanscellseditData = [
  { methodName: "community.aspx/editCellFanCollection", callBack: fanCellCollectionEdited, filtertype: "fan", crudtype: "edit" }
];
// Cell viewing its fans 
var cellsfansloadData = [
  { methodName: "community.aspx/loadCellFanCollection", callBack: cellFanCollectionLoaded, filtertype: "cell" }
];
// Cell editing its fans 
var cellsfanseditData = [
  { methodName: "community.aspx/editCellFanCollection", callBack: cellFanCollectionEdited, filtertype: "cell", crudtype: "edit" }
];

//*** CELLFAN's from Fans perspective 

var loadfanCellClick = d3.select("div#fancelllist").on("click", function () {

    contentSetup(cellfanContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fanscellsloadData)
        .text("Load CellFan")
        .on("click", cellfancrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

//Editing of list follows a different pattern  
var editfanCellClick = d3.select("div#editFancells").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(fanscellseditData)
        .text("Edit CellFan")
        .on("click", cellfancrud);
});

//*** CELLFAN's from Cells perspective

var loadCellFanClick = d3.select("div#cellfanlist").on("click", function () {

    contentSetup(cellfanContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(cellsfansloadData)
        .text("Load CellFan")
        .on("click", cellfancrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var editcellFanClick = d3.select("div#editCellfans").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(cellsfanseditData)
        .text("Edit CellFan")
        .on("click", cellfancrud);
});


// ||||||||||||||   ***    CELLFED CRUD    ***    |||||||||||||||| //

//Callbacks for CELLFED CRUD 

var populateCellFedCollectionFields = function (anArray, cellfed) {

    //Select & data
    var elements = d3.select("div.content")
        .selectAll("div.properties")
        .data(anArray);

    //Enter
    elements
        .enter()
        .append("div")
        .classed("properties", true);

    //Update
    if (cellfed === "fed") {
        elements.text(function (d) { return d.CellName });
    }
    else {
        elements.text(function (d) { return d.FedName });
    }

    //Exit
    elements
        .exit()
        .remove();
};

var fedCellsCollectionLoaded = function (aCellFedCollection) {
    populateCellFedCollectionFields(aCellFedCollection.CellFedList, "fed");
};

var fedCellsCollectionEdited = function (aCellFedCollection) {
    populateCellFedCollectionFields(aCellFedCollection.CellFedList, "fed");
};

var cellFedCollectionLoaded = function (aCellFedCollection) {
    populateCellFedCollectionFields(aCellFedCollection.CellFedList, "cell");
};

var cellFedsCollectionEdited = function (aCellFedCollection) {
    populateCellFedCollectionFields(aCellFedCollection.CellFedList, "cell");
};

// CELLFED Methods and Events  

var cellfedcrud = function cellfedData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aCellFedCollection = { CellFedFilter: { CellfedFilter: {} } };
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number") {
        aCellFedCollection.isFiltered = true;
        if (d.filtertype === "fed")
            aCellFedCollection.CellFedFilter.CellfedFilter.FedKey = filter.node().value;
        else
            aCellFedCollection.CellFedFilter.CellfedFilter.CelKey = filter.node().value;
    }
    else {
        aCellFedCollection.isFiltered = true;
        if (d.filtertype === "fed")
            aCellFedCollection.CellFedFilter.CellfedFilter.FedName = filter.text();
        else
            aCellFedCollection.CellFedFilter.CellfedFilter.CellName = filter.text();
    }

    //Remove the cellfeds that are have checkboxes that are checked 
    if (d.crudtype === "edit") {
        aCellFedCollection.CellFedList = [];
        var chkboxes = d3.selectAll("input.chkbox");
        chkboxes.each(function (d, i) {
            if (chkboxes[0][i].checked === false) {
                var CellFed = {};
                var thiscellfed = chkboxes[0][i].__data__;
                CellFed.CelKey = thiscellfed.CelKey;
                //CellFed.CellFedDateJoined = thiscellfed.CellFedDateJoined;
                CellFed.CellName = thiscellfed.CellName;
                CellFed.FedKey = thiscellfed.FedKey;
                CellFed.FedName = thiscellfed.FedName;
                CellFed.HashValue = thiscellfed.HashValue;
                CellFed.ObjectState = thiscellfed.ObjectState;

                aCellFedCollection.CellFedList.push(CellFed);
            }
        });
    }

    var CellFedCollection = { 'aCellFedCollection': aCellFedCollection };
    ajaxCall(methodname, CellFedCollection, callback);
}

//Data Arrays for CellFed Crud Methods 
var cellfedContentTemplate = [
    { title: "Cell Key", fieldId: "CelKey" },
    { title: "Cell Name", fieldId: "CellName" },
    { title: "Cell Owner Key", fieldId: "FedKey" },
    { title: "Cell Owner Name", fieldId: "FedName" }
];

// Fed viewing his/her cells 
var fedscellsloadData = [
  { methodName: "community.aspx/loadCellFedCollection", callBack: fedCellsCollectionLoaded, filtertype: "fed" }
];
// Fed editing his/her cells 
var fedscellseditData = [
  { methodName: "community.aspx/editCellFedCollection", callBack: fedCellsCollectionEdited, filtertype: "fed", crudtype: "edit" }
];
// Cell viewing its fans 
var cellsfedsloadData = [
  { methodName: "community.aspx/loadCellFedCollection", callBack: cellFedCollectionLoaded, filtertype: "cell" }
];
// Cell editing his/her cells 
var cellsfedseditData = [
  { methodName: "community.aspx/editCellFedCollection", callBack: cellFedsCollectionEdited, filtertype: "cell", crudtype: "edit" }
];

//*** CELLFED's from Cells perspective

var loadfedCellsClick = d3.select("div#cellfedlist").on("click", function () {

    contentSetup(cellfedContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(cellsfedsloadData)
        .text("Load CellFed")
        .on("click", cellfedcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

//Editing of list follows a different pattern  
var editcellFedsClick = d3.select("div#editCellfeds").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(cellsfedseditData)
        .text("Edit CellFed")
        .on("click", cellfedcrud);
});

//*** CELLFED's from Fed's perspective

var loadCellFedClick = d3.select("div#fedcelllist").on("click", function () {

    contentSetup(cellfedContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fedscellsloadData)
        .text("Load CellFed")
        .on("click", cellfedcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

//Editing of list follows a different pattern  
var editfedCellsClick = d3.select("div#editFedCells").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(fedscellseditData)
        .text("Edit CellFed")
        .on("click", cellfedcrud);
});


// ||||||||||||||   ***    FANFED CRUD    ***    |||||||||||||||| //

//Callbacks for FANFED CRUD 

var populateFanFedCollectionFields = function (anArray, fanfed) {

    //Select & data
    var elements = d3.select("div.content")
        .selectAll("div.properties")
        .data(anArray);

    //Enter
    elements
        .enter()
        .append("div")
        .classed("properties", true);

    //Update
    if (fanfed === "fed") {
        elements.text(function (d) { return d.FanName });
    }
    else {
        elements.text(function (d) { return d.FedName });
    }

    //Exit
    elements
        .exit()
        .remove();
};

var fedFansCollectionLoaded = function (aFanFedCollection) {
    populateFanFedCollectionFields(aFanFedCollection.FanFedList, "fed");
};

var fedFansCollectionEdited = function (aFanFedCollection) {
    populateFanFedCollectionFields(aFanFedCollection.FanFedList, "fed");
};

var fanFedCollectionLoaded = function (aFanFedCollection) {
    populateFanFedCollectionFields(aFanFedCollection.FanFedList, "fan");
};

var fanFedsCollectionEdited = function (aFanFedCollection) {
    populateFanFedCollectionFields(aFanFedCollection.FanFedList, "fan");
};

// FANFED Methods and Events  

var fanfedcrud = function fanfedData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aFanFedCollection = { FanFedFilter: { FanfedFilter: {} } };
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number") {
        aFanFedCollection.isFiltered = true;
        if (d.filtertype === "fed")
            aFanFedCollection.FanFedFilter.FanfedFilter.FedKey = filter.node().value;
        else
            aFanFedCollection.FanFedFilter.FanfedFilter.FanKey = filter.node().value;
    }
    else {
        aFanFedCollection.isFiltered = true;
        if (d.filtertype === "fed")
            aFanFedCollection.FanFedFilter.FanfedFilter.FedName = filter.text();
        else
            aFanFedCollection.FanFedFilter.FanfedFilter.FanName = filter.text();
    }

    //Remove the fanfeds that are have checkboxes that are checked 
    if (d.crudtype === "edit") {
        aFanFedCollection.FanFedList = [];
        var chkboxes = d3.selectAll("input.chkbox");
        chkboxes.each(function (d, i) {
            if (chkboxes[0][i].checked === false) {
                var FanFed = {};
                var thisfanfed = chkboxes[0][i].__data__;
                FanFed.FanKey = thisfanfed.FanKey;
                //FanFed.FanFedDateJoined = thisfanfed.FanFedDateJoined;
                FanFed.FanName = thisfanfed.FanName;
                FanFed.FedKey = thisfanfed.FedKey;
                FanFed.FedName = thisfanfed.FedName;
                FanFed.HashValue = thisfanfed.HashValue;
                FanFed.ObjectState = thisfanfed.ObjectState;

                aFanFedCollection.FanFedList.push(FanFed);
            }
        });
    }

    var FanFedCollection = { 'aFanFedCollection': aFanFedCollection };
    ajaxCall(methodname, FanFedCollection, callback);
}

//Data Arrays for FanFed Crud Methods 
var fanfedContentTemplate = [
    { title: "Fan Key", fieldId: "FanKey" },
    { title: "Fan Name", fieldId: "FanName" },
    { title: "Fan Owner Key", fieldId: "FedKey" },
    { title: "Fan Owner Name", fieldId: "FedName" }
];

// Fed viewing his/her fans 
var fedsfansloadData = [
  { methodName: "community.aspx/loadFanFedCollection", callBack: fedFansCollectionLoaded, filtertype: "fed" }
];
// Fed editing his/her fans 
var fedsfanseditData = [
  { methodName: "community.aspx/editFanFedCollection", callBack: fedFansCollectionEdited, filtertype: "fed", crudtype: "edit" }
];
// Fan viewing its fans 
var fansfedsloadData = [
  { methodName: "community.aspx/loadFanFedCollection", callBack: fanFedCollectionLoaded, filtertype: "fan" }
];
// Fan editing his/her fans 
var fansfedseditData = [
  { methodName: "community.aspx/editFanFedCollection", callBack: fanFedsCollectionEdited, filtertype: "fan", crudtype: "edit" }
];

//*** FANFED's from Fans perspective

var loadfedFansClick = d3.select("div#fanfedlist").on("click", function () {

    contentSetup(fanfedContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fansfedsloadData)
        .text("Load FanFed")
        .on("click", fanfedcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

//Editing of list follows a different pattern  
var editfanFedsClick = d3.select("div#editFanfeds").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(fansfedseditData)
        .text("Edit FanFed")
        .on("click", fanfedcrud);
});

//*** FANFED's from Fed's perspective

var loadFedFanClick = d3.select("div#fedfanlist").on("click", function () {

    contentSetup(fanfedContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fedsfansloadData)
        .text("Load FanFed")
        .on("click", fanfedcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

//Editing of list follows a different pattern  
var editfedFansClick = d3.select("div#editFedFans").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(fedsfanseditData)
        .text("Edit FanFed")
        .on("click", fanfedcrud);
});



// ||||||||||||||   ***    FANFED CRUD    ***    |||||||||||||||| //

//Callbacks for FANFED CRUD 

var populateFriendCollectionFields = function (anArray, friend) {

    //Select & data
    var elements = d3.select("div.content")
        .selectAll("div.properties")
        .data(anArray);

    //Enter
    elements
        .enter()
        .append("div")
        .classed("properties", true);

    //Update
    if (friend === "friend") {
        elements.text(function (d) { return d.Fan2DisplayName });
    }
    else {
        elements.text(function (d) { return d.Fan1DisplayName });
    }

    //Exit
    elements
        .exit()
        .remove();
};

var friendsCollectionLoaded = function (aFriendCollection) {
    populateFriendCollectionFields(aFriendCollection.FriendList, "friend");
};

var friendCollectionEdited = function (aFriendCollection) {
    populateFriendCollectionFields(aFriendCollection.FriendList, "friend");
};

// FANFED Methods and Events  

var friendcrud = function fanfedData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aFriendCollection = { FriendFilter: { FriendshipFilter: {} } };
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number") {
        aFriendCollection.isFiltered = true;
        aFriendCollection.FriendFilter.FriendshipFilter.Fan1Key = filter.node().value;
    }
    else {
        aFriendCollection.isFiltered = true;
        aFriendCollection.FriendFilter.FriendshipFilter.Fan1Name = filter.text();
    }

    //Remove the friends that are have checkboxes that are checked 
    if (d.crudtype === "edit") {
        aFriendCollection.FriendList = [];
        var chkboxes = d3.selectAll("input.chkbox");
        chkboxes.each(function (d, i) {
            if (chkboxes[0][i].checked === false) {
                var Friend = {};
                var thisfriend = chkboxes[0][i].__data__;
                Friend.Fan1Key = thisfriend.Fan1Key;
                Friend.Fan1Name = thisfriend.Fan1Name;
                Friend.Fan1Surname = thisfriend.Fan1Surname;
                Friend.Fan2Key = thisfriend.Fan2Key;
                Friend.Fan2Name = thisfriend.Fan2Name;
                Friend.Fan2Surname = thisfriend.Fan2Surname;
                Friend.Relationship = thisfriend.Relationship;
                Friend.FriendDateEstablished = thisfriend.FriendDateEstablished;
                Friend.HashValue = thisfriend.HashValue;
                Friend.ObjectState = thisfriend.ObjectState;

                aFriendCollection.FriendList.push(Friend);
            }
        });
    }

    var FriendCollection = { 'aFriendCollection': aFriendCollection };
    ajaxCall(methodname, FriendCollection, callback);
}

//Data Arrays for Friend Crud Methods 
var friendContentTemplate = [
    { title: "Friend1 Key", fieldId: "Friend1Key" },
    { title: "Friend2 Name", fieldId: "Friend2Name" },
    { title: "Friend2 Key", fieldId: "Friend2Key" },
    { title: "Friend2 Name", fieldId: "Friend2Name" }
];

// Fan viewing his/her friends 
var friendloadData = [
  { methodName: "community.aspx/loadFriendCollection", callBack: friendsCollectionLoaded, filtertype: "fan" }
];
// Fan editing his/her friends 
var friendeditData = [
  { methodName: "community.aspx/editFriendCollection", callBack: friendCollectionEdited, filtertype: "fan", crudtype: "edit" }
];

//*** FRIEND's from Fans perspective

var loadfriendsClick = d3.select("div#loadFriends").on("click", function () {

    contentSetup(friendContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(friendloadData)
        .text("Load Friend")
        .on("click", friendcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

//Editing of list follows a different pattern  
var editfriendsClick = d3.select("div#editFriends").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(friendeditData)
        .text("Edit Friend")
        .on("click", friendcrud);
});
