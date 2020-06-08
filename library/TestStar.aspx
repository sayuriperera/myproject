<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TestStar.aspx.cs" Inherits="library.TestStar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        .Star
        {
            background - image: url(images / Star.gif);
            height: 17px;
            width: 17px;
        }
        .WaitingStar
        {
            background - image: url(images / WaitingStar.gif);
            height: 17px;
            width: 17px;
        }
        .FilledStar
        {
            background - image: url(images / FilledStar.gif);
            height: 17px;
            width: 17px;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                    <div class="card-body">

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
