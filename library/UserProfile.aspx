<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="library.test" %>
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
                                  <div class="row">
                            <div class="col">
                                <center>
                                      <h3>USER PROFILE</h3>
                                </center>  
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                   <label>Employee ID</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Employee ID" ReadOnly="True"></asp:TextBox>
                               </div> 
                                     </div>
                             </div>
                                <div class="row">
                                <div class="col-md-6">
                                  <label>Username</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Username" ReadOnly="True"></asp:TextBox>
                               </div> 
                                </div>
                                    <div class="col-md-6">
                                  <label>Password</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Password" ReadOnly="True"></asp:TextBox>
                               </div> 
                                </div>
                               </div>
                       

                                 <div class="row">
                            <div class="col-md-6">
                                   <label>New Username</label>
                               <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="New Username"></asp:TextBox>
                               </div> 
                                    </div>
                                <div class="col-md-6">
                                  <label>New Password</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="New Password"></asp:TextBox>
                               </div> 
                                </div>
                            
                            </div>
                            <div class="row">
                            <div class="col-md-6 mx-auto">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button1" runat="server" Text="Back" OnClick="Button1_Click" />
                                </div>
                            </div>
                            <div class="col-md-6 mx-auto">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block" ID="Button2" runat="server" Text="Update" OnClick="Button2_Click"  />
                                </div>
                            </div>
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
