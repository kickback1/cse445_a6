<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment5Web.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Login</h2>

        <asp:Label ID="lblRole" runat="server" Text="Role:" /><br />
        <asp:DropDownList ID="ddlRole" runat="server">
            <asp:ListItem Text="Member" Value="Member" />
            <asp:ListItem Text="Staff" Value="Staff" />
        </asp:DropDownList>
        <br /><br />

        <asp:Label ID="lblUser" runat="server" Text="Username:" /><br />
        <asp:TextBox ID="txtUser" runat="server" /><br /><br />

        <asp:Label ID="lblPass" runat="server" Text="Password:" /><br />
        <asp:TextBox ID="txtPass" runat="server" TextMode="Password" /><br /><br />

        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <br /><br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />

        <br /><br />
        <a href="Signup.aspx">Sign up</a>
        <br />
        <a href="Default.aspx">Back to Home</a>

    </form>
</body>
</html>
