﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="InterventionMonitor.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1 {
            height: 483px;
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 23px">
   
    
    </div>
                <asp:Panel ID="Panel2" runat="server" Height="418px" HorizontalAlign="Center" style="margin-top: 23px">
                    <asp:Label ID="Label4" runat="server" Text="Ecare" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <asp:Panel ID="Panel1" runat="server" BackColor="#DFDFDF" Height="272px" HorizontalAlign="Center" style="margin-left: 299px; margin-right: 294px; margin-top: 30px" BorderColor="#CCCCCC" BorderStyle="Ridge">
            <p style="height: 55px">
                <br />
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" Text="Enter your credentials"></asp:Label>
            </p>
            <p style="margin-top: 34px; margin-bottom: 0px;">
            <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <br />

                <br />
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </p>
            <p style="margin-top: 0px; height: 51px; margin-bottom: 0px;">
                &nbsp;</p>
            <p style="height: 52px; margin-top: 0px">
                <asp:Button ID="Button1" runat="server" BackColor="#6600FF" Font-Size="Large" ForeColor="White" Height="35px" Text="Login" Width="272px" Onclick="LogIn"/>
                
            </p>
        </asp:Panel>
                            </asp:Panel>
    </form>
</body>
</html>
