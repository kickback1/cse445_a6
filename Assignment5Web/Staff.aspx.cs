using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Xml;
using Assignment5DLL;

namespace Assignment5Web
{
    public partial class Staff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // check if user is logged in as Staff
            if (Session["user"] == null || Session["role"] == null || Session["role"].ToString() != "Staff")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            lblWelcome.Text = Session["user"].ToString() + " (Staff)";
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            Response.Redirect("Default.aspx");
        }

        // loads all registered members from Member.xml
        protected void btnLoadMembers_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Member.xml");
            if (!File.Exists(path))
                return;

            DataTable dt = new DataTable();
            dt.Columns.Add("Username");

            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            XmlNodeList users = doc.SelectNodes("//User");

            foreach (XmlNode user in users)
            {
                DataRow row = dt.NewRow();
                row["Username"] = user["Username"].InnerText;
                dt.Rows.Add(row);
            }

            gvMembers.DataSource = dt;
            gvMembers.DataBind();
        }

        // adds a new staff account to Staff.xml using the DLL hash
        protected void btnAddStaff_Click(object sender, EventArgs e)
        {
            string username = txtNewUser.Text.Trim();
            string password = txtNewPass.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStaffResult.ForeColor = System.Drawing.Color.Red;
                lblStaffResult.Text = "Both fields required.";
                return;
            }

            string path = Server.MapPath("~/Staff.xml");
            XmlDocument doc = new XmlDocument();

            if (File.Exists(path))
                doc.Load(path);
            else
            {
                XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(dec);
                doc.AppendChild(doc.CreateElement("Staff"));
            }

            // check if username already exists
            XmlNodeList existing = doc.SelectNodes("//User");
            foreach (XmlNode u in existing)
            {
                if (u["Username"].InnerText.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    lblStaffResult.ForeColor = System.Drawing.Color.Red;
                    lblStaffResult.Text = "Username already exists.";
                    return;
                }
            }

            // hash password using DLL
            string hashed = HashHelper.GetHash(password);

            XmlElement user = doc.CreateElement("User");

            XmlElement nameEl = doc.CreateElement("Username");
            nameEl.InnerText = username;
            user.AppendChild(nameEl);

            XmlElement passEl = doc.CreateElement("Password");
            passEl.InnerText = hashed;
            user.AppendChild(passEl);

            doc.DocumentElement.AppendChild(user);
            doc.Save(path);

            lblStaffResult.ForeColor = System.Drawing.Color.Green;
            lblStaffResult.Text = "Staff account created.";
            txtNewUser.Text = "";
        }

        // shows basic app info
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            string info = "";

            string memberPath = Server.MapPath("~/Member.xml");
            if (File.Exists(memberPath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(memberPath);
                int count = doc.SelectNodes("//User").Count;
                info += "Registered members: " + count + "<br />";
            }

            string staffPath = Server.MapPath("~/Staff.xml");
            if (File.Exists(staffPath))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(staffPath);
                int count = doc.SelectNodes("//User").Count;
                info += "Staff accounts: " + count + "<br />";
            }

            info += "Current time: " + DateTime.Now.ToString("g") + "<br />";

            lblInfo.Text = info;
        }
    }
}
