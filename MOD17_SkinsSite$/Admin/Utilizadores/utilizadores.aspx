<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="utilizadores.aspx.cs" Inherits="MOD17_SkinsSite_.Admin.Utilizador.Utilizadores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Utilizadores</h1>
    <asp:GridView ID="gvUtilizadores" runat="server"></asp:GridView>
    <h1>Adicionar Utilizador</h1>
    Nome:<asp:TextBox runat="server" ID="tb_nome"></asp:TextBox><br />
    Email:<asp:TextBox runat="server" ID="tb_email"></asp:TextBox><br />
    Morada:<asp:TextBox runat="server" ID="tb_morada"></asp:TextBox><br />
    Nif:<asp:TextBox runat="server" ID="tb_nif"></asp:TextBox><br />
    Password:<asp:TextBox runat="server" ID="tb_password" TextMode="Password"></asp:TextBox><br />
    Perfil:<asp:DropDownList runat="server" ID="dd_perfil">
                <asp:ListItem Value="0">Admin</asp:ListItem>
                <asp:ListItem Value="1">Jogador de CSGO</asp:ListItem>
           </asp:DropDownList>
    <br />
    <asp:Button runat="server" ID="bt_guardar" Text="Adicionar" OnClick="bt_guardar_Click" /><br />
    <asp:Label runat="server" ID="lb_erro"></asp:Label>
</asp:Content>
