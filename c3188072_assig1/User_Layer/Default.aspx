<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/User_Layer/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="c3188072_assig1._Default" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome!</h1>
        <p class="lead">B.E.T.T.E.R. or Battling Elemental Titans Through Excercising Routines is an interactive online game aimed to make exercise fun</p>
        <p><a href="../about" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                All you need to do to get started is make an account
            </p>
            <p>
                <a class="btn btn-default" href="../Account/register">Register &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>How does it work?</h2>
            <p>
                B.E.T.T.E.R. encourages exercise by allowing players to upload reports on their exercise to level up their creatures
            </p>
            <p>
                <a class="btn btn-default" href="../about">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Need Help?</h2>
            <p>
                Check out our list of common problems and their solutions.
            </p>
            <p>
                <a class="btn btn-default" href="../help">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
