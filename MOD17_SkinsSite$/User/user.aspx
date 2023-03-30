<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="user.aspx.cs" Inherits="MOD17_SkinsSite_.User.user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Área de utilizador</h1>
    <div runat="server" id="divPerfil">
        Nome: <asp:Label runat="server" ID="lbNome"></asp:Label>
        <br />Email: <asp:Label runat="server" ID="lbEmail"></asp:Label>
        <br />Nick: <asp:Label runat="server" ID="lbNick"></asp:Label><br />
        <asp:Button runat="server" ID="btEditar" Text="Editar Perfil" Onclick="btEditar_Click"/>
    </div>
    <div runat="server" id="divEditar">
        Nome: <asp:TextBox runat="server" ID="tbNome"></asp:TextBox>
        <br />Email: <asp:TextBox runat="server" ID="tbEmail"></asp:TextBox>
        <br />Nick: <asp:TextBox runat="server" ID="tbNick"></asp:TextBox>
        <br />
        <asp:Button runat="server" ID="btAtualizar" Text="Atualizar Perfil" OnClick="btAtualizar_Click" />
        <asp:Button runat="server" ID="btCancelar" Text="Cancelar" OnClick="btCancelar_Click" />
    </div>
</asp:Content>