<%@ Page Title="" Language="C#" MasterPageFile="~/Consts.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WEB_PROJECT_IdoEngel.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Table.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form1" runat="server">
  <div class="btn-container">
    <input type="text" name="inputField" id="inputField" placeholder="what to delete?" class="delField" />
    <button type="submit" name="delBtn" id="delBtn" class="delBtn">Delete!</button>
  </div>
  <asp:Literal ID="litTable" runat="server" />
</form>
    
    
    <div class="table-container">
        <%=fromDal %>
    </div>
    
</asp:Content>
