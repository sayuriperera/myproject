using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace library
{
    public partial class EmployeePerformanceAnalysis : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        List<DataPoint> dataPoints1;
		List<DataPoint> dataPoints2;
		List<DataPoint> dataPoints3;
		List<DataPoint> dataPoints4;
		List<DataPoint> dataPoints5;
		List<DataPoint> dataPoints6;
		List<DataPoint> dataPoints7;
        private String empID;
        private static String[] MONTHS = { "January" , "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" ==============================");
            dataPoints1 = new List<DataPoint>();
		    dataPoints2 = new List<DataPoint>();
			dataPoints3 = new List<DataPoint>();
			dataPoints4 = new List<DataPoint>();
			dataPoints5 = new List<DataPoint>();
			dataPoints6 = new List<DataPoint>();
			dataPoints7 = new List<DataPoint>();


            LoadEmployeeComboBoxData();
            LoadDataFromDB();
            RegisterArrayInClientSide();
        }

        protected void OnChangeEmployee()
        {

            System.Diagnostics.Debug.WriteLine(" ===---- ");
            dataPoints1.Clear();
            dataPoints2.Clear();
            dataPoints3.Clear();
            dataPoints4.Clear();
            dataPoints5.Clear();
            dataPoints6.Clear();
            dataPoints7.Clear();
            LoadDataFromDB();
            RegisterArrayInClientSide();
        }

        private void LoadDataFromDB()
        {

            String selectedEmployeeID = cmbEmployee.Value.ToString();
            int year = DateTime.Now.Year;

            try
            {
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd;
                cmd = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID=@empID AND Year=@year AND Type=@type", connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@type", "Attendance");

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dataPoints1.Add(new DataPoint( (dr.GetValue(6).ToString() + " " + dr.GetValue(1).ToString()) ,Int32.Parse(dr.GetValue(3).ToString())));
                    }
                }

                cmd = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID=@empID AND Year=@year AND Type=@type", connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@type", "Targetsmet");

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dataPoints2.Add(new DataPoint((dr.GetValue(6).ToString() + " " + dr.GetValue(1).ToString()), Int32.Parse(dr.GetValue(3).ToString())));
                    }
                }

                cmd = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID=@empID AND Year=@year AND Type=@type", connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@type", "Customer Service");

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dataPoints3.Add(new DataPoint((dr.GetValue(6).ToString() + " " + dr.GetValue(1).ToString()), Int32.Parse(dr.GetValue(3).ToString())));
                    }
                }


                cmd = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID=@empID AND Year=@year AND Type=@type", connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@type", "Oral Effective Communication");

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dataPoints4.Add(new DataPoint((dr.GetValue(6).ToString() + " " + dr.GetValue(1).ToString()), Int32.Parse(dr.GetValue(3).ToString())));
                    }
                }

                cmd = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID=@empID AND Year=@year AND Type=@type", connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@type", "Descipline");

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dataPoints5.Add(new DataPoint((dr.GetValue(6).ToString() + " " + dr.GetValue(1).ToString()), Int32.Parse(dr.GetValue(3).ToString())));
                    }
                }

                cmd = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID=@empID AND Year=@year AND Type=@type", connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@type", "Appropriate Dressing");

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dataPoints6.Add(new DataPoint((dr.GetValue(6).ToString() + " " + dr.GetValue(1).ToString()), Int32.Parse(dr.GetValue(3).ToString())));
                    }
                }

                cmd = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Emp_ID=@empID AND Year=@year AND Type=@type", connection);
                cmd.Parameters.AddWithValue("@empID", selectedEmployeeID);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.Parameters.AddWithValue("@type", "Teamwork");

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        dataPoints7.Add(new DataPoint((dr.GetValue(6).ToString() + " " + dr.GetValue(1).ToString()), Int32.Parse(dr.GetValue(3).ToString())));
                    }
                }

                connection.Close();

            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(" === " + e.Message);
            }
        }

        private void LoadEmployeeComboBoxData()
        {
            empID = (string)Session["empID"];


            try
            {
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT Emp_ID FROM Emp_Detail WHERE Post=@post AND Department=(SELECT Department FROM Emp_Detail WHERE Emp_ID=@empID)", connection);
                cmd.Parameters.AddWithValue("@post", "Sales staff");
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" === " + ex.Message);
            }
        }

		private void RegisterArrayInClientSide()
        {

            dataPoints1 = SortingByMonth(dataPoints1);
            dataPoints2 = SortingByMonth(dataPoints2);
            dataPoints3 = SortingByMonth(dataPoints3);
            dataPoints4 = SortingByMonth(dataPoints4);
            dataPoints5 = SortingByMonth(dataPoints5);
            dataPoints6 = SortingByMonth(dataPoints6);
            dataPoints7 = SortingByMonth(dataPoints7);


            ClientScript.RegisterArrayDeclaration("array1", JsonConvert.SerializeObject(dataPoints1));
			ClientScript.RegisterArrayDeclaration("array2", JsonConvert.SerializeObject(dataPoints2));
			ClientScript.RegisterArrayDeclaration("array3", JsonConvert.SerializeObject(dataPoints3));
			ClientScript.RegisterArrayDeclaration("array4", JsonConvert.SerializeObject(dataPoints4));
			ClientScript.RegisterArrayDeclaration("array5", JsonConvert.SerializeObject(dataPoints5));
			ClientScript.RegisterArrayDeclaration("array6", JsonConvert.SerializeObject(dataPoints6));
			ClientScript.RegisterArrayDeclaration("array7", JsonConvert.SerializeObject(dataPoints7));

            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "graph()", true);
        }

        private List<DataPoint> SortingByMonth(List<DataPoint> data)
        {
            DataPoint temp = null;
            Char[] s = { ' ' };

            for (int write = 0; write < data.Count; write++)
            {
                for (int sort = 0; sort < data.Count - 1; sort++)
                {
                    String m1 = data[sort].Label.Split(s)[1];
                    String m2 = data[sort+1].Label.Split(s)[1];
                    if (Array.IndexOf(MONTHS,m1) > Array.IndexOf(MONTHS, m2))
                    {
                        temp = data[sort + 1];
                        data[sort + 1] = data[sort];
                        data[sort] = temp;
                    }
                }
            }

            return data;
        }

        protected void cmbEmployee_ServerChange(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(" ============================================ ");
        }
    }
}