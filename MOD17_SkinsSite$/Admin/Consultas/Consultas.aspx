<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="MOD17_SkinsSite_.Admin.Consultas.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Consultas</h2>
    <asp:DropDownList runat="server" ID="ddConsultas" CssClass="form-control" AutoPostBack="true"
        OnSelectedIndexChanged="ddConsultas_SelectedIndexChanged" runat="server">
        <asp:ListItem Value="0">Top de Skins mais requisitados</asp:ListItem>
        <asp:ListItem Value="1">Top de Jogadores</asp:ListItem>
        <asp:ListItem Value="2">Top de skin mais compradas do último mês</asp:ListItem>
        <asp:ListItem Value="9">Nº de compras por mês</asp:ListItem>
        <asp:ListItem Value="10">Lista dos utilizadores que compraram a skin mais caro</asp:ListItem>
        <asp:ListItem Value="11">Lista das skins cujo preço é superior à média</asp:ListItem>
        <asp:ListItem Value="12">Lista dos utilizadores com a mesma password</asp:ListItem>
    </asp:DropDownList>
    <asp:GridView CssClass="table" ID="gvConsultas" runat="server"></asp:GridView>
</asp:Content>