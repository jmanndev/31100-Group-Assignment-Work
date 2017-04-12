<%@ Page Title="Interventions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInterventions.aspx.cs" Inherits="InterventionMonitor.ViewInterventions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content" style="height: 308px">


        
        <asp:ListBox ID="LbInterventions" runat="server" Height="249px" Width="400px"></asp:ListBox>


    </div>
</asp:Content>