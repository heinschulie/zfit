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


// ||||||||||||||   ***    FANWORKOUT CRUD    ***    |||||||||||||||| //

//Callbacks for FANWORKOUT CRUD 

var populateCollectionFields = function (anArray, fanworkout) {

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
    if (fanworkout === "fan") {
        elements.text(function (d) { return d.WrtName });
    }
    else {
        elements.text(function (d) { return d.FanName });
    }

    //Exit
    elements
        .exit()
        .remove();
};

var fanWorkoutCollectionLoaded = function (aFanWorkoutCollection) {
    populateCollectionFields(aFanWorkoutCollection.FanWorkoutList, "fan");
};

var fanWorkoutCollectionEdited = function (aFanWorkoutCollection) {
    populateCollectionFields(aFanWorkoutCollection.FanWorkoutList, "fan");
};


// FANWORKOUT Methods and Events  

var fanworkoutcrud = function fanworkoutData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aFanWorkoutCollection = { FanWorkoutFilter: { FawFilter: {} } };
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number") {
        aFanWorkoutCollection.isFiltered = true;
        if (d.filtertype === "fan")
            aFanWorkoutCollection.FanWorkoutFilter.FawFilter.FanKey = filter.node().value;
        else
            aFanWorkoutCollection.FanWorkoutFilter.FawFilter.WrtKey = filter.node().value;
    }
    else {
        aFanWorkoutCollection.isFiltered = true;
        if (d.filtertype === "fan")
            aFanWorkoutCollection.FanWorkoutFilter.FawFilter.FanName = filter.text();
        else
            aFanWorkoutCollection.FanWorkoutFilter.FawFilter.WrtName = filter.text();
    }

    //Remove the fanworkouts that are have checkboxes that are checked 
    if (d.crudtype === "edit") {
        aFanWorkoutCollection.FanWorkoutList = [];
        var chkboxes = d3.selectAll("input.chkbox");
        chkboxes.each(function (d, i) {
            if (chkboxes[0][i].checked === false) {
                var FanWorkout = {};
                var thisfanworkout = chkboxes[0][i].__data__;
                FanWorkout.FanKey = thisfanworkout.FanKey;
                FanWorkout.WrtKey = thisfanworkout.WrtKey;
                FanWorkout.FanWorkoutDateCreated = thisfanworkout.FanWorkoutDateCreated;

                aFanWorkoutCollection.FanWorkoutList.push(FanWorkout);
            }
        });
    }

    var FanWorkoutCollection = { 'aFanWorkoutCollection': aFanWorkoutCollection };
    ajaxCall(methodname, FanWorkoutCollection, callback);
}

//Data Arrays for FanWorkout Crud Methods 
var fanworkoutContentTemplate = [
    { title: "Fan Key", fieldId: "FanKey" },
    { title: "Wrt Key", fieldId: "WrtKey" },
    { title: "Wrt Name", fieldId: "WrtName" }
];

// Fan viewing his/her workouts 
var fanworkoutloadData = [
  { methodName: "physical.aspx/loadFanWorkoutCollection", callBack: fanWorkoutCollectionLoaded, filtertype: "fan" }
];
// Fan editing his/her workouts 
var fanworkouteditData = [
  { methodName: "physical.aspx/editFanWorkoutCollection", callBack: fanWorkoutCollectionEdited, filtertype: "fan", crudtype: "edit" }
];

//*** FANWORKOUT's from Cells perspective

