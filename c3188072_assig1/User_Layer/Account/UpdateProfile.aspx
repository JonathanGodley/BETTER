<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="c3188072_assig1.User_Layer.Account.UpdateProfile" Title="Update your Profile" MasterPageFile="~/User_Layer/Shared/Site.Master" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div class="form-horizontal">
        <h4>Update your account details</h4>
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
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" TextMode="SingleLine" ToolTip="Enter your Name"></asp:TextBox>
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
                <asp:CompareValidator CssClass="text-danger" ID="CompareValidator1" runat="server" ErrorMessage="Parent and User email must be different" ControlToCompare="Email" ControlToValidate="ParentEmail" Operator="NotEqual" Display="None"></asp:CompareValidator>


            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" ToolTip="Enter a password that is atleast 8 characters long" />
                <asp:RegularExpressionValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="The password should be at least 8 alpha numeric characters long" ValidationExpression="^([\S\s]{8,})$"></asp:RegularExpressionValidator>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="UpdateDetails" Text="Update Details" CssClass="btn btn-default" ToolTip="Update your details" />
                <a class="btn btn-default" href="ChangePassword">Change Password</a>
            </div>
        </div>

    </div>
</asp:Content>
