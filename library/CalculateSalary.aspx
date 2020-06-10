<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CalculateSalary.aspx.cs" Inherits="library.CalculateSalary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Calculate Salaries</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                 <div class="form-group">
                                     <img src="images/icons8-payroll-80.png" width="100px" height="100px/>
                                 </div>
                                </center>
                            </div>
                            </div>
                         <div class="row">
                            <div class="col">
                               <label>Upload excel sheet</label>
                                 <div class="form-group">
                                     <asp:FileUpload class="form-control" ID="FileUpload1" onchange="readURL(this);" runat="server" />
                               </div>
                            </div>
                            </div>
                        <div class="row">
                            <div class="col-md-6">
                                  <label>Date of Birth</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Start Date Required. " ControlToValidate="TextBox5" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val6"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Select a valid start date. " ControlToValidate="TextBox5" Operator="LessThan" Type="Date" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val6" ControlToCompare="TextBox1"></asp:CompareValidator>
                                     <asp:CompareValidator ID="CompareValidator3" runat="server" ErrorMessage="Cannot be a future date. " Operator="LessThanEqual" Type="Date"  ControlToValidate="TextBox5" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val6" ></asp:CompareValidator>

                               </div> 
                            </div>
                            <div class="col-md-6">
                             <label>Gender</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="End date Required. " ControlToValidate="TextBox5" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val6"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="End date should be greater than start date. " ControlToValidate="TextBox1" Operator="GreaterThan" Type="Date" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val6" ControlToCompare="TextBox5"></asp:CompareValidator>
                                     <asp:CompareValidator ID="CompareValidator4" runat="server" ErrorMessage="Cannot be a future date. " Operator="LessThanEqual" Type="Date"  ControlToValidate="TextBox1" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val6" ></asp:CompareValidator>

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
                                    <asp:Button class="btn btn-success btn-block" ID="Button1" runat="server" Text="Create" ValidationGroup="Val6" OnClick="Button1_Click"/>
                                </div>
                            </div>

                        </div>
                    </div>
                    </div>
                </div>
        </div>
        </div>
</asp:Content>
