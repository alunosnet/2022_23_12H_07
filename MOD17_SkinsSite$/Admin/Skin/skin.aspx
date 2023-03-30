<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="skin.aspx.cs" Inherits="MOD17_SkinsSite_.Admin.Skin.Skin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gestão de Skins</h2>
    <asp:GridView ID="gvSkins" runat="server" CssClass="table" />
    <h2>Adicionar Skin</h2>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbNome">Nome:</label>
        <asp:TextBox CssClass="form-control" ID="tbNome" runat="server" MaxLength="100" Required placeholder="Nome da Skin" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbAno">Ano:</label>
        <asp:TextBox CssClass="form-control" ID="tbAno" runat="server" TextMode="Number" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbData">Data de Aquisição:</label>
        <asp:TextBox CssClass="form-control" ID="tbData" runat="server" TextMode="Date" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_tbPreco">Preço:</label>
        <asp:TextBox ID="tbPreco" CssClass="form-control" runat="server" TextMode="Number" /><br />
    </div>
    <div class="from-group">
        <label for="ContentPlaceHolder1_dpTipo">Tipo:</label>
        <asp:DropDownList CssClass="form-select" ID="dpTipo" runat="server">
            <asp:ListItem Text="Ak-47" Value="skin1" />
            <asp:ListItem Text="AWP" Value="skin2" />
            <asp:ListItem Text="Desert Eagle" Value="skin3" />
            <asp:ListItem Text="SSG 08" Value="skin4" />
            <asp:ListItem Text="M4A1S" Value="skin5" />
            <asp:ListItem Text="M4A4" Value="skin6" />
            <asp:ListItem Text="MP9" Value="skin7" />
            <asp:ListItem Text="USP" Value="skin8" />
            <asp:ListItem Text="Glock" Value="skin9" />
            <asp:ListItem Text="MAC-10" Value="skin10" />
         </asp:DropDownList>
    </div>
    <div class="form-group">
        <label for="ContentPlaceHolder1_fuCapa">Capa:</label>
        <asp:FileUpload ID="fuCapa" runat="server" CssClass="form-control" />
    </div> 
    <br />
    <asp:Button CssClass="btn btn-lg btn-success" runat="server" ID="bt" Text="Adicionar" OnClick="bt_Click" />

    <asp:Label runat="server" ID="lbErro" />
</asp:Content>
