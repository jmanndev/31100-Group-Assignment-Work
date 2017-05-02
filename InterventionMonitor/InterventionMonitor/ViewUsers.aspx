<%@ Page Title="Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewUsers.aspx.cs" Inherits="InterventionMonitor.ViewUsers" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content" style="height: 308px">


        <asp:ListBox ID="lbUsers" runat="server" Width="200px"></asp:ListBox>
        <br />
        <asp:Button ID="btnAll" runat="server" Text="All" OnClick="btnAll_Click" padding="20px"/>
        <asp:Button ID="btnEngineer" runat="server" Text="Site Engineer" OnClick="btnEngineer_Click" padding="20px"/>
        <asp:Button ID="btnManager" runat="server" Text="Manager" OnClick="btnManager_Click" padding="20px"/>
        <br />
        <br />
        <asp:Button ID="btnEdit" runat="server" OnClick="btnEdit_Click" Text="Edit" />


    </div>
</asp:Content>
