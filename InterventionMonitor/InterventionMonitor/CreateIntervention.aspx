<%@ Page Title="Create Intervention" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CreateIntervention.aspx.cs" Inherits="InterventionMonitor.CreateIntervention" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content" style="height: 308px">


        <br />
        
        <asp:Label ID="lblName" runat="server" Text="Name" Width="100px"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" Width="150px"></asp:TextBox>
        
        <br />
        <br />
        
        <asp:Label ID="lblDistrict" runat="server" Text="District" Width="100px"></asp:Label>
        <asp:DropDownList ID="ddlDistrict" runat="server" Width="150px" >
        </asp:DropDownList>
        <br />
        <br />
        
        <asp:Label ID="lblAddress" runat="server" Text="Address" Width="100px"></asp:Label>
        
        
        <asp:TextBox ID="txtAddress" runat="server" Width="150px"></asp:TextBox>
        
        <br />
        <br />
        
        <asp:Label ID="lblNotes" runat="server" Text="Notes" Width="100px"></asp:Label>
        
        
        <asp:TextBox ID="txtNotes" runat="server" Width="361px"  TextMode="MultiLine"></asp:TextBox>
        
        <br />
        <br />

        <div ID= "holders" style="width:463px;">
        <asp:Button ID="BtnSubmit" runat="server" Text="Submit" style="float: right;" OnClick="SubmitButton_Click"></asp:Button>
        </div>

        <asp:Label ID ="lblErrorMessage" runat="server" Width="250px" ForeColor="Red" Font-Bold="true"></asp:Label>

    </div>
</asp:Content>
