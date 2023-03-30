<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="MOD17_SkinsSite_.Admin.Compra.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Compras</h2>
    <asp:CheckBox runat="server" ID="cb_skins_compradas" AutoPostBack="true" OnCheckedChanged="cb_skins_compradas_CheckedChanged"/>Só skins compradas
    <asp:GridView runat="server" ID="gv_compra"></asp:GridView>
    <h2>Resgistar nova Compra</h2>
    Skin: <asp:DropDownList runat="server" ID="dd_skin"></asp:DropDownList>
    <br />
    Utilizador: <asp:DropDownList runat="server" ID="dd_utilizador"></asp:DropDownList>
    <br />
    <asp:Button runat="server" ID="bt_registar" Text="Comprar" OnClick="bt_registar_Click" />
    <br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>