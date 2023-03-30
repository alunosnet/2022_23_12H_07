using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_.Admin.Skin
{
    public partial class ApagarSkin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //querystring nskin
                int nskin = int.Parse(Request["nskin"].ToString());

                Models.skin lv = new Models.skin();
                DataTable dados = lv.devolveDadosSkin(nskin);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //a nskin não existe na tabela das skins
                    throw new Exception("Skin não existe.");
                }
                //mostrar os dados da skin
                lbNskin.Text = dados.Rows[0]["nskin"].ToString();
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                imgCapa.ImageUrl = @"~\Public\Imagens\" + nskin + ".jpg";
                imgCapa.Width = 300;
            }
            catch
            {
                Response.Redirect("~/Admin/Skin/skin.aspx");
            }

        }

        protected void btVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/Skin/skin.aspx");
        }

        protected void btRemover_Click(object sender, EventArgs e)
        {
            try
            {
                int nskin = int.Parse(Request["nskin"].ToString());
                Models.skin lv = new Models.skin();
                lv.removerSkin(nskin);
                //apagar a capa
                string ficheiro = Server.MapPath(@"~\Public\Imagens\") + nskin + ".jpg";
                if (File.Exists(ficheiro))
                    File.Delete(ficheiro);
                //Response.Redirect("~/Admin/Skin/skin.aspx");
                lbErro.Text = "A skin foi removida com sucesso";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('skin.aspx')", true);
            }
            catch
            {
                Response.Redirect("~/Admin/Skin/skin.aspx");
            }
        }
    }
}