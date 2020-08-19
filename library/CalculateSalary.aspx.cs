
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Excel;
using Org.BouncyCastle.Utilities;
using System;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web.WebPages;

namespace library
{
    public partial class CalculateSalary : System.Web.UI.Page
    {

        private static readonly string SavePath = "F:\\Project Sayuri\\";
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
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
        private static int year;
        private static int totalNoOfLeavesGet;
        private static float allowance;
        private static float finalFigure;
        private static Boolean flag = false;
        private static int attendance;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                SalaryReceiptDIV.Visible = false;
                LoadEmployeeComboBoxData();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string strFileType = Path.GetExtension(ExcelFile.FileName).ToLower();
            string path = ExcelFile.PostedFile.FileName;
            // Upload attendace sheet
            if (strFileType == ".xlsx")
            {
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
                string excelPath = SavePath + path;
                ExcelFile.SaveAs(SavePath + path);
                int i = 0;
                foreach (var worksheet in Workbook.Worksheets(@excelPath)) {
                    i = 0;
                    foreach (var row in worksheet.Rows)
                    {
                        i++;
                        if(i == 1)
                        {
                            continue;
                        }
                        Cell[] cells = row.Cells;
                        var date = cells[0].Value;
                        
                        DateTime dateTime = DateTime.FromOADate(double.Parse(date.ToString())).Date;
                        string empID = cells[1].Text;

                        string checkIn = DateTime.FromOADate(double.Parse(cells[2].Value)).ToString("HH:mm:ss");
                        string checkOut = DateTime.FromOADate(double.Parse(cells[3].Value)).ToString("HH:mm:ss");
                        
                    
                   
                        SqlCommand cmd1 = new SqlCommand("SELECT * FROM Attendance WHERE EmpID=@empID AND Date=@date", connection);
                        cmd1.Parameters.AddWithValue("@empID", empID);
                        cmd1.Parameters.AddWithValue("@date", dateTime);

                        SqlDataReader dr = cmd1.ExecuteReader();

                        if (!dr.HasRows)
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO Attendance VALUES (@empID,@date,@checkIn,@checkOut)", connection);
                            cmd.Parameters.AddWithValue("@empID", empID);
                            cmd.Parameters.AddWithValue("@date", dateTime);
                            cmd.Parameters.AddWithValue("@checkIn", checkIn);
                            cmd.Parameters.AddWithValue("@checkOut", checkOut);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand("UPDATE Attendance SET CheckIn=@checkIn, CheckOut=@checkOut WHERE EmpID=@empID AND Date=@date", connection);
                            cmd.Parameters.AddWithValue("@empID", empID);
                            cmd.Parameters.AddWithValue("@date", dateTime);
                            cmd.Parameters.AddWithValue("@checkIn", checkIn);
                            cmd.Parameters.AddWithValue("@checkOut", checkOut);
                            cmd.ExecuteNonQuery();
                        }
                       
                        

                    }
                }
                Response.Write("<script> alert('All employees attendance saved successfully!');</script>");
                connection.Close();
            }
            else
            {
                Response.Write("<script> alert('Invalid file format. Format should be in excel!')!');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }

        // Salary Calculation 

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

        protected void Button3_Click(object sender, EventArgs e)
        {
            flag = false;
            if (cmbEmployee.SelectedValue.IsEmpty())
            {
                SalaryReceiptDIV.Visible = false;
                Response.Write("<script> alert('Please select a employee!');</script>");
            } else if (txt_year.Text.IsEmpty())
            {
                SalaryReceiptDIV.Visible = false;
                Response.Write("<script> alert('Enter year!');</script>");
            } else if (cmbMonth.Value.IsEmpty())
            {
                SalaryReceiptDIV.Visible = false;
                Response.Write("<script> alert('Select a month!');</script>");
            } else
            {
                empID = cmbEmployee.SelectedValue.ToString();
                year = Int32.Parse(txt_year.Text);
                month = Int32.Parse(cmbMonth.Value);

                // WHERE MONTH(happened_at) = 1 AND YEAR(happened_at) = 2009
                SqlConnection connection = new SqlConnection(strcon);
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                SqlCommand cmd11 = new SqlCommand("SELECT * FROM Salary WHERE EmpID=@empID AND Year=@year AND Month=@month", connection);
                cmd11.Parameters.AddWithValue("@empID", empID);
                cmd11.Parameters.AddWithValue("@month", month);
                cmd11.Parameters.AddWithValue("@year", year);

                SqlDataReader dr11 = cmd11.ExecuteReader();
                if(dr11.HasRows)
                {
                    String msg = empID + "'s " + year.ToString() + "/" + month.ToString() + " salary is already in the database!";
                    SalaryReceiptDIV.Visible = false;
                    Response.Write("<script> alert('" + msg  + "');</script>");
                    
                } else
                {
                    SqlCommand cmd1 = new SqlCommand("SELECT * FROM Attendance WHERE EmpID=@empID AND MONTH(Date)=@month AND YEAR(Date)=@year", connection);
                    cmd1.Parameters.AddWithValue("@empID", empID);
                    cmd1.Parameters.AddWithValue("@month", month);
                    cmd1.Parameters.AddWithValue("@year", year);

                    SqlDataReader dr = cmd1.ExecuteReader();

                    if (dr.HasRows)
                    {
                        attendance = 0;
                        int noOfLeaves = 0;
                        float daytime = 0F;
                        float overtime = 0F;
                        while (dr.Read())
                        {
                            DateTime date = dr.GetDateTime(1).Date;
                            TimeSpan checkIn = dr.GetTimeSpan(2);
                            TimeSpan checkOut = dr.GetTimeSpan(3);

                            float t2 = (float)(checkIn).TotalMinutes;
                            if (t2 == 0)
                            {
                                noOfLeaves++;
                            }
                            else
                            {
                                attendance += 1;
                                float t = (float)(checkOut - checkIn).TotalMinutes / 60f;
                                if (t < 8)
                                {
                                    daytime += t;
                                }
                                else
                                {
                                    daytime += 8;
                                    overtime += t - 8;
                                }
                            }
                        }


                        string post = "";
                        string status = "";
                        SqlCommand cmd10 = new SqlCommand("SELECT Post,Status FROM Emp_Detail WHERE Emp_ID=@empID;", connection);
                        cmd10.Parameters.AddWithValue("@empID", empID);
                        SqlDataReader dr10 = cmd10.ExecuteReader();
                        if (dr10.Read())
                        {
                            post = dr10.GetString(0);
                            status = dr10.GetString(1);
                        }

                        SqlCommand cmd2 = new SqlCommand("SELECT ID FROM Post WHERE Type=@post;", connection);
                        cmd2.Parameters.AddWithValue("@post", post);
                        SqlDataReader dr2 = cmd2.ExecuteReader();

                        int postID = 0;
                        if (dr2.Read())
                        {

                            postID = dr2.GetInt32(0);
                        }

                        SqlCommand cmd3 = new SqlCommand("SELECT * FROM Salary_Ratings WHERE PostID=@postID;", connection);
                        cmd3.Parameters.AddWithValue("@postID", postID);
                        SqlDataReader dr3 = cmd3.ExecuteReader();

                        float hourlyRate = 0f;
                        float overtimeRate = 0f;
                        while (dr3.Read())
                        {
                            hourlyRate = (float)dr3.GetDouble(1);
                            overtimeRate = (float)dr3.GetDouble(2);
                            break;
                        }

                        totalNoOfLeavesGet = 0;
                        SqlCommand cmd4 = new SqlCommand("SELECT NoOfLeaves FROM Emp_Leave WHERE Emp_ID=@empID AND Year=@year;", connection);
                        cmd4.Parameters.AddWithValue("@empID", empID);
                        cmd4.Parameters.AddWithValue("@year", year);
                        SqlDataReader dr4 = cmd4.ExecuteReader();

                        if (dr4.Read())
                        {
                            totalNoOfLeavesGet = dr4.GetInt32(0);
                        }

                        int s = -1;

                        if(status.Equals("Permanent"))
                        {
                            s = 1;
                        } else
                        {
                            s = 2;
                        }

                        int totalNoOfLeaves = 0;
                        SqlCommand cmd5 = new SqlCommand("SELECT SUM(NoOfPremitted) FROM Post_Leave WHERE PostID=@postID;", connection);
                        cmd5.Parameters.AddWithValue("@postID",s);
                        SqlDataReader dr5 = cmd5.ExecuteReader();

                        if (dr5.Read())
                        {

                            try
                            {
                                totalNoOfLeaves = dr5.GetInt32(0);

                            }
                            catch (Exception ex)
                            {

                            }


                        }

                        basicSalary = 0f;

                        if (noOfLeaves > 0)
                        {
                            if (totalNoOfLeaves > totalNoOfLeavesGet)
                            {
                                if ((totalNoOfLeaves - totalNoOfLeavesGet) > 0)
                                {
                                    if ((totalNoOfLeaves - totalNoOfLeavesGet) >= noOfLeaves)
                                    {
                                        basicSalary += (float)noOfLeaves * 8f * hourlyRate;
                                        totalNoOfLeavesGet += noOfLeaves;
                                    }
                                    else
                                    {
                                        basicSalary += (float)(totalNoOfLeaves - totalNoOfLeavesGet) * 8f * hourlyRate;
                                        totalNoOfLeavesGet = totalNoOfLeaves;
                                    }
                                }
                            }
                        }

                        basicSalary += daytime * hourlyRate;
                        overtimeSalary = (overtime * overtimeRate);
                        totalBasicSalary = basicSalary + overtimeSalary;


                        SqlCommand cmd6 = new SqlCommand("SELECT * FROM TaxRate WHERE name=@name", connection);
                        cmd6.Parameters.AddWithValue("@name", "EPF");
                        SqlDataReader dr6 = cmd6.ExecuteReader();
                        epf = 0f;
                        if (dr6.Read())
                        {
                            epf = (float)dr6.GetDouble(1);
                        }

                        SqlCommand cmd7 = new SqlCommand("SELECT * FROM TaxRate WHERE name=@name", connection);
                        cmd7.Parameters.AddWithValue("@name", "ETF");
                        SqlDataReader dr7 = cmd7.ExecuteReader();
                        etf = 0f;
                        if (dr7.Read())
                        {
                            etf = (float)dr7.GetDouble(1);
                        }

                        epfPart = totalBasicSalary * epf / 100f;
                        netSalary = totalBasicSalary - epfPart;


                        SqlCommand cmd8 = new SqlCommand("SELECT * FROM Emp_Detail WHERE Emp_ID=@empID", connection);
                        cmd8.Parameters.AddWithValue("@empID", empID);
                        SqlDataReader dr8 = cmd8.ExecuteReader();
                        string employeeName = "";
                        if (dr8.Read())
                        {
                            employeeName = dr8.GetString(3);
                        }

                        etfContribution = totalBasicSalary * etf / 100f;

                        EmplpoyeeID.InnerText = "Employee ID : " + empID.ToString();
                        EmployeeName.InnerText = "Employee Name : " + employeeName;
                        MonthYear.InnerText = "Month/Year : " + month + "/" + year;

                        BasicSalary.InnerText = basicSalary.ToString("0.00");
                        OvertimeSalary.InnerText = overtimeSalary.ToString("0.00");
                        TotalBasicSalary.InnerText = totalBasicSalary.ToString("0.00");
                        EPF_Name.InnerText = "-" + epf.ToString() + "% EPF";
                        EPF.InnerText = "(" + epfPart.ToString("0.00") + ")";
                        NetSalary.InnerText = netSalary.ToString("0.00");
                        ETF.InnerText = etfContribution.ToString("0.00");
                        ETF_Name.InnerText = "ETF Contribution (" + etf + "%)";
                        SalaryReceiptDIV.Visible = true;
                        flag = true;




                    }
                    else
                    {
                        SalaryReceiptDIV.Visible = false;
                        Response.Write("<script> alert('There is no attendance records for given input!');</script>");
                    }
                    connection.Close();
                }

            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if(flag)
            {
                allowance = 0f;
                finalFigure = netSalary;
                if (!Allowances.Value.IsEmpty())
                {
                    allowance = float.Parse(Allowances.Value);
                    finalFigure += allowance;
                  
                    SqlConnection connection = new SqlConnection(strcon);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    SqlCommand cmd1 = new SqlCommand("DELETE FROM Emp_Leave WHERE Emp_ID=@empID AND Year=@year", connection);
                    cmd1.Parameters.AddWithValue("@empID", empID);
                    cmd1.Parameters.AddWithValue("@year", year);
                    cmd1.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Emp_Leave VALUES(@empID,@year,@noOfLeaves)", connection);
                    cmd2.Parameters.AddWithValue("@empID", empID);
                    cmd2.Parameters.AddWithValue("@year", year); 
                    cmd2.Parameters.AddWithValue("@noOfLeaves",totalNoOfLeavesGet);
                    cmd2.ExecuteNonQuery(); 

                    SqlCommand cmd3 = new SqlCommand("INSERT INTO Salary(EmpID,Year,Month,BasicSalary," +
                        "OvertimeSalary,TotalBasicSalary,EpfPart,NetSalary,EpfRate,EtfRate,EtfContribution,Allowance,FinalFigure) VALUES(" +
                        "@empID,@year,@month,@basicSalary," +
                        "@overtimeSalary,@totalBasicSalary,@epfPart,@netSalary," +
                        "@epfRate,@etfRate,@etfContribution,@allowance,@finalFigure)", connection);
                    cmd3.Parameters.AddWithValue("@empID", empID);
                    cmd3.Parameters.AddWithValue("@year", year);
                    cmd3.Parameters.AddWithValue("@month", month);
                    cmd3.Parameters.AddWithValue("@basicSalary", basicSalary);
                    cmd3.Parameters.AddWithValue("@overtimeSalary", overtimeSalary);
                    cmd3.Parameters.AddWithValue("@totalBasicSalary", totalBasicSalary);
                    cmd3.Parameters.AddWithValue("@epfPart", epfPart);
                    cmd3.Parameters.AddWithValue("@netSalary", netSalary);
                    cmd3.Parameters.AddWithValue("@epfRate", epf);
                    cmd3.Parameters.AddWithValue("@etfRate", etf);
                    cmd3.Parameters.AddWithValue("@etfContribution", etfContribution);
                    cmd3.Parameters.AddWithValue("@allowance", allowance);
                    cmd3.Parameters.AddWithValue("@finalFigure", finalFigure);
                    cmd3.ExecuteNonQuery();


                    SqlCommand cmd4 = new SqlCommand("INSERT INTO AttendanceByMonth VALUES(@empID,@year,@month,@noOfDays)", connection);
                    cmd4.Parameters.AddWithValue("@empID", empID);
                    cmd4.Parameters.AddWithValue("@year", year);
                    cmd4.Parameters.AddWithValue("@month", month);
                    cmd4.Parameters.AddWithValue("@noOfDays", attendance);
                    cmd4.ExecuteNonQuery();

                    SalaryReceiptDIV.Visible = false;
                    Response.Write("<script> alert('Salary Calculation saved successfully!')</script>");

                    connection.Close();
                }
            } else
            {
                Response.Write("<script> alert('Select employee,year and month to generate salary script!')!');</script>");
            }
           
        }
    }
}