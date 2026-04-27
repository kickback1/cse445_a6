using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment5DLL;

namespace Assignment5Web
{
    public partial class HashTest : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // this runs when the button is clicked and hashes the input and saves it
        protected void btnHash_Click(object sender, EventArgs e)
        {
            string input = txtInput.Text;
            Session["lastInput"] = input;

            string result = HashHelper.GetHash(input);

            lblResult.Text = result;
            lblSession.Text = "" + Session["lastInput"];
        }
    }
}