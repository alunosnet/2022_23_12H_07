using projetoSkins15.comprador;
using projetoSkins15;
using projetoSkins15.compra;
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
    public partial class Form1 : Form
    {
        BaseDados bd = new BaseDados("M15_BDskins");
        public Form1()
        {
            InitializeComponent();
            TopJogadores();
        }
        public void TopJogadores()
        {
            string sql = @"SELECT Nome,count(*) as [Nr Compras] FROM Jogadores 
                            INNER JOIN compra ON 
                            jogadores.njogador=compra.njogador
                        GROUP By compra.ncomprador, Nome
                        ORDER BY count(*) DESC";
            dataGridView1.DataSource = bd.DevolveSQL(sql);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void skinsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            f_skins skins = new f_skins(bd);
            skins.Show();
        
        
        }

        private void compradorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            f_comprador comprador = new f_comprador(bd);
            comprador.Show();

        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f_compra compra = new f_compra(bd);
            compra.Show();
        
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Abre o form dos livros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    }
}