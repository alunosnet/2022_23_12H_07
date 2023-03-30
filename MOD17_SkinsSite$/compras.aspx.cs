using MOD17_SkinsSite_.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_
{
    public partial class compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            ConfigurarGrid();
            if (IsPostBack) return;
            AtualizarGrid();
        }

        private void AtualizarGrid()
        {
            gvSkins.Columns.Clear();
            gvSkins.DataSource = null;
            gvSkins.DataBind();

            Models.skin skin = new Models.skin();
            gvSkins.DataSource = skin.listarskinDisponiveis();

            ButtonField bt = new ButtonField();
            bt.HeaderText = "Comprar";
            bt.Text = "Comprar";
            bt.ButtonType = ButtonType.Button;
            bt.CommandName = "comprar";
            bt.ControlStyle.CssClass = "btn btn-danger";
            gvSkins.Columns.Add(bt);

            gvSkins.DataBind();
        }

        private void ConfigurarGrid()
        {
            gvSkins.RowCommand += GvSkins_RowCommand; 
        }

        private void GvSkins_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int linha = int.Parse(e.CommandArgument.ToString());
            int idskins = int.Parse(gvSkins.Rows[linha].Cells[1].Text);
            int nutilizador = int.Parse(Session["id"].ToString());
            if (e.CommandName == "comprar")
            {
                Models.compra emp = new Models.compra();
                emp.adicionarReserva(idskins, nutilizador, DateTime.Now.AddDays(7));
                Response.Redirect("/user/historico.aspx");

            }
        }
    }
}