using MOD17_SkinsSite_.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_.User
{
    public partial class user : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "1") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            if (!IsPostBack)
            {
                divEditar.Visible = false;
                MostrarPerfil();
            }
        }

        void MostrarPerfil()
        {
            int id = int.Parse(Session["id"].ToString());
            Models.utilizador utilizador = new Models.utilizador();
            DataTable dados = utilizador.devolveDadosUtilizador(id);
            if (divPerfil.Visible == true)
            {
                lbNome.Text = dados.Rows[0]["nome"].ToString();
                lbNick.Text = dados.Rows[0]["nick"].ToString();
                lbEmail.Text = dados.Rows[0]["email"].ToString();

            }
            else
            {
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbEmail.Text = dados.Rows[0]["email"].ToString();
                tbNick.Text = dados.Rows[0]["Nick"].ToString();

            }
        }
        protected void btAtualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            string nome = tbNome.Text;
            string email = tbEmail.Text;
            string nick = tbNick.Text;

            Models.utilizador utilizador = new Models.utilizador();
            utilizador.nome = nome; 
            utilizador.nick = nick;
            utilizador.email = email;
            utilizador.nutilizador = id;
            utilizador.atualizarUtilizador();
            btCancelar_Click(sender, e);
        }

        protected void btCancelar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = true;
            divEditar.Visible = false;
            MostrarPerfil();
        }
        protected void btEditar_Click(object sender, EventArgs e)
        {
            divPerfil.Visible = false;
            divEditar.Visible = true;
            MostrarPerfil();
        }     
    }
}