using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_
{
    public partial class detalhesSkin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Models.skin skin = new Models.skin();
                DataTable dados = skin.devolveDadosSkin(id);
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbAno.Text = dados.Rows[0]["ano"].ToString();
                lbPreco.Text = String.Format("{0:c}", Decimal.Parse(dados.Rows[0]["preco"].ToString()));
                string ficheiro = @"~\Public\Images\" + dados.Rows[0]["nskin"].ToString() + ".jpg";
                imgCapa.ImageUrl = ficheiro;
                imgCapa.Width = 200;
                //criar cookie
                HttpCookie cookie = new HttpCookie("ultimaskin", Server.UrlEncode(lbNome.Text));
                cookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(cookie);
            }
            catch
            {
                Response.Redirect("~/index.aspx");
            }
        }

        protected void btComprar_Click(object sender, EventArgs e)
        {
            try
            {
                int idskin = int.Parse(Request["id"].ToString());
                int nutilizador = int.Parse(Session["id"].ToString());
                Models.compra compra = new Models.compra();
                compra.adicionarCompra(idskin, nutilizador, DateTime.Now.AddDays(7));
                lbErro.Text = "Skin reservada com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);
            }
            catch
            {
                Response.Redirect("/index.aspx");
            }
        }
    }
}