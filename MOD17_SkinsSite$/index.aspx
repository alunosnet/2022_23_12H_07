<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MOD17_SkinsSite_.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>CSGO.Bussiness</h1>
    <!--Login-->
     <div runat="server" id="divLogin" class="float-end col-sm-2 table-bordered divLogin" style="z-index:1">
        Email:<asp:TextBox CssClass="form-control" TextMode="Email" runat="server" ID="tb_Email"></asp:TextBox><br />
        Password:<asp:TextBox CssClass="form-control" runat="server" ID="tb_Password" TextMode="Password"></asp:TextBox><br />
        <asp:Label runat="server" ID="lb_erro"></asp:Label><br />
        <asp:Button  CssClass="btn btn-info" runat="server" ID="bt_login" Text="Login" OnClick="bt_login_Click" />
        <asp:Button  CssClass="btn btn-danger" runat="server" ID="bt_recuperar" Text="Recuperar password" OnClick="bt_recuperar_Click" />
    </div>
    <!--Pesquisa-->
    <div class="col-sm-10 float-start">
        <h1>Skins Online</h1>
        <div class=" col-sm-9 input-group">
            <asp:TextBox CssClass="form-control" ID="tbPesquisa" runat="server"></asp:TextBox>
            <span class="input-group-btn">
                <asp:Button CssClass="btn btn-info" runat="server" ID="btPesquisar" Text="Pesquisar" OnClick="btPesquisar_Click" />
            </span>
        </div>
    </div>
    <!--Lista das Skins-->
    <div class="float-start col-md-9 m-1" id="divSkins" runat="server"></div>

</asp:Content>
