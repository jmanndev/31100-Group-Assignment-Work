<%@ Page Title="Clients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewClients.aspx.cs" Inherits="InterventionMonitor.ViewClients" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content" style="height: 308px">





        <asp:ListBox ID="LbClients" runat="server" Height="249px" Width="400px"></asp:ListBox>





        <br />
        <br />

        <div id="btnHolder" style="width: 400px;"><br style="clear: both;" />
            <asp:Button ID="BtnCreateClient" runat="server" Text="New Client" Style="float: right;" OnClick="BtnCreateClient_Click" />
        </div>
    </div>
</asp:Content>
