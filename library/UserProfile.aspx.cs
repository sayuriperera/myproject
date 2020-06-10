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
            GetData();
        }

        // get data defined function
        void GetData()
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

        //clear the textboxes after updating 
        void ClearText()
        {
            TextBox3.Text = " ";
            TextBox4.Text = " ";
        }
        //back button
        protected void Button1_Click(object sender, EventArgs e)
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
                        if (dr.GetValue(3).ToString() == "Assistant")
                        {
                            Response.Redirect("CreateProfile.aspx");
                        }
                        else if(dr.GetValue(3).ToString() == "Supervisor")
                        {
                            Response.Redirect("SupervisorPage.aspx");
                        }
                        else
                        {
                            Response.Redirect("AdminPage.aspx");
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //update button
        protected void Button2_Click(object sender, EventArgs e)
        {
            string password;
            if (TextBox3.Text.Trim() == "")
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

                SqlCommand cmd = new SqlCommand("UPDATE Login set Password = @Password where UserName='" + Session["name"].ToString().Trim()+ "'", con);
                cmd.Parameters.AddWithValue("@Password", password);
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    Response.Write("<script> alert('Password updated successfully.');</script>");
                    GetData();
                    ClearText();
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
          
        }
    }
}