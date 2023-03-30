using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_.Admin.Skin
{
    public partial class EditarSkin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            try
            {
                //querystring nskin
                int nskin = int.Parse(Request["nskin"].ToString());

                Models.skin lv = new Models.skin();
                DataTable dados = lv.devolveDadosSkin(nskin);
                if (dados == null || dados.Rows.Count == 0)
                {
                    //a nskin não existe na tabela das Skins
                    throw new Exception("Skin não existe.");
                }
                //mostrar os dados skin
                tbNome.Text = dados.Rows[0]["nome"].ToString();
                tbAno.Text = dados.Rows[0]["ano"].ToString();
                tbPreco.Text = dados.Rows[0]["preco"].ToString();
                tbData.Text = DateTime.Parse(dados.Rows[0]["data_aquisicao"].ToString()).ToString("yyyy-MM-dd");
                Random rnd = new Random();
                imgCapa.ImageUrl = @"~\Public\Imagens\" + nskin + ".jpg?" + rnd.Next(9999);
                imgCapa.Width = 300;
            }
            catch
            {
                Response.Redirect("~/Admin/Skin/skin.aspx");
            }
        }
            protected void btAtualizar_Click(object sender, EventArgs e)
            {
                try
                {
                    string nome = tbNome.Text;
                    if (nome.Trim().Length < 3)
                    {
                        throw new Exception("O nome é muito pequeno.");
                    }
                    int ano = int.Parse(tbAno.Text);
                    if (ano > DateTime.Now.Year || ano < 0)
                    {
                        throw new Exception("O ano não é válido");
                    }
                    DateTime data = DateTime.Parse(tbData.Text);
                    if (data > DateTime.Now)
                    {
                        throw new Exception("A data tem de ser inferior à data atual");
                    }
                    Decimal preco = Decimal.Parse(tbPreco.Text);
                    if (preco < 0 || preco > 100)
                    {
                        throw new Exception("O preço deve estar entre 0 e 100");
                    }
                    string tipo = dpTipo.SelectedValue;
                    if (tipo == "")
                    {
                        throw new Exception("O tipo não é válido");
                    }
                    Models.skin skin = new Models.skin();
                    skin.nome = nome;
                    skin.preco = preco;
                    skin.ano = ano;
                    skin.data_aquisicao = data;
                    skin.nskin = int.Parse(Request["nskin"].ToString());
                    skin.atualizaSkin();

                    if (fuCapa.HasFile)
                    {
                        string ficheiro = Server.MapPath(@"~\Public\Imagens\");
                        ficheiro = ficheiro + skin.nskin + ".jpg";
                        fuCapa.SaveAs(ficheiro);
                    }

                    lbErro.Text = "A Skin foi atualizado com sucesso";
                    ScriptManager.RegisterStartupScript(this, typeof(Page),
                        "Redirecionar", "returnMain('skin.aspx')", true);
                }
                catch (Exception ex)
                {
                    lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                    return;
                }

            }
    }
}
