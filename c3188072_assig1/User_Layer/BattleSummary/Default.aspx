<%@ Page Language="C#" MasterPageFile="~/User_Layer/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="c3188072_assig1.User_Layer.BattleSummary.Default" Title="Fight Summary" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <h2><%: Title %></h2>
        <hr />
        <div class="row text-center">
            <%--hardcoded data items--%>
            <div class="col-sm-6">
                <div class="panel panel-default">
                    <div class="row">
                        <div class="col-sm-12">
                            <h4>Steve</h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                           <%-- Decide which picture to render --%>
                            <%          string imgURL = "";
                                if (Character.Element == "Fire") { imgURL = "../../assets/images/fire.png"; }
                                else if (Character.Element == "Water") { imgURL = "../../assets/images/water.png"; }
                                else if (Character.Element == "Water") { imgURL = "../../assets/images/air.png"; }
                                else if (Character.Element == "Earth") { imgURL = "../../assets/images/earth.png"; } %>

                           <img src="<%:imgURL%>" alt="Element Image" height="30" />
                        </div>
                        <div class="col-sm-9">
                            <div class="container">
                                <table class="table table-condensed table-bordered">
                                    <tbody>
                                        <tr>
                                            <td>Level</td>
                                            <td><%:Character.Level.ToString()%></td>
                                        </tr>
                                        <tr>
                                            <td>Step</td>
                                            <td><%:Character.Step.ToString()%></td>
                                        </tr>
                                        <tr>
                                            <td>Wins</td>
                                            <td><%:Character.Wins.ToString()%></td>
                                        </tr>
                                        <tr>
                                            <td>Losses</td>
                                            <td><%:Character.Losses.ToString()%></td>
                                        </tr>
                                        <tr>
                                            <td>Draws</td>
                                            <td><%:Character.Draws.ToString()%></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <h2>Fight History</h2>
        <hr />
        <table class="table table-striped table-hover">
            <thead>
                <tr>
                    <th class="text-center">Opponent</th>
                    <th class="text-center">Owner</th>
                    <th class="text-center">Outcome</th>
                    <th class="text-center">View</th>
                </tr>
            </thead>
            <tbody class="text-center">
                <%@ Import Namespace="c3188072_assig1.Models" %>
                <%foreach (FightRecord fr in fRecs)
                    {
                        if (fr.Victor == Character.Id)
                        {%>
                <tr class="success">
                    <td><%: Utilities.FindCharacter(fr.GetNOT(Character.Id)).Name.ToString() %></td>
                     <% string output = "";
                        if (Utilities.FindCharacter(fr.GetNOT(Character.Id)).AnonymousOwner == true) { output = "Anonymous"; }
                        else { output = Utilities.FindPlayer((Utilities.FindCharacter(fr.GetNOT(Character.Id)).Owner)).Name.ToString(); }%>
                    <td><%: output %></td>
                    <td>Victory</td>
                    <td><a href="../Combat/Outcome/<%:fr.ID.ToString()%>">View Battle</a></td>
                </tr>
                <%}

                    else if (fr.Victor == -1)
                    {%>
                <tr class="">
                    <td><%: Utilities.FindCharacter(fr.GetNOT(Character.Id)).Name.ToString() %></td>
                    <% string output = "";
                        if (Utilities.FindCharacter(fr.GetNOT(Character.Id)).AnonymousOwner == true) { output = "Anonymous"; }
                        else { output = Utilities.FindPlayer((Utilities.FindCharacter(fr.GetNOT(Character.Id)).Owner)).Name.ToString(); }%>
                    <td><%: output %></td>
                    <td>Draw</td>
                    <td><a href="../Combat/Outcome/<%:fr.ID.ToString()%>">View Battle</a></td>
                </tr>
                <%}

                    else if (fr.Victor != Character.Id)
                    {%>
                <tr class="danger">
                    <td><%: Utilities.FindCharacter(fr.GetNOT(Character.Id)).Name.ToString() %></td>
                    <% string output = "";
                        if (Utilities.FindCharacter(fr.GetNOT(Character.Id)).AnonymousOwner == true) { output = "Anonymous"; }
                        else { output = Utilities.FindPlayer((Utilities.FindCharacter(fr.GetNOT(Character.Id)).Owner)).Name.ToString(); }%>
                    <td><%: output %></td>
                    <td>Loss</td>
                    <td><a href="../Combat/Outcome/<%:fr.ID.ToString()%>">View Battle</a></td>
                </tr>
                <%}

                    }%>
                <tr>
            </tbody>
        </table>
    </div>
</asp:Content>
