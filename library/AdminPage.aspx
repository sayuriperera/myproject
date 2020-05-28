<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="library.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        
    <center>
    <img src="images/download.jpg" width="100" height="100"/>
    <h2>PIYARA FASHION</h2>
        <h3>EMPLOYEE MANAGEMENT SYSTEM</h3>
    </center>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-4 mx-auto"
     <CENTER>
             <div>
                <a href="CreateUser.aspx"> <button type="button" class="btn btn-dark btn-block" style="margin:5px">CREATE USER</button></a>
            </div>
    <div>
                 <a href="CreateProfile.aspx"><button type="button" class="btn btn-dark btn-block" style="margin:5px">CREATE EMPLOYEE PROFILE</button></a>
    </div>
         <div>
             <button type="button" class="btn btn-dark btn-block" style="margin:5px">CALCULATE SALARIES</button>
         </div>
         <div>
             <button type="button" class="btn btn-dark btn-block" style="margin:5px">GENERATE REPORTS</button>
         </div>
         <div>
             <button type="button" class="btn btn-dark btn-block" style="margin:5px">EDIT EPLOYEE DATA</button>
         </div>
         <div>
             <a href="ViewEmployee.aspx"><button type="button" class="btn btn-dark btn-block" style="margin:5px">VIEW EMPLOYEE DETAILS</button></a>
         </div>
         <div>
             <a href="ViewAll.aspx"><button type="button" class="btn btn-dark btn-block" style="margin:5px">VIEW ALL EMPLOYEE</button></a>
         </div>
         <br />

      </CENTER>
        </div>
        </div>
</asp:Content>
