<%@ Page Title="Create Client" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="CreateClient.aspx.cs" Inherits="InterventionMonitor.CreateClient" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content" style="height: 308px">


        <br />

        <asp:Label ID="lblName" runat="server" Text="Name" Width="100px" AssociatedControlID="txtName"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" Width="150px" AutoPostBack="True"></asp:TextBox>

        <asp:RequiredFieldValidator ID="rfvForName" runat="server" ControlToValidate="txtName" ErrorMessage="Set client name" ForeColor="Red"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblDistrict" runat="server" AssociatedControlID="lblDistrictValue" Text="District" Width="100px"></asp:Label>
        <asp:Label ID="lblDistrictValue" runat="server" Width="300px"></asp:Label>

        <br />
        <br />

        <asp:Label ID="lblAddress" runat="server" Text="Address" Width="100px" AssociatedControlID="txtAddress"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server" Width="150px"></asp:TextBox>

        <br />
        <br />

        <asp:Label ID="lblNotes" runat="server" Text="Notes" Width="100px" AssociatedControlID="txtNotes"></asp:Label>
        <asp:TextBox ID="txtNotes" runat="server" Width="361px" TextMode="MultiLine"></asp:TextBox>

        <br />
        <br />

        <div id="button-container">
            <asp:Button ID="BtnCreate" runat="server" Text="Create Client" class="button-submit" OnClick="CreateButton_Click"></asp:Button>
        </div>

    </div>
</asp:Content>
