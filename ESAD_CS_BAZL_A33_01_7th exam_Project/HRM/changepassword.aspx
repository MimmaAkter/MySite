<%@ Page Title="" Language="C#" MasterPageFile="~/maintemp.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="HRM.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ChangePassword ID="ChangePassword1" runat="server" ContinueDestinationPageUrl="~/homepage.aspx"></asp:ChangePassword>
    </div>
</asp:Content>
