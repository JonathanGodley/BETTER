<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="c3188072_assig1.User_Layer.Exercise.Default" MasterPageFile="~/User_Layer/Shared/Site.Master" Title="Manage Exercise Points" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="container">
        <h2><%: Title %></h2>
        <hr />    
        <div class="btn-group">
            <a href="/Exercise/Upload" class="btn btn-default" role="button">Upload Exercise Report</a>
            <a href="/Exercise/Enter" class="btn btn-default" role="button">Enter Exercise Points</a>
            <a href="/Exercise/Allocate" class="btn btn-default" role="button">Allocate Exercise Points</a>
        </div>
        <h3>Exercise History</h3>
        <table class="table table-striped table-condensed table-hover">
            <thead>
                <tr>
                    <th>Date</th>
                    <th>Points</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (c3188072_assig1.Models.ExerciseRecord er in c3188072_assig1.Models.Utilities.FindPlayer((int)Session["CurrentUser"]).GetUserExercise())
                    { %>
                <tr class="display-table-tr">
                    <td><%: er.Date %></td>
                    <td><%: er.PointsEarned %></td>
                </tr>
                <%  } %>
            </tbody>
        </table>
    </div>
</asp:Content>
