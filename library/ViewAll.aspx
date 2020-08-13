<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ViewAll.aspx.cs" Inherits="library.ViewAll" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.21/css/jquery.dataTables.min.css">

    <script type="text/javascript">
        /*$(document).ready(function () {
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        })*/

        $(document).ready(function () {
            // Setup - add a text input to each footer cell
            $('#example tfoot th').each(function () {
                var title = $(this).text();
                $(this).html('<input type="text" placeholder="Search ' + title + '" />');
            });

            // DataTable
            var table = $('#example').DataTable({
                initComplete: function () {
                    // Apply the search
                    this.api().columns().every(function () {
                        var that = this;

                        $('input', this.footer()).on('keyup change clear', function () {
                            if (that.search() !== this.value) {
                                that
                                    .search(this.value)
                                    .draw();
                            }
                        });
                    });
                }
            });

        });


    </script>
    <style type="text/css">
        .auto-style1 {
            font-size: x-small;
        }
      
        tfoot input {
        width: 100%;
        padding: 3px;
        box-sizing: border-box;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
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
                          
                            <div class="col">
                                <table id="example"  class="display" style="width:100%">
        <thead>
            <tr>
                <th>Employee ID</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Full Name</th>
                <th>Gender</th>
                <th>City</th>
                <th>District</th>
                <th>Status</th>
                <th>Post</th>
                <th>Department</th>
                <th>Qualifications</th>
                <th>Other Information</th>
            </tr>
        </thead>
        <tbody id="TBL_Body" runat="server">
           
        </tbody>
        <tfoot>
            <tr>
                <<th>Employee ID</th>
                <th>First Name</th>
                <th>Last Name</th>
                <th>Full Name</th>
                <th>Gender</th>
                <th>City</th>
                <th>District</th>
                <th>Status</th>
                <th>Post</th>
                <th>Department</th>
                <th>Qualifications</th>
                <th>Other Information</th>
            </tr>
        </tfoot>
    </table>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                 <div class="form-group">
                                    <asp:Button class="btn btn-primary btn-block" ID="Button1" runat="server" Text="Back" OnClick="Button1_Click"/>
                                </div>
                            </div>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
