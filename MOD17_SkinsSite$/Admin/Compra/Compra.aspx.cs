using MOD17_SkinsSite_.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_.Admin.Compra
{
    public partial class Compra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }

            ConfigurarGrid();

            if (IsPostBack) return;

            AtualizarGrid();
            AtualizarDDSKins();
            AtualizarDDUtilizador();
        }

        private void AtualizarDDUtilizador()
        {
            Models.utilizador u = new Models.utilizador();
            dd_utilizador.Items.Clear();
            DataTable dados = u.listaTodosUtilizadoresDisponiveis();
            foreach (DataRow linha in dados.Rows)
                dd_utilizador.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["nutilizador"].ToString())
             );
        }

        private void AtualizarDDSKins()
        {
            Models.skin lv = new Models.skin();
            dd_skin.Items.Clear();
            DataTable dados = lv.listarskinDisponiveis();
            foreach (DataRow linha in dados.Rows)
                dd_skin.Items.Add(
                    new ListItem(linha["nome"].ToString(), linha["nskin"].ToString())
             );
        }

        private void AtualizarGrid()
        {
            Models.compra emp = new Models.compra();

            DataTable dados;
            if (cb_skins_compradas.Checked)
                dados = emp.listaTodasComprasPorConcluirComNomes();
            else
                dados = emp.listaTodasComprasPorConcluirComNomes();

            gv_compra.Columns.Clear();
            gv_compra.DataSource = null;
            gv_compra.DataBind();
            if (dados == null || dados.Rows.Count == 0) return;
            //botoes de comando
            //receber 
            ButtonField bfReceber = new ButtonField();
            bfReceber.HeaderText = "Receber skin";
            bfReceber.Text = "Receber";
            bfReceber.ButtonType = ButtonType.Button;
            bfReceber.ControlStyle.CssClass = "btn btn-info";
            bfReceber.CommandName = "receber";
            gv_compra.Columns.Add(bfReceber);
            //enviar um email 
            ButtonField bfEmail = new ButtonField();
            bfReceber.HeaderText = "Enviar email";
            bfReceber.Text = "email";
            bfReceber.ButtonType = ButtonType.Button;
            bfReceber.ControlStyle.CssClass = "btn btn-danger";
            bfReceber.CommandName = "email";
            gv_compra.Columns.Add(bfEmail);

            gv_compra.DataSource = dados;
            gv_compra.AutoGenerateColumns = true;
            gv_compra.DataBind();
        }

        private void ConfigurarGrid()
        {
            //paginação
            gv_compra.AllowPaging = true;
            gv_compra.PageSize = 5;
            gv_compra.PageIndexChanging += Gv_Compra_PageIndexChanging;
            //botes de comando 
            gv_compra.RowCommand += Gv_Compra_RowCommand;
        }

        private void Gv_Compra_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_compra.PageIndex = e.NewPageIndex;
            gv_compra.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }

        private void Gv_Compra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //mudar de página
            if (e.CommandName == "Page") return;

            //linha
            int linha = int.Parse(e.CommandArgument.ToString());

            //id do emprestimo
            int idemprestimo = int.Parse(gv_compra.Rows[linha].Cells[2].Text);
            Models.compra emp = new Models.compra();
            if (e.CommandName == "receber")
            {
                AtualizarDDUtilizador();
                AtualizarDDSKins();
                AtualizarGrid();
            }
            if (e.CommandName == "email")
            {
                string email = ConfigurationManager.AppSettings["MeuEMail"];
                string password = ConfigurationManager.AppSettings["MinhaPassword"];
                DataTable dados = emp.devolveDadosCompra(idemprestimo);
                int nutilizador = int.Parse(dados.Rows[0]["nutilizador"].ToString());
                DataTable dadosUtilizador = new Models.utilizador().devolveDadosUtilizador(nutilizador);
                string emailUtilizador = dadosUtilizador.Rows[0]["email"].ToString();
                AtualizarDDUtilizador();
                AtualizarDDSKins();
                AtualizarGrid();
            }
        }
        protected void bt_registar_Click(object sender, EventArgs e)
        {
            try
            {
                Models.compra emp = new Models.compra();
                int nskin = int.Parse(dd_skin.SelectedValue);
                int nutilizador = int.Parse(dd_utilizador.SelectedValue);
                emp.adicionarCompra(nskin, nutilizador, DateTime.Now);

                lb_erro.Text = "A compra foi registado com sucesso.";
                lb_erro.CssClass = "";
            }
            catch (Exception erro)
            {
                lb_erro.Text = "Ocorreu o seguinte erro: " + erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
            AtualizarDDSKins();
            AtualizarDDUtilizador();
            AtualizarGrid();
        }

        protected void cb_skins_compradas_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarGrid();
        }
    }
}