﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

namespace library
{
    public partial class ControlPanal : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LEAVES_DIV.Visible = false;
                LoadPositionComboBox();
                LoadLeaveTypeComboBox();
                LoadEmployees();
            }
        }

        private void LoadPositionComboBox() {
            try
            {
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Post", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DDL_Position_1.Items.Add(new ListItem(dr.GetValue(1).ToString(), dr.GetValue(0).ToString()));
                    }

                }

                connection.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" === " + ex.Message);
            }
        }

        private void LoadLeaveTypeComboBox()
        {
            try
            {
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM Leave", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                DDL_LeaveType.Items.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DDL_LeaveType.Items.Add(new ListItem(dr.GetValue(1).ToString(), dr.GetValue(0).ToString()));
                    }

                }

                connection.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" === " + ex.Message);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (TXT_NoOfPremitted.Text.IsEmpty())
                {
                    Response.Write("<script> alert('No Of Premitted field is required!');</script>");
                } else if (DDL_Position.SelectedValue.IsEmpty())
                {
                    Response.Write("<script> alert('Post field is required!');</script>");
                } else if (DDL_LeaveType.SelectedValue.IsEmpty())
                {
                    Response.Write("<script> alert('Leave TYpe is required!');</script>");
                } else
                {
                    int noOfPremitetd = Int32.Parse(TXT_NoOfPremitted.Text.ToString());
                    int selectedPosition = Int32.Parse(DDL_Position.SelectedValue.ToString());
                    int selectedLeaveType = Int32.Parse(DDL_LeaveType.SelectedValue.ToString());

                    SqlConnection connection = new SqlConnection(strcon);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Post_Leave WHERE PostID=@postID AND LeaveID=@leaveID", connection);
                    cmd1.Parameters.AddWithValue("@postID", selectedPosition);
                    cmd1.Parameters.AddWithValue("@leaveID", selectedLeaveType);

                    SqlDataReader dr = cmd1.ExecuteReader();

                    if(!dr.HasRows)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Post_Leave VALUES (@postID,@leaveTypeID,@noOfPremitted)", connection);
                        cmd.Parameters.AddWithValue("@postID", selectedPosition);
                        cmd.Parameters.AddWithValue("@leaveTypeID", selectedLeaveType);
                        cmd.Parameters.AddWithValue("@noOfPremitted", noOfPremitetd);
                        cmd.ExecuteNonQuery();
                    } else
                    {
                        SqlCommand cmd = new SqlCommand("UPDATE Post_Leave SET NoOfPremitted=@noOfPremitted WHERE PostID=@postID AND LeaveID=@leaveTypeID", connection);
                        cmd.Parameters.AddWithValue("@postID", selectedPosition);
                        cmd.Parameters.AddWithValue("@leaveTypeID", selectedLeaveType);
                        cmd.Parameters.AddWithValue("@noOfPremitted", noOfPremitetd);
                        cmd.ExecuteNonQuery();
                    }
                    Response.Write("<script> alert('Successfully Updated!');</script>");
                    connection.Close();
                }
              
            } catch (Exception ex)
            {
                Response.Write("<script> alert('Invalid format of input');</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (TXT_HR.Text.IsEmpty())
            {
                Response.Write("<script> alert('Hourly rate is required!');</script>");
            }
            else if (TXT_OR.Text.IsEmpty())
            {
                Response.Write("<script> alert('Overtime rate is required!');</script>");
            }
            else if (DDL_Position_1.SelectedValue.IsEmpty())
            {
                Response.Write("<script> alert('Post type is required!');</script>");
            }
            else
            {
                double OR = Double.Parse(TXT_OR.Text.ToString());
                int selectedPosition = Int32.Parse(DDL_Position_1.SelectedValue.ToString());
                double HR = Double.Parse(TXT_HR.Text.ToString());

                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Salary_Ratings WHERE PostID=@postID", connection);
                cmd1.Parameters.AddWithValue("@postID", selectedPosition);
             

                SqlDataReader dr = cmd1.ExecuteReader();

                if (!dr.HasRows)
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Salary_Ratings VALUES (@postID,@hr,@or)", connection);
                    cmd.Parameters.AddWithValue("@postID", selectedPosition);
                    cmd.Parameters.AddWithValue("@hr", HR);
                    cmd.Parameters.AddWithValue("@or", OR);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Salary_Ratings SET HourlyRate=@hr, OvertimeRate=@or WHERE PostID=@postID", connection);
                    cmd.Parameters.AddWithValue("@postID", selectedPosition);
                    cmd.Parameters.AddWithValue("@hr", HR);
                    cmd.Parameters.AddWithValue("@or", OR);
                    cmd.ExecuteNonQuery();
                }
                Response.Write("<script> alert('Successfully Updated!');</script>");
                connection.Close();
            }
        }

        protected void Button5_Click1(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(strcon);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            if (ETF.Text.IsEmpty())
            {
                if(!EPF.Text.IsEmpty())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE TaxRate SET percentage=@percentage WHERE name=@name", connection);
                    cmd.Parameters.AddWithValue("@percentage", float.Parse(EPF.Text));
                    cmd.Parameters.AddWithValue("@name", "EPF");
                    cmd.ExecuteNonQuery();
                    Response.Write("<script> alert('Successfully updated EPF!');</script>");
                } else
                {
                    Response.Write("<script> alert('Both EPF and ETF fields empty!');</script>");
                }
            } else
            {
                if (!EPF.Text.IsEmpty())
                {
                    SqlCommand cmd = new SqlCommand("UPDATE TaxRate SET percentage=@percentage WHERE name=@name", connection);
                    cmd.Parameters.AddWithValue("@percentage", float.Parse(EPF.Text));
                    cmd.Parameters.AddWithValue("@name", "EPF");
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd1 = new SqlCommand("UPDATE TaxRate SET percentage=@percentage WHERE name=@name", connection);
                    cmd1.Parameters.AddWithValue("@percentage", float.Parse(ETF.Text));
                    cmd1.Parameters.AddWithValue("@name", "ETF");
                    cmd1.ExecuteNonQuery();

                    Response.Write("<script> alert('Successfully updated EPF and ETF!');</script>");
                }
                else
                {
                    SqlCommand cmd1 = new SqlCommand("UPDATE TaxRate SET percentage=@percentage WHERE name=@name", connection);
                    cmd1.Parameters.AddWithValue("@percentage", float.Parse(ETF.Text));
                    cmd1.Parameters.AddWithValue("@name", "ETF");
                    cmd1.ExecuteNonQuery();
                    Response.Write("<script> alert('Successfully updated ETF!');</script>");
                }
            }
            connection.Close();
        }

        protected void Btn_AddNewLeaveType_Click(object sender, EventArgs e)
        {
            string leaveType = TXT_NewLeaveType.Text;

            if(leaveType.IsEmpty())
            {
                Response.Write("<script> alert('Leave type is required!');</script>");
            } else
            {
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO Leave(Leave_Type) VALUES(@type)", connection);
                cmd.Parameters.AddWithValue("@type", leaveType);
                cmd.ExecuteNonQuery();
                LoadLeaveTypeComboBox();
                TXT_NewLeaveType.Text = "";
                Response.Write("<script> alert('Successfully added new leave type!');</script>");
            }
        }

        private void LoadEmployees()
        {
            
                  try
            {
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT Emp_ID FROM Emp_Detail", connection);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        EMP_ID.Items.Add(dr.GetString(0));
                    }

                }

                connection.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" === " + ex.Message);
            }
        }

        // View Employee taken leaves and remaining leaves
        protected void View_Click(object sender, EventArgs e)
        {
            string empID = EMP_ID.SelectedValue;

            try
            {
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd1 = new SqlCommand("SELECT Status FROM Emp_Detail WHERE Emp_ID=@empID", connection);
                cmd1.Parameters.AddWithValue("@empID", empID);
                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.HasRows)
                {
                    string status = "";
                    if (dr1.Read())
                    {
                        status = dr1.GetString(0);
                    }

                    System.Diagnostics.Debug.WriteLine("Status == " + status);

                    int statusID = -1;
                    if (status.Equals("Permanent"))
                    {
                        statusID = 1;
                    }
                    else
                    {
                        statusID = 2;
                    }

                    int total = 0;
                    SqlCommand cmd = new SqlCommand("SELECT SUM(NoOfPremitted) FROM Post_Leave WHERE PostID=@postID", connection);
                    cmd.Parameters.AddWithValue("@postID", statusID);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {

                        if (dr.Read())
                        {
                            total = dr.GetInt32(0);
                        }
                    }

                    int taken = 0;

                    SqlCommand cmd2 = new SqlCommand("SELECT SUM(NoOfLeaves) FROM Emp_Leave WHERE Emp_ID=@empID", connection);
                    cmd2.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader dr2 = cmd2.ExecuteReader();


                    try
                    {
                        if (dr2.HasRows)
                        {
                            if (dr2.Read())
                            {
                                taken = dr2.GetInt32(0);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        taken = 0;
                    }


                    Remaining.InnerText = "Number of Remaining Leaves : " + ((total - taken).ToString());
                    Taken.InnerText = "Number of Taken Leaves : " + (taken.ToString());
                    LEAVES_DIV.Visible = true;

                }
                else
                {
                    LEAVES_DIV.Visible = false;
                    Response.Write("<script> alert('Employee doen't exists!');</script>");
                }
                connection.Close();
            }catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
           
            

        }
    }
}