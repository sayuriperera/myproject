<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CalculateSalary.aspx.cs" Inherits="library.CalculateSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div>
            <div>

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Upload Attendance of Employees</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                 <div class="form-group">
                                <center>
                                     <img src="images/icons8-payroll-80.png" width="100px" height="100px/>
                                    </center>
                                 </div>
                            </div>
                            </div>
                        <br />
                         <div class="row">
                            <div class="col">
                               <label>Upload excel sheet</label>
                                 <div class="form-group">
                                     <asp:FileUpload class="form-control" ID="ExcelFile"   onchange="readURL(this);" runat="server" />
                                     <asp:RegularExpressionValidator   
id="FileUpLoadValidator" runat="server"   
ErrorMessage="Upload excel file only."   
ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.xlsx)$"   
ControlToValidate="ExcelFile">  
</asp:RegularExpressionValidator> 
                               </div>
                            </div>
                            </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button2" runat="server" Text="Back" OnClick="Button2_Click" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block" ID="Button1" runat="server" Text="Upload Attendance Sheet" ValidationGroup="Val6" OnClick="Button1_Click"/>
                                </div>
                            </div>

                        </div>
                    </div>
                    </div>
                </div>
        </div>


            <br />
             <br />
 
         <label style="margin-left:2%;"> Select Employee  </label>
         <asp:DropDownList  id="cmbEmployee" runat="server"></asp:DropDownList>
         <label style="margin-left:2%;"> Enter Year </label>
         <asp:TextBox  ID="txt_year" runat="server" placeholder="Year"></asp:TextBox> 
         <label style="margin-left:2%;"> Select Month </label>
         <select id="cmbMonth" runat="server">
                                     <option value="1">January</option>
                                     <option value="2">February</option>
                                     <option value="3">March</option>
                                     <option value="4">April</option>
                                     <option value="5">May</option>
                                     <option value="6">June</option>
                                     <option value="7">July</option>
                                     <option value="8">August</option>
                                     <option value="9">September</option>
                                     <option value="10">October</option>
                                     <option value="11">November</option>
                                     <option value="12">December</option>
         </select>
         <asp:Button style="margin-left:2%;" class="btn btn-success" ID="Button3" runat="server" Text="Calculate Salary" AutoPostback="false"  OnClick="Button3_Click" />
    
    <br />
    <br />
        </div>
          
        <center>
        <div id="SalaryReceiptDIV"  runat="server" style="width:80%;">
             <hr style="background-color:red;" />
            <center>
                <h6 style="color:blueviolet;"><u>Salary Script</u></h6>
            </center>
             <hr style="background-color:red;" />
            <div style="text-align:left;color:blue;">
                <h6 id="EmplpoyeeID" runat="server"></h6>
                <h6 id="EmployeeName" runat="server"></h6>
                <h6 id="MonthYear" runat="server"></h6>
            </div>
            <hr style="background-color:red;" />
            
            <table border="1" style="width:80%;">
                <tr>
                    <td>Basic Salary</td>
                    <td id="BasicSalary" runat="server"></td>
                </tr>
                 <tr>
                    <td>Overtime Salary</td>
                    <td id="OvertimeSalary" runat="server"></td>
                </tr>
                 <tr>
                    <td>Total Basic Salary</td>
                    <td id="TotalBasicSalary" runat="server"></td>
                </tr>
                 <tr>
                    <td id="EPF_Name" runat="server"></td>
                    <td id="EPF" runat="server"></td>
                </tr>
                <tr>
                    <td>Net Salary</td>
                    <td id="NetSalary" runat="server"></td>
                </tr>
                <tr>
                    <td id="ETF_Name" runat="server"></td>
                    <td id="ETF" runat="server"></td>
                </tr>
            </table>

            <br />
            <br />
            <label>Add Allowances : </label>
            <input type="number" ID="Allowances" runat="server"/>
            <asp:Button style="margin-left:2%;" class="btn btn-success" ID="Button5" runat="server" Text="Approve" AutoPostback="false"  OnClick="Button5_Click" />
        </div>
            </center>
       <br />
        <br />


</asp:Content>
