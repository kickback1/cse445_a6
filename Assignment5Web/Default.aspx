<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment5Web._Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Web Application</title>
</head>
<body>
    <form id="form1" runat="server">

        <h1>Our Web Application</h1>

        <p>
            This app allows users to register, login, and access a protected member page.
            It uses XML for storage, hashing for passwords, session for login tracking,
            and includes a web service.
        </p>

        <h2>Navigation</h2>

        <a href="Login.aspx">Login</a><br />
        <a href="Signup.aspx">Signup</a><br />
        <a href="Member.aspx">Member Page</a><br />
        <a href="Staff.aspx">Staff Page</a><br />
        <a href="MyServiceTest.aspx">Web Service Test</a><br />
        <a href="HashTest.aspx">Hash Test</a><br />

        <br />
        <br />

        <h2>Application and Components Summary</h2>

        <table border="1" cellpadding="5" cellspacing="0">
            <tr style="background-color:#cccccc;">
                <th>Provider</th>
                <th>Component</th>
                <th>Description</th>
                <th>Link</th>
            </tr>


            <tr>
                <td></td>
                <td>Login Page</td>
                <td>Allows users to login as Member or Staff using XML stored accounts</td>
                <td><a href="Login.aspx">Try</a></td>
            </tr>

            <tr>
                <td></td>
                <td>Signup Page</td>
                <td>Allows users to register with CAPTCHA verification</td>
                <td><a href="Signup.aspx">Try</a></td>
            </tr>

            <tr>
                <td></td>
                <td>Member Page</td>
                <td>Protected page only accessible after Member login</td>
                <td><a href="Member.aspx">Try</a></td>
            </tr>

            <tr>
                <td></td>
                <td>Web Service</td>
                <td>Text reversing service</td>
                <td><a href="MyServiceTest.aspx">Try</a></td>
            </tr>

            <tr>
                <td></td>
                <td>Session</td>
                <td>Stores logged-in user info and role</td>
                <td>Used in Member/Staff Pages</td>
            </tr>
			
			<tr>
                <td></td>
                <td>DLL </td>
                <td>SHA256 hashing function (HashHelper.GetHash). Used for all password storage in Member.xml and Staff.xml.</td>
                <td><a href="HashTest.aspx">Try</a></td>
            </tr>
			
            <tr>
                <td></td>
                <td>Member.xml</td>
                <td>Stores member credentials with SHA256 hashed passwords. Written by Signup, read by Login.</td>
                <td>Used in Login/Signup</td>
            </tr>


            <tr>
                <td></td>
                <td>Staff Page</td>
                <td>Admin page: view registered members, add staff accounts, view app info. Requires Staff login.</td>
                <td><a href="Staff.aspx">Try</a></td>
            </tr>

            <tr>
                <td></td>
                <td>Staff.xml</td>
                <td>Stores staff credentials with SHA256 hashed passwords.</td>
                <td>Used in Staff login</td>
            </tr>

            <tr>
                <td></td>
                <td>Forms Security </td>
                <td>Forms Authentication with auto-redirect to Login.aspx. Authorization blocks for Member.aspx and Staff.aspx.</td>
                <td>Try accessing Staff.aspx without login</td>
            </tr>

        </table>

    </form>
</body>
</html>
