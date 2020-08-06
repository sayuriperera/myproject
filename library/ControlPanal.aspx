<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ControlPanal.aspx.cs" Inherits="library.ControlPanal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <br />
    <div class="container">
        
            <center>
                      <h3>CONTROL PANEL</h3>
                                </center>
        <div class="row">
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">                    
                                  <center>
                                      <h4>Leave Management</h4>
                                </center>
                                </div>
                            </div>
                        <div class="row">
                            <div class="col">
                                <label>Select the Position</label>
                                <div class="form-group">
                                <asp:DropDownList ID="DDL_Position" runat="server">
                                    
                                </asp:DropDownList>

                                    </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <label>Select the Leave type</label>
                                <div class="form-group">
                                <asp:DropDownList ID="DDL_LeaveType" runat="server">
                                   
                                </asp:DropDownList>
                                    </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col">
                                <label>Select the Numebr of Leaves Permitted</label>
                                <div class="form-group">
                                <asp:TextBox ID="TXT_NoOfPremitted" runat="server" TextMode="Number"></asp:TextBox>
                                    </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                 <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button3" runat="server" Text="Back" />
                                </div>
                            </div>
                             <div class="col-md-6">
                                 <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block" ID="Button4" runat="server" AutoPostBack="false" Text="Update" OnClick="Button1_Click" />
                                </div>
                            </div>

                        </div>
                      </div>
                       </div>
                   </div>
            <div class="col-md-4">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">                                
                                  <center>
                                      <h4>Salary Rates</h4>
                                </center>
                                </div>
                            </div>
                      <div class="row">
                            <div class="col">
                                <label>Select the Position</label>
                                <div class="form-group">
                                <asp:DropDownList ID="DDL_Position_1" runat="server">
                                    <asp:ListItem Text="Select" Value="Select" />
                                </asp:DropDownList>
                                    </div>
                            </div>
                        </div>
                            <div class="row">
                            <div class="col">
                                <label>Enter the Hourly Rate</label>
                                <div class="form-group">
                                <asp:TextBox ID="TXT_HR" runat="server" TextMode="Number"></asp:TextBox>
                                    </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <label>Enter the Overtime Rate</label>
                                <div class="form-group">
                                <asp:TextBox ID="TXT_OR" runat="server" TextMode="Number"></asp:TextBox>
                                    </div>
                            </div>
                        </div>
                         <div class="row">
                            <div class="col-md-6">
                                 <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button5" runat="server" Text="Back" OnClick="Button5_Click1"/>
                                </div>
                            </div>
                             <div class="col-md-6">
                                 <div class="form-group">
                                    <asp:Button class="btn btn-success btn-block" ID="Button6" runat="server" AutoPostBack="false" OnClick="Button5_Click" Text="Update" />
                                </div>
                            </div>

                        </div>
                        </div>
                    </div>
                  </div>
                <div class="col-md-4">
                     <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">                                
                                  <center>
                                      <h4>Tax Rates</h4>
                                </center>
                                </div>
                            </div>
                        <div class="row">
                            <div class="col">
                                  <label>ETF Percentage</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="ETF Percentage"></asp:TextBox>
                                    
                                    </div>
                               </div> 
                            </div>
                        <div class="row">
                        <div class="col">
                             <label>EPF Percentage</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="EPF Percentage"></asp:TextBox>
                                    
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
                                    <asp:Button class="btn btn-success btn-block" ID="Button2" runat="server" Text="Set" />
                                </div>
                            </div>

                        </div>
                    
                 </div>
           </div>
</div>
         
      </div>
        </div>
</asp:Content>
