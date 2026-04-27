using System;
using System.Web.UI;
using System.Xml;
using Assignment5DLL;

namespace Assignment5Web
{
    public partial class Signup : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // generate a random 4-digit captcha
                Random rand = new Random();
                int code = rand.Next(1000, 9999);

                // store it in session and show it
                Session["captcha"] = code.ToString();
                lblCaptchaCode.Text = code.ToString();
            }
        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            string newUser = txtNewUser.Text;
            string newPass = txtNewPass.Text;

            // check if fields are empty
            if (newUser == "" || newPass == "")
            {
                lblSignupMessage.ForeColor = System.Drawing.Color.Red;
                lblSignupMessage.Text = "Fill all fields";
                return;
            }

            // check captcha
            string enteredCaptcha = txtCaptcha.Text;
            string realCaptcha = Session["captcha"].ToString();

            if (enteredCaptcha != realCaptcha)
            {
                lblSignupMessage.ForeColor = System.Drawing.Color.Red;
                lblSignupMessage.Text = "Wrong captcha";
                return;
            }

            // load XML file
            string filePath = Server.MapPath("~/Member.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            // get all users
            XmlNodeList users = doc.SelectNodes("//User");

            // check if username already exists
            foreach (XmlNode user in users)
            {
                if (user["Username"].InnerText == newUser)
                {
                    lblSignupMessage.ForeColor = System.Drawing.Color.Red;
                    lblSignupMessage.Text = "Username already exists";
                    return;
                }
            }

            // create new user node
            XmlNode root = doc.SelectSingleNode("Members");

            XmlElement userNode = doc.CreateElement("User");

            XmlElement username = doc.CreateElement("Username");
            username.InnerText = newUser;

            XmlElement password = doc.CreateElement("Password");
            password.InnerText = HashHelper.GetHash(newPass);

            // attach username + password to user
            userNode.AppendChild(username);
            userNode.AppendChild(password);

            // add user to XML and save
            root.AppendChild(userNode);
            doc.Save(filePath);
            lblSignupMessage.ForeColor = System.Drawing.Color.Green;

            lblSignupMessage.Text = "User registered!";
        }
    }
}