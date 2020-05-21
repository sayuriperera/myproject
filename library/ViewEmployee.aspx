<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewEmployee.aspx.cs" Inherits="library.ViewEmployee" %>
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
                                    <h3>Memeber Details</h3>
                                </center>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col-md-6">
                                <label>Serach by Employee ID/Name</label>
                                 <div class="form-group">
                                     <div class="input-group">
                                <asp:TextBox class="form-control" ID="TextBox16" runat="server"></asp:TextBox>
                                    <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Search" />
                                     </div>
                                     </div>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="col">
                               <label>Employee ID</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Employee ID" ReadOnly="True"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                  <label>First Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="First Name" ReadOnly="True"></asp:TextBox>
                               </div> 
                            </div>
                            <div class="col-md-6">
                             <label>Last Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Last Name" ReadOnly="True"></asp:TextBox>
                               </div>
                                </div>
                        </div>

                        <div class="row">
                            <div class="col">
                               <label>Full Name</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>NIC Number</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="NIC Number" ReadOnly="True"></asp:TextBox>
                               </div>
                            </div>
                             <div class="col-md-6">
                                <label>Contact Number</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Contact Number" TextMode="Phone" ReadOnly="True"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                  <label>Date of Birth</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>
                               </div> 
                            </div>
                            <div class="col-md-6">
                             <label>Gender</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox12" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>  
                               </div>
                                </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Address</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Address" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                  <label>City</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox7" placeholder="City" runat="server" TextMode="SingleLine" ReadOnly="True"></asp:TextBox>
                               </div> 
                            </div>
                            <div class="col-md-6">
                             <label>District</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox13" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>                                    
                               </div>
                                </div>
                        </div>

                              <div class="row">
                            <div class="col-md-6">
                                <label>Joined Date</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>
                               </div>
                            </div>
                             <div class="col-md-6">
                                <label>Status</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox14" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>                                  
                               </div>
                            </div>
                        </div>

                            <div class="row">
                            <div class="col-md-6">
                               <label>Post</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Post" ReadOnly="True"></asp:TextBox>
                               </div>
                            </div>
                                <div class="col-md-6">
                               <label>Department</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox15" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>                             
                               </div>
                            </div>
</div>
                      

                        <div class="row">
                            <div class="col-md-4 mx-auto">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block" ID="Button1" runat="server" Text="Back" />
                                </div>
                            </div>
                            <div class="col-md-4 mx-auto">
                                <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block" ID="Button2" runat="server" Text="Print" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
