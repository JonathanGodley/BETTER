<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Enter.aspx.cs" Inherits="c3188072_assig1.User_Layer.Exercise.Enter" MasterPageFile="~/User_Layer/Shared/Site.Master" Title="Enter Exercise Points" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %></h2>
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PointsEarned" CssClass="col-md-2 control-label">Points Earned</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PointsEarned" CssClass="form-control" ToolTip="Enter the points you earned exercising!" TextMode="Number" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PointsEarned"
                                CssClass="text-danger" ErrorMessage="Please enter how many points you earned!" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="ParentPin" CssClass="col-md-2 control-label">Parent Pin</asp:Label>
                        <div class="col-md-10">
                            <%-- used onKeyDown to prevent letters from being entered in the pin section --%>
                            <%-- sourced from https://stackoverflow.com/questions/9732455/how-to-allow-only-integers-in-a-textbox with thanks to "EIV" & "Matt H" --%>
                            <%-- note: does still allow symbols to be entered @#$%^ etc --%>
                            <asp:TextBox runat="server" ID="ParentPin" TextMode="Password" CssClass="form-control" ToolTip="Enter your Parent's PIN number" MaxLength="4" onkeydown="return (!((event.keyCode>=65 && event.keyCode <= 95) || event.keyCode >= 106) && event.keyCode!=32);" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ParentPin" CssClass="text-danger" ErrorMessage="The parent pin field is required." Display="Dynamic" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="EnterPoints" Text="Upload" CssClass="btn btn-default" ToolTip="Upload an Exercise Report" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
