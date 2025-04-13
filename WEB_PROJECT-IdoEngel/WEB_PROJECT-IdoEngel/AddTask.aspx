<%@ Page Title="" Language="C#" MasterPageFile="~/Consts.Master" AutoEventWireup="true" CodeBehind="AddTask.aspx.cs" Inherits="WEB_PROJECT_IdoEngel.AddTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="ShowTasks.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="form-card">
    <h1>Add a new task</h1>
    <form>
      <div class="form-field">
        <label for="title">Title</label>
        <input type="text" id="title" name="title">
      </div>

      <div class="form-field">
        <label for="content">What to do?</label>
        <textarea id="content" name="content"></textarea>
      </div>

      <div class="form-field">
        <label for="date">Pick a date</label>
        <input type="date" id="date" name="date">
      </div>

     <div class="form-field">
      <label for="isImportant">
        <input type="checkbox" id="isImportant" name="isImportant">
        Important
      </label>
    </div>

      <button type="submit", id="submit">ADD!</button>
    </form>
  </div>

</asp:Content>
