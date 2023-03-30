using MOD17_SkinsSite_.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MOD17_SkinsSite_.Admin.Skin
{
    public partial class Skin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserLogin.ValidarSessao(Session, Request, "0") == false)
            {
                Response.Redirect("~/index.aspx");
            }
            ConfigurarGrid();

            if (!IsPostBack)
            {
                AtualizarGrid();
            }
        }
        /// <summary>
        /// Configuração da grelha das skins
        /// </summary>
        private void AtualizarGrid()
        {
            /* 
            Skin sk = new skin();
            gvLigvSkins.DataSource = lv.ListaTodasSkins();
            gvSkin.DataBind();
           */
            gvSkins.Columns.Clear();
            Models.skin lv = new Models.skin();
            DataTable dados = lv.ListaTodosSkin();

            DataColumn dcEditar = new DataColumn();
            dcEditar.ColumnName = "Editar";
            dcEditar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcEditar);

            DataColumn dcApagar = new DataColumn();
            dcApagar.ColumnName = "Apagar";
            dcApagar.DataType = Type.GetType("System.String");
            dados.Columns.Add(dcApagar);

            //colunas da gridview
            gvSkins.DataSource = dados;
            gvSkins.AutoGenerateColumns = false;

            //Editar
            HyperLinkField hlEditar = new HyperLinkField();
            hlEditar.HeaderText = "Editar";
            hlEditar.DataTextField = "Editar";
            hlEditar.Text = "Editar...";
            hlEditar.DataNavigateUrlFormatString = "EditarSkin.aspx?nskin={0}";
            hlEditar.DataNavigateUrlFields = new string[] { "nskin" };
            gvSkins.Columns.Add(hlEditar);
            //Apagar
            HyperLinkField hlApagar = new HyperLinkField();
            hlApagar.HeaderText = "Apagar";
            hlApagar.DataTextField = "Apagar";
            hlApagar.Text = "Apagar...";
            hlApagar.DataNavigateUrlFormatString = "ApagarSkin.aspx?nskin={0}";
            hlApagar.DataNavigateUrlFields = new string[] { "nskin" };
            gvSkins.Columns.Add(hlApagar);
            //nskin
            BoundField bfnskin = new BoundField();
            bfnskin.HeaderText = "Nº Skin";
            bfnskin.DataField = "nskin";
            gvSkins.Columns.Add(bfnskin);
            //nome
            BoundField bfnome = new BoundField();
            bfnome.HeaderText = "Nome";
            bfnome.DataField = "nome";
            gvSkins.Columns.Add(bfnome);
            //ano
            BoundField bfano = new BoundField();
            bfano.HeaderText = "Ano";
            bfano.DataField = "ano";
            gvSkins.Columns.Add(bfano);
            //data aquisição
            BoundField bfdata = new BoundField();
            bfdata.HeaderText = "Data aquisição";
            bfdata.DataField = "data_aquisicao";
            bfdata.DataFormatString = "{0:dd-MM-yyyy}";
            gvSkins.Columns.Add(bfdata);
            //Preço
            BoundField bfpreco = new BoundField();
            bfpreco.HeaderText = "Preço";
            bfpreco.DataField = "preco";
            bfpreco.DataFormatString = "{0:C}";
            gvSkins.Columns.Add(bfpreco);
            //Tipo
            //BoundField bftipo = new BoundField();
            //bftipo.HeaderText = "Tipo";
            //bftipo.DataField = "tipo";
            //gvSkins.Columns.Add(bftipo);
            //Capa
            ImageField ifcapa = new ImageField();
            ifcapa.HeaderText = "Capa";
            int aleatorio = new Random().Next(99999);
            ifcapa.DataImageUrlFormatString = "~/Public/Imagens/{0}.jpg?" + aleatorio;
            ifcapa.DataImageUrlField = "nskin";
            ifcapa.ControlStyle.Width = 200;
            gvSkins.Columns.Add(ifcapa);

            gvSkins.DataBind();
        }

        private void ConfigurarGrid()
        {
            gvSkins.AllowPaging = true;
            gvSkins.PageSize = 5;
            gvSkins.PageIndexChanging += GvSkins_PageIndexChanging;
        }

        private void GvSkins_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSkins.PageIndex = e.NewPageIndex;
            AtualizarGrid();
        }
        /// <summary>
        /// Adicionar uma Skin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void bt_Click(object sender, EventArgs e)
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
                skin.quantidade = 1;
                int nskin = skin.Adicionar();

                if (fuCapa.HasFile)
                {
                    string ficheiro = Server.MapPath(@"~\Public\Imagens\");
                    ficheiro = ficheiro + nskin + ".jpg";
                    fuCapa.SaveAs(ficheiro);
                }
            }
            catch (Exception ex)
            {
                lbErro.Text = "Ocorreu o seguinte erro: " + ex.Message;
                return;
            }
            //limpar form
            tbAno.Text = "";
            tbNome.Text = "";
            tbPreco.Text = "";
            dpTipo.SelectedIndex = 0;
            tbData.Text = DateTime.Now.ToShortDateString();
            //atualizar grid
            AtualizarGrid();
        }
        /// <summary>
        /// Atualiza a grid das Skins
        /// </summary>
        /// 

    }
}
