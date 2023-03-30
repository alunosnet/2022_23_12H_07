using projetoSkins15;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoSkins15.compra
{
    public partial class f_compra : Form
    {
    public int ncompra_escolhido;
        BaseDados bd;
        public f_compra(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
            AtualizaCBJogadores();
            AtualizaCBSkin();
            AtualizarGrelha();
        }

        private void AtualizaCBJogadores()
        {
            cbJogadores.Items.Clear();
            DataTable dados = jogador.ListarTodos(bd);
            foreach (DataRow dr in dados.Rows)
            {
                jogador jogador = new jogador();
                jogador.njogador = int.Parse(dr["njogador"].ToString());
                jogador.nome = dr["nome"].ToString();
                cbJogadores.Items.Add(jogador);
            }
        }

        private void AtualizaCBSkin()
        {
            cbSkin.Items.Clear();
            DataTable dados = skin.ListarDisponiveis(bd);
            foreach (DataRow dr in dados.Rows)
            {
                skin skin = new skin();
                skin.NSkin = int.Parse(dr["nskin"].ToString());
                skin.Nome = dr["nome"].ToString();
                cbSkin.Items.Add(skin);
            }
        }

        private void f_compra_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validar o form
            if (cbSkin.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um jogagor");
                return;
            }
            if (cbSkin.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha uma skin");
                return;
            }
            jogador jogador = cbJogadores.SelectedItem as jogador;
            skin skin = cbSkin.SelectedItem as skin;
            compra compra = new compra(jogador.njogador, skin.NSkin, dtDataCompra.Value);
            compra.Adicionar(bd);

            AtualizaCBSkin();
            AtualizarGrelha();
        }

        private void cbJogadores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void AtualizarGrelha()
        {
            dataGridView1.DataSource = compra.ListarTodos(bd);
            string sql = "select nome,count(*) as [N skins] from jogadores inner join compra on jogadores.njogador = compra.njogador group by jogadores.njogador,nome";
            bd.ExecutaSQL(sql);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApagarCompra();
            AtualizarGrelha();
        }

        private void ApagarCompra()
        { 
            string sql = "DELETE FROM compra WHERE ncompra=" + ncompra_escolhido;
            bd.ExecutaSQL(sql);
        }
        private void AtualizaGrelha()
        {
            dataGridView1.DataSource = compra.ListarTodos(bd);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Criar um objeto skin
            compra compra = new compra();
            //Preencher as propriedades
            compra.ncompra = ncompra_escolhido;
            skin s = (skin)cbSkin.SelectedItem;
            compra.nskin = s.NSkin;
            compra.ncompra = ncompra_escolhido;
            jogador j = (jogador)cbJogadores.SelectedItem;
            compra.njogador = j.njogador;
            compra.data_compra = dtDataCompra.Value;
            //Guardar na BD
            compra.Atualizar(bd);
            AtualizaGrelha();
            //TODO: manter selecionada a linha do último skin editada
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int linha = dataGridView1.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            ncompra_escolhido = int.Parse(dataGridView1.Rows[linha].Cells[0].Value.ToString());
            
        }
    }
}
