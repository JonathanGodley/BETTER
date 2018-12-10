<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Outcome.aspx.cs" Inherits="c3188072_assig1.User_Layer.Combat.Outcome" MasterPageFile="~/User_Layer/Shared/Site.Master" Title="Battle Outcome" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <h2><%: Title %> - Battle #<%:fRecord.ID%></h2>
        <hr />
        <%-- deretermine victor --%>
        <%if (fRecord.Victor == Character.Id)
            {%>
        <div class="alert alert-success">
            <strong>Success!</strong> You Won!
        </div>
        <%}
            else if (fRecord.Victor == -1)
            { %>
        <div class="alert alert-warning">
            <strong>Draw!</strong> No Victor!
        </div>
        <%}
            else if (fRecord.Victor == Opponent.Id)
            { %>
        <div class="alert alert-danger">
            <strong>Loss!</strong> You Lost!
        </div>
        <%}
            else
            {
                // should never happen, means error occured

                Response.BufferOutput = true;
                Response.Redirect("~/Shared/ErrorPage");

            } %>
        <div class="row text-center">
            <%--hardcoded data items--%>
            <div class="col-sm-5">
                <div class="panel panel-default">
                    <div class="row">
                        <div class="col-sm-12">
                            <h4><%:Character.Name%></h4>
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
                                            <td><%:Character.Level%></td>
                                        </tr>
                                        <tr>
                                            <td>XP</td>
                                            <td><%:Character.Xp%></td>
                                        </tr>
                                        <tr>
                                            <td>Step</td>
                                            <td><%:Character.Step%></td>
                                        </tr>
                                        <tr>
                                            <td>Element</td>
                                            <td><%:Character.Element%></td>
                                        </tr>
                                        <tr>
                                            <td>Wins</td>
                                            <td><%:Character.Wins%></td>
                                        </tr>
                                        <tr>
                                            <td>Losses</td>
                                            <td><%:Character.Losses%></td>
                                        </tr>
                                        <tr>
                                            <td>Draws</td>
                                            <td><%:Character.Draws%></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <h4>Owner: <%:c3188072_assig1.Models.Utilities.FindPlayer(Character.Owner).Name%></h4>
                </div>
            </div>
            <div class="col-sm-2">
                <h1 class="text-danger">Vs</h1>
            </div>
            <div class="col-sm-5">
                <div class="panel panel-default">
                    <div class="row">
                        <div class="col-sm-12">
                            <h4><%:Opponent.Name%></h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <%-- Decide which picture to render --%>
                            <%      
                                if (Opponent.Element == "Fire") { imgURL = "../../assets/images/fire.png"; }
                                else if (Opponent.Element == "Water") { imgURL = "../../assets/images/water.png"; }
                                else if (Opponent.Element == "Water") { imgURL = "../../assets/images/air.png"; }
                                else if (Opponent.Element == "Earth") { imgURL = "../../assets/images/earth.png"; } %>

                           <img src="<%:imgURL%>" alt="Element Image" height="30" />
                        </div>
                        <div class="col-sm-9">
                            <div class="container">
                                <table class="table table-condensed table-bordered">
                                    <tbody>
                                        <tr>
                                            <td>Level</td>
                                            <td><%:Opponent.Level%></td>
                                        </tr>
                                        <tr>
                                            <td>XP</td>
                                            <td><%:Opponent.Xp%></td>
                                        </tr>
                                        <tr>
                                            <td>Step</td>
                                            <td><%:Opponent.Step%></td>
                                        </tr>
                                        <tr>
                                            <td>Element</td>
                                            <td><%:Opponent.Element%></td>
                                        </tr>
                                        <tr>
                                            <td>Wins</td>
                                            <td><%:Opponent.Wins%></td>
                                        </tr>
                                        <tr>
                                            <td>Losses</td>
                                            <td><%:Opponent.Losses%></td>
                                        </tr>
                                        <tr>
                                            <td>Draws</td>
                                            <td><%:Opponent.Draws%></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <h4>Owner:  <% string output = "";
                        if (Opponent.AnonymousOwner == true) { output = "Anonymous"; }
                        else { output = c3188072_assig1.Models.Utilities.FindPlayer(Opponent.Owner).Name.ToString(); }%>
                    <%: output %></h4>
                </div>
            </div>
        </div>
        <div class="text-center">
            <asp:HyperLink NavigateUrl="~/Combat/" runat="server" CssClass="btn btn-default" ToolTip="Return to the Challenge Page">Challenge Another Player</asp:HyperLink>
        </div>
    </div>

</asp:Content>
