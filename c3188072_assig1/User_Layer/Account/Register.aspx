<%@ Page Title="Register" Language="C#" MasterPageFile="~/User_Layer/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="c3188072_assig1.Account.Register" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" TextMode="SingleLine" ToolTip="Enter your Name" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name"
                    CssClass="text-danger" ErrorMessage="Your name is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" ToolTip="Enter a valid email address - This will be your username" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ParentEmail" CssClass="col-md-2 control-label">Parent Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ParentEmail" CssClass="form-control" TextMode="Email" ToolTip="Enter the email of a Parent or Guardian, Necessary to receive a Parental Pin" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ParentEmail"
                    CssClass="text-danger" ErrorMessage="The parent email field is required to receive XP points from exercising." />
                <br />
                <asp:CompareValidator CssClass="text-danger" ID="CompareValidator1" runat="server" ErrorMessage="Parent and User email must be different" ControlToCompare="Email" ControlToValidate="ParentEmail" Operator="NotEqual"></asp:CompareValidator>

            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" ToolTip="Enter a password that is atleast 8 characters long" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The password field is required." />
                <br />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password should be at least 8 alpha numeric characters long" ValidationExpression="^([\S\s]{8,})$" Display="None"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirm password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" ToolTip="Enter a password that is atleast 8 characters long" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                <br />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="None" ErrorMessage="The password and confirmation password do not match." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Register" CssClass="btn btn-default" ToolTip="Create a new account" />
            </div>
        </div>
    </div>
</asp:Content>
