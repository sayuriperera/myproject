<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewAll.aspx.cs" Inherits="library.ViewAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      });
   </script>
    <style type="text/css">
        .auto-style1 {
            font-size: x-small;
        }
      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
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
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:EmployeeMgtDBConnectionString %>" SelectCommand="SELECT * FROM [Emp_Detail]"></asp:SqlDataSource>

                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="Emp_ID" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="Emp_ID" HeaderText="Employee ID" ReadOnly="True" SortExpression="Emp_ID" />
                                        <asp:BoundField DataField="First_Name" HeaderText="First Name" SortExpression="First_Name" />
                                        <asp:BoundField DataField="Last_Name" HeaderText="Last Name" SortExpression="Last_Name" />
                                        <asp:BoundField DataField="Full_Name" HeaderText="Full Name" SortExpression="Full_Name" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                                        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                                        <asp:BoundField DataField="District" HeaderText="District" SortExpression="District" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                                        <asp:BoundField DataField="Post" HeaderText="Post" SortExpression="Post" />
                                        <asp:BoundField DataField="Department" HeaderText="Department" SortExpression="Department" />
                                        <asp:BoundField DataField="Qualifications" HeaderText="Qualifications" SortExpression="Qualifications" />
                                       
                                        <asp:TemplateField HeaderText="Other Information">

                                            <ItemTemplate>
                                                <div class="container-fluid">
                                                    <div class="row">
                                                        <div class="col-lg-12">
                                                            <div class="row">
                                                                <div class="auto-style1">

                                                                   Contact Number
                                                                    <asp:Label ID="Label1" runat="server" Font-Size="X-Small" Text='<%# Eval("Contact_No") %>' Font-Bold="True"></asp:Label>

                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="auto-style1">

                                                                    NIC Number 
                                                                    <asp:Label ID="Label2" runat="server" Font-Size="X-Small" Text='<%# Eval("NIC") %>' Font-Bold="True"></asp:Label>

                                                                </div>
                                                            </div>   
                                                             <div class="row">
                                                                <div class="auto-style1">

                                                                   Joined Date
                                                                    <asp:Label ID="Label3" runat="server" Font-Size="X-Small" Text='<%# Eval("Joined_Date") %>' Font-Bold="True"></asp:Label>

                                                                </div>
                                                            </div>
                                                        </div>
                                                       
                                                  </div>
                                                </div>
                                            </ItemTemplate>

                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
