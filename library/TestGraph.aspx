<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TestGraph.aspx.cs" Inherits="library.TestGraph" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://canvasjs.com/assets/script/canvasjs.min.js"></script>
    <script>
        function graph() {
            var chart = new CanvasJS.Chart("chartContainer", {
                animationEnabled: true,
                theme: "light2", // "light1", "light2", "dark1", "dark2"
                title: {
                    text: "Testing Bar Charts"
                },
                axisY: {
                    title: "Percentage"
                },
                data: [{
                    type: "column",
                    showInLegend: true,
                    legendMarkerColor: "grey",
                    legendText: "Percentage %",
                    dataPoints: [
                        { y: 300878, label: "Venezuela" },
                        { y: 266455, label: "Saudi" },
                        { y: 169709, label: "Canada" },
                        { y: 158400, label: "Iran" },
                        { y: 142503, label: "Iraq" },
                        { y: 101500, label: "Kuwait" },
                        { y: 97800, label: "UAE" },
                        { y: 80000, label: "Russia" }
                    ]
                }]
            });
            chart.render();

        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
          <h3 style="text-align:center;">Employee Performance Analysis</h3>
   <div id="chartContainer" style="height: 370px; width: 100%;"></div>
    <br />
    <br />
    <br />
    <br />
</asp:Content>
