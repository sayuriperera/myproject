using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace library
{
    public partial class AdminReportGeneration : System.Web.UI.Page
    {

        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        private List<DataPoint> dataPoints;
        private static Boolean flag = false;

        // Salary Script
        private static float basicSalary = 0f;
        private static float overtimeSalary;
        private static float totalBasicSalary;
        private static float epfPart;
        private static float netSalary;
        private static float epf;
        private static float etf;
        private static float etfContribution;
        private static string empID;
        private static int month;
        private static int Year;
        private static float allowance;
        private static float finalFigure;
        private static string employeeName;

        protected void Page_Load(object sender, EventArgs e)
        {
            dataPoints = new List<DataPoint>();
            if (!IsPostBack)
            {
                SalaryReceiptDIV.Visible = false;
                LoadEmployeeComboBoxData();
                LoadEmployeeComboBoxData1();
            }
        }


        // Refresh Button
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (cmbEmployee.SelectedValue.IsEmpty()) {
                Response.Write("<script> alert('Please select a employee and enter year');</script>");
            } else
            {
                string empID = cmbEmployee.SelectedValue;
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT Year,Month,NoOfDays FROM AttendanceByMonth WHERE EmpID=@empID", connection);
                cmd.Parameters.AddWithValue("@empID", empID);
                SqlDataReader dr = cmd.ExecuteReader();

                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        dataPoints.Add(new DataPoint(dr.GetInt32(0).ToString() + "/" + dr.GetInt32(1).ToString(),dr.GetInt32(2)));
                    }
                    ClientScript.RegisterArrayDeclaration("array", JsonConvert.SerializeObject(dataPoints));
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "graph()", true);
                } else
                {
                    Response.Write("<script> alert('There is no any record for selected employee!');</script>");
                }
            }
        }

        // Reload Button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(cmbEmployee1.SelectedValue.IsEmpty() )
            {
                flag = false;
                SalaryReceiptDIV.Visible = false;
                Response.Write("<script> alert('Please select a employee');</script>");
            } else
            {
                if (year.Text.IsEmpty())
                {
                    flag = false;
                    SalaryReceiptDIV.Visible = false;
                    Response.Write("<script> alert('Please enter year');</script>");
                } else
                {
                    if(cmbMonth.Value.IsEmpty())
                    {
                        flag = false;
                        SalaryReceiptDIV.Visible = false;
                        Response.Write("<script> alert('Please select month');</script>");
                    } else
                    {
                        empID = cmbEmployee1.SelectedValue;
                        Year = Int32.Parse(year.Text);
                        month = Int32.Parse(cmbMonth.Value);

                        
                        SqlConnection connection = new SqlConnection(strcon);
                        if (connection.State == ConnectionState.Closed)
                        {
                            connection.Open();
                        }
                        SqlCommand cmd = new SqlCommand("SELECT* FROM Salary WHERE EmpID=@empID AND Year=@year AND Month=@month", connection);
                        cmd.Parameters.AddWithValue("@empID",empID);
                        cmd.Parameters.AddWithValue("@month", month);
                        cmd.Parameters.AddWithValue("@year", Year);
                        SqlDataReader dr = cmd.ExecuteReader();
                        cmbEmployee.Items.Clear();
                        if (dr.HasRows)
                        {
                            SqlCommand cmd8 = new SqlCommand("SELECT * FROM Emp_Detail WHERE Emp_ID=@empID", connection);
                            cmd8.Parameters.AddWithValue("@empID", empID);
                            SqlDataReader dr8 = cmd8.ExecuteReader();
                          
                            if (dr8.Read())
                            {
                                employeeName = dr8.GetString(3);
                            }

                            if (dr.Read())
                            {
                                EmplpoyeeID.InnerText = "Employee ID : " + empID.ToString();
                                EmployeeName.InnerText = "Employee Name : " + employeeName;
                                MonthYear.InnerText = "Month/Year : " + month + "/" + Year;

                                basicSalary = (float) dr.GetDouble(3);
                                overtimeSalary = (float)dr.GetDouble(4);
                                totalBasicSalary = (float)dr.GetDouble(5);
                                epfPart = (float)dr.GetDouble(6); 
                                netSalary = (float)dr.GetDouble(7);
                                epf = (float)dr.GetDouble(8);
                                etf = (float)dr.GetDouble(9); 
                                etfContribution = (float)dr.GetDouble(10);
                                allowance = (float)dr.GetDouble(11);
                                finalFigure = (float)dr.GetDouble(12);

                                BasicSalary.InnerText = basicSalary.ToString("0.00");
                                OvertimeSalary.InnerText = overtimeSalary.ToString("0.00");
                                TotalBasicSalary.InnerText = totalBasicSalary.ToString("0.00");
                                EPF_Name.InnerText = "-" + epf.ToString() + "% EPF";
                                EPF.InnerText = "(" + epfPart.ToString("0.00") + ")";
                                NetSalary.InnerText = netSalary.ToString("0.00");
                                ETF.InnerText = etfContribution.ToString("0.00");
                                ETF_Name.InnerText = "ETF Contribution (" + etf + "%)";
                                Allowances.InnerHtml = allowance.ToString("0.00");
                                FinalFigure.InnerHtml = finalFigure.ToString("0.00");
                                SalaryReceiptDIV.Visible = true;
                                flag = true;
                                LoadEmployeeComboBoxData();

                            }
                        } else
                        {
                            flag = false;
                            SalaryReceiptDIV.Visible = false;
                            Response.Write("<script> alert('No any records for entered employee and year/month');</script>");
                        }
                        connection.Close();
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                string html = @"<!DOCTYPE html>  
                        <html xmlns='http://www.w3.org/1999/xhtml'>  
                        <head>  
                            <title></title>  
                        </head>  
                        <body>";

                   html += "<center><h4>Salary Script</h4></center>" +
                    "<div><h4>Employee ID : " + empID + "</h4>" +
                    "<h4>Employee Name : " + employeeName + "</h4>" +
                    "<h4>Month/Year : " + month.ToString() + "/" + Year.ToString() + "</h4></div><br/><table border='1' style='width:80%;'>" +
                    "<tr><td>Basic Salary</td><td>" + basicSalary.ToString("0.00") + "</td></tr>" +
                    "<tr><td>Overtime Salary</td><td>" + overtimeSalary.ToString("0.00") + "</td></tr>" +
                    "<tr><td>Total Basic Salary</td><td>" + totalBasicSalary.ToString("0.00") + "</td></tr>" +
                    "<tr><td>-" + epf.ToString() + "% EPF</td><td>" + epfPart.ToString("0.00") + "</td></tr>" +
                    "<tr><td>Net Salary</td><td>" + netSalary.ToString("0.00") + "</td></tr>" +
                    "<tr><td>ETF Contribution (" + etf + "%)</td><td>" + etfContribution.ToString("0.00") + "</td></tr>" +
                    "<tr><td>Allowances</td><td>" + allowance.ToString("0.00") + "</td></tr>" +
                    "<tr><td>Final Figure</td><td>" + finalFigure.ToString("0.00") + "</td></tr>" +
                    "</table></body></html>";

                GeneratePDF(html, (empID + "-" + Year.ToString() + "/" + month.ToString() + "Salary Script"));
                        

            } else
            {
                Response.Write("<script> alert('Please reload a salary script to download');</script>");
            }
        }

        private void LoadEmployeeComboBoxData()
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

        private void LoadEmployeeComboBoxData1()
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
                cmbEmployee1.Items.Clear();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                       
                        cmbEmployee1.Items.Add(dr.GetValue(0).ToString());
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" === " + ex.Message);
            }
        }

        // Genearte PDF and Download
        private void GeneratePDF(string strHTML, string filename)
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
            string attachment = "attachment;filename=" + filename + ".pdf";
            Response.AddHeader("content-disposition", attachment);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.Flush();
            Response.End();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Value.IsEmpty()) {
                Response.Write("<script> alert('Please select a month');</script>");
            } else if (year.Text.IsEmpty()) {
                Response.Write("<script> alert('Enter year');</script>");
            } else
            {
                int y = Int32.Parse(year.Text);
                int m = Int32.Parse(cmbMonth.Value);
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT s.EmpID,e.Full_Name,s.FinalFigure FROM Salary s INNER JOIN Emp_Detail e ON s.EmpID = e.Emp_ID WHERE s.Year=@year AND s.Month=@month", connection);
                cmd.Parameters.AddWithValue("@month", m);
                cmd.Parameters.AddWithValue("@year", y);
                SqlDataReader dr = cmd.ExecuteReader();


                string html = @"<!DOCTYPE html>  
                        <html xmlns='http://www.w3.org/1999/xhtml'>  
                        <head>  
                            <title></title>  
                        </head>  
                        <body><center><h1>Summary of Employees Salary</h1></center><br/>";

                html += "<h4>Year/Month" + y.ToString() + "/" + m.ToString() + "</h4><br/>";
                html += "<table border='1' style='width:80%;'>";
                html += "<tr><th>Employee ID</th><th>Employee Name</th><th>Final Figure</th></tr>";
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        html += "<tr><td>" + dr.GetString(0) + "</td><td>" + dr.GetString(1) + "</td><td>" + dr.GetDouble(2).ToString("0.00") + "</td></tr>";
                    }
                    html += "</table></body></html>";

                    GeneratePDF(html, (y.ToString() + "/" + m.ToString() + "-" + "Salary Report"));

                } else
                {
                    Response.Write("<script> alert('No records for entered year and month!');</script>");
                }

                connection.Close();
            }
        }

        // Attendance Report 
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (cmbMonth.Value.IsEmpty())
            {
                Response.Write("<script> alert('Please select a month');</script>");
            }
            else if (year.Text.IsEmpty())
            {
                Response.Write("<script> alert('Enter year');</script>");
            }
            else
            {
                int y = Int32.Parse(year.Text);
                int m = Int32.Parse(cmbMonth.Value);
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT e.Emp_ID,e.Full_Name,a.NoOfDays FROM AttendanceByMonth a INNER JOIN Emp_Detail e ON a.EmpID = e.Emp_ID WHERE a.Year=@year AND a.Month=@month", connection);
                cmd.Parameters.AddWithValue("@month", m);
                cmd.Parameters.AddWithValue("@year", y);
                SqlDataReader dr = cmd.ExecuteReader();


                string html = @"<!DOCTYPE html>  
                        <html xmlns='http://www.w3.org/1999/xhtml'>  
                        <head>  
                            <title></title>  
                        </head>  
                        <body><center><h1>Summary of Employees Attendance Report</h1></center><br/>";

                html += "<h4>Year/Month : " + y.ToString() + "/" + m.ToString() + "</h4><br/>";
                html += "<table border='1' style='width:80%;'>";
                html += "<tr><th>Employee ID</th><th>Employee Name</th><th>No Of Days</th></tr>";
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        html += "<tr><td>" + dr.GetString(0) + "</td><td>" + dr.GetString(1) + "</td><td>" + dr.GetInt32(2) + "</td></tr>";
                    }
                    html += "</table></body></html>";

                    GeneratePDF(html, (y.ToString() + "/" + m.ToString() + "-" + "Attendance Report"));

                }
                else
                {
                    Response.Write("<script> alert('No records for entered year and month!');</script>");
                }

                connection.Close();
            }
        }
    }
}