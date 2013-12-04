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


// ||||||||||||||   ***    WORKOUT CRUD    ***    |||||||||||||||| // 

var populateWorkoutFields = function (aWorkout) {
    d3.select("#WorkoutName").text(aWorkout.WrtName);
    d3.select("#WrtAvailability").text(aWorkout.WrtAvailability);
    d3.select("#WrtResultFunction").text(aWorkout.WrtResultFunction);
    d3.select("#WrtDescription").text(aWorkout.WrtDescription);
    d3.select("#WrtOwnerKey").text(aWorkout.WrtOwnerKey);
    d3.select("#WrtOwnerName").text(aWorkout.WrtOwnerName);
    d3.select("#FedKey").text(aWorkout.FedKey);
    d3.select("#FedName").text(aWorkout.FedName);
    d3.select("#CelKey").text(aWorkout.CelKey);
    d3.select("#CelName").text(aWorkout.CelName);
    d3.select("#DateCreated").text(aWorkout.DateCreated);
};

var workoutLoaded = function (aWorkout) {
    populateWorkoutFields(aWorkout);
};

var workoutAdded = function (aWorkout) {
    populateWorkoutFields(aWorkout);
};

var workoutEdited = function (aWorkout) {
    populateWorkoutFields(aWorkout);
};

var workoutDeleted = function (aWorkout) {
    alert("Workout Deleted");
};

// WORKOUT Methods and Events  

var workoutcrud = function workoutData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aWorkout = {};
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number")
        aWorkout.WrtKey = filter.node().value;
    else
        aWorkout.WrtKey = parseInt(filter.text());

    aWorkout.WrtName = d3.select("#WorkoutName").text();
    aWorkout.WrtAvailability = filter.node().value;
    aWorkout.WrtResultFunction = d3.select("#WrtResultFunction").text();
    aWorkout.WrtDescription = d3.select("#WrtDescription").text();
    aWorkout.WrtOwnerKey = 2; //Hardcoded - Just to keep html simple 
    aWorkout.WrtOwnerName = d3.select("#WrtOwnerName").text();
    aWorkout.FedKey = 3; //Hardcoded - Just to keep html simple 
    aWorkout.FedName = d3.select("#FedName").text();
    aWorkout.CelKey = 4; //Hardcoded - Just to keep html simple 
    aWorkout.CelName = d3.select("#CelName").text();
    aWorkout.DateCreated = d3.select("#DateCreated").text();

    var Workout = { 'aWorkout': aWorkout };
    ajaxCall(methodname, Workout, callback);
}

//Data Arrays for Workout Crud Methods 
var workoutContentTemplate = [
    { title: "Workout Name", fieldId: "WorkoutName" },
    { title: "Workout Availability Key", fieldId: "WrtAvailability" },
    { title: "Wrt Result Function", fieldId: "WrtResultFunction" },
    { title: "Wrt Description", fieldId: "WrtDescription" },
    { title: "Wrt Owner Key", fieldId: "WrtOwnerKey" },
    { title: "Wrt Owner Name", fieldId: "WrtOwnerName" },
    { title: "Fed Key", fieldId: "FedKey" },
    { title: "Fed Name", fieldId: "FedName" },
    { title: "Cel Key", fieldId: "CelKey" },
    { title: "Cel Name", fieldId: "CelName" },
    { title: "Date Created", fieldId: "DateCreated" }
];

var workoutloadData = [
  { methodName: "physical.aspx/loadWorkout", callBack: workoutLoaded }
];

var workoutaddData = [
  { methodName: "physical.aspx/addWorkout", callBack: workoutAdded }
];

var workouteditData = [
  { methodName: "physical.aspx/editWorkout", callBack: workoutEdited }
];

var workoutdeleteData = [
  { methodName: "physical.aspx/deleteWorkout", callBack: workoutDeleted }
];

var loadWorkoutClick = d3.select("div#loadWorkout").on("click", function () {

    contentSetup(workoutContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(workoutloadData)
        .text("Load Workout")
        .on("click", workoutcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var addWorkoutClick = d3.select("div#addWorkout").on("click", function () {

    contentSetup(workoutContentTemplate, true);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(workoutaddData)
        .text("Add Workout")
        .on("click", workoutcrud);
});

var editWorkoutClick = d3.select("div#editWorkout").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .attr("contenteditable", "true")
        .classed("delete", false)
        .classed("add", false)
        .classed("edit", true);

    d3.select(".testButton")
        .data(workouteditData)
        .text("Edit Workout")
        .on("click", workoutcrud);
});

var deleteWorkoutClick = d3.select("div#deleteWorkout").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .classed("edit", false)
        .classed("add", false)
        .classed("delete", true)
        .attr("contenteditable", "false");

    d3.select(".testButton")
        .data(workoutdeleteData)
        .text("Delete Workout")
        .on("click", workoutcrud);
});