var loadFanWorkoutClick = d3.select("div#fanworkoutCollection").on("click", function () {

    contentSetup(fanworkoutContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fanworkoutloadData)
        .text("Load FanWorkout")
        .on("click", fanworkoutcrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var editfanWorkoutClick = d3.select("div#editFanworkout").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(fanworkouteditData)
        .text("Edit FanWorkout")
        .on("click", fanworkoutcrud);
});

// ||||||||||||||   ***    FANSESSION CRUD    ***    |||||||||||||||| //

//Callbacks for FANSESSION CRUD 

var populateSessionCollectionFields = function (anArray, fansession) {

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
    if (fansession === "fan") {
        elements.text(function (d) { return d.WrtName });
    }
    else {
        elements.text(function (d) { return d.FanName });
    }

    //Exit
    elements
        .exit()
        .remove();
};

var populateFanSessionFields = function (aFanSession) {
    d3.select("#FanKey").text(aFanSession.FanKey);
    d3.select("#FanName").text(aFanSession.FanDisplayName);
    d3.select("#WrtKey").text(aFanSession.WrtKey);
    d3.select("#WrtName").text(aFanSession.WrtName);
    d3.select("#FanSessionDateDone").text(aFanSession.FanSessionDateDone);
    d3.select("#CelKey").text(aFanSession.CelKey);
    d3.select("#CelName").text(aFanSession.CelName);
    d3.select("#PrgKey").text(aFanSession.PrgKey);
    d3.select("#PrgName").text(aFanSession.PrgName);
    d3.select("#FssLock").text(aFanSession.FssLock);
};

var fanSessionCollectionLoaded = function (aFanSessionCollection) {
    populateSessionCollectionFields(aFanSessionCollection.FanSessionList, "fan");
};

var fanSessionCollectionEdited = function (aFanSessionCollection) {
    populateSessionCollectionFields(aFanSessionCollection.FanSessionList, "fan");
};

var fanSessionLoaded = function (aFanSession) {
    populateFanSessionFields(aFanSession);
};

var fanSessionAdded = function (aFanSession) {
    populateFanSessionFields(aFanSession);
};

var fanSessionEdited = function (aFanSession) {
    populateFanSessionFields(aFanSession);
};

var fanSessionDeleted = function (aFanSession) {
    alert("FanSession Deleted");
};


// FANSESSION Methods and Events  

var fansessionCollectioncrud = function fansessionData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aFanSessionCollection = { FanSessionFilter: { FssFilter: {} } };
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number") {
        aFanSessionCollection.isFiltered = true;
        if (d.filtertype === "fss")
            aFanSessionCollection.FanSessionFilter.FssFilter.FanKey = filter.node().value;
        else
            aFanSessionCollection.FanSessionFilter.FssFilter.WrtKey = filter.node().value;
    }
    else {
        aFanSessionCollection.isFiltered = true;
        if (d.filtertype === "fan")
            aFanSessionCollection.FanSessionFilter.FssFilter.FanName = filter.text();
        else
            aFanSessionCollection.FanSessionFilter.FssFilter.WrtName = filter.text();
    }

    //Remove the fansessions that are have checkboxes that are checked 
    if (d.crudtype === "edit") {
        aFanSessionCollection.FanSessionList = [];
        var chkboxes = d3.selectAll("input.chkbox");
        chkboxes.each(function (d, i) {
            if (chkboxes[0][i].checked === false) {
                var FanSession = {};
                var thisfansession = chkboxes[0][i].__data__;
                FanSession.FanKey = thisfansession.FanKey;
                FanSession.WrtKey = thisfansession.WrtKey;
                FanSession.CelKey = thisfansession.CelKey;
                FanSession.PrgKey = thisfansession.PrgKey;
                FanSession.FssLock = thisfansession.FssLock;
                FanSession.FanSessionDateDone = thisfansession.FanSessionDateDone;

                aFanSessionCollection.FanSessionList.push(FanSession);
            }
        });
    }

    var FanSessionCollection = { 'aFanSessionCollection': aFanSessionCollection };
    ajaxCall(methodname, FanSessionCollection, callback);
}

//Data Arrays for FanSession Crud Methods 
var fansessionContentTemplate = [
    { title: "Fan Key", fieldId: "FanKey" },
    { title: "Fan Name", fieldId: "FanName" },
    { title: "Wrt Key", fieldId: "WrtKey" },
    { title: "Wrt Name", fieldId: "WrtName" },
    { title: "Fss Date Done", fieldId: "FanSessionDateDone" },
    { title: "Cel Key", fieldId: "CelKey" },
    { title: "Cel Name", fieldId: "CelName" },
    { title: "Prg Key", fieldId: "PrgKey" },
    { title: "Prg Name", fieldId: "PrgName" },
    { title: "Fss Lock", fieldId: "FssLock" }
];

// Fan viewing his/her sessions 
var fansessionCollectionloadData = [
  { methodName: "physical.aspx/loadFanSessionCollection", callBack: fanSessionCollectionLoaded, filtertype: "fan" }
];
// Fan editing his/her sessions 
var fansessionCollectioneditData = [
  { methodName: "physical.aspx/editFanSessionCollection", callBack: fanSessionCollectionEdited, filtertype: "fan", crudtype: "edit" }
];

var fanSessionloadData = [
  { methodName: "physical.aspx/loadFanSession", callBack: fanSessionLoaded }
];

var fanSessionaddData = [
  { methodName: "physical.aspx/addFanSession", callBack: fanSessionAdded }
];

var fanSessioneditData = [
  { methodName: "physical.aspx/editFanSession", callBack: fanSessionEdited }
];

var fanSessiondeleteData = [
  { methodName: "physical.aspx/deleteFanSession", callBack: fanSessionDeleted }
];

//*** FANSESSION's from Cells perspective

var loadFanSessionCollectionClick = d3.select("div#fansessionCollection").on("click", function () {

    contentSetup(fansessionContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fansessionCollectionloadData)
        .text("Load FanSession")
        .on("click", fansessionCollectioncrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var editFansessionCollectionClick = d3.select("div#editFansessionCollection").on("click", function () {
    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(fansessionCollectioneditData)
        .text("Edit FanSession")
        .on("click", fansessionCollectioncrud);
});

// FANSESSION Methods and Events  

var fanSessioncrud = function fanSessionData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aFanSession = {};
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number")
        aFanSession.FssKey = filter.node().value;
    else
        aFanSession.FssKey = parseInt(filter.text());

    aFanSession.FanKey = 2;
    aFanSession.FanName = d3.select("#FanName").text();
    aFanSession.WrtKey = 3;
    aFanSession.WrtName = d3.select("#WrtName").text();
    aFanSession.FanSessionDateDone = d3.select("#FanSessionDateDone").text();
    aFanSession.CelKey = 3; //Hardcoded - Just to keep html simple 
    aFanSession.CelName = d3.select("#CelName").text();
    aFanSession.PrgKey = 1; //Hardcoded - Just to keep html simple 
    aFanSession.PrgName = d3.select("#PrgName").text();
    aFanSession.FssLock = false; //Hardcoded - Just to keep html simple 

    var FanSession = { 'aFanSession': aFanSession };
    ajaxCall(methodname, FanSession, callback);
}


var loadFanSessionClick = d3.select("div#loadFanSession").on("click", function () {

    contentSetup(fansessionContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fanSessionloadData)
        .text("Load FanSession")
        .on("click", fanSessioncrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var addFanSessionClick = d3.select("div#addFanSession").on("click", function () {

    contentSetup(fansessionContentTemplate, true);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(fanSessionaddData)
        .text("Add FanSession")
        .on("click", fanSessioncrud);
});

var editFanSessionClick = d3.select("div#editFanSession").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .attr("contenteditable", "true")
        .classed("delete", false)
        .classed("add", false)
        .classed("edit", true);

    d3.select(".testButton")
        .data(fanSessioneditData)
        .text("Edit FanSession")
        .on("click", fanSessioncrud);
});

var deleteFanSessionClick = d3.select("div#deleteFanSession").on("click", function () {
    d3.select("div.content")
        .selectAll("div.properties")
        .classed("edit", false)
        .classed("add", false)
        .classed("delete", true)
        .attr("contenteditable", "false");

    d3.select(".testButton")
        .data(fanSessiondeleteData)
        .text("Delete FanSession")
        .on("click", fanSessioncrud);
});






// ||||||||||||||   ***    SESSIONACTIVITY CRUD    ***    |||||||||||||||| //

//Callbacks for SESSIONACTIVITY CRUD 

var populateFSACollectionFields = function (anArray, sessionactivity) {

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
    if (sessionactivity === "activity") {
        elements.text(function (d) { return d.FsaResult });
    }
    else {
        elements.text(function (d) { return d.FsaResult });
    }

    //Exit
    elements
        .exit()
        .remove();
};

var activitySessionCollectionLoaded = function (aSessionActivityCollection) {
    populateFSACollectionFields(aSessionActivityCollection.FanSessionActivityList, "activity");
};

var activitySessionCollectionEdited = function (aSessionActivityCollection) {
    populateFSACollectionFields(aSessionActivityCollection.FanSessionActivityList, "activity");
};

var sessionActivityCollectionLoaded = function (aSessionActivityCollection) {
    populateFSACollectionFields(aSessionActivityCollection.FanSessionActivityList, "session");
};

var sessionActivityCollectionEdited = function (aSessionActivityCollection) {
    populateFSACollectionFields(aSessionActivityCollection.FanSessionActivityList, "session");
};

// SESSIONACTIVITY Methods and Events  

var sessionactivitycrud = function sessionactivityData(d, i) {

    var methodname = d.methodName;
    var callback = d.callBack;
    var aFanSessionActivityCollection = { FanSessionActivityFilter: { FanSessionActivityFilter: {} } };
    var filter = d3.select("#textFilter");

    if (filter.attr("type") === "number") {
        aFanSessionActivityCollection.isFiltered = true;
        if (d.filtertype === "activity")
            aFanSessionActivityCollection.FanSessionActivityFilter.FanSessionActivityFilter.ActKey = filter.node().value;
        else
            aSessionActivityCollection.FanSessionActivityFilter.FanSessionActivityFilter.FssKey = filter.node().value;
    }
    else {
        aSessionActivityCollection.isFiltered = true;
        if (d.filtertype === "activity")
            aSessionActivityCollection.SessionActivityFilter.SessionactivityFilter.ActivityName = filter.text();
        else
            aSessionActivityCollection.SessionActivityFilter.SessionactivityFilter.SessionName = filter.text();
    }

    //Remove the sessionactivitys that are have checkboxes that are checked 
    if (d.crudtype === "edit") {
        aFanSessionActivityCollection.FanSessionActivityList = [];
        var chkboxes = d3.selectAll("input.chkbox");
        chkboxes.each(function (d, i) {
            if (chkboxes[0][i].checked === false) {
                var FanSessionActivity = {};
                var thissessionactivity = chkboxes[0][i].__data__;
                FanSessionActivity.FanKey = thissessionactivity.FanKey;
                FanSessionActivity.WrtKey = thissessionactivity.WrtKey;
                FanSessionActivity.FssKey = thissessionactivity.FssKey;
                FanSessionActivity.ExcKey = thissessionactivity.ExcKey;
                FanSessionActivity.ActKey = thissessionactivity.ActKey;
                FanSessionActivity.FsaResult = thissessionactivity.FsaResult;

                aFanSessionActivityCollection.FanSessionActivityList.push(FanSessionActivity);
            }
        });
    }

    var FanSessionActivityCollection = { 'aFanSessionActivityCollection': aFanSessionActivityCollection };
    ajaxCall(methodname, FanSessionActivityCollection, callback);
}

//Data Arrays for SessionActivity Crud Methods 
var sessionactivityContentTemplate = [
    { title: "Fan Key", fieldId: "FanKey" },
    { title: "Wrt Key", fieldId: "WrtKey" },
    { title: "Fss Key", fieldId: "FssKey" },
    { title: "Exc Key", fieldId: "ExcKey" },
    { title: "Act Key", fieldId: "ActKey" },    
    { title: "Fsa Result", fieldId: "FsaResult" }
];

// Activity viewing his/her sessions 
var activityssessionsloadData = [
  { methodName: "physical.aspx/loadFanSessionActivityCollection", callBack: activitySessionCollectionLoaded, filtertype: "activity" }
];
// Activity editing his/her sessions 
var activityssessionseditData = [
  { methodName: "physical.aspx/editFanSessionActivityCollection", callBack: activitySessionCollectionEdited, filtertype: "activity", crudtype: "edit" }
];
// Session viewing its activitys 
var sessionsactivitysloadData = [
  { methodName: "physical.aspx/loadFanSessionActivityCollection", callBack: sessionActivityCollectionLoaded, filtertype: "session" }
];
// Session editing its activitys 
var sessionsactivityseditData = [
  { methodName: "physical.aspx/editFanSessionActivityCollection", callBack: sessionActivityCollectionEdited, filtertype: "session", crudtype: "edit" }
];

//*** SESSIONACTIVITY's from Activitys perspective 

var loadactivitySessionClick = d3.select("div#activitySessionCollection").on("click", function () {

    contentSetup(sessionactivityContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(activityssessionsloadData)
        .text("Load SessionActivity")
        .on("click", sessionactivitycrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

//Editing of list follows a different pattern  
var editactivitySessionClick = d3.select("div#editActivitySessionCollection").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(activityssessionseditData)
        .text("Edit SessionActivity")
        .on("click", sessionactivitycrud);
});

//*** SESSIONACTIVITY's from Sessions perspective

var loadSessionActivityClick = d3.select("div#sessionactivitylist").on("click", function () {

    contentSetup(sessionactivityContentTemplate, false);

    d3.select("#textFilter")
        .attr("type", "number");

    d3.select(".testButton")
        .data(sessionsactivitysloadData)
        .text("Load SessionActivity")
        .on("click", sessionactivitycrud);

    var container = d3.select("div#" + this.id + "CrudContainer");
    sidenav(container);
});

var editsessionActivityClick = d3.select("div#editSessionactivitys").on("click", function () {

    var elements = d3.select("div.content")
        .selectAll("div.properties");

    elements
       .each(function (d) {
           d3.select(this).append("input")
             .attr("type", "checkbox")
             .classed("chkbox", true);
       });

    d3.select(".testButton")
        .data(sessionsactivityseditData)
        .text("Edit SessionActivity")
        .on("click", sessionactivitycrud);
});
