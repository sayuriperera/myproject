﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditEmployee.aspx.cs" Inherits="library.EditEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
        function readURL(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#Image1').attr('src', e.target.result);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>
    <style>
        #Image1{
             position:absolute;
             right:0px;
             margin-right:40px;
        }
    </style>
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
                                    <h3>Update Employee Details</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Serach by Employee ID/Name</label>
                                 <div class="form-group">
                                     <div class="input-group">
                                <asp:TextBox class="form-control" ID="TextBox16" runat="server"></asp:TextBox>
                                    <asp:Button class="btn btn-primary" ID="Button3" runat="server" Text="Search" OnClick="Button3_Click" />
                                     </div>
                                     </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-7">
                               <label>Employee ID</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Employee ID" ReadOnly="True"></asp:TextBox>
                                     <asp:Label ID="Label1" runat="server" Text="Employee ID cannot be edited." Font-Bold="True" Font-Size="X-Small" ForeColor="Blue"></asp:Label>
                                 </div>
                            </div>
                            
                            <div class="col-md-5">
                                <asp:Image ID="Image1" runat="server" CssClass="img-thumbnail"  />
                            </div>
                        </div>
                    <div class="row">
                            <div class="col">
                               <label>Employee Image</label>
                                 <div class="form-group">
                                     <asp:FileUpload class="form-control" ID="FileUpload1" onchange="readURL(this);" runat="server" />
                               </div>
                            </div>
                    </div>

                        <div class="row">
                            <div class="col-md-6">
                                  <label>First Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="First Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="First Name Required" ControlToValidate="TextBox1" Font-Size="X-Small" Font-Bold="True" ForeColor="Red" ValidationGroup="val2" ></asp:RequiredFieldValidator>

                               </div> 
                            </div>
                            <div class="col-md-6">
                             <label>Last Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Last Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Last Name Required" ControlToValidate="TextBox3" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="val2"></asp:RequiredFieldValidator>

                               </div>
                                </div>
                        </div>

                        <div class="row">
                            <div class="col">
                               <label>Full Name</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Full Name"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="FullName Required" ControlToValidate="TextBox4" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="val2"></asp:RequiredFieldValidator>

                               </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>NIC Number</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="NIC Number"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="NIC Number Required" ControlToValidate="TextBox2" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="val2"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Not a valid NIC number" ControlToValidate="TextBox2" ValidationExpression="[0-9a-zA-Z]{9,12}" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val2" Font-Bold="True"></asp:RegularExpressionValidator>

                               </div>
                            </div>
                             <div class="col-md-6">
                                <label>Contact Number</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Contact Number" TextMode="Phone"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Contact Number Required" ControlToValidate="TextBox8" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="val2"></asp:RequiredFieldValidator>
                                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Not a valid Phone number" ValidationGroup="Val2" ControlToValidate="TextBox8" ValidationExpression="[0-9]{10}" Font-Size="X-Small" ForeColor="Red" Font-Bold="True"></asp:RegularExpressionValidator>

                               </div>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                  <label>Date of Birth</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Date of Birth Required" ControlToValidate="TextBox5" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="val2"></asp:RequiredFieldValidator>
                                    
                               </div> 
                            </div>
                            <div class="col-md-6">
                             <label>Gender</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Female" Value="Female" />
                                        <asp:ListItem Text="Male" Value="Male" />
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Select a gender" ControlToValidate="DropDownList1" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val2" InitialValue="Select"></asp:RequiredFieldValidator>
                                    
                               </div>
                                </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Address</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Address" TextMode="MultiLine"></asp:TextBox>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Address Required" ControlToValidate="TextBox6" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="val2"></asp:RequiredFieldValidator>

                               </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                  <label>City</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox7" placeholder="City" runat="server" TextMode="SingleLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="City is Required" ControlToValidate="TextBox7" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="val2"></asp:RequiredFieldValidator>

                               </div> 
                            </div>
                            <div class="col-md-6">
                             <label>District</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList2" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Ampara" Value="Ampara" />
                                        <asp:ListItem Text="Anuradhapura" Value="Anuradhapura" />
                                        <asp:ListItem Text="Badulla" Value="Badulla" />
                                        <asp:ListItem Text="Batticaloa" Value="Baticaloa" />
                                        <asp:ListItem Text="Colombo" Value="Colombo" />
                                        <asp:ListItem Text="Galle" Value="Galle" />
                                        <asp:ListItem Text="Gampaha" Value="Gampaha" />
                                        <asp:ListItem Text="Hambantota" Value="Hambantota" />
                                        <asp:ListItem Text="Jaffna" Value="Jaffna" />
                                        <asp:ListItem Text="Kalutara" Value="Kalutara" />
                                        <asp:ListItem Text="Kandy" Value="Kandy" />
                                        <asp:ListItem Text="Kegalle" Value="Kegalle" />
                                        <asp:ListItem Text="Kilinochchi" Value="Kilinochchi" />
                                        <asp:ListItem Text="Kurunegala" Value="Kurunegala" />
                                        <asp:ListItem Text="Manar" Value="Manar" />
                                        <asp:ListItem Text="Matale" Value="Matale" />
                                        <asp:ListItem Text="Matara" Value="Matara" />
                                        <asp:ListItem Text="Monaragala" Value="Monaragala" />
                                        <asp:ListItem Text="Mullativu" Value="Mullativu" />
                                        <asp:ListItem Text="Nuwara Eliya" Value="Nuwara Eliya" />
                                        <asp:ListItem Text="Polonnaruwa" Value="Polonnaruwa" />
                                        <asp:ListItem Text="Puttalam" Value="Puttalam" />
                                        <asp:ListItem Text="Ratnapura" Value="Ratnapura" />
                                        <asp:ListItem Text="Trincomalee" Value="Trincomalee" />
                                        <asp:ListItem Text="Vvaniya" Value="Vavniya" />

                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Select a district" ControlToValidate="DropDownList2" Font-Bold="True" Font-Size="X-Small" ForeColor="Red" ValidationGroup="Val2" InitialValue="Select"></asp:RequiredFieldValidator>
                                    
                               </div>
                                </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Qualifications</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox17" runat="server" placeholder="Qualifications" TextMode="MultiLine"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                              <div class="row">
                            <div class="col-md-6">
                                <label>Joined Date</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" ></asp:TextBox>
                                     

                               </div>
                            </div>
                             <div class="col-md-6">
                                <label>Status</label>
                                 <div class="form-group">
                                   <asp:DropDownList CssClass="form-control" ID="DropDownList3" runat="server">
                                        <asp:ListItem Text="Select" Value="Select" />
                                        <asp:ListItem Text="Permanent" Value="Permanent" />
                                        <asp:ListItem Text="Temporary" Value="Temporary" />

                                    </asp:DropDownList>
                                    
                               </div>
                            </div>
                        </div>

                            <div class="row">
                            <div class="col-md-6">
                               <label>Post</label>
                                 <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Post"></asp:TextBox>
                               </div>
                            </div>
                                <div class="col-md-6">
                               <label>Department</label>
                                 <div class="form-group">
                                   <asp:DropDownList CssClass="form-control" ID="DropDownList4" runat="server">
                                        <asp:ListItem Text="None" Value="None" />
                                        <asp:ListItem Text="Houseware" Value="Houseware" />
                                        <asp:ListItem Text="Ladies wear" Value="Ladies wear" />
                                        <asp:ListItem Text="Gents wear" Value="Gents wear" />
                                        <asp:ListItem Text="Kids wear" Value="Kids wear" />
                                        <asp:ListItem Text="Entertainment" Value="Entertainment" />
                                        <asp:ListItem Text="Toys" Value="Toys" />

                                    </asp:DropDownList>
                               </div>
                            </div>
</div>
                      

                        <div class="row">
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-warning btn-block" ID="Button1" runat="server" Text="Update" OnClick="Button1_Click" ValidationGroup="val2" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-danger btn-block" ID="Button2" runat="server" Text="Delete" OnClick="Button2_Click" ValidationGroup="val2" />
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button4" runat="server" Text="Cancel" OnClick="Button4_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
</asp:Content>
