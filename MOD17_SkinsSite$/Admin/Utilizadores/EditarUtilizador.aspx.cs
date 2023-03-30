using MOD17_SkinsSite_.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_.Admin.Utilizador
{
    public partial class EditarUtilizador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar sessão
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            //consultar a bd para recolher os dados do utilizador
            if (IsPostBack) return;
            try
            {
                int id = int.Parse(Request["id"].ToString());
                Models.utilizador utilizador = new Models.utilizador();
                DataTable dados = utilizador.devolveDadosUtilizador(id);
                if (dados == null || dados.Rows.Count != 1)
                {
                    throw new Exception("Utilizador não existe");
                }
                tbNome.Text = dados.Rows[0]["nome"].ToString();
            }
            catch
            {
                lbErro.Text = "O utilizador indicado não existe.";
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Admin/Utilizadores/Utilizadores.aspx')", true);
            }
        }

        protected void btEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string nome = tbNome.Text.Trim();
                if (string.IsNullOrEmpty(nome) || nome.Length < 3)
                {
                    throw new Exception("O nome não é válido.");
                }
                string perfil = tbPerfil.Text.Trim();
                if (string.IsNullOrEmpty(perfil) || perfil.Length < 3)
                {
                    throw new Exception("O perfil não é válido.");
                }
                string nick = tbNick.Text.Trim();
                if (string.IsNullOrEmpty(nick) || nick.Length < 3)
                {
                    throw new Exception("O nick não é válido.");
                }
                string email = tbEmail.Text.Trim();
                if (string.IsNullOrEmpty(email) || email.Length < 3)
                {
                    throw new Exception("O email não é válido.");
                }
                int id = int.Parse(Request["id"].ToString());
                Models.utilizador utilizador = new Models.utilizador();
                utilizador.nome = nome;
                utilizador.nick = nick;
                utilizador.email = email;
                utilizador.perfil = perfil;
                utilizador.nutilizador = id;

                utilizador.atualizarUtilizador();
            }
            catch (Exception error)
            {
                lbErro.Text = "Ocorreu um erro: " + error.Message;
                return;
            }
            lbErro.Text = "Utilizador atualizado com sucesso.";
            ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/Admin/Utilizadores/Utilizadores.aspx')", true);
        }
    }
}
