<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyServiceTest.aspx.cs" Inherits="Assignment5Web.MyServiceTest" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Service Page</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Reverse Text</h2>

        Type something:
        <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>

        <br /><br />

        <asp:Button ID="btnReverse" runat="server" Text="Reverse" OnClick="btnReverse_Click" />

        <br /><br />

        Output:
        <asp:Label ID="lblResult" runat="server"></asp:Label>

    </form>
</body>
</html>