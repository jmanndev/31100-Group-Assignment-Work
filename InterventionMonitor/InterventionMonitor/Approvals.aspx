<%@ Page Title="Awaiting Approval" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Approvals.aspx.cs" Inherits="InterventionMonitor.Approvals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:GridView ID="gvApprovals" runat="server"></asp:GridView>
</asp:Content>
