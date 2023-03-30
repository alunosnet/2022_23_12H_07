using MOD17_SkinsSite_.Classes;
using MOD17_SkinsSite_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_
{
    public partial class historico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            AtualizaGrid();
        }
        private void AtualizaGrid()
        {
            gvhistorico.Columns.Clear();
            gvhistorico.DataSource = null;
            gvhistorico.DataBind();

            int nutilizador = int.Parse(Session["id"].ToString());
            compra emp = new compra();
            gvhistorico.DataSource = emp.listaTodasCompraComNomes(nutilizador);
            gvhistorico.DataBind();
        }
    }
}