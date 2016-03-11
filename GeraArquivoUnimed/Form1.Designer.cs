namespace GeraArquivoUnimed
{
    partial class Form1
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
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.btnDadosCordilheira = new System.Windows.Forms.Button();
            this.btnGerarArquivo = new System.Windows.Forms.Button();
            this.dtg = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).BeginInit();
            this.SuspendLayout();
            // 
            // sfd
            // 
            this.sfd.DefaultExt = "txt";
            this.sfd.Filter = "Arquivo txt|*.txt|Todos os arquivos|*.*";
            this.sfd.Title = "Nome do arquivo para gravar";
            // 
            // btnDadosCordilheira
            // 
            this.btnDadosCordilheira.Location = new System.Drawing.Point(12, 386);
            this.btnDadosCordilheira.Name = "btnDadosCordilheira";
            this.btnDadosCordilheira.Size = new System.Drawing.Size(235, 46);
            this.btnDadosCordilheira.TabIndex = 6;
            this.btnDadosCordilheira.Text = "Pegar dados do cordilheira";
            this.btnDadosCordilheira.UseVisualStyleBackColor = true;
            this.btnDadosCordilheira.Click += new System.EventHandler(this.btnDadosCordilheira_Click);
            // 
            // btnGerarArquivo
            // 
            this.btnGerarArquivo.Location = new System.Drawing.Point(755, 386);
            this.btnGerarArquivo.Name = "btnGerarArquivo";
            this.btnGerarArquivo.Size = new System.Drawing.Size(235, 46);
            this.btnGerarArquivo.TabIndex = 7;
            this.btnGerarArquivo.Text = "Gerar Arquivo";
            this.btnGerarArquivo.UseVisualStyleBackColor = true;
            this.btnGerarArquivo.Click += new System.EventHandler(this.btnGerarArquivo_Click);
            // 
            // dtg
            // 
            this.dtg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtg.Location = new System.Drawing.Point(13, 13);
            this.dtg.Name = "dtg";
            this.dtg.RowTemplate.Height = 24;
            this.dtg.Size = new System.Drawing.Size(977, 367);
            this.dtg.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 444);
            this.Controls.Add(this.dtg);
            this.Controls.Add(this.btnGerarArquivo);
            this.Controls.Add(this.btnDadosCordilheira);
            this.Name = "Form1";
            this.Text = "Gerador de Arquivos para Unimed";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnDadosCordilheira;
        private System.Windows.Forms.Button btnGerarArquivo;
        private System.Windows.Forms.DataGridView dtg;
    }
}

