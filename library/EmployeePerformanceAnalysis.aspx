<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeePerformanceAnalysis.aspx.cs" Inherits="library.EmployeePerformanceAnalysis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>

    <script>
        function graph() {

                    var chart = new CanvasJS.Chart("chartContainer", {
                        animationEnabled: true,
                        title: {
                            text: "Employee Performance Progress"
                        },
                        axisY: {
                            includeZero: false
                        },
                        toolTip: {
                            shared: true
                        },
                        data: [
                            {
                                type: "line",
                                name: "Attendance",
                                showInLegend: true,
                                dataPoints: array1[0]
                            },
                            {
                                type: "line",
                                 name: "Targetsmet",
                                showInLegend: true,
                                dataPoints: array2[0]
                            },
                            {
                                type: "line",
                                name: "Customer Service",
                                showInLegend: true,
                                dataPoints: array3[0]
                            },
                            {
                                type: "line",
                                name: "Oral Effective Communication",
                                showInLegend: true,
                                dataPoints: array4[0]
                            },
                            {
                                type: "line",
                                name: "Descipline",
                                showInLegend: true,
                                dataPoints: array5[0]
                            },
                            {
                                type: "line",
                                name: "Appropriate Dressing",
                                showInLegend: true,
                                dataPoints: array6[0]
                            },
                            {
                                type: "line",
                                name: "Teamwork",
                                showInLegend: true,
                                dataPoints: array7[0]
                            }]
                        });
                chart.render();
 
        }
    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


   <div id="employee">
        <br />
          <h3 style="text-align:center;">Employee Performance Analysis</h3>
      
       <label style="margin-left:10%;"> Select Employee  </label>
         <select id="cmbEmployee" runat="server" OnSelectedIndexChanged="OnChangeEmployee()">
                                   
         </select>
   </div>
   <div id="chartContainer" style="height: 370px; width: 100%;"></div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>





