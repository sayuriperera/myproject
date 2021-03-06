﻿using System;
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
    public partial class UserLogin : System.Web.UI.Page
    {
        private readonly string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //login button
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Login where UserName ='" + TextBox1.Text.Trim() + "' AND Password = '" + TextBox2.Text.Trim() + "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script> alert('Login Successful');</script>");
                        Session["name"] = dr.GetValue(0).ToString();
                        Session["empID"] = dr.GetValue(2).ToString();
                        Session["hello"] = "user";
                        string role = dr.GetValue(3).ToString();

                        if (role == "Assistant")
                        {
                            Response.Redirect("CreateProfile.aspx");
                        }
                        else if (role == "Supervisor")
                        {
                            Response.Redirect("SupervisorPage.aspx");
                        }
                    }
                  
                }
                else
                {
                    Response.Write("<script> alert('Login Unsuccessful');</script>");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(" =============== " + ex.Message);
                Response.Write("<script> alert('" + ex.Message + "');</script>");
            }
        }
    }
    }
