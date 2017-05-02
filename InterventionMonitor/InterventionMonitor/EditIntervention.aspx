<%@ Page Title="Edit Intervention" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="EditIntervention.aspx.cs" Inherits="InterventionMonitor.EditIntervention" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content">

        <br />

        <asp:Label ID="lblClient" runat="server" Text="Client" Width="120px" AssociatedControlID="lblClientValue"></asp:Label>
        <asp:Label ID="lblClientValue" runat="server" Width="200px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblDistrict" runat="server" Text="District" Width="120px" AssociatedControlID="lblDistrictValue"></asp:Label>
        <asp:Label ID="lblDistrictValue" runat="server" Width="300px"></asp:Label>

        <br />
        <br />
        
        <asp:Label ID="lblDate" runat="server" Text="Date" Width="120px" AssociatedControlID="lblDateValue"></asp:Label>
        <asp:Label ID="lblDateValue" runat="server" Width="100px"></asp:Label>

        <br />
        <br />

        <asp:Label ID="lblType" runat="server" Text="Type" Width="120px" AssociatedControlID="lblTypeValue"></asp:Label>
        <asp:Label ID="lblTypeValue" runat="server" Width="300px"></asp:Label>

        <br />
        <br />
        <asp:Label ID="lblHoursRequired" runat="server" Text="Hours Required" Width="120px" AssociatedControlID="lblHoursRequiredValue"></asp:Label>
        <asp:Label ID="lblHoursRequiredValue" runat="server" Width="100px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblCostRequired" runat="server" Text="Cost Required" Width="120px" AssociatedControlID="lblCostRequiredValue"></asp:Label>
        <asp:Label ID="lblCostRequiredValue" runat="server" Width="100px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblRequestedBy" runat="server" AssociatedControlID="lblRequestedByValue" Text="Proposed By" Width="120px"></asp:Label>
        <asp:Label ID="lblRequestedByValue" runat="server" Width="150px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server" Text="Status" Width="120px" AssociatedControlID="lblStatusValue"></asp:Label>
        <asp:Label ID="lblStatusValue" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblApprovedBy" runat="server" AssociatedControlID="lblApprovedByValue" Text="Approved By" Width="120px"></asp:Label>
        <asp:Label ID="lblApprovedByValue" runat="server" Width="150px"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblRemainingLife" runat="server" Text="Remaining Life" Width="120px" AssociatedControlID="txtRemainingLife"></asp:Label>
        <asp:TextBox ID="txtRemainingLife" runat="server" Width="100px" AutoPostBack="True"></asp:TextBox>
        <asp:Label ID="lblRemainingLifeUnit" runat="server" Text="%"></asp:Label>

        <asp:RequiredFieldValidator ID="rfvForRemainingLife" runat="server" ErrorMessage="Set remaining Life" Display="Dynamic" ForeColor="Red" ControlToValidate="txtRemainingLife" SetFocusOnError="True"></asp:RequiredFieldValidator>

        <asp:RangeValidator ID="rvForRemainingLife" runat="server" ErrorMessage="Choose a number between 0 and 100 inclusive." MaximumValue="100" MinimumValue="0" ControlToValidate="txtRemainingLife" ForeColor="Red" SetFocusOnError="True"></asp:RangeValidator>

        <br />
        <br />

        <asp:Label ID="lblNotes" runat="server" Text="Notes" Width="120px" AssociatedControlID="txtNotes"></asp:Label>
        <asp:TextBox ID="txtNotes" runat="server" Width="361px" TextMode="MultiLine"></asp:TextBox>

        <br />
        <br />

        <div class="button-container">
            <asp:Button ID="btnApprove" runat="server" class="button-submit" Text="Approve Intervention" OnClick="btnApprove_Click" />
            <asp:Button ID="btnComplete" runat="server" class="button-submit" Text="Complete Intervention" OnClick="btnComplete_Click" />
            <asp:Button ID="btnCancel" runat="server" class="button-cancel" Text="Cancel Intervention" OnClick="btnCancel_Click" />
        </div>

    </div>
</asp:Content>
