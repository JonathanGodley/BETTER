<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Allocate.aspx.cs" Inherits="c3188072_assig1.User_Layer.Exercise.Allocate" MasterPageFile="~/User_Layer/Shared/Site.Master" Title="Allocate Exercise Points" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <div class="container">
        <h2><%: Title %></h2>
        <hr />
        <h3>Available Points:
            <asp:Label ID="avlXP" runat="server" Text="200" ToolTip="How many points are available to spend"></asp:Label></h3>

        <asp:Panel CssClass="row text-center" ID="dataPanel" runat="server">
            <%--data items--%>
            <% foreach (c3188072_assig1.Models.UserCharacter cpChar in cpChars)
                { %>
            <div class="col-sm-6">
                <div class="panel panel-default">
                    <div class="row">
                        <div class="col-sm-12">
                            <h4><%:cpChar.Name%></h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <%-- Decide which picture to render --%>
                            <%          string imgURL = "";
                                if (cpChar.Element == "Fire") { imgURL = "../../assets/images/fire.png"; }
                                else if (cpChar.Element == "Water") { imgURL = "../../assets/images/water.png"; }
                                else if (cpChar.Element == "Water") { imgURL = "../../assets/images/air.png"; }
                                else if (cpChar.Element == "Earth") { imgURL = "../../assets/images/earth.png"; } %>

                           <img src="<%:imgURL%>" alt="Element Image" height="30" />
                        </div>
                        <div class="col-sm-9">
                            <div class="container">
                                <table class="table table-condensed table-bordered">
                                    <tbody>
                                        <tr>
                                            <td>Level</td>
                                            <td><%:cpChar.Level%></td>
                                        </tr>
                                        <tr>
                                            <td>XP</td>
                                            <td><%:cpChar.Xp%></td>
                                        </tr>
                                        <tr>
                                            <td>Step</td>
                                            <td><%:cpChar.Step%></td>
                                        </tr>
                                        <tr>
                                            <td>Element</td>
                                            <td><%:cpChar.Element%></td>
                                        </tr>
                                        <tr>
                                            <td>Allocate</td>
                                            <td>
                                                <asp:TextBox CssClass="text-center" Text="0" ID="xpInput" runat="server" TextMode="Number" ToolTip="Enter the number of points you want to spend" EnableViewState="False"></asp:TextBox></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <% } %>
        </asp:Panel>
        <div class="text-center">
            <asp:Button ID="AllocatePoints" runat="server" Text="Allocate Points" CssClass="btn btn-primary" OnClick="SpendPoints" ToolTip="Allocate exercise points to your characters" />
            <p>
                <asp:Label ID="pointWarning" runat="server" Text="Not Enough Points" CssClass="text-danger" Visible="False"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>
