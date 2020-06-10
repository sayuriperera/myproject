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
    public partial class ViewEmployee : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Search button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkEmpExists())
            {
                getEmployeeDetails();

            }
          
            else
            {
                Response.Write("<script> alert('Invalid Employee ID');</script>");
            }        
        }
        //defined functions
        bool checkEmpExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Emp_Detail where Emp_ID='" + TextBox16.Text.Trim() + "' OR First_Name='" + TextBox16.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void getEmployeeDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from Emp_Detail where Emp_ID='" + TextBox16.Text.Trim() + "' OR First_Name='" + TextBox16.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox11.Text = dr.GetValue(0).ToString();
                        TextBox1.Text = dr.GetValue(1).ToString();
                        TextBox3.Text = dr.GetValue(2).ToString();
                        TextBox4.Text = dr.GetValue(3).ToString();
                        TextBox2.Text = dr.GetValue(4).ToString();
                        TextBox5.Text = Convert.ToDateTime(dr.GetValue(5)).ToString("dd/MM/yyyy");
                        TextBox12.Text = dr.GetValue(6).ToString();
                        TextBox6.Text = dr.GetValue(7).ToString();
                        TextBox7.Text = dr.GetValue(8).ToString();
                        TextBox13.Text = dr.GetValue(9).ToString();
                        TextBox8.Text = dr.GetValue(10).ToString();
                        TextBox9.Text = Convert.ToDateTime(dr.GetValue(11)).ToString("dd/MM/yyyy");
                        TextBox14.Text = dr.GetValue(12).ToString();
                        TextBox10.Text = dr.GetValue(13).ToString();
                        TextBox15.Text = dr.GetValue(14).ToString();
                        TextBox17.Text = dr.GetValue(15).ToString();
                        Image1.ImageUrl = dr.GetValue(16).ToString();
                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
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
            Response.Redirect("AdminPage.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}