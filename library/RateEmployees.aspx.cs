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
        private String empID;
        private String selectedEmployeeID;
        private String selectedMonth;
  


        protected void Page_Load(object sender, EventArgs e)
        {
            

            empID = (string)Session["empID"];
        

            try
            {
                SqlConnection connection = new SqlConnection(strcon);
                if(connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
               
                    SqlCommand cmd = new SqlCommand("SELECT Emp_ID FROM Emp_Detail WHERE Post=@post AND Department=(SELECT Department FROM Emp_Detail WHERE Emp_ID=@empID)", connection);
                    cmd.Parameters.AddWithValue("@post","Sales staff");
                    cmd.Parameters.AddWithValue("@empID", empID);
                    SqlDataReader dr = cmd.ExecuteReader();
                cmbEmployee.Items.Clear();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            cmbEmployee.Items.Add(dr.GetValue(0).ToString());
                        }

                    }

                    connection.Close();
                
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine(" === " + ex.Message);
            }


            
        }

        //rate button
        protected void Button1_Click(object sender, EventArgs e)
        {

            Rating();
            Response.Write("<script> alert('Rating Success!');</script>");
        }

        private void Rating()
        {

            selectedEmployeeID = cmbEmployee.Value.ToString();
            selectedMonth = cmbMonth.Value.ToString();
            int year = DateTime.Now.Year;
            String attendance = labelone.Value.ToString();
            String targetsmet = labeltwo.Value.ToString();
            String customerservice = labelthree.Value.ToString();
            String oraleffectivecommunication = labelfour.Value.ToString();
            String descipline = labelfive.Value.ToString();
            String appropriatedressing = labelsix.Value.ToString();
            String teamwork = labelseven.Value.ToString();

            int a, t, c, o, d, ap, te;

            if (attendance.Equals(""))
            {
                a = 0;
            }
            else
            {
                a = Int32.Parse(attendance);
            }

            if (targetsmet.Equals(""))
            {
                t = 0;
            }
            else
            {
                t = Int32.Parse(targetsmet);
            }

            if(customerservice.Equals(""))
            {
                c = 0;
            }
            else
            {
                c = Int32.Parse(customerservice);
            }

            if (oraleffectivecommunication.Equals(""))
            {
                o = 0;
            }
            else
            {
                o = Int32.Parse(oraleffectivecommunication);
            }

            if (descipline.Equals(""))
            {
                d = 0;
            }
            else
            {
                d = Int32.Parse(descipline);
            }

            if (appropriatedressing.Equals(""))
            {
                ap = 0;
            }
            else
            {
                ap = Int32.Parse(appropriatedressing);
            }

            if (teamwork.Equals(""))
            {
                te = 0;
            }
            else
            {
                te = Int32.Parse(teamwork);
            }

            try
            {
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd, cmd1;
                cmd1 = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID =@empID AND Month=@month AND Year=@year AND Type=@type", connection);
                cmd1.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd1.Parameters.AddWithValue("@month", selectedMonth);
                cmd1.Parameters.AddWithValue("@year", year);
                cmd1.Parameters.AddWithValue("@type", "Attendance");

                SqlDataReader dr = cmd1.ExecuteReader();

                if(dr.HasRows){
                    cmd = new SqlCommand("UPDATE Emp_Ratings SET Rating=@rating WHERE Emp_ID=@empID AND Year=@year AND Month=@month AND Type=@type", connection);
                    cmd.Parameters.AddWithValue("rating", a);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@type", "Attendance");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Emp_Ratings(Emp_ID,Month,Supervisor_ID,Rating,Type,Year) VALUES(@empID,@month,@supervisor,@rating,@type,@year)", connection);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@supervisor", empID);
                    cmd.Parameters.AddWithValue("@rating", a);
                    cmd.Parameters.AddWithValue("@type", "Attendance");
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.ExecuteNonQuery();
                }



                cmd1 = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID =@empID AND Month=@month AND Year=@year AND Type=@type", connection);
                cmd1.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd1.Parameters.AddWithValue("@month", selectedMonth);
                cmd1.Parameters.AddWithValue("@year", year);
                cmd1.Parameters.AddWithValue("@type", "Targetsmet");

                dr = cmd1.ExecuteReader();

                if (dr.HasRows)
                {
                    cmd = new SqlCommand("UPDATE Emp_Ratings SET Rating=@rating WHERE Emp_ID=@empID AND Year=@year AND Month=@month AND Type=@type", connection);
                    cmd.Parameters.AddWithValue("rating", t);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@type", "Targetsmet");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Emp_Ratings(Emp_ID,Month,Supervisor_ID,Rating,Type,Year) VALUES(@empID,@month,@supervisor,@rating,@type,@year)", connection);
                    cmd.Parameters.AddWithValue("@rating", t);
                    cmd.Parameters.AddWithValue("@type", "Targetsmet");
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@supervisor", empID);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.ExecuteNonQuery();
                }

                cmd1 = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID =@empID AND Month=@month AND Year=@year AND Type=@type", connection);
                cmd1.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd1.Parameters.AddWithValue("@month", selectedMonth);
                cmd1.Parameters.AddWithValue("@year", year);
                cmd1.Parameters.AddWithValue("@type", "Customer Service");

                dr = cmd1.ExecuteReader();

                if (dr.HasRows)
                {
                    cmd = new SqlCommand("UPDATE Emp_Ratings SET Rating=@rating WHERE Emp_ID=@empID AND Year=@year AND Month=@month AND Type=@type", connection);
                    cmd.Parameters.AddWithValue("rating", c);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@type", "Customer Service");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Emp_Ratings(Emp_ID,Month,Supervisor_ID,Rating,Type,Year) VALUES(@empID,@month,@supervisor,@rating,@type,@year)", connection);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@supervisor", empID);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@rating", c);
                    cmd.Parameters.AddWithValue("@type", "Customer Service");
                    cmd.ExecuteNonQuery();
                }


                cmd1 = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID =@empID AND Month=@month AND Year=@year AND Type=@type", connection);
                cmd1.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd1.Parameters.AddWithValue("@month", selectedMonth);
                cmd1.Parameters.AddWithValue("@year", year);
                cmd1.Parameters.AddWithValue("@type", "Oral Effective Communication");

                dr = cmd1.ExecuteReader();

                if (dr.HasRows)
                {
                    cmd = new SqlCommand("UPDATE Emp_Ratings SET Rating=@rating WHERE Emp_ID=@empID AND Year=@year AND Month=@month AND Type=@type", connection);
                    cmd.Parameters.AddWithValue("rating", o);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@type", "Oral Effective Communication");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Emp_Ratings(Emp_ID,Month,Supervisor_ID,Rating,Type,Year) VALUES(@empID,@month,@supervisor,@rating,@type,@year)", connection);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@supervisor", empID);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@rating", o);
                    cmd.Parameters.AddWithValue("@type", "Oral Effective Communication");
                    cmd.ExecuteNonQuery();
                }

                cmd1 = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID =@empID AND Month=@month AND Year=@year AND Type=@type", connection);
                cmd1.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd1.Parameters.AddWithValue("@month", selectedMonth);
                cmd1.Parameters.AddWithValue("@year", year);
                cmd1.Parameters.AddWithValue("@type", "Descipline");

                dr = cmd1.ExecuteReader();

                if (dr.HasRows)
                {
                    cmd = new SqlCommand("UPDATE Emp_Ratings SET Rating=@rating WHERE Emp_ID=@empID AND Year=@year AND Month=@month AND Type=@type", connection);
                    cmd.Parameters.AddWithValue("rating", d);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@type", "Descipline");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Emp_Ratings(Emp_ID,Month,Supervisor_ID,Rating,Type,Year) VALUES(@empID,@month,@supervisor,@rating,@type,@year)", connection);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@supervisor", empID);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@rating", d);
                    cmd.Parameters.AddWithValue("@type", "Descipline");
                    cmd.ExecuteNonQuery();
                }

                cmd1 = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID =@empID AND Month=@month AND Year=@year AND Type=@type", connection);
                cmd1.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd1.Parameters.AddWithValue("@month", selectedMonth);
                cmd1.Parameters.AddWithValue("@year", year);
                cmd1.Parameters.AddWithValue("@type", "Appropriate Dressing");

                dr = cmd1.ExecuteReader();

                if (dr.HasRows)
                {
                    cmd = new SqlCommand("UPDATE Emp_Ratings SET Rating=@rating WHERE Emp_ID=@empID AND Year=@year AND Month=@month AND Type=@type", connection);
                    cmd.Parameters.AddWithValue("rating", ap);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@type", "Appropriate Dressing");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Emp_Ratings(Emp_ID,Month,Supervisor_ID,Rating,Type,Year) VALUES(@empID,@month,@supervisor,@rating,@type,@year)", connection);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@supervisor", empID);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@rating", ap);
                    cmd.Parameters.AddWithValue("@type", "Appropriate Dressing");
                    cmd.ExecuteNonQuery();
                }


                cmd1 = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID =@empID AND Month=@month AND Year=@year AND Type=@type", connection);
                cmd1.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd1.Parameters.AddWithValue("@month", selectedMonth);
                cmd1.Parameters.AddWithValue("@year", year);
                cmd1.Parameters.AddWithValue("@type", "Teamwork");

                dr = cmd1.ExecuteReader();

                if (dr.HasRows)
                {
                    cmd = new SqlCommand("UPDATE Emp_Ratings SET Rating=@rating WHERE Emp_ID=@empID AND Year=@year AND Month=@month AND Type=@type", connection);
                    cmd.Parameters.AddWithValue("rating", ap);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@type", "Teamwork");
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO Emp_Ratings(Emp_ID,Month,Supervisor_ID,Rating,Type,Year) VALUES(@empID,@month,@supervisor,@rating,@type,@year)", connection);
                    cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    cmd.Parameters.AddWithValue("@supervisor", empID);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@rating", te);
                    cmd.Parameters.AddWithValue("@type", "Teamwork");
                    cmd.ExecuteNonQuery();
                }

               

                connection.Close();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" === " + ex.Message);
            }

        }
    }
}