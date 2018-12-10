<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/User_Layer/Shared/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="c3188072_assig1.User_Layer.Account.ChangePassword" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    &nbsp;&nbsp;&nbsp;


    <div class="form-horizontal">
        <h4>Change your password</h4>
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">New Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="NewPassword" TextMode="Password" CssClass="form-control" ToolTip="Enter a password that is atleast 8 characters long" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="NewPassword"
                    CssClass="text-danger" ErrorMessage="The password should be at least 8 alpha numeric characters long" ValidationExpression="^([\S\s]{8,})$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" CssClass="col-md-2 control-label">Previous Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="OldPassword" TextMode="Password" CssClass="form-control" ToolTip="Please enter your current password" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="OldPassword"
                    CssClass="text-danger" ErrorMessage="Please enter your current password"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="UpdateDetails" Text="Change Password" CssClass="btn btn-default" ToolTip="Change Password" />
            </div>
        </div>
    </div>
</asp:Content>
