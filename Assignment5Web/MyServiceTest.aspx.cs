using System;

namespace Assignment5Web
{
    public partial class MyServiceTest : System.Web.UI.Page
    {
        // this runs when the button is clicked and reverses the text
        protected void btnReverse_Click(object sender, EventArgs e)
        {
            TextService service = new TextService();
            lblResult.Text = service.ReverseText(txtInput.Text);
        }
    }
}