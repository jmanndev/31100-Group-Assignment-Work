<%@ Page Title="Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewReports.aspx.cs" Inherits="InterventionMonitor.ViewReports" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Label ID="lblSelect" runat="server" Text="Select report type:"></asp:Label>
    <br />
    <asp:DropDownList ID="ddlReports" runat="server" OnSelectedIndexChanged="ddlReports_SelectedIndexChanged" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblEngineer" runat="server" Text="Engineers"></asp:Label>
    <asp:DropDownList ID="ddlEngineer" runat="server" Width ="150px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblDistrict" runat="server" Text="Districts"></asp:Label>
    <asp:DropDownList ID="ddlDistrict" runat="server" Width ="150px">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnRunReport" runat="server" Text="Generate Report" OnClick="btnRunReport_Click" />
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
    <br />
    <br />
    <asp:Label ID="lblResult" runat="server" Text="Cost: $"></asp:Label>
    <asp:Label ID="lblResultView" runat="server" Text=""></asp:Label>
    
</asp:Content>
