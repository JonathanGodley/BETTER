<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New.aspx.cs" Inherits="c3188072_assig1.User_Layer.Character.New" MasterPageFile="~/User_Layer/Shared/Site.Master" Title="Create New Character" %>

<%-- Jonathan Godley - c3188072 --%>
<%-- Last Modified: 03/11/2017 --%>
<%-- Inft3050 Assignment 2 --%>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="container ">
        <h2><%: Title %></h2>
        <hr />
        <p>Create a character by choosing an element and entering a name!</p>
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <div>
            <h4>Select an Element</h4>
            <asp:RadioButtonList CssClass="radio" ID="ElementRadioButtonList" runat="server" ToolTip="Select an Element for your new Character">
                <asp:ListItem Value="1">Fire</asp:ListItem>
                <asp:ListItem Value="2">Water</asp:ListItem>
                <asp:ListItem Value="3">Earth</asp:ListItem>
                <asp:ListItem Value="4">Air</asp:ListItem>
            </asp:RadioButtonList>
            <p>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="text-danger" ErrorMessage="Please Select an Element" ControlToValidate="ElementRadioButtonList"></asp:RequiredFieldValidator>
            </p>
        </div>
        <h4>Character Name</h4>
        <asp:TextBox CssClass="form-control" ID="NameTextBox" runat="server"></asp:TextBox>
        <p>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="text-danger" ErrorMessage="Please Enter a Character Name" ControlToValidate="NameTextBox" ToolTip="Enter a name for your new character"></asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Button CssClass="btn" ID="CreateCharacter" runat="server" Text="Create" OnClick="Create" ToolTip="Create your Character" />
        </p>
    </div>
</asp:Content>
