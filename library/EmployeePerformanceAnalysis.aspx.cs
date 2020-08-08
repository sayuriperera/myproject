using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.Collections;
using library.Model;
using System.Web.UI.HtmlControls;
using System.Web.Configuration;

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
        static ArrayList employees;
        static BestEmployeeHeader docHeader;
        private String empID;
        private static String[] MONTHS = { "January" , "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        protected void Page_Load(object sender, EventArgs e)
        {

            dataPoints1 = new List<DataPoint>();
            dataPoints2 = new List<DataPoint>();
            dataPoints3 = new List<DataPoint>();
            dataPoints4 = new List<DataPoint>();
            dataPoints5 = new List<DataPoint>();
            dataPoints6 = new List<DataPoint>();
            dataPoints7 = new List<DataPoint>();

            LoadDataFromDB();
            RegisterArrayInClientSide();
            
            if(!IsPostBack)
            {
                EmployeeRankingDiv.Visible = false;
                LoadEmployeeComboBoxData();
            }
           
        }

        private void LoadDataFromDB()
        {

            String selectedEmployeeID = cmbEmployee.SelectedValue.ToString();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if(EmployeeRankingDiv.Visible)
            {

                System.Diagnostics.Debug.WriteLine(docHeader.Department);

                string strHTML = @"<!DOCTYPE html>  
                        <html xmlns='http://www.w3.org/1999/xhtml'>  
                        <head>  
                            <title></title>  
                        </head>  
                        <body>";

          strHTML += "<div> " +
            "<h3 style='text-align:center;color:red;'>Employee Ranking</h3>" +
             "<br />" +
            " <div style='margin-left:10%;'> " +
               " <h4>Department : " + docHeader.Department  + "</h4>" +
                 " <h4>Supervisor ID : " + docHeader.SupervisorID + "</h4>" +
                " <h4>Supervisor Name : " + docHeader.SupervisorName +"</h4>" +
              " <h4>Year : " + docHeader.Year.ToString() +"</h4>" +
                " <h4>Month : " + docHeader.Month +"</h4>" +
           "</div><br /> <center> <table  border='1' style='width:80%'><tr><td>Rank</td><td>Employee ID</td><td>Employee Name</td><td>Score</td></tr>";
            
            for(int i=employees.Count-1;i>=0;i--){

                    string row = "<tr>";
                    row += "<td>" + ((Employee)employees[i]).Rank.ToString() + "</td>";
                    row += "<td>" + ((Employee)employees[i]).EmployeeID.ToString() + "</td>";
                    row += "<td>" + ((Employee)employees[i]).EmployeeName.ToString() + "</td>";
                    row += "<td>" + ((Employee)employees[i]).Score.ToString() + "</td></tr>";

                    strHTML += row;
                }

                strHTML += "</table></center></div>";
                GeneratePDF(strHTML, docHeader.Department,docHeader.Year.ToString(),docHeader.Month.ToString());
            } else
            {
                Response.Write("<script> alert('Please enter yearn month and reload to generate employee ranking report');</script>");
            }
        }

        // generate pdf
       // [Obsolete]
        private void GeneratePDF(string strHTML,string department,string year,string month)
        {
            Document pdfDoc = new Document();
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, HttpContext.Current.Response.OutputStream);
            pdfDoc.Open();
          
#pragma warning disable CS0612 // Type or member is obsolete
            HTMLWorker htmlWorker = new HTMLWorker(pdfDoc);
#pragma warning restore CS0612 // Type or member is obsolete
            htmlWorker.Parse(new StringReader(strHTML));
            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            string attachment = "attachment;filename=" + department + " " + year.ToString() + "-" + month + ".pdf";
            Response.AddHeader("content-disposition", attachment);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.Flush();
            Response.End();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //EmployeeRankingDiv.Visible = true;
            if (year.Text.ToString().IsEmpty())
            {
                Response.Write("<script> alert('Please enter year to generate employee ranking report');</script>");
            }
            else
            {
                int selectedYear = Int32.Parse(year.Text.ToString());
                string selectedMonth = cmbMonth.Value.ToString();

               try
                {
                    SqlConnection connection = new SqlConnection(strcon);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    empID = (string)Session["empID"];
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Emp_Ratings WHERE Year=@year AND Month=@month", connection);
                    cmd.Parameters.AddWithValue("@year", selectedYear);
                    cmd.Parameters.AddWithValue("@month", selectedMonth);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        docHeader = new BestEmployeeHeader();
                        docHeader.SupervisorID = empID;
                        docHeader.Year = selectedYear;
                        docHeader.Month = selectedMonth;
                        SqlCommand cmd1 = new SqlCommand("SELECT * FROM Emp_Detail WHERE Emp_ID=@empID", connection);
                        cmd1.Parameters.AddWithValue("@empID", empID);
                        SqlDataReader dr1 = cmd1.ExecuteReader();
                        while(dr1.Read())
                        {
                            docHeader.SupervisorName = dr1.GetString(3).ToString();
                            docHeader.Department = dr1.GetString(14).ToString();
                            break;
                        }

                        SqlCommand cmd2 = new SqlCommand("SELECT * FROM Emp_Detail WHERE Post=@post AND Department=(SELECT Department FROM Emp_Detail WHERE Emp_ID=@empID)", connection);
                        cmd2.Parameters.AddWithValue("@post", "Sales staff");
                        cmd2.Parameters.AddWithValue("@empID", empID);
                        SqlDataReader dr2 = cmd2.ExecuteReader();
                        if(dr2.HasRows)
                        {
                            employees = new ArrayList();
                            while (dr2.Read())
                            {
                                Employee employee = new Employee();
                                employee.EmployeeID = dr2.GetValue(0).ToString();
                                employee.EmployeeName = dr2.GetValue(3).ToString();

                                SqlCommand cmd3 = new SqlCommand("SELECT SUM(Rating) FROM Emp_Ratings WHERE Emp_ID=@empID AND Year=@year AND Month=@month", connection);
                                cmd3.Parameters.AddWithValue("@empID",employee.EmployeeID);
                                cmd3.Parameters.AddWithValue("@year", selectedYear);
                                cmd3.Parameters.AddWithValue("@month", selectedMonth);
                                SqlDataReader dr3 = cmd3.ExecuteReader();

                                if(dr3.HasRows)
                                {
                                    while(dr3.Read())
                                    {
                                        employee.Score = dr3.GetDouble(0);
                                        break;
                                    }
                                }else
                                {
                                    employee.Score = 0;
                                }

                                employees.Add(employee);
                            }

                            Employee temp;
                            int count = employees.Count;
                            for(int i=0;i<count-1;i++)
                            {
                                for(int j=0;j<count-i-1;j++)
                                {
                                    if(((Employee) employees[j]).Score > ((Employee)employees[j+1]).Score)
                                    {
                                        temp = (Employee) employees[j];
                                        employees[j] = employees[j + 1];
                                        employees[j + 1] = temp;
                                    }
                                }
                            }


                            ID_Department.InnerHtml = "Department : " + docHeader.Department;
                            ID_SupervisorID.InnerHtml = "Supervisor ID : " + docHeader.SupervisorID;
                            ID_SupervisorName.InnerHtml = "Supervisor Name : " + docHeader.SupervisorName;
                            ID_Year.InnerHtml = "Year : " + docHeader.Year.ToString();
                            ID_Month.InnerHtml = "Month : " + docHeader.Month;

                            HtmlTableRow row = new HtmlTableRow();
                            HtmlTableCell cell1 = new HtmlTableCell();
                            HtmlTableCell cell2 = new HtmlTableCell();
                            HtmlTableCell cell3 = new HtmlTableCell();
                            HtmlTableCell cell4 = new HtmlTableCell();



                            cell1.ColSpan = 1;
                            cell1.InnerText = "Rank";
                            cell2.ColSpan = 1;
                            cell2.InnerText = "Employee ID";
                            cell3.ColSpan = 1;
                            cell3.InnerText = "Employee Name";
                            cell4.ColSpan = 1;
                            cell4.InnerText = "Score";
                            row.Cells.Add(cell1);
                            row.Cells.Add(cell2);
                            row.Cells.Add(cell3);
                            row.Cells.Add(cell4);
                            TBL_Ranking.Rows.Add(row);

                            int Rank = 1;
                            for(int i=count-1;i>=0;i--)
                            {
                                ((Employee)employees[i]).Rank = Rank;

                                row = new HtmlTableRow();
                                cell1 = new HtmlTableCell();
                                cell2 = new HtmlTableCell();
                                cell3 = new HtmlTableCell();
                                cell4 = new HtmlTableCell();
                                cell1.ColSpan = 1;
                                cell1.InnerText = ((Employee)employees[i]).Rank.ToString();
                                cell2.ColSpan = 1;
                                cell2.InnerText = ((Employee)employees[i]).EmployeeID.ToString();
                                cell3.ColSpan = 1;
                                cell3.InnerText = ((Employee)employees[i]).EmployeeName.ToString();
                                cell4.ColSpan = 1;
                                cell4.InnerText = ((Employee)employees[i]).Score.ToString();
                                row.Cells.Add(cell1);
                                row.Cells.Add(cell2);
                                row.Cells.Add(cell3);
                                row.Cells.Add(cell4);
                                TBL_Ranking.Rows.Add(row);
                                Rank++;
                            }

                            EmployeeRankingDiv.Visible = true;

                        }
                        else
                        {
                            Response.Write("<script> alert('No employees under the supervisor');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script> alert('No records for given year and month');</script>");
                    }
                    connection.Close();

               }
               catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(" ===1 " + ex.Message);
                } 
            }
        }
    }
}