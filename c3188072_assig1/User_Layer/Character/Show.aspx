<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="c3188072_assig1.User_Layer.Character.Show" MasterPageFile="~/User_Layer/Shared/Site.Master" Title="View/Manage Characters" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <% c3188072_assig1.Models.UserCharacter cpChar = Character; %>
    <div class="container">
        <h2><%: Title %></h2>
        <hr />
        <p>
            <asp:Label ID="IntroText" runat="server" Text="View your Character's Details" />
        </p>
        <div class="col-sm-3"></div>
        <div class="row text-center">
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
                                            <td>Wins</td>
                                            <td><%:cpChar.Wins%></td>
                                        </tr>
                                        <tr>
                                            <td>Losses</td>
                                            <td><%:cpChar.Losses%></td>
                                        </tr>
                                        <tr>
                                            <td>Draws</td>
                                            <td><%:cpChar.Draws%></td>
                                        </tr>
                                        <tr>
                                            <td>Created</td>
                                            <td><%:cpChar.Created%></td>
                                        </tr>
                                        <tr>
                                            <td>Anonymous</td>
                                            <td><asp:CheckBox ID="AnonymousOwner" runat="server" OnCheckedChanged="AnonymousOwner_CheckedChanged" ViewStateMode="Enabled" EnableViewState="True" AutoPostBack="True"/>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="text-center">
            <asp:Button ID="Select" OnClick="SelectCharacter" CssClass="btn btn-success" runat="server" Text="Select This Character" ToolTip="Select This Character" />
            <asp:Button ID="Delete" OnClick="DeleteCharacter" CssClass="btn btn-danger" runat="server" Text="Delete This Character" ToolTip="Delete This Character" />
        </div>
    </div>
</asp:Content>
