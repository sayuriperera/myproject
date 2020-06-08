using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library
{
    public partial class RateEmployees : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //rate button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Emp_Ratings" + "(Rating) values(@Rating)", con);
                cmd.Parameters.AddWithValue("@Rating",Label1);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Member rated successfully.');</script>");
            }
            catch(Exception ex)
            {

                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }
    }
}