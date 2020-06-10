﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ControlPanal.aspx.cs" Inherits="library.ControlPanal" %>
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
                                      <h3>CONTROL PANEL</h3>
                                </center>  
                                </div>
                            </div>
                            <div class="row">
                            <div class="col-md-6">
                                  <label>ETF Percentage</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="ETF Percentage"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="First Name Required" ControlToValidate="TextBox1" Font-Size="X-Small" Font-Bold="True" ForeColor="Red" ValidationGroup="val3" ></asp:RequiredFieldValidator>

                               </div> 
                            </div>
                            <div class="col-md-6">
                             <label>EPF Percentage</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="EPF Percentage"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Last Name Required" ControlToValidate="TextBox3" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="val3"></asp:RequiredFieldValidator>
                               </div>
                                </div>
                        </div>
                          <div class="row">
                            <div class="col">                                
                                <center>
                                      <h3>SALARY CONTROL</h3>
                                </center>  
                                </div>
                            </div>
                                   <div class="row">
                                       <div class="col-md-6">
                                           <label>Employee Type</label>
                                <div class="form-group">
                                           <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                               <asp:ListItem Text="Select" Value="Select" />
                                               <asp:ListItem Text="Department Supervisor" Value="Department Supervisor" />
                                               <asp:ListItem Text="Sales staff" Value="Sales staff" />
                                               <asp:ListItem Text="Operations staff" Value="Operations staff" />
                                           </asp:DropDownList>
                                       </div>
                                           </div>

                                       <div class="col-md-6">
                                           <label>Hourly Rate</label>
                                <div class="form-group">
                                           <asp:TextBox  CssClass="form-control" ID="TextBox2" runat="server" placeholder="Rate"></asp:TextBox>
                                       </div>
                                   </div>
                                          </div>
                        <div class="row">
                            <div class="col-md-6">
                                 <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button1" runat="server" Text="Back" OnClick="Button1_Click"/>
                                </div>
                            </div>
                             <div class="col-md-6">
                                 <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block" ID="Button2" runat="server" Text="Update" />
                                </div>
                            </div>

                        </div>
                     
                    </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>
