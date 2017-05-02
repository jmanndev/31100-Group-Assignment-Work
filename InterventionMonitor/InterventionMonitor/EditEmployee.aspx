<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="InterventionMonitor.EditEmployee" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content" style="height: 308px">

        <asp:Label ID="lblEmployeeID" runat="server" Text="Employee ID:"></asp:Label>
        <asp:Label ID="lblDisplayEmployeeID" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblEmployeeName" runat="server" Text="Name"></asp:Label>
        <asp:Label ID="lblDisplayEmployeeName" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblEmployeeUserName" runat="server" Text="Username"></asp:Label>
        <asp:Label ID="lblDisplayEmployeeUserName" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="lblDistrict" runat="server" Text="District"></asp:Label>
        <asp:DropDownList ID="ddlDistrict" runat="server">
        </asp:DropDownList>
        <br />



        <br />
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />



    </div>
</asp:Content>
