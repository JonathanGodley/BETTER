<%@ Page MasterPageFile="~/User_Layer/Shared/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="c3188072_assig1.User_Layer.HallOfFame.Default" Title="Hall Of Fame" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <h2><%: Title %></h2>
        <hr />
        <p>This lists all characters that have been retired to the Hall of Fame.</p>
        <p>Your character can be here too if you keep excercising!</p>
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Character</th>
                    <th>Owner</th>
                    <th>Battles Won</th>
                    <th>Battles Lost</th>
                    <th>Creation Date</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (c3188072_assig1.Models.UserCharacter uc in hofChars)
                    { %>
                <tr class="display-table-tr">
                    <td><%: uc.Name %></td>
                    <% string output = "";
                        if (uc.AnonymousOwner == true) { output = "Anonymous"; }
                        else { output = c3188072_assig1.Models.Utilities.FindPlayer(uc.Owner).Name.ToString(); }%>
                    <td><%: output %></td>
                    <td><%: uc.Wins %></td>         
                    <td><%: uc.Losses %></td>
                    <td><%: uc.Created %></td>
                </tr>
                <%  } %>
            </tbody>
        </table>
    </div>
</asp:Content>
