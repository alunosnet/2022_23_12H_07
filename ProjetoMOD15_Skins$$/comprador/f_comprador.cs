using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projetoSkins15.comprador
{
    public partial class f_comprador : Form
    {
        BaseDados bd;
        int njogador_escolhido;

        public f_comprador(BaseDados bd )
        {
            InitializeComponent();
            this.bd = bd;
            AtualizarGrelha();
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button2.Visible = true;
        }
        /// <summary>
        /// Procurar fotografia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void f_comprador_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //validar o formulário
            
            //Criar um objeto (int njogador, string nome, byte[] fotografias)
            jogador comprador = new jogador(0, tbNome.Text, tbNick.Text);
            //Guardar na bd
            comprador.Guardar(bd);
            //limpar form
            LimparForm();
            //atualizar grid
            AtualizarGrelha();
        }

        private void LimparForm()
        {
            tbNome.Text = "";
            tbNick.Text = "";
        }

        private void AtualizarGrelha()
        {
            dgLeitores.DataSource = jogador.ListarTodos(bd);
        }

        private void dgLeitores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgLeitores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //selecionar e mostrar os dados do leitor
            int linha = dgLeitores.CurrentCell.RowIndex;
            if (linha == -1)
            {
                return;
            }
            int njogador = int.Parse(dgLeitores.Rows[linha].Cells[0].Value.ToString());
            jogador jogador = new jogador();
            jogador.ProcurarPorNrJogador(bd, njogador);
            tbNome.Text = jogador.nome;
            tbNick.Text = jogador.nick;
            //Guardar o njogador
            njogador_escolhido = njogador;
            //mostrar os botões para editar, apagar e cancelar
            button3.Visible = true;
            button4.Visible = true;
            button5.Visible = true;
            button2.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //confirmar que pretende apagar
            if (jogador.Jcomprador(bd, njogador_escolhido))
            {
                MessageBox.Show("Este jogador não pode ser eliminado porque já comprou skins");
                return;
            }
            
            jogador.Apagar(bd, njogador_escolhido);
            AtualizarGrelha();
            button5_Click(sender, e);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //validar o form

            jogador jogador = new jogador();
            jogador.njogador = njogador_escolhido;
            jogador.nome = tbNome.Text;
            jogador.nick = tbNick.Text;
            jogador.Atualizar(bd);
            button5_Click(sender, e);
            AtualizarGrelha();  
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button4.Visible = false;
            button5.Visible = false;
            button2.Visible = true;
            LimparForm();
        }
    }
}
