<%@ Page Language="C#" MasterPageFile="~/masters/basetemplate.Master" AutoEventWireup="true" CodeBehind="physical.aspx.cs" Inherits="zfit.physical" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="styles/physical.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNavPlaceholder" runat="server">
    <div class="sideNavElement" id="exc" contenteditable="false">Exercises</div>
    <div class="subelementContainer" id="excCrudContainer">
        <div class="sideNavSecElement" id="loadExercise">Load Exercise</div>
        <div class="subelementContainer" id="loadExerciseCrudContainer">
            <div class="sideNavTerElement" id="editExercise">Edit Exercise</div>
            <div class="sideNavTerElement" id="deleteExercise">Delete Exercise</div>
        </div>       
        <div class="sideNavSecElement" id="addExercise">Add Exercise</div>
        <div class="sideNavSecElement" id="loadExerciseCollection">Load Exercise List</div>   
    </div>
    <div class="sideNavElement" id="act" contenteditable="false">Activities</div>
    <div class="subelementContainer" id="actCrudContainer">
        <div class="sideNavSecElement" id="loadActivity">Load Activity</div>
        <div class="subelementContainer" id="loadActivityCrudContainer">
            <div class="sideNavTerElement" id="editActivity">Edit Activity</div>
            <div class="sideNavTerElement" id="deleteActivity">Delete Activity</div>
        </div> 
        <div class="sideNavSecElement" id="addActivity">Add Activity</div>       
        <div class="sideNavSecElement" id="loadActivityCollection">Load Activity List</div>        
    </div>
    <div class="sideNavElement" id="wrt" contenteditable="false">Workouts</div>
    <div class="subelementContainer" id="wrtCrudContainer">
        <div class="sideNavSecElement" id="loadWorkout">Load Workout</div>
        <div class="subelementContainer" id="loadWorkoutCrudContainer">
            <div class="sideNavTerElement" id="editWorkout">Edit Workout</div>
            <div class="sideNavTerElement" id="deleteWorkout">Delete Workout</div>
        </div> 
        <div class="sideNavSecElement" id="addWorkout">Add Workout</div>
        <div class="sideNavSecElement" id="loadWorkoutCollection">Load Workout List</div>              
        <div class="sideNavSecElement" id="fanworkoutCollection">Fan Workout List</div>        
        <div class="subelementContainer" id="fanworkoutCollectionCrudContainer">
            <div class="sideNavTerElement" id="editFanworkout">Edit Fan's Workouts</div>
        </div> 
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <input class="textFilter" id="textFilter" contenteditable="true" /> 
    <div class="testButton"> TEST </div>
   
      <%--Scripts--%>
        <script type="text/javascript" src="scripts/jquery-1.10.1.min.js"></script>  
        <script type="text/javascript" src="scripts/d3.v3.min.js"></script> 
        <%--<script src="http://d3js.org/d3.v3.min.js" charset="utf-8"></script>--%>
        <script type="text/javascript" src="../scripts/base.js"></script> 
        <script type="text/javascript" src="scripts/physical.js"></script> 
</asp:Content>
