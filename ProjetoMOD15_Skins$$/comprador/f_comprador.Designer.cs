namespace projetoSkins15.comprador
{
    partial class f_comprador
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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dgLeitores = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.tbNome = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbNick = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgLeitores)).BeginInit();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(366, 302);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(296, 36);
            this.button5.TabIndex = 17;
            this.button5.Text = "Cancelar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(545, 260);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(117, 36);
            this.button4.TabIndex = 18;
            this.button4.Text = "Atualizar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(366, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 36);
            this.button3.TabIndex = 19;
            this.button3.Text = "Apagar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dgLeitores
            // 
            this.dgLeitores.AllowUserToAddRows = false;
            this.dgLeitores.AllowUserToDeleteRows = false;
            this.dgLeitores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLeitores.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgLeitores.Location = new System.Drawing.Point(366, 29);
            this.dgLeitores.Name = "dgLeitores";
            this.dgLeitores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgLeitores.ShowEditingIcon = false;
            this.dgLeitores.Size = new System.Drawing.Size(296, 225);
            this.dgLeitores.TabIndex = 16;
            this.dgLeitores.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLeitores_CellClick);
            this.dgLeitores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLeitores_CellContentClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(147, 187);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(163, 67);
            this.button2.TabIndex = 15;
            this.button2.Text = "Adicionar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbNome
            // 
            this.tbNome.Location = new System.Drawing.Point(134, 29);
            this.tbNome.Name = "tbNome";
            this.tbNome.Size = new System.Drawing.Size(203, 20);
            this.tbNome.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Nick";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Nome";
            // 
            // tbNick
            // 
            this.tbNick.Location = new System.Drawing.Point(134, 74);
            this.tbNick.Name = "tbNick";
            this.tbNick.Size = new System.Drawing.Size(203, 20);
            this.tbNick.TabIndex = 11;
            // 
            // f_comprador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 364);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dgLeitores);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbNick);
            this.Controls.Add(this.tbNome);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "f_comprador";
            this.Text = "f_comprador";
            this.Load += new System.EventHandler(this.f_comprador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgLeitores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dgLeitores;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbNick;
    }
}