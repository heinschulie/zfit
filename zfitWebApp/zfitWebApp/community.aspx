<%@ Page Language="C#" MasterPageFile="~/masters/basetemplate.Master" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="zfit.community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="styles/profile.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNavPlaceholder" runat="server">
    <div class="sideNavElement" id="frd" contenteditable="false">Friends</div>
        <div class="subelementContainer" id="frdCrudContainer">
            <div class="sideNavSubElement" id="loadFriends">Load Friend List</div>
            <div class="sideNavSubElement" id="editFriends">Edit Friends List</div>
        </div>
    <div class="sideNavElement" id="cel" contenteditable="false">Cells</div>
        <div class="subelementContainer" id="celCrudContainer">
            <div class="sideNavSubElement" id="loadCell">Load Cell</div>
            <div class="sideNavSubElement" id="editCell">Edit Cell</div>
            <div class="sideNavSubElement" id="deleteCell">Delete Cell</div>
            <div class="sideNavSubElement" id="fancelllist">Fan's Cell List</div>
            <div class="sideNavSubElement" id="cellfanlist">Cell's Fan List</div>
            <div class="sideNavSubElement" id="cellfedlist">Cell's Fed List</div>
        </div>
    <div class="sideNavElement" id="fed" contenteditable="false">Federations</div>
        <div class="subelementContainer" id="fedCrudContainer">
            <div class="sideNavSubElement" id="loadFed">Load Fed</div>
            <div class="sideNavSubElement" id="editFed">Edit Fed</div>
            <div class="sideNavSubElement" id="deleteFed">Delete Fed</div>
            <div class="sideNavSubElement" id="fedfanlist">Fed Fan's List</div>
            <div class="sideNavSubElement" id="fedcelllist">Fed Cell's List</div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <input class="textFilter" id="textFilter" contenteditable="true"></input>
    <div class="testButton"> TEST </div>
   
      <%--Scripts--%>
        <script type="text/javascript" src="scripts/jquery-1.10.1.min.js"></script>  
        <script src="http://d3js.org/d3.v3.min.js" charset="utf-8"></script>
        <script type="text/javascript" src="../scripts/base.js"></script> 
        <script type="text/javascript" src="scripts/community.js"></script> 
</asp:Content>

