<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RecuperarPassword.aspx.cs" Inherits="MOD17_SkinsSite_.RecuperarPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Recuperação da Palavra Passe</h1>
    Nova palavra Passe: <asp:TextBox runat="server" ID="tb_password" TextMODE="Password"></asp:TextBox>
    <br />
    <asp:Button runat="server" ID="bt_recuperar" Text="Definir nova password" OnClick="bt_recuperar_Click" />
    <br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>