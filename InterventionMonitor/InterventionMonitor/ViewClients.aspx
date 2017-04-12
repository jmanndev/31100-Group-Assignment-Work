<%@ Page Title="Clients" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewClients.aspx.cs" Inherits="InterventionMonitor.ViewClients" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content" style="height: 308px">
        




        <asp:ListBox ID="ListBox1" runat="server" Height="249px" Width="400px"></asp:ListBox>
        




        <br />
        <br />
        <div ID="btnHolder" style="width:400px;">
            <asp:Button ID="BtnCreate" runat="server" Text="New Client" style="float:right;" OnClick="BtnCreate_Click"/>
        </div>




    </div>
</asp:Content>