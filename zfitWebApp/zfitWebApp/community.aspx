<%@ Page Language="C#" MasterPageFile="~/masters/basetemplate.Master" AutoEventWireup="true" CodeBehind="community.aspx.cs" Inherits="zfit.community" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="styles/profile.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNavPlaceholder" runat="server">
    <div class="sideNavElement" id="frd" contenteditable="false">Friends</div>
    <div class="subelementContainer" id="frdCrudContainer">
        <div class="sideNavSecElement" id="loadFriends">Load Friend List</div>
        <div class="subelementContainer" id="loadFriendsCrudContainer">
            <div class="sideNavTerElement" id="editFriends">Edit Friends List</div>
        </div>       
        <div class="sideNavSecElement" id="fancelllist">Fan's Cell List</div>
        <div class="subelementContainer" id="fancelllistCrudContainer">
            <div class="sideNavTerElement" id="editFancells">Edit Fan's Cell List</div>
        </div> 
        <div class="sideNavSecElement" id="fanfedlist">Fan's Fed List</div>
        <div class="subelementContainer" id="fanfedlistCrudContainer">
            <div class="sideNavTerElement" id="editFanfeds">Edit Fan's Fed List</div>
        </div> 
    </div>
    <div class="sideNavElement" id="cel" contenteditable="false">Cells</div>
    <div class="subelementContainer" id="celCrudContainer">
        <div class="sideNavSecElement" id="loadCell">Load Cell</div>
        <div class="subelementContainer" id="loadCellCrudContainer">
            <div class="sideNavTerElement" id="editCell">Edit Cell</div>
            <div class="sideNavTerElement" id="deleteCell">Delete Cell</div>
        </div> 
        <div class="sideNavSecElement" id="addCell">Add Cell</div>       
        <div class="sideNavSecElement" id="cellfanlist">Cell's Fan List</div>        
        <div class="subelementContainer" id="cellfanlistCrudContainer">
            <div class="sideNavTerElement" id="editCellfans">Edit Cell's Fan List</div>
        </div> 
        <div class="sideNavSecElement" id="cellfedlist">Cell's Fed List</div>  
        <div class="subelementContainer" id="cellfedlistCrudContainer">
            <div class="sideNavTerElement" id="editCellfeds">Edit Cell's Fed List</div>
        </div> 
    </div>
    <div class="sideNavElement" id="fed" contenteditable="false">Federations</div>
    <div class="subelementContainer" id="fedCrudContainer">
        <div class="sideNavSecElement" id="loadFed">Load Fed</div>
        <div class="subelementContainer" id="loadFedCrudContainer">
            <div class="sideNavTerElement" id="editFed">Edit Fed</div>
            <div class="sideNavTerElement" id="deleteFed">Delete Fed</div>
        </div> 
        <div class="sideNavSecElement" id="addFed">Add Fed</div>
        <div class="sideNavSecElement" id="fedfanlist">Fed Fan's List</div>       
        <div class="subelementContainer" id="fedfanlistCrudContainer">
            <div class="sideNavTerElement" id="editFedFans">Edit Fed's Fan List</div>
        </div> 
        <div class="sideNavSecElement" id="fedcelllist">Fed Cell's List</div>
        <div class="subelementContainer" id="fedcelllistCrudContainer">
            <div class="sideNavTerElement" id="editFedCells">Edit Fed's Cell List</div>
        </div> 
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <input class="textFilter" id="textFilter" contenteditable="true" /> 
    <div class="testButton"> TEST </div>
   
      <%--Scripts--%>
        <script type="text/javascript" src="scripts/jquery-1.10.1.min.js"></script>  
        <script src="http://d3js.org/d3.v3.min.js" charset="utf-8"></script>
        <script type="text/javascript" src="../scripts/base.js"></script> 
        <script type="text/javascript" src="scripts/community.js"></script> 
</asp:Content>

