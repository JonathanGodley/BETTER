<%@ Page Language="C#" MasterPageFile="~/User_Layer/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="c3188072_assig1.User_Layer.Combat.Default" Title="Challenge A Player" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <h2><%: Title %></h2>
        <hr />
        <p>Select an Opponent to challenge for XP!</p>
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Character</th>
                    <th>Type</th>
                    <th>Level</th>
                    <th>Step</th>
                    <th>Owner</th>
                    <th>Challenge</th>
                </tr>
            </thead>
            <tbody>
                <%foreach (c3188072_assig1.Models.UserCharacter uc in uChars)
                    { %>

                <tr>
                    <td><%:uc.Name%></td>
                    <td><%:uc.Element%></td>
                    <td><%:uc.Level%></td>
                    <td><%:uc.Step%></td>
                     <% string output = "";
                        if (uc.AnonymousOwner == true) { output = "Anonymous"; }
                        else { output = c3188072_assig1.Models.Utilities.FindPlayer(uc.Owner).Name.ToString(); }%>
                    <td><%: output %></td>
                    <td><a href="Fight/<%:uc.Id%>">Prepare to Fight!</a></td>
                </tr>
                <%}%>
            </tbody>
        </table>
    </div>
</asp:Content>
