<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="Assignment5Web.Staff" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Staff Page</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Staff Page</h2>
        <p>Welcome, <asp:Label ID="lblWelcome" runat="server" /></p>
        <p><a href="Default.aspx">Home</a> | <asp:LinkButton ID="lnkLogout" runat="server" OnClick="lnkLogout_Click">Logout</asp:LinkButton></p>

        <hr />

        <h3>Registered Members</h3>
        <asp:Button ID="btnLoadMembers" runat="server" Text="Load Members" OnClick="btnLoadMembers_Click" />
        <br /><br />
        <asp:GridView ID="gvMembers" runat="server" AutoGenerateColumns="false" EmptyDataText="No members found.">
            <Columns>
                <asp:BoundField DataField="Username" HeaderText="Username" />
            </Columns>
        </asp:GridView>

        <hr />

        <h3>Add Staff Account</h3>
        <asp:Label ID="lblNewUser" runat="server" Text="Username:" /><br />
        <asp:TextBox ID="txtNewUser" runat="server" /><br /><br />
        <asp:Label ID="lblNewPass" runat="server" Text="Password:" /><br />
        <asp:TextBox ID="txtNewPass" runat="server" TextMode="Password" /><br /><br />
        <asp:Button ID="btnAddStaff" runat="server" Text="Add Staff" OnClick="btnAddStaff_Click" />
        <br />
        <asp:Label ID="lblStaffResult" runat="server" />

        <hr />

        <h3>Application Info</h3>
        <asp:Button ID="btnRefresh" runat="server" Text="Refresh" OnClick="btnRefresh_Click" />
        <br /><br />
        <asp:Label ID="lblInfo" runat="server" />

    </form>
</body>
</html>
