using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_.Admin.Utilizador
{
    public partial class Utilizadores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: validar a sessão do utilizador
            AtualizaGrid();
        }

        private void AtualizaGrid()
        {
            Models.utilizador utilizador = new Models.utilizador();
            gvUtilizadores.DataSource = utilizador.ListaTodosUtilizadores();
            gvUtilizadores.DataBind();
        }

        protected void bt_guardar_Click(object sender, EventArgs e)
        {
            //validar o form
            string nome = tb_nome.Text;
            string email = tb_email.Text;
            string morada = tb_morada.Text;
            string password = tb_password.Text;
            Random rnd = new Random();

            Models.utilizador utilizador = new Models.utilizador();
            utilizador.nome = nome;
            utilizador.email = email;
            utilizador.password = password;
            utilizador.Adicionar();

            //limpar form
            tb_email.Text = "";
            tb_morada.Text = "";
            tb_nif.Text = "";
            tb_nome.Text = "";

            //atualizar grid
            AtualizaGrid();
        }
    }
}