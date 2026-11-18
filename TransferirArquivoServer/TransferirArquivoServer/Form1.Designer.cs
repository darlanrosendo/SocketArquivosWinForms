namespace TransferirArquivoServer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxEnderecoIP = new TextBox();
            numericUpDownPorta = new NumericUpDown();
            btnEstabelecerConexao = new Button();
            btnPararServidor = new Button();
            linkLabelPasta = new LinkLabel();
            listBoxListaLogs = new ListBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPorta).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(776, 84);
            label1.TabIndex = 0;
            label1.Text = "Servidor para Compartilhar Arquivo";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxEnderecoIP
            // 
            textBoxEnderecoIP.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxEnderecoIP.Location = new Point(12, 96);
            textBoxEnderecoIP.Name = "textBoxEnderecoIP";
            textBoxEnderecoIP.Size = new Size(378, 29);
            textBoxEnderecoIP.TabIndex = 1;
            textBoxEnderecoIP.Text = "127.0.0.1";
            // 
            // numericUpDownPorta
            // 
            numericUpDownPorta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numericUpDownPorta.Location = new Point(396, 96);
            numericUpDownPorta.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDownPorta.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownPorta.Name = "numericUpDownPorta";
            numericUpDownPorta.Size = new Size(120, 29);
            numericUpDownPorta.TabIndex = 2;
            numericUpDownPorta.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // btnEstabelecerConexao
            // 
            btnEstabelecerConexao.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEstabelecerConexao.Location = new Point(12, 131);
            btnEstabelecerConexao.Name = "btnEstabelecerConexao";
            btnEstabelecerConexao.Size = new Size(378, 61);
            btnEstabelecerConexao.TabIndex = 3;
            btnEstabelecerConexao.Text = "Estabelecer Conexão";
            btnEstabelecerConexao.UseVisualStyleBackColor = true;
            btnEstabelecerConexao.Click += btnEstabelecerConexao_Click;
            // 
            // btnPararServidor
            // 
            btnPararServidor.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPararServidor.Location = new Point(396, 131);
            btnPararServidor.Name = "btnPararServidor";
            btnPararServidor.Size = new Size(378, 61);
            btnPararServidor.TabIndex = 4;
            btnPararServidor.Text = "Parar Servidor";
            btnPararServidor.UseVisualStyleBackColor = true;
            btnPararServidor.Click += btnPararServidor_Click;
            // 
            // linkLabelPasta
            // 
            linkLabelPasta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabelPasta.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelPasta.Location = new Point(12, 206);
            linkLabelPasta.Name = "linkLabelPasta";
            linkLabelPasta.Size = new Size(762, 40);
            linkLabelPasta.TabIndex = 5;
            linkLabelPasta.TabStop = true;
            linkLabelPasta.Text = "Clique para selecionar a pasta...";
            linkLabelPasta.TextAlign = ContentAlignment.MiddleLeft;
            linkLabelPasta.LinkClicked += linkLabelPasta_LinkClicked;
            // 
            // listBoxListaLogs
            // 
            listBoxListaLogs.BackColor = SystemColors.Info;
            listBoxListaLogs.FormattingEnabled = true;
            listBoxListaLogs.Location = new Point(12, 269);
            listBoxListaLogs.Name = "listBoxListaLogs";
            listBoxListaLogs.Size = new Size(776, 169);
            listBoxListaLogs.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxListaLogs);
            Controls.Add(linkLabelPasta);
            Controls.Add(btnPararServidor);
            Controls.Add(btnEstabelecerConexao);
            Controls.Add(numericUpDownPorta);
            Controls.Add(textBoxEnderecoIP);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownPorta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxEnderecoIP;
        private NumericUpDown numericUpDownPorta;
        private Button btnEstabelecerConexao;
        private Button btnPararServidor;
        private LinkLabel linkLabelPasta;
        private ListBox listBoxListaLogs;
    }
}
