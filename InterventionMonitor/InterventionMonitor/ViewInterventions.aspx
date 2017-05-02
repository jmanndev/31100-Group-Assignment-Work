<%@ Page Title="Interventions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewInterventions.aspx.cs" Inherits="InterventionMonitor.ViewInterventions" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content">
        <asp:GridView ID="GwInterventions" runat="server"
            AutoGenerateColumns="false"
            OnRowEditing="GwInterventions_RowEditing">
            <Columns>
                <asp:BoundField DataField="ID"  HeaderText="ID" SortExpression="ID" />
                <asp:BoundField DataField="DisplayClient"  HeaderText="Client" SortExpression="DisplayClient" />
                <asp:BoundField DataField="DisplayDate"  HeaderText="Date" SortExpression="DisplayDate" />
                <asp:BoundField DataField="DisplayType"  HeaderText="Type" SortExpression="DisplayType" />
                <asp:BoundField DataField="HoursRequired"  HeaderText="Hours Required" SortExpression="HoursRequired" />
                <asp:BoundField DataField="CostRequired"  HeaderText="Cost Required (AUD)" SortExpression="CostRequired" />
                <asp:BoundField DataField="DisplayStatus"  HeaderText="Status" SortExpression="DisplayStatus" />
                <asp:BoundField DataField="Life"  HeaderText="Remaining Life" SortExpression="Life" />
                <asp:CommandField ShowEditButton="true" ButtonType="Button" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
