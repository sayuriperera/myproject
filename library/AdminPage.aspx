<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="library.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        
    <center>
    <img src="images/download.jpg" width="100" height="100"/>
    <h2>PIYARA FASHION</h2>
        <h3>EMPLOYEE MANAGEMENT SYSTEM</h3>
    </center>
   <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="card h-100">
                <div class="card-body flex-fill">
    <div>
                 <a href="CreateProfile.aspx"><button type="button" class="btn btn-dark btn-block" style="margin:5px">CREATE EMPLOYEE PROFILE</button></a>
    </div>
        
         <div>
           <a href="EditEmployee.aspx"><button type="button" class="btn btn-dark btn-block" style="margin:5px">EDIT EPLOYEE DATA</button></a>
         </div>
         <div>
             <a href="ViewEmployee.aspx"><button type="button" class="btn btn-dark btn-block" style="margin:5px">VIEW EMPLOYEE DETAILS</button></a>
         </div>
         <div>
             <a href="ViewAll.aspx"><button type="button" class="btn btn-dark btn-block" style="margin:5px">VIEW ALL EMPLOYEE</button></a>
         </div>
        
         
       
</div>
       </div>
        </div>
            <div class="col-md-4">
                <div class="card h-100">
                <div class="card-body flex-fill">
                     <div>
           <a href="CalculateSalary.aspx"> <button type="button" class="btn btn-dark btn-block" style="margin:5px">CALCULATE SALARIES</button></a>
         </div>
         <div>
           <a href="AdminReportGeneration.aspx"><button type="button" class="btn btn-dark btn-block" style="margin:5px">GENERATE REPORTS</button></a>
         </div>
                     

              </div>
                    </div>
                </div>
            <div class="col-md-4">
                <div class="card h-100">
                <div class="card-body flex-fill">
                    <div>
                <a href="CreateUser.aspx"> <button type="button" class="btn btn-dark btn-block" style="margin:5px">MANAGE USERS</button></a>
            </div>
             <div>
          <a href="ControlPanal.aspx"><button type="button" class="btn btn-dark btn-block" style="margin:5px">CONTROL PANEL</button></a>
         </div>
                    </div>
                    </div>
                </div>
        </div>
        </div>
    <br />
</asp:Content>
