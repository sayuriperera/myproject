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
    public partial class EditEmployee : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        protected void Page_Load(object sender, EventArgs e)
        {
            CompareValidator1.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
            CompareValidator2.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
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
                Response.Write("<script>alert('Invalid name or Employee ID');</script>");
            }
        }
        //update button 
        protected void Button1_Click(object sender, EventArgs e)
        {
            upDateEmployee();
        }

        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteEmployee();
        }
        //cancel button
        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }


        //defined fuctions
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
                        TextBox5.Text = Convert.ToDateTime (dr.GetValue(5)).ToString("dd/MM/yyyy");
                        DropDownList1.Text = dr.GetValue(6).ToString();
                        TextBox6.Text = dr.GetValue(7).ToString();
                        TextBox7.Text = dr.GetValue(8).ToString();
                        DropDownList2.Text = dr.GetValue(9).ToString();
                        TextBox8.Text = dr.GetValue(10).ToString();
                        TextBox9.Text = Convert.ToDateTime (dr.GetValue(11)).ToString("dd/MM/yyyy");
                        DropDownList3.Text = dr.GetValue(12).ToString();
                        TextBox10.Text = dr.GetValue(13).ToString();
                        DropDownList4.Text = dr.GetValue(14).ToString();
                        TextBox17.Text = dr.GetValue(15).ToString();
                        Image1.ImageUrl = dr.GetValue(16).ToString();
                        global_filepath = dr.GetValue(16).ToString();
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

        void upDateEmployee()
        {
            try
            {
                string filepath = "~/Employee_photos/social-media.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (filename == "" || filename== null)
                {
                    filepath = global_filepath;
                }
                else
                {
                    FileUpload1.SaveAs(Server.MapPath("Employee_photos/" + filename));
                    filepath = "~/Employee_photos/" + filename;
                }

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE Emp_Detail SET Emp_ID=@Emp_ID ,First_Name=@First_Name, Last_Name=@Last_Name,Full_Name=@Full_Name, NIC=@NIC, DOB=@DOB, Gender=@Gender,Address=@Address,City=@City,District=@District,Contact_No=@Contact_No,Joined_Date=@Joined_Date,Status=@Status,Post=@Post,Department=@Department,Qualifications=@Qualifications,Image=@Image where Emp_ID='" + TextBox16.Text.Trim() + "' OR First_Name='" + TextBox16.Text.Trim() + "';", con);

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
                cmd.Parameters.AddWithValue("@Qualifications", TextBox17.Text.Trim());
                cmd.Parameters.AddWithValue("@Image", filepath);
            


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Employee Details Updated Successfully');</script>");
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        //delete 
        void deleteEmployee()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("delete from Emp_Detail where Emp_ID='" + TextBox16.Text.Trim() + "' OR First_Name='" + TextBox16.Text.Trim() + "';", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Employee deleted Successfully');</script>");
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
               
            }
        }

        void clearForm()
        {
            TextBox16.Text = "";
            TextBox11.Text = "";
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox2.Text = "";
            TextBox5.Text = "";
            DropDownList1.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            DropDownList2.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            DropDownList3.Text = "";
            TextBox10.Text = "";
            DropDownList4.Text = "";
            TextBox17.Text = "";
            Image1.ImageUrl = "";
            global_filepath = "";
        }
    }



}
