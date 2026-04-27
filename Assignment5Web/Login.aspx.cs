using System;
using System.Xml;
using System.Web.Security;
using System.Web.UI;
using Assignment5DLL;

namespace Assignment5Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;
            string role = ddlRole.SelectedValue;

            if (username == "" || password == "")
            {
                lblMessage.Text = "Enter username and password";
                return;
            }

            bool valid = false;

            if (role == "Staff")
            {
                // Staff login - check Staff.xml using DLL hash
                valid = CheckStaffLogin(username, password);
            }
            else
            {
                // Member login - check Member.xml
                valid = CheckMemberLogin(username, password);
            }

            if (valid)
            {
                Session["user"] = username;
                Session["role"] = role;

                // set Forms Authentication ticket
                FormsAuthentication.SetAuthCookie(username, false);

                if (role == "Staff")
                    Response.Redirect("Staff.aspx");
                else
                    Response.Redirect("Member.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid login";
            }
        }

        // checks Member.xml using GetHashCode (existing member accounts)
        private bool CheckMemberLogin(string username, string password)
        {
            string filePath = Server.MapPath("~/Member.xml");
            if (!System.IO.File.Exists(filePath))
                return false;

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList users = doc.SelectNodes("//User");

            string hashed = password.GetHashCode().ToString();

            foreach (XmlNode user in users)
            {
                if (username == user["Username"].InnerText &&
                    hashed == user["Password"].InnerText)
                {
                    return true;
                }
            }
            return false;
        }

        // checks Staff.xml using the DLL SHA256 hash
        private bool CheckStaffLogin(string username, string password)
        {
            string filePath = Server.MapPath("~/Staff.xml");
            if (!System.IO.File.Exists(filePath))
                return false;

            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList users = doc.SelectNodes("//User");

            // hash with DLL
            string hashed = HashHelper.GetHash(password);

            foreach (XmlNode user in users)
            {
                if (username == user["Username"].InnerText &&
                    hashed == user["Password"].InnerText)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
