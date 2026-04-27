<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Assignment5Web.Signup" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Signup</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Signup</h2>

        <asp:Label ID="Label1" runat="server" Text="New Username:" />
        <br />
        <asp:TextBox ID="txtNewUser" runat="server" />
        <br />
        <br />

        <asp:Label ID="Label2" runat="server" Text="New Password:" />
        <br />
        <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" />
        <br />
        <br />

        <asp:Label ID="lblCaptcha" runat="server" Text="Enter code:" />
        <br />
        <asp:Label ID="lblCaptchaCode" runat="server" Font-Bold="true" />
        <br />
        <asp:TextBox ID="txtCaptcha" runat="server" />
        <br />
        <br />

        <asp:Button ID="btnSignup" runat="server" Text="Signup" OnClick="btnSignup_Click" />
        <br />
        <br />

        <asp:Label ID="lblSignupMessage" runat="server" ForeColor="Green" />

        <a href="Default.aspx">Back to Home</a>

    </form>
</body>
</html>
