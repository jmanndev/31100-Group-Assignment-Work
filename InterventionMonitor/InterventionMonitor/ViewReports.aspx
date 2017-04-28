<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="InterventionMonitor.ViewReports" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:Label ID="lblSelect" runat="server" Text="Select report type:"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlReports" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:ListBox ID="lbResults" runat="server"></asp:ListBox>
</asp:Content>
