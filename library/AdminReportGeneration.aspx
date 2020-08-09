<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AdminReportGeneration.aspx.cs" Inherits="library.AdminReportGeneration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
  <script>
      function graph() {

          console.log(array[0]);

          var chart = new CanvasJS.Chart("chartContainer", {
              animationEnabled: true,
              theme: "light2", // "light1", "light2", "dark1", "dark2"
              title: {
                  text: "Employee Attendance Analysis By Month"
              },
              axisY: {
                  title: "No Of Days"
              },
              data: [{
                  type: "column",
                  showInLegend: true,
                  legendMarkerColor: "grey",
                  legendText: "Year/Month",
                  dataPoints: array[0]
              }]
          });
          chart.render();

      }
  </script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="employee">
        <br />
         <center>
         <h2>Employee Attedance Analysis</h2>
         </center>
         
       <label style="margin-left:10%;"> Select Employee  </label>
         <asp:DropDownList  id="cmbEmployee" runat="server"></asp:DropDownList>
         <asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Refresh" AutoPostback="false"  OnClick="Button1_Click" />
   </div>
    <br />
   <div id="chartContainer" style="height: 370px; width: 100%;"></div>
      <br /><br />
    <div>
        <center>
            <h2>Employee Salary Report Generation</h2>
        </center><br />
       
         <label style="margin-left:10%;"> Select Employee  </label>
         <asp:DropDownList  id="cmbEmployee1" runat="server"></asp:DropDownList>
        <label style="margin-left:10%;"> Enter Year </label>
        <asp:TextBox  ID="year" runat="server" placeholder="Year"></asp:TextBox>
        <label style="margin-left:2%;"> Select Month </label>
        <select id="cmbMonth" runat="server">
                                     <option value="1">January</option>
                                     <option value="2">February</option>
                                     <option value="3">March</option>
                                     <option value="4">April</option>
                                     <option value="5">May</option>
                                     <option value="6">June</option>
                                     <option value="7">July</option>
                                     <option value="8">August</option>
                                     <option value="9">September</option>
                                     <option value="10">October</option>
                                     <option value="11">November</option>
                                     <option value="12">December</option>
                                </select>
        <asp:Button style="margin-left:2%;" class="btn btn-success" ID="Button3" runat="server" Text="Reload" AutoPostback="false"  OnClick="Button3_Click" />
        <asp:Button style="margin-left:2%;" class="btn btn-success" ID="Button2" runat="server" Text="Download Salary Report" AutoPostback="false" OnClick="Button2_Click" />
        <br />
        <br />
         <asp:Button style="margin-left:2%;" class="btn btn-success" ID="Button4" runat="server" Text="Download All Employees Salary Report" AutoPostback="false" OnClick="Button4_Click" />  <br /> <br />
        <asp:Button style="margin-left:2%;" class="btn btn-success" ID="Button5" runat="server" Text="Download Attendance Report of All Employees" AutoPostback="false" OnClick="Button5_Click" />
        <br /><br />
       <center>
        <div id="SalaryReceiptDIV"  runat="server" style="width:80%;">
             <hr style="background-color:red;" />
            <center>
                <h6 style="color:blueviolet;"><u>Salary Script</u></h6>
            </center>
             <hr style="background-color:red;" />
            <div style="text-align:left;color:blue;">
                <h6 id="EmplpoyeeID" runat="server"></h6>
                <h6 id="EmployeeName" runat="server"></h6>
                <h6 id="MonthYear" runat="server"></h6>
            </div>
            <hr style="background-color:red;" />
            
            <table border="1" style="width:80%;">
                <tr>
                    <td>Basic Salary</td>
                    <td id="BasicSalary" runat="server"></td>
                </tr>
                 <tr>
                    <td>Overtime Salary</td>
                    <td id="OvertimeSalary" runat="server"></td>
                </tr>
                 <tr>
                    <td>Total Basic Salary</td>
                    <td id="TotalBasicSalary" runat="server"></td>
                </tr>
                 <tr>
                    <td id="EPF_Name" runat="server"></td>
                    <td id="EPF" runat="server"></td>
                </tr>
                <tr>
                    <td>Net Salary</td>
                    <td id="NetSalary" runat="server"></td>
                </tr>
                <tr>
                    <td id="ETF_Name" runat="server"></td>
                    <td id="ETF" runat="server"></td>
                </tr>
                <tr>
                    <td>Allowances</td>
                    <td id="Allowances" runat="server"></td>
                </tr>
                <tr>
                    <td>Final Figure</td>
                    <td id="FinalFigure" runat="server"></td>
                </tr>
            </table>

            <br />
            <br />
            
        </div>
            </center>
       <br />
        <br />

    </div>
</asp:Content>
