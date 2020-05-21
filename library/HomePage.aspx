<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="library.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img src="images/download.jpg" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>
                                        Welcome!
                                    </h3>
                                    <p>Master pages allow you to create a consistent look and behavior for all the pages (or group of pages) in your web application.
A master page provides a template for other pages, with shared layout and functionality. The master page defines placeholders for the content, which can be overridden by content pages.
The output result is a combination of the master page and the content page.
The content pages contain the content you want to display.
When users request the content page, ASP.NET merges the pages to produce output that combines the layout of the master page with the content of the content page.
More Info on Master Page – https://docs.microsoft.com/en-us/previous-versions/dct97kc3(v=vs.140)?redirectedfrom=MSDN
Watch the video tutorial at the end of this video to understand more about how to cre</p>
                                </center>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
