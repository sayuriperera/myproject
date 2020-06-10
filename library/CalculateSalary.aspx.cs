using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library
{
    public partial class CalculateSalary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CompareValidator3.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
            CompareValidator4.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
}