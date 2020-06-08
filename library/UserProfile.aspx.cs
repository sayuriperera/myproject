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
    public partial class test : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from Login where UserName='" + Session["name"].ToString() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox1.Text = dr.GetValue(2).ToString();
                        TextBox2.Text = dr.GetValue(0).ToString();
                        TextBox5.Text = dr.GetValue(1).ToString();
                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        //back button
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }
        //update button
        protected void Button2_Click(object sender, EventArgs e)
        {
            string username,password;
            if(TextBox3.Text.Trim() == "")
            {
                username = TextBox2.Text.Trim();
            }
            else
            {
                username = TextBox3.Text.Trim();
            }
            if (TextBox4.Text.Trim() == "")
            {
                password = TextBox5.Text.Trim();
            }
            else
            {
                password = TextBox4.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Login set UserName = @UserName, Password = @Password where UserName='" + Session["name"].ToString().Trim()+ "'", con);
                cmd.Parameters.AddWithValue("@UserName", username);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('Username and password updated successfully.');</script>");
                Response.Redirect("HomePage.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
          
        }
    }
}