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
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">
                          <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Rate Employees</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                 <div class="form-group">
                               <center>
                                     <img src="images/icons8-name-tag-100.png" width="100px" height="100px/>
                              </center>
                                 </div>
                            </div>
                            </div>
                        <hr />
                        <br />
                       <div class="row">
                           <div class="col">
                         <h4>Productivity</h4>
                        <center>
                           <h6>Attendance</h6>
                        <span  onmouseover="starmark(this)" onclick="starmark(this)" id="1one" style="font-size:40px;cursor:pointer;"  class="fa fa-star checked"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="2one"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="3one"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="4one"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="5one"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                       </center>

                        <br />  
                                    </div>
                       </div>
        <div class="row">
            <div class="col">
             
                        <center>
                           <h6>Targets Met</h6>
                        <span  onmouseover="starmark(this)" onclick="starmark(this)" id="1two" style="font-size:40px;cursor:pointer;"  class="fa fa-star checked"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="2two"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="3two"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="4two"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="5two"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <asp:Label ID="Label2" runat="server"></asp:Label>
                       </center>

                        <br />  
                    </div>
                  
            </div>
                        <hr />
                         <h4>Communication</h4>
                        <div class="row">
            <div class="col">
            
                        <center>
                            <h6>Customer Service</h6>
                        <span  onmouseover="starmark(this)" onclick="starmark(this)" id="1three" style="font-size:40px;cursor:pointer;"  class="fa fa-star checked"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="2three"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="3three"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="4three"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="5three"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                       </center>

                        <br />  
                    </div>
                  
            </div>
                        <div class="row">
            <div class="col">
             
                        <center>
                            <h6>Oral Effective Communication</h6>
                        <span  onmouseover="starmark(this)" onclick="starmark(this)" id="1four" style="font-size:40px;cursor:pointer;"  class="fa fa-star checked"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="2four"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="3four"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="4four"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="5four"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <asp:Label ID="Label4" runat="server"></asp:Label>
                       </center>

                        <br />  
                    </div>
                  
            </div> <hr />
                         <h4>Workplace Behaviour</h4>
                        <div class="row">
            <div class="col">
            
                        <center>
                            <h6>Descipline</h6>
                        <span  onmouseover="starmark(this)" onclick="starmark(this)" id="1five" style="font-size:40px;cursor:pointer;"  class="fa fa-star checked"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="2five"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="3five"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="4five"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="5five"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <asp:Label ID="Label5" runat="server"></asp:Label>
                       </center>

                        <br />  
                    </div>
                  
            </div>
             <div class="row">
            <div class="col">
      
                        <center>
                            <h6>Appropriate Dressing</h6>
                        <span  onmouseover="starmark(this)" onclick="starmark(this)" id="1six" style="font-size:40px;cursor:pointer;"  class="fa fa-star checked"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="2six"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="3six"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="4six"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="5six"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <asp:Label ID="Label6" runat="server"></asp:Label>
                       </center>

                        <br />  
                    </div>
                  
            </div>
                        <div class="row">
            <div class="col">
      
                        <center>
                            <h6>Teamwork</h6>
                        <span  onmouseover="starmark(this)" onclick="starmark(this)" id="1seven" style="font-size:40px;cursor:pointer;"  class="fa fa-star checked"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="2seven"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="3seven"  style="font-size:40px;cursor:pointer;" class="fa fa-star "></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="4seven"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <span onmouseover="starmark(this)" onclick="starmark(this)" id="5seven"  style="font-size:40px;cursor:pointer;" class="fa fa-star"></span>
                        <asp:Label ID="Label7" runat="server"></asp:Label>
                       </center>

                        <br />  
                    </div>
                  
            </div>
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
    <br />
</asp:Content>
