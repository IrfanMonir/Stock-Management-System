using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockManagementWebApp.UI
{
    public partial class LoginUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signInButton_Click(object sender, EventArgs e)
        {
            if (userNameTextBox.Text == "shamima.cse007@gmail.com" & passwordTextBox.Text == "proma007")
            {
                Response.Redirect("IndexUI.aspx");
            }
            else
            {
                errorMessageLabel.InnerHtml = "Username or password is not correct";
            }
        }
    }
}