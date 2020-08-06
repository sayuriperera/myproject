<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CalculateSalary.aspx.cs" Inherits="library.CalculateSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
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
        </div>
    <br />
    <br />


</asp:Content>
