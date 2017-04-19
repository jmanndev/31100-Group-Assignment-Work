<%@ Page Title="Site Engineer Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateClient.aspx.cs" Inherits="InterventionMonitor.SiteEngineerHome" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content" style="height: 308px">

        <asp:Button ID="BtnChangeDetails" runat="server" Text="My Details" Width="200px" />
        <br />
        <br />
        <asp:Button ID="BtnMyClients" runat="server" Text="My Clients" OnClick="BtnMyClients_Click" Width="200px" />
        <br />
        <br />
        <asp:Button ID="BtnMyInterventions" runat="server" Text="My Interventions" OnClick="BtnMyInterventions_Click" Width="200px" />
        <br />
        <br />
        <asp:Button ID="BtnCreateClient" runat="server" Text="New Client" OnClick="BtnCreateClient_Click" Width="200px" />

    </div>
</asp:Content>
