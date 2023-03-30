using MOD17_SkinsSite_.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_
{
    public partial class Registo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_guardar_Click1(object sender, EventArgs e)
        {
            try
            {
                //validar os dados do form
                //validar o form
                string nome = tb_nome.Text.Trim();
                if (nome.Length < 3)
                {
                    throw new Exception("O nome tem de ter pelo menos 3 letras");
                }
                string email = tb_email.Text.Trim();
                if (email == String.Empty || email.Contains("@") == false ||
                   email.Contains('.') == false)
                {
                    throw new Exception("O email indicado não é válido");
                }
                string morada = tb_morada.Text.Trim();
                if (morada.Length < 3)
                {
                    throw new Exception("A morada tem de ter pelo menos 3 letras");
                }
                string password = tb_password.Text.Trim();
                if (password.Length < 5)
                {
                    throw new Exception("A password tem de ter pelo menos 5 letras");
                }

                //validar recaptcha
                /*var respostaRecaptcha = Request.Form["g-Recaptcha-Response"];
                var valido = ReCaptcha.Validate(respostaRecaptcha);
                if (valido == false)
                {
                    throw new Exception("Tem de provar que não é um robot");
                }*/
                //inserir o utilizador na bd
                Models.utilizador utilizador = new Models.utilizador();
                utilizador.nome = nome;
                utilizador.email = email;
                utilizador.password = password;
                utilizador.nick = tb_nick.Text;
                utilizador.perfil = "1";
                utilizador.Adicionar();
                lb_erro.Text = "Registado com sucesso";
                //redicionar para index
                ScriptManager.RegisterStartupScript(this, typeof(Page),
                    "Redirecionar", "returnMain('/index.aspx')", true);
            }
            catch (Exception erro)
            {
                lb_erro.Text = erro.Message;
                lb_erro.CssClass = "alert alert-danger";
            }
        }
    }
}