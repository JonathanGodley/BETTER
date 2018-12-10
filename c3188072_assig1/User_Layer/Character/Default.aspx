<%@ Page MasterPageFile="~/User_Layer/Shared/Site.Master" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="c3188072_assig1.User_Layer.Character.Default" Title="Character Select" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container ">
        <h2><%: Title %></h2>
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
        <p>View and Select a Character to make it active, or create a new Character</p>
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th>Character</th>
                    <th>Level</th>
                    <th>XP</th>
                    <th>Step</th>
                    <th>Element</th>
                    <th>Battles Won</th>
                    <th>Battles Lost</th>
                    <th>Creation Date</th>
                    <th class="text-center">Select</th>
                </tr>
            </thead>
            <tbody>
                <% foreach (c3188072_assig1.Models.UserCharacter pChars in playChars)
                    { %>
                <tr class="display-table-tr">
                    <td><%: pChars.Name    %></td>
                    <td><%: pChars.Level   %></td>
                    <td><%: pChars.Xp      %></td>
                    <td><%: pChars.Step    %></td>
                    <td><%: pChars.Element %></td>
                    <td><%: pChars.Wins    %></td>
                    <td><%: pChars.Losses  %></td>
                    <td><%: pChars.Created %></td>
                    <td class="text-center">
                        <a class="btn btn-primary" href="Show/<%: pChars.Id %>">View</a>
                    </td>
                </tr>
                <%  } %>
            </tbody>
        </table>
        <div class="container text-center">
            <asp:Button Onclick="New" ID="NewCharacter" CssClass="btn btn-success" runat="server" ToolTip="Create a new Character" Text ="Create a new Character" />
        </div>
    </div>
</asp:Content>
