namespace projetoSkins15.compra
{
    partial class f_compra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtDataCompra = new System.Windows.Forms.DateTimePicker();
            this.cbSkin = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbJogadores = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtDataCompra
            // 
            this.dtDataCompra.Location = new System.Drawing.Point(133, 135);
            this.dtDataCompra.Name = "dtDataCompra";
            this.dtDataCompra.Size = new System.Drawing.Size(147, 20);
            this.dtDataCompra.TabIndex = 23;
            // 
            // cbSkin
            // 
            this.cbSkin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkin.FormattingEnabled = true;
            this.cbSkin.Location = new System.Drawing.Point(133, 88);
            this.cbSkin.Name = "cbSkin";
            this.cbSkin.Size = new System.Drawing.Size(148, 21);
            this.cbSkin.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Data de Compra ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Skin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Jogador ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(132, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 67);
            this.button2.TabIndex = 31;
            this.button2.Text = "Comprar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbJogadores
            // 
            this.cbJogadores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJogadores.FormattingEnabled = true;
            this.cbJogadores.Location = new System.Drawing.Point(132, 36);
            this.cbJogadores.Name = "cbJogadores";
            this.cbJogadores.Size = new System.Drawing.Size(148, 21);
            this.cbJogadores.TabIndex = 32;
            this.cbJogadores.SelectedIndexChanged += new System.EventHandler(this.cbJogadores_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(350, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(445, 240);
            this.dataGridView1.TabIndex = 33;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(678, 293);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 36);
            this.button4.TabIndex = 35;
            this.button4.Text = "Atualizar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(350, 293);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 36);
            this.button3.TabIndex = 36;
            this.button3.Text = "Apagar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // f_compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 391);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbJogadores);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dtDataCompra);
            this.Controls.Add(this.cbSkin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "f_compra";
            this.Text = "f_compra";
            this.Load += new System.EventHandler(this.f_compra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtDataCompra;
        private System.Windows.Forms.ComboBox cbSkin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbJogadores;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
    }
}