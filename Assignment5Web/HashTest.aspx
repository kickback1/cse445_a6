<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HashTest.aspx.cs" Inherits="Assignment5Web.HashTest" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Hash Page</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Hash Page and Save Input</h2>

        <!-- input box for user text -->
        Enter text:
        <asp:TextBox ID="txtInput" runat="server"></asp:TextBox>

        <br />
        <br />

        <!-- button to hash the text -->
        <asp:Button ID="btnHash" runat="server" Text="Click to Hash" OnClick="btnHash_Click" />

        <br />
        <br />

        <!-- shows the hash result -->
        Result:
        <asp:Label ID="lblResult" runat="server"></asp:Label>

        <br />
        <br />

        <!-- shows last input saved in session -->
        Last saved input:
        <asp:Label ID="lblSession" runat="server"></asp:Label>

        <a href="Default.aspx">Back to Home</a>

    </form>
</body>
</html>