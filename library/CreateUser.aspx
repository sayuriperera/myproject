<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="library.WebForm1" %>
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
                                    <h3>Create User Account</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            
                            <div class="col-md-6">
                             <label>User Type</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Assistant" Value="Assistant" />
                                        <asp:ListItem Text="Supervisor" Value="Supervisor" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val4" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Select a User Type" InitialValue="Select" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
                               </div>
                                </div>

                      
                            <div class="col-md-6">
                               <label>Employee ID</label>
                                 <div class="form-group">
                                     <div class="input-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Employee ID"></asp:TextBox>
                                         <asp:Button class="btn btn-primary" ID="Button2" runat="server" Text="Go" OnClick="Button2_Click" />
                                         </div>
                               </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                <label>First Name</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="First name" ReadOnly="True"></asp:TextBox>

                               </div>
                            </div>
                             <div class="col-md-6">
                                <label>Department</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Department"  ReadOnly="True"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                      <div class="row">
                            <div class="col-md-6">
                                 <label>User Name</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="User Name"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Name Required" ControlToValidate="TextBox1" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val4"></asp:RequiredFieldValidator>
                                </div>
                                </div>
                                <div class="col-md-6">
                             
                                 <label>Password</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password Required." ControlToValidate="TextBox2" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val4"></asp:RequiredFieldValidator>

                               </div>
                                </div>
                          </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button3" runat="server" Text="Back" OnClick="Button3_Click" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block" ID="Button1" runat="server" Text="Create" OnClick="Button1_Click" ValidationGroup="Val4" />
                                </div>
                            </div>
                        </div>

                        </br>
                         <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Remove User Account</h3>
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                 <label>Employee ID</label>
                                  <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="EmployeeID" runat="server" placeholder="Employee ID"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Employee ID is required!" ControlToValidate="EmployeeID" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="ValGroupTwo"
                                      ></asp:RequiredFieldValidator>
                                </div>
                                </div>
                               
                                </div>
                          

                         <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button class="btn btn-block" BackColor="Red" ForeColor="White" ID="RemoveUser" runat="server" Text="Remove" OnClick="RemoveUser_Click" ValidationGroup="ValGroupTwo" />
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
</asp:Content>
