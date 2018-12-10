<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="c3188072_assig1.User_Layer.Overview.Default" MasterPageFile="~/User_Layer/Shared/Site.Master" Title="Main Menu" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="text-right"><a href="../Account/UpdateProfile">Update Profile</a></div>
    <div class="container">
        <h2>Hello <%:uAc.Name%>, Welcome Back!</h2>
        <p>Logged in as <%:uAc.Email%> - <a href="../Account/Logout/">Not You?</a></p>
        
        <% if (pointsLeft == true)
            {%>
        <div class="alert alert-info">
            <a href="../Exercise/">
                <strong>Info!</strong> You have <%:uAc.ExercisePoints%> unspent excercise points!
            </a>
        </div>
            <% } %>
        <% if (pointsLeft == false)
            {%>
        <div class="alert alert-info">
            <a href="../Exercise/">
                <strong>Info!</strong> Don't forget to excercise to strengthen your titans!
            </a>
        </div>
            <% } %>
        <% if (battleFought == true)
            {%>
        <div class="alert alert-info">
            <a href="../BattleSummary/">
                <strong>Combat!</strong> You have been involved in fights while offline!
            </a>
             </div>
            <% } %>
       
        
        <hr />
        <h3>Your Characters</h3>
        <div class="row text-center">
            <%foreach (c3188072_assig1.Models.UserCharacter uc in uAc.GetUserCharacters())
                {%>
            <div class="col-sm-6">
                <div class="panel panel-default">
                    <div class="row">
                        <div class="col-sm-12">
                            <h4><%: uc.Name %></h4>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <%-- Decide which picture to render --%>
                            <%          string imgURL = "";
                                if (uc.Element == "Fire") { imgURL = "../../assets/images/fire.png"; }
                                else if (uc.Element == "Water") { imgURL = "../../assets/images/water.png"; }
                                else if (uc.Element == "Water") { imgURL = "../../assets/images/air.png"; }
                                else if (uc.Element == "Earth") { imgURL = "../../assets/images/earth.png"; } %>

                           <img src="<%:imgURL%>" alt="Element Image" height="30" />
                        </div>
                        <div class="col-sm-9">
                            <div class="container">
                                <table class="table table-condensed table-bordered">
                                    <tbody>
                                        <tr>
                                            <td>Level</td>
                                            <td><%: uc.Level%></td>
                                        </tr>
                                        <tr>
                                            <td>XP</td>
                                            <td><%: uc.Xp %></td>
                                        </tr>
                                        <tr>
                                            <td>Step</td>
                                            <td><%: uc.Step %></td>
                                        </tr>
                                        <tr>
                                            <td>Element</td>
                                            <td><%: uc.Element %></td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table class="table table-condensed">
                                    <thead>
                                        <tr>
                                            <td>
                                                <a href="../Character/Show/<%: uc.Id %>">More Information</a>
                                            </td>
                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%}%>
        </div>
    </div>
</asp:Content>
