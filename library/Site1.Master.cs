using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sessionhello = Session["hello"] as string;
                if (string.IsNullOrEmpty(sessionhello))
                //if (Session["hello"].Equals(null))
                {
                    LinkButton2.Visible = true; //admin login
                    LinkButton1.Visible = true; //user login
                    LinkButton4.Visible = true; //hello
                    LinkButton3.Visible = false; //logout
                }
                else if(Session["hello"].Equals("user"))
                {
                    LinkButton2.Visible = false; //admin login
                    LinkButton1.Visible = false; //user login
                    LinkButton3.Visible = true; //logout
                    LinkButton4.Visible = true; //hello
                    LinkButton4.Text = "Hello " + Session["name"].ToString(); 
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminLogin.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserLogin.aspx");
        }
        //logout
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["hello"] = " ";
            Session["name"] = " ";
            LinkButton2.Visible = true; //admin login
            LinkButton1.Visible = true; //user login
            LinkButton4.Visible = true; //hello
            LinkButton3.Visible = false; //logout
            Response.Redirect("HomePage.aspx");
        }
    }
}