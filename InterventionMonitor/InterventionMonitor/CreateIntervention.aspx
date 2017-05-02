<%@ Page Title="Create Intervention" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" CodeBehind="CreateIntervention.aspx.cs" Inherits="InterventionMonitor.CreateIntervention" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div id="body-content">

        <br />

        <asp:Label ID="lblClient" runat="server" Text="Client" Width="120px" AssociatedControlID="ddlClient"></asp:Label>
        <asp:DropDownList ID="ddlClient" runat="server" Width="200px">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvForClient" runat="server" ControlToValidate="ddlClient" ErrorMessage="Choose a client" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ProposeValidation"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="lblDistrict" runat="server" Text="District" Width="120px" AssociatedControlID="lblDistrictValue"></asp:Label>
        <asp:Label ID="lblDistrictValue" runat="server" Width="300px"></asp:Label>

        <br />
        <br />
        
        <asp:Label ID="lblDate" runat="server" Text="Date" Width="120px" AssociatedControlID="txtDate"></asp:Label>
        <asp:TextBox ID="txtDate" runat="server" Width="150px" TextMode="Date"></asp:TextBox>

        <asp:RequiredFieldValidator ID="rfvForDate" runat="server" ControlToValidate="txtDate" ErrorMessage="Choose a date" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ProposeValidation"></asp:RequiredFieldValidator>

        <br />
        <br />

        <asp:Label ID="lblTypes" runat="server" Text="Type" Width="120px" AssociatedControlID="ddlType"></asp:Label>
        <asp:DropDownList ID="ddlType" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" >
        </asp:DropDownList>

        <asp:RequiredFieldValidator ID="rfvForType" runat="server" ControlToValidate="ddlType" ErrorMessage="Choose a type" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ProposeValidation"></asp:RequiredFieldValidator>

        <br />
        <br />
        <asp:Label ID="lblHoursRequired" runat="server" Text="Hours Required" Width="120px" AssociatedControlID="txtHoursRequired"></asp:Label>
        <asp:TextBox ID="txtHoursRequired" runat="server" Enabled="False" ReadOnly="True" Width="100px"></asp:TextBox>
        <asp:CheckBox ID="ckbDefaultHoursRequired" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="ckbDefaultHoursRequired_CheckedChanged" Text="Set Default Hours" />
        <asp:RequiredFieldValidator ID="rfvForHours" runat="server" ControlToValidate="txtHoursRequired" Display="Dynamic" ErrorMessage="Set hours" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ProposeValidation"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvForHours" runat="server" ControlToValidate="txtHoursRequired" ErrorMessage="Set correct hours" MaximumValue="5000" MinimumValue="0" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ProposeValidation"></asp:RangeValidator>
        <br />
        <br />
        <asp:Label ID="lblCostRequired" runat="server" Text="Cost Required" Width="120px" AssociatedControlID="txtCostRequired"></asp:Label>
        <asp:TextBox ID="txtCostRequired" runat="server" Enabled="False" ReadOnly="True" Width="100px"></asp:TextBox>
        <asp:Label ID="lblCostRequiredUnit" runat="server" Text="AUD"></asp:Label>
        <asp:CheckBox ID="ckbDefaultCostRequired" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="ckbDefaultCostRequired_CheckedChanged" Text="Set Default Cost" />
        <asp:RequiredFieldValidator ID="rfvForCost" runat="server" ControlToValidate="txtCostRequired" Display="Dynamic" ErrorMessage="Set Cost" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ProposeValidation"></asp:RequiredFieldValidator>
        <asp:RangeValidator ID="rvForCost" runat="server" ControlToValidate="txtCostRequired" ErrorMessage="Set correct cost" MaximumValue="1000000" MinimumValue="0" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ProposeValidation"></asp:RangeValidator>
        <br />
        <br />
        <asp:Label ID="lblStatus" runat="server" Text="Status" Width="120px" AssociatedControlID="lblStatusValue"></asp:Label>
        <asp:Label ID="lblStatusValue" runat="server" Width="105px"></asp:Label>
        <asp:CustomValidator ID="cvApprovalConstraints" runat="server" ValidationGroup="ApproveValidation"></asp:CustomValidator>
        <br />
        <br />
        <asp:Label ID="lblRemainingLife" runat="server" Text="Remaining Life" Width="120px" AssociatedControlID="txtRemainingLife"></asp:Label>
        <asp:TextBox ID="txtRemainingLife" runat="server" Width="100px">100</asp:TextBox>
        <asp:Label ID="lblRemainingLifeUnit" runat="server" Text="%"></asp:Label>

        <asp:RequiredFieldValidator ID="rfvForRemainingLife" runat="server" ControlToValidate="txtRemainingLife" Display="Dynamic" ErrorMessage="Set remaining life" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ProposeValidation"></asp:RequiredFieldValidator>

        <asp:RangeValidator ID="rvForRemainingLife" runat="server" ErrorMessage="Choose a number between 0 and 100 inclusive." MaximumValue="100" MinimumValue="0" ControlToValidate="txtRemainingLife" ForeColor="Red" SetFocusOnError="True" ValidationGroup="ProposeValidation"></asp:RangeValidator>

        <br />
        <br />

        <asp:Label ID="lblNotes" runat="server" Text="Notes" Width="120px" AssociatedControlID="txtNotes"></asp:Label>
        <asp:TextBox ID="txtNotes" runat="server" Width="361px" TextMode="MultiLine"></asp:TextBox>

        <br />
        <asp:ValidationSummary ID="ApproveValidationSummary" runat="server" ForeColor="Red" ValidationGroup="ApproveValidation" />
        <br />

        <div id="button-container" style="width: 463px;">
            <asp:Button ID="btnPropose" runat="server" Text="Propose Intervention" Style="float: right;" OnClick="ProposeButton_Click" ValidationGroup="ProposeValidation"></asp:Button>
            <asp:Button ID="btnApprove" runat="server" Text="Approve Intervention" Style="float: right;" OnClick="ApproveButton_Click" ValidationGroup="ApproveValidation"></asp:Button>
        </div>

    </div>
</asp:Content>
