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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //create button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkEmpExists())
            {
                createUser();
            }
            else
            {
                Response.Write("<script>alert('Employee ID doesn't exist');</script>");
            }
        }
        //go button 
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkEmpExists())
            {
                getDepartment();
            }
            else
            {
                Response.Write("<script> alert('Invalid Employee ID');</script>");
            }
        }

        //back button
        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
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
                SqlCommand cmd = new SqlCommand("SELECT * from Emp_Detail where Emp_ID='" + TextBox11.Text.Trim() + "' OR First_Name='" + TextBox11.Text.Trim() + "';", con);
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


        void getDepartment()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("SELECT * from Emp_Detail where Emp_ID='" + TextBox11.Text.Trim() + "' OR First_Name='" + TextBox11.Text.Trim() + "';", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        TextBox3.Text = dr.GetValue(1).ToString();
                        TextBox8.Text = dr.GetValue(14).ToString();
                    }

                }
                else
                {
                    Response.Write("<script>alert('Invalid Employee ID');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void createUser()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Login" + "(UserName,Password,Emp_ID,Role) values(@UserName,@Password,@Emp_ID,@Role)", con);
                cmd.Parameters.AddWithValue("@UserName", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@Password", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@Emp_ID", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@Role", DropDownList1.SelectedItem.Value);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script> alert('User created successfully.');</script>");
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox11.Text = "";
            TextBox3.Text = "";
            TextBox8.Text = "";
            DropDownList1.Text = "";
        }

      
    }
}