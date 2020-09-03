namespace apLabirinto
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lbCaminhos = new System.Windows.Forms.Label();
            this.dgvLabirinto = new System.Windows.Forms.DataGridView();
            this.dgvCaminhos = new System.Windows.Forms.DataGridView();
            this.btnArquivo = new System.Windows.Forms.Button();
            this.btnEncontrar = new System.Windows.Forms.Button();
            this.dlgAbrir = new System.Windows.Forms.OpenFileDialog();
            this.clnSolucao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabirinto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Labirinto";
            // 
            // lbCaminhos
            // 
            this.lbCaminhos.AutoSize = true;
            this.lbCaminhos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCaminhos.Location = new System.Drawing.Point(493, 54);
            this.lbCaminhos.Name = "lbCaminhos";
            this.lbCaminhos.Size = new System.Drawing.Size(163, 18);
            this.lbCaminhos.TabIndex = 1;
            this.lbCaminhos.Text = "Caminhos encontrados";
            // 
            // dgvLabirinto
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLabirinto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLabirinto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLabirinto.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLabirinto.Location = new System.Drawing.Point(28, 87);
            this.dgvLabirinto.Name = "dgvLabirinto";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLabirinto.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLabirinto.Size = new System.Drawing.Size(445, 298);
            this.dgvLabirinto.TabIndex = 2;
            // 
            // dgvCaminhos
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaminhos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCaminhos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCaminhos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clnSolucao});
            this.dgvCaminhos.Location = new System.Drawing.Point(496, 87);
            this.dgvCaminhos.Name = "dgvCaminhos";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCaminhos.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCaminhos.RowHeadersWidth = 100;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.dgvCaminhos.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCaminhos.Size = new System.Drawing.Size(473, 298);
            this.dgvCaminhos.TabIndex = 3;
            this.dgvCaminhos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCaminhos_CellClick);
            // 
            // btnArquivo
            // 
            this.btnArquivo.Location = new System.Drawing.Point(769, 18);
            this.btnArquivo.Name = "btnArquivo";
            this.btnArquivo.Size = new System.Drawing.Size(97, 56);
            this.btnArquivo.TabIndex = 4;
            this.btnArquivo.Text = "Abrir arquivo";
            this.btnArquivo.UseVisualStyleBackColor = true;
            this.btnArquivo.Click += new System.EventHandler(this.btnArquivo_Click);
            // 
            // btnEncontrar
            // 
            this.btnEncontrar.Location = new System.Drawing.Point(872, 18);
            this.btnEncontrar.Name = "btnEncontrar";
            this.btnEncontrar.Size = new System.Drawing.Size(97, 56);
            this.btnEncontrar.TabIndex = 5;
            this.btnEncontrar.Text = " Encontrar caminhos";
            this.btnEncontrar.UseVisualStyleBackColor = true;
            this.btnEncontrar.Click += new System.EventHandler(this.btnEncontrar_Click);
            // 
            // clnSolucao
            // 
            this.clnSolucao.HeaderText = "Caminho";
            this.clnSolucao.Name = "clnSolucao";
            this.clnSolucao.Width = 370;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 421);
            this.Controls.Add(this.btnEncontrar);
            this.Controls.Add(this.btnArquivo);
            this.Controls.Add(this.dgvCaminhos);
            this.Controls.Add(this.dgvLabirinto);
            this.Controls.Add(this.lbCaminhos);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Caminhos em Labirinto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLabirinto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCaminhos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbCaminhos;
        private System.Windows.Forms.DataGridView dgvLabirinto;
        private System.Windows.Forms.DataGridView dgvCaminhos;
        private System.Windows.Forms.Button btnArquivo;
        private System.Windows.Forms.Button btnEncontrar;
        private System.Windows.Forms.OpenFileDialog dlgAbrir;
        private System.Windows.Forms.DataGridViewTextBoxColumn clnSolucao;
    }
}

