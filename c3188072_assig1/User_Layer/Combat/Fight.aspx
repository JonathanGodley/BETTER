<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fight.aspx.cs" Inherits="c3188072_assig1.User_Layer.Combat.Fight" MasterPageFile="~/User_Layer/Shared/Site.Master" Title="Fight Preperation" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container">
        <h2><%: Title %></h2>
        <hr />
        <div class="row text-center">
            <%--data items--%>
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
                            <h4>
                                <asp:Label ID="OpponentLabel" runat="server" Text="Label"></asp:Label></h4>
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
            <asp:Button ID="AllocatePoints" runat="server" OnClick="StartFight" Text="Begin Fight" CssClass="btn btn-success" ToolTip="Start the battle" />
            <asp:HyperLink NavigateUrl="~/Combat/" runat="server" CssClass="btn btn-danger" ToolTip="Return to the previous page">Cancel Fight</asp:HyperLink>
        </div>
    </div>

</asp:Content>
