<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true"  CodeBehind="EmployeePerformanceAnalysis.aspx.cs" Inherits="library.EmployeePerformanceAnalysis" MaintainScrollPositionOnPostback="true"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>

    <script>
        function graph() {

            console.log(array1[0]);
            console.log(array2[0]);
            console.log(array3[0]);
            console.log(array4[0]);
            console.log(array5[0]);
            console.log(array6[0]);
            console.log(array7[0]);

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
         
       <label style="margin-left:10%;"> Select Employee  </label>
         <asp:DropDownList  id="cmbEmployee" runat="server"></asp:DropDownList>
         <asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Refresh"  OnClick="Button1_Click" />
   </div>
    <br />
   <div id="chartContainer" style="height: 370px; width: 100%;"></div>
      <br /><br />
    <div>
        <label style="margin-left:10%;"> Enter Year </label>
        <asp:TextBox  ID="year" runat="server" placeholder="Year"></asp:TextBox>
        <label style="margin-left:2%;"> Select Month </label>
        <select id="cmbMonth" runat="server">
                                     <option value="January">January</option>
                                     <option value="February">February</option>
                                     <option value="March">March</option>
                                     <option value="April">April</option>
                                     <option value="May">May</option>
                                     <option value="June">June</option>
                                     <option value="July">July</option>
                                     <option value="August">August</option>
                                     <option value="September">September</option>
                                     <option value="October">October</option>
                                     <option value="November">November</option>
                                     <option value="December">December</option>
                                </select>
        <asp:Button style="margin-left:2%;" class="btn btn-success" ID="Button3" runat="server" Text="Reload" AutoPostback="false"  OnClick="Button3_Click" />
        <asp:Button style="margin-left:2%;" class="btn btn-success" ID="Button2" runat="server" Text="Download Report" AutoPostback="false" OnClick="Button2_Click" />
        <br /><br />
        <div ID="EmployeeRankingDiv" runat="server">
            <h3 style="text-align:center;color:red;">Employee Ranking</h3>
            <br />
            
            <div style="margin-left:10%;">
                <h4 ID="ID_Department" runat="server"></h4>
                <h4 ID="ID_SupervisorID" runat="server"></h4>
                <h4 ID="ID_SupervisorName" runat="server"></h4>
                <h4 ID="ID_Year" runat="server"></h4>
                <h4 ID="ID_Month" runat="server"></h4>
           </div>
            
            <br />
            <center>
            <table id="TBL_Ranking" runat="server" border="1" style="width:80%">
               
            </table>
           </center>
            <br />
            <br />
        </div>
    </div>
</asp:Content>





