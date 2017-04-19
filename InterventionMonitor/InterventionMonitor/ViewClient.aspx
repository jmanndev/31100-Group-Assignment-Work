<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewClient.aspx.cs" Inherits="InterventionMonitor.ViewClient" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content" style="height: 308px">


        <br />
        
        <asp:Label ID="lblName" runat="server" Text="Name" Width="100px"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>

        <br /><br />

        <asp:Label ID="lblAddress" runat="server" Text="Name" Width="100px"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server" Width="150px"></asp:TextBox>

        <br /><br />
        
        <asp:Label ID="lblNotes" runat="server" Text="Notes" Width="100px"></asp:Label>
        <asp:TextBox ID="txtNotes" runat="server" Width="361px"  TextMode="MultiLine"></asp:TextBox>

        <br /><br />
        
        <asp:Label ID="lblInterventions" runat="server" Text="Interventions" Width="100px"></asp:Label> <br />
        <asp:ListBox ID="LbInterventions" runat="server" Width="400px"></asp:ListBox>

    </div>
</asp:Content>
