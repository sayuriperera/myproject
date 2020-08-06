using System;
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
                LoadPositionComboBox();
                LoadLeaveTypeComboBox();
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
                DDL_Position.Items.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        DDL_Position.Items.Add(new ListItem(dr.GetValue(1).ToString(),dr.GetValue(0).ToString()));
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
    }
}