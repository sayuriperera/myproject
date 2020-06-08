<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RateEmployees.aspx.cs" Inherits="library.RateEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
      var count;
        function starmark(item) {
            count = item.id[0];
            sessionStorage.starRating = count;
            var subid = item.id.substring(1);
            for (var i = 0; i < 5; i++) {
                if (i < count) {
                    document.getElementById((i + 1) + subid).style.color = "orange";
                }
                else {
                    document.getElementById((i + 1) + subid).style.color = "black";
                }
            }
            
        }
        function sthng(count) {
            label1.Text = Convert.ToString(count);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <center>
                        <span  onmouseover="starmark(this)" onclick="starmark(this)" id="1one" style="font-size:40px;cursor:pointer;"  class="fa fa-star checked"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="2one"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="3one"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="4one"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="5one"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                       </center>
                        <br />
                            <div class="row">
                            <div class="col-6">
                                 <asp:Button ID="Button2" class="btn btn-primary btn-block" runat="server" Text="Cancel" />
                            </div>
                            <div class="col-6">
                                 <asp:Button ID="Button1" class="btn btn-success btn-block" runat="server" Text="Submit Rating" />
                            </div>
                        </div>
                       
                    </div>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
