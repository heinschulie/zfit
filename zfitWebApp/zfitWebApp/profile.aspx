<%@ Page Title="" Language="C#" MasterPageFile="~/masters/basetemplate.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="zfit.profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="styles/profile.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sideNavPlaceholder" runat="server">
    <div class="sideNavElement" id="loadFan" contenteditable="false">Load Fan</div>
    <div class="sideNavElement" id="editFan" contenteditable="false">Edit Fan</div>
    <div class="sideNavElement" id="deleteFan" contenteditable="false">Delete Fan</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="properties" id="fanUserID"></div>
    <div class="properties" id="fanPassword"></div>
    <div class="properties" id="fanName"></div>
    <div class="properties" id="fanSurname"></div>
    <div class="properties" id="fanEmail"></div>
    <div class="properties" id="fanAvatar"></div>
    <div class="testButton"> TEST </div>
   
      <%--Scripts--%>
        <script type="text/javascript" src="scripts/jquery-1.10.1.min.js"></script>  
        <script src="http://d3js.org/d3.v3.min.js" charset="utf-8"></script>
        <script type="text/javascript" src="../scripts/base.js"></script> 
        <script type="text/javascript" src="scripts/profile.js"></script> 
</asp:Content>
