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
    public partial class ViewAll : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadEmployeeTableData();
            }
        }


        private void LoadEmployeeTableData()
        {
            SqlConnection connection = new SqlConnection(strcon);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand cmd = new SqlCommand("SELECT * FROM Emp_Detail", connection);
            SqlDataReader dr = cmd.ExecuteReader();

            string body = "";

            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    body += "<tr>" + "<td>" + dr.GetString(0) + "</td>" + "<td>" + dr.GetString(1) + "</td>" + "<td>" + dr.GetString(2) + "</td>" + "<td>" + dr.GetString(3) + "</td>" + "<td>" + dr.GetString(6) + "</td>" + "<td>" + dr.GetString(8) + "</td>" + "<td>" + dr.GetString(9) + "</td>" + "<td>" + dr.GetString(12) + "</td>" + "<td>" + dr.GetString(13) + "</td>" + "<td>" + dr.GetString(14) + "</td>" + "<td>" + dr.GetString(15) + "</td>" + "<td>" + dr.GetString(4) + "<br/>" + dr.GetDecimal(10) + "<br/>" + dr.GetDateTime(11) + "</td>" + "</tr>";
                }
                TBL_Body.InnerHtml = body;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPage.aspx");
        }
    }
}