<%@ Page Title="Manager" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerView.aspx.cs" Inherits="InterventionMonitor.ManagerView" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Button ID="btnView" runat="server" OnClick="Button1_Click" Text="Interventions awaiting approval" />




</asp:Content>
