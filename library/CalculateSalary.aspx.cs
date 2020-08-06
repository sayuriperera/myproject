
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using Excel;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;

namespace library
{
    public partial class CalculateSalary : System.Web.UI.Page
    {

        private static readonly string SavePath = "F:\\Project Sayuri\\";
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
           
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
    }
}