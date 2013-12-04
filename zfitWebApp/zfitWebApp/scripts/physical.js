// ||||||||||||||   ***    EXERCISE CRUD    ***    |||||||||||||||| // 

var populateExerciseFields = function (aExercise) {
    d3.select("#ExerciseName").text(aExercise.ExcName);
    d3.select("#ExcType").text(aExercise.ExcType);
};

var populateExerciseCollection = function (aExerciseCollection) {

    var wrts = d3.select("div.content")
        .selectAll("div.properties")
        .data(aExerciseCollection.ExerciseList);

    wrts.enter()
        .append("div")
        .classed("properties", true);

    wrts.text(function (d) { return d.ExcName });

    wrts.exit().remove();
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

var exerciseCollectionLoaded = function (aExerciseCollection) {
    populateExerciseCollection(aExerciseCollection);
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

var exercisecollectionData = [
  { methodName: "physical.aspx/loadExerciseCollection", callBack: exerciseCollectionLoaded }
];

var loadExerciseCollectionClick = d3.select("div#loadExerciseCollection").on("click", function () {

    contentSetup(exerciseContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(exercisecollectionData)
        .text("Load Exercise")
        .on("click", exercisecrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

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

var populateworkoutCollection = function (aWorkoutCollection) {
    var wrts = d3.select("div.content")
        .selectAll("div.properties")
        .data(aWorkoutCollection.WorkoutList);
    wrts.enter()
        .append("div")
        .classed("properties", true);
    wrts.text(function (d) { return d.WrtName });
    wrts.exit().remove(); 
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

var workoutCollectionLoaded = function (aWorkoutCollection) {
    populateworkoutCollection(aWorkoutCollection);
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

var workoutcollectionData = [
  { methodName: "physical.aspx/loadWorkoutCollection", callBack: workoutCollectionLoaded }
];

var loadWorkoutCollectionClick = d3.select("div#loadWorkoutCollection").on("click", function () {

    contentSetup(workoutContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(workoutcollectionData)
        .text("Load Workout")
        .on("click", workoutcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

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


// ||||||||||||||   ***    ACTIVITY CRUD    ***    |||||||||||||||| // 

var populateActivityFields = function (aActivity) {
    d3.select("#ExcKey").text(aActivity.ExcKey);
    d3.select("#ExcName").text(aActivity.ExcName);
    d3.select("#WrtKey").text(aActivity.WrtKey);
    d3.select("#WrtName").text(aActivity.WrtName);
    d3.select("#ActDescription").text(aActivity.ActDescription);
    d3.select("#ActUnitOfMeasure").text(aActivity.ActUnitOfMeasure);
    d3.select("#ActMeasure").text(aActivity.ActMeasure);
    d3.select("#ActUnitOfTime").text(aActivity.ActUnitOfTime);
    d3.select("#ActTime").text(aActivity.ActTime);
    d3.select("#ActRepetitions").text(aActivity.ActRepetitions);
    d3.select("#ActRest").text(aActivity.ActRest);
    d3.select("#ActResultType").text(aActivity.ActResultType);
};

var populateactivityCollection = function (aActivityCollection) {
    var wrts = d3.select("div.content")
        .selectAll("div.properties")
        .data(aActivityCollection.ActivityList);
    wrts.enter()
        .append("div")
        .classed("properties", true);
    wrts.text(function (d) { return d.ExcName });
    wrts.exit().remove();
};

var activityLoaded = function (aActivity) {
    populateActivityFields(aActivity);
};

var activityAdded = function (aActivity) {
    populateActivityFields(aActivity);
};

var activityEdited = function (aActivity) {
    populateActivityFields(aActivity);
};

var activityDeleted = function (aActivity) {
    alert("Activity Deleted");
};

var activityCollectionLoaded = function (aActivityCollection) {
    populateactivityCollection(aActivityCollection);
};
// ACTIVITY Methods and Events  

var activitycrud = function activityData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aActivity = {};
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number")
        aActivity.ActKey = filter.node().value;
    else
        aActivity.ActKey = parseInt(filter.text());

    aActivity.ExcKey = 1;
    aActivity.ExcName = d3.select("#ExcName").text();
    aActivity.WrtKey = 3;
    aActivity.WrtName = d3.select("#WrtName").text();
    aActivity.ActDescription = d3.select("#ActDescription").text();
    aActivity.ActUnitOfMeasure = 3; //Hardcoded - Just to keep html simple 
    aActivity.ActMeasure = 2; //Hardcoded - Just to keep html simple 
    aActivity.ActUnitOfTime = 3; //Hardcoded - Just to keep html simple 
    aActivity.ActTime = 3; //Hardcoded - Just to keep html simple 
    aActivity.ActRepetitions = 3; //Hardcoded - Just to keep html simple 
    aActivity.ActRest = 4; //Hardcoded - Just to keep html simple 
    aActivity.ActResultType = 3;

    var Activity = { 'aActivity': aActivity };
    ajaxCall(methodname, Activity, callback);
}

//Data Arrays for Activity Crud Methods 
var activityContentTemplate = [
    { title: "Exercise Name", fieldId: "ExcKey" },
    { title: "Exercise Name", fieldId: "ExcName" },
    { title: "Workout Key", fieldId: "WrtKey" },
    { title: "Workout Name", fieldId: "WrtName" },
    { title: "Act Description", fieldId: "ActDescription" },
    { title: "Act Unit O fMeasure", fieldId: "ActUnitOfMeasure" },
    { title: "Act Unit O fMeasure", fieldId: "ActMeasure" },
    { title: "Act Unit Of Time", fieldId: "ActUnitOfTime" },
    { title: "Act Time", fieldId: "ActTime" },
    { title: "ActRepetitions", fieldId: "ActRepetitions" },
    { title: "Act Rest", fieldId: "ActRest" },
    { title: "Act ResultType", fieldId: "ActResultType" }
];

var activityloadData = [
  { methodName: "physical.aspx/loadActivity", callBack: activityLoaded }
];

var activityaddData = [
  { methodName: "physical.aspx/addActivity", callBack: activityAdded }
];

var activityeditData = [
  { methodName: "physical.aspx/editActivity", callBack: activityEdited }
];

var activitydeleteData = [
  { methodName: "physical.aspx/deleteActivity", callBack: activityDeleted }
];

var activitycollectionData = [
  { methodName: "physical.aspx/loadActivityCollection", callBack: activityCollectionLoaded }
];

var loadActivityCollectionClick = d3.select("div#loadActivityCollection").on("click", function () {

    contentSetup(activityContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(activitycollectionData)
        .text("Load Activity")
        .on("click", activitycrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var loadActivityClick = d3.select("div#loadActivity").on("click", function () {

    contentSetup(activityContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(activityloadData)
        .text("Load Activity")
        .on("click", activitycrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var addActivityClick = d3.select("div#addActivity").on("click", function () {

    contentSetup(activityContentTemplate, true);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(activityaddData)
        .text("Add Activity")
        .on("click", activitycrud);
});

var editActivityClick = d3.select("div#editActivity").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .attr("contenteditable", "true")
        .classed("delete", false)
        .classed("add", false)
        .classed("edit", true);

    d3.select(".testButton")
        .data(activityeditData)
        .text("Edit Activity")
        .on("click", activitycrud);
});

var deleteActivityClick = d3.select("div#deleteActivity").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .classed("edit", false)
        .classed("add", false)
        .classed("delete", true)
        .attr("contenteditable", "false");

    d3.select(".testButton")
        .data(activitydeleteData)
        .text("Delete Activity")
        .on("click", activitycrud);
});
