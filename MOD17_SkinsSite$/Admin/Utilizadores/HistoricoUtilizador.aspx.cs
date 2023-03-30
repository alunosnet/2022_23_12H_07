using MOD17_SkinsSite_.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_.Admin.Utilizador
{
    public partial class BlloquearUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
                Response.Redirect("~/index.aspx");
            try
            {
                atualizarGrid();
            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe";
                lbErro.CssClass = "alert alert-danger";
                Redirecionar();
            }
        }
        private void atualizarGrid()
        {
            gvHistorico.Columns.Clear();
            gvHistorico.DataSource = null;
            gvHistorico.DataBind();

            int id = int.Parse(Request["id"].ToString());
            Models.compra compra = new Models.compra();
            gvHistorico.DataSource = compra.listaTodasCompraComNomes(id);
            gvHistorico.DataBind();
        }

        private void Redirecionar()
        {
            //redirecionar
            ScriptManager.RegisterStartupScript(this, typeof(Page), "Redirecionar",
                "returnMain('/Admin/Utilizadores/Utilizadores.aspx');", true);
        }
    }
}
   
