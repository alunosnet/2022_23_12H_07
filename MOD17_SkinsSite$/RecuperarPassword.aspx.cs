using MOD17_SkinsSite_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_
{
    public partial class RecuperarPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_recuperar_Click(object sender, EventArgs e)
        {
            try
            {
                string password = tb_password.Text.Trim();
                if (password.Length == 0)
                    throw new Exception("Tem de indicar uma password");
                string guid = Server.UrlDecode(Request["id"].ToString());
                utilizador Utilizador = new utilizador();
                Utilizador.atualizarPassword(guid, password);
                lb_erro.Text = "Password atualizada com sucesso";
                //redicionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redireciona ", "returnMain('/index.aspx')", true);
            }
            catch (Exception erro)
            {
                lb_erro.Text = erro.Message;
            }
        }
    }
}