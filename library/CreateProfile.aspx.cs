using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace library
{
    public partial class CreateProfile : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Create Employee Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIDExists())
            {

                Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID');</script>");
            }
            //Response.Write("<script> alert('test');</script>");
            else
            {
                createMember();
            }

            bool checkIDExists()
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * from Emp_Detail where Emp_ID='" + TextBox11.Text.Trim() + "';", con);
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

            void createMember()
            {
                try
                {
                    string filepath = "~/Employee_photos/social-media.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("Employee_photos/" + filename));
                    filepath = "~/Employee_photos/" + filename;


                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                        //Response.Write("<script> alert('hii');</script>");
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO Emp_Detail" + "(Emp_ID,First_Name,Last_Name,Full_Name,NIC,DOB,Gender,Address,City,District,Contact_No,Joined_Date,Status,Post,Department,Qualifications,Image) values(@Emp_ID,@First_Name,@Last_Name,@Full_Name,@NIC,@DOB,@Gender,@Address,@City,@District,@Contact_No,@Joined_Date,@Status,@Post,@Department,@Qualifications,@Image)", con);
                    cmd.Parameters.AddWithValue("@Emp_ID", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@First_Name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Last_Name", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Full_Name", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@NIC", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Address", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@City", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@District", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Contact_No", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@Joined_Date", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@Status", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Post", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@Department", DropDownList4.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@Qualifications", TextBox12.Text.Trim());
                    cmd.Parameters.AddWithValue("@Image", filepath);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script> alert('Member created successfully.');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script> alert('" + ex.Message + "');</script>");
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
}