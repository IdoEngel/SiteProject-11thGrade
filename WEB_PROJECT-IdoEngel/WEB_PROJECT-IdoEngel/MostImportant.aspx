<%@ Page Title="" Language="C#" MasterPageFile="~/Consts.Master" AutoEventWireup="true" CodeBehind="MostImportant.aspx.cs" Inherits="WEB_PROJECT_IdoEngel.MostImportant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ShowTasks.css" rel="stylesheet" />
    <link href="Table.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%=fromDal %>
</asp:Content>
