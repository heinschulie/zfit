// ||||||||||||||   ***    EXERCISE CRUD    ***    |||||||||||||||| // 

var populateExerciseFields = function (aExercise) {
    d3.select("#ExerciseName").text(aExercise.ExcName);
    d3.select("#ExcType").text(aExercise.ExcType);
};

var exerciseLoaded = function (aExercise) {
    populateExerciseFields(aExercise);
};

var exerciseAdded = function (aExercise) {
    populateExerciseFields(aExercise);
};

var exerciseEdited = function (aExercise) {
    populateExerciseFields(aExercise);
};

var exerciseDeleted = function (aExercise) {
    alert("Exercise Deleted");
};

// EXERCISE Methods and Events  

var exercisecrud = function exerciseData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aExercise = {};
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number")
        aExercise.ExcKey = filter.node().value;
    else
        aExercise.ExcKey = parseInt(filter.text());

    aExercise.ExcName = d3.select("#ExerciseName").text();
    aExercise.ExcType = filter.node().value;
    var Exercise = { 'aExercise': aExercise };
    ajaxCall(methodname, Exercise, callback);
}

//Data Arrays for Exercise Crud Methods 
var exerciseContentTemplate = [
    { title: "Exercise Name", fieldId: "ExerciseName" },
    { title: "Exercise Type Key", fieldId: "ExcType" },
    { title: "Exercise Type Name", fieldId: "ExcTypeName" }
];

var exerciseloadData = [
  { methodName: "physical.aspx/loadExercise", callBack: exerciseLoaded }
];

var exerciseaddData = [
  { methodName: "physical.aspx/addExercise", callBack: exerciseAdded }
];

var exerciseeditData = [
  { methodName: "physical.aspx/editExercise", callBack: exerciseEdited }
];

var exercisedeleteData = [
  { methodName: "physical.aspx/deleteExercise", callBack: exerciseDeleted }
];

var loadExerciseClick = d3.select("div#loadExercise").on("click", function () {

    contentSetup(exerciseContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(exerciseloadData)
        .text("Load Exercise")
        .on("click", exercisecrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var addExerciseClick = d3.select("div#addExercise").on("click", function () {

    contentSetup(exerciseContentTemplate, true);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(exerciseaddData)
        .text("Add Exercise")
        .on("click", exercisecrud);
});

var editExerciseClick = d3.select("div#editExercise").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .attr("contenteditable", "true")
        .classed("delete", false)
        .classed("add", false)
        .classed("edit", true);

    d3.select(".testButton")
        .data(exerciseeditData)
        .text("Edit Exercise")
        .on("click", exercisecrud);
});

var deleteExerciseClick = d3.select("div#deleteExercise").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .classed("edit", false)
        .classed("add", false)
        .classed("delete", true)
        .attr("contenteditable", "false");

    d3.select(".testButton")
        .data(exercisedeleteData)
        .text("Delete Exercise")
        .on("click", exercisecrud);
});
