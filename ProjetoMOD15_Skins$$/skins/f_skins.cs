using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoSkins15
{
    public partial class f_skins : Form
    {
        string nomeskin = "";
        BaseDados bd;
        int nskin_escolhido;
        int nrlinhas, nrpagina;
        public f_skins(BaseDados bd)
        {
            this.bd = bd;
            InitializeComponent();
            AtualizaGrelha();

        }

        /// <summary>
        /// Imprimir a grelha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AtualizaGrelha()
        {
            dgSkin.AllowUserToAddRows = false;
            dgSkin.AllowUserToDeleteRows = false;
            dgSkin.ReadOnly = true;
            dgSkin.DataSource = skin.ListarTodos(bd);
            

        }

        private void cbPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
           AtualizaGrelha();
        }

        private void f_skins_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.Landscape = true;
            printPreviewDialog1.ShowDialog();
        }
        private void imprimeGrelha(System.Drawing.Printing.PrintPageEventArgs e, DataGridView grelha)
        {
            Graphics impressora = e.Graphics;
            Font tipoLetra = new Font("Arial", 10);
            Font tipoLetraMaior = new Font("Arial", 12, FontStyle.Bold);
            Brush cor = Brushes.Black;
            float mesquerda, mdireita, msuperior, minferior, linha, largura;
            Pen caneta = new Pen(cor, 2);

            //margens
            mesquerda = printDocument1.DefaultPageSettings.Margins.Left;
            mdireita = printDocument1.DefaultPageSettings.Bounds.Right - mesquerda;
            msuperior = printDocument1.DefaultPageSettings.Margins.Top;
            minferior = printDocument1.DefaultPageSettings.Bounds.Height - msuperior;
            largura = mdireita - mesquerda;
            //calcular as colunas da grelha
            float[] colunas = new float[grelha.Columns.Count];
            float lgrelha = 0;
            for (int i = 0; i < grelha.Columns.Count; i++)
                lgrelha += grelha.Columns[i].Width;
            colunas[0] = mesquerda;
            float total = mesquerda, larguraColuna;
            for (int i = 0; i < grelha.Columns.Count - 1; i++)
            {
                larguraColuna = grelha.Columns[i].Width / lgrelha;
                colunas[i + 1] = larguraColuna * largura + total;
                total = colunas[i + 1];
            }
            //cabeçalhos
            for (int i = 0; i < grelha.Columns.Count; i++)
            {
                impressora.DrawString(grelha.Columns[i].HeaderText, tipoLetraMaior, cor, colunas[i], msuperior);
            }
            linha = msuperior + tipoLetraMaior.Height;
            //ciclo para percorrer a grelha
            int l;
            for (l = nrlinhas; l < grelha.Rows.Count; l++)
            {
                //desenhar linha
                impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
                //escrever uma linha
                for (int c = 0; c < grelha.Columns.Count; c++)
                {
                    impressora.DrawString(grelha.Rows[l].Cells[c].Value.ToString(),
                        tipoLetra, cor, colunas[c], linha);
                }
                //avançar para linha seguinte
                linha = linha + tipoLetra.Height;
                //verificar se o papel acabou
                if (linha + tipoLetra.Height > minferior)
                    break;
            }
            //tem mais páginas?
            if (l < grelha.Rows.Count)
            {
                nrlinhas = l + 1;
                e.HasMorePages = true;
            }
            //rodapé
            impressora.DrawString("12ºH - Página " + nrpagina.ToString(), tipoLetra, cor, mesquerda, minferior);
            //nr página
            nrpagina++;
            //linhas
            //linha superior
            impressora.DrawLine(caneta, mesquerda, msuperior, mdireita, msuperior);
            //linha inferior
            impressora.DrawLine(caneta, mesquerda, linha, mdireita, linha);
            //colunas
            for (int c = 0; c < colunas.Length; c++)
            {
                impressora.DrawLine(caneta, colunas[c], msuperior, colunas[c], linha);
            }
            //linha lado direito
            impressora.DrawLine(caneta, mdireita, msuperior, mdireita, linha);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimparForm();
            button3.Visible = false;
            button4.Visible = false;
            button2.Visible = true;
            button5.Visible = false;
        }

        private void LimparForm()
        {
            tbNome.Text = "";
            tbPreco.Text = "";
            nomeskin = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }
            decimal preco;
            if (decimal.TryParse(tbPreco.Text, out preco) == false)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero.");
                tbPreco.Focus();
                return;
            }
            if (preco < 0 || preco >= 100)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero.");
                tbPreco.Focus();
                return;
            }
            /*A capa é opcional*/
            if (string.IsNullOrEmpty(nomeskin) == false && nomeskin.Contains("projetoSkins15") == false)
            {
                if (System.IO.File.Exists(nomeskin) == false)
                {
                    MessageBox.Show("O ficheiro indicado para a capa não existe.");
                    return;
                }
                //apagar a capa antiga
                skin antigo = new skin();
                antigo.Procurar(nskin_escolhido, bd);
                System.IO.File.Delete(antigo.Capa);
                //guardar imagem
                Guid guid = Guid.NewGuid();
                string caminhoBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                caminhoBD += "\\projetoSkins15\\";
                caminhoBD += guid.ToString();
                //copiar o ficheiro
                System.IO.File.Copy(nomeskin, caminhoBD);
                nomeskin = caminhoBD;
            }
            //Criar um objeto skin
            skin skin = new skin();
            //Preencher as propriedades
            skin.Nome = nome;
            skin.Capa = nomeskin;
            skin.Preco = preco;
            skin.NSkin = nskin_escolhido;
            //Guardar na BD
            skin.Atualizar(bd);
            //Limpar o form
            LimparForm();
            AtualizaGrelha();
            //TODO: manter selecionada a linha do último skin editada
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApagarRegisto();
        }

        void ApagarRegisto()
        {
            if (nskin_escolhido < 1)
            {
                MessageBox.Show("Tem de selecionar um livro primeiro. Clique com o botão esquerdo.");
                return;
            }
            if (compra.compra.skinVendida(bd, nskin_escolhido))
            {
                MessageBox.Show("Esta Skin nao pode ser eliminada porque já foi vendida");
                return;
            }
            //confirmar
            if (MessageBox.Show(
                "Tem a certeza que pretende eliminar a skin selecionado?",
                "Confirmar",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //apagar da bd
                skin.ApagarSkin(nskin_escolhido, bd);
                //apagar o ficheiro da capa
                if (System.IO.File.Exists(nomeskin))
                {
                    GC.Collect();
                    try
                    {
                        System.IO.File.Delete(nomeskin);
                    }
                    catch { }
                }
            }
            //limpar form
            LimparForm();
            //trocar botões
            button2.Visible = true;
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            //Atualizar a grelha
            AtualizaGrelha();

        }

        private void dgSkin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //pesquisar na bd a skin com nome like textBox1.text
            //atualizar grelha com resultado da pesquisa
            dgSkin.DataSource = skin.PesquisaPorNome(bd, textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Validar os dados
            string nome = tbNome.Text;
            if (nome == "" || nome.Length < 3)
            {
                MessageBox.Show("Nome tem de ter pelo menos 3 letras.");
                tbNome.Focus();
                return;
            }
            decimal preco;
            if (decimal.TryParse(tbPreco.Text, out preco) == false)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero.");
                tbPreco.Focus();
                return;
            }
            if (preco < 0 || preco >= 100)
            {
                MessageBox.Show("O preço tem de ser superior ou igual a zero.");
                tbPreco.Focus();
                return;
            }
            /*A capa é opcional*/
            if (string.IsNullOrEmpty(nomeskin) == false)
            {
                if (System.IO.File.Exists(nomeskin) == false)
                {
                    MessageBox.Show("O ficheiro indicado para a capa não existe.");
                    return;
                }
                //guardar imagem
                Guid guid = Guid.NewGuid();
                string caminhoBD = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                caminhoBD += "\\projetoSkins15\\";
                caminhoBD += guid.ToString();
                //copiar o ficheiro
                System.IO.File.Copy(nomeskin, caminhoBD);
                nomeskin = caminhoBD;
            }
            //Criar um objeto skin
            skin skin = new skin();
            //Preencher as propriedades
            skin.Nome = nome;
            skin.Preco = preco;
            //Guardar na BD
            skin.Guardar(bd);
            //Limpar o form
            LimparForm();
            AtualizaGrelha();
        }

        private void dgSkin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button2.Visible = false;

            int linha = dgSkin.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int nskin = int.Parse(dgSkin.Rows[linha].Cells[0].Value.ToString());
            skin escolhido = new skin();
            escolhido.Procurar(nskin, bd);
            tbNome.Text = escolhido.Nome;
            tbPreco.Text = escolhido.Preco.ToString();
            if (System.IO.File.Exists(escolhido.Capa))
            {
                //pbCapa.Image = Image.FromFile(escolhido.Capa);
                //Solução para o bug que não permitia apagar a capa quando se eliminava um livro
                Image img;
                using (var bitmap = new Bitmap(escolhido.Capa))
                {
                    img = new Bitmap(bitmap);
                }
                nomeskin = escolhido.Capa;
            }
            else
            {
                nomeskin = String.Empty;
            }
            nskin_escolhido = escolhido.NSkin;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tbNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void pbCapa_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.InitialDirectory = "c:\\";
            ficheiro.Filter = "Imagens |*.jpg;*.png | Todos os ficheiros |*.*";
            ficheiro.Multiselect = false;
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    nomeskin = temp;
                }
            }
        }
        /// <summary>
        /// Guardar na bd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    }
}

