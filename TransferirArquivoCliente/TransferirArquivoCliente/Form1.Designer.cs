namespace TransferirArquivoCliente
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
            label2 = new Label();
            textBoxEnderecoIP = new TextBox();
            numericUpDownPorta = new NumericUpDown();
            linkLabelArquivo = new LinkLabel();
            btnEnviarArquivo = new Button();
            labelStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownPorta).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1, 22);
            label2.Name = "label2";
            label2.Size = new Size(776, 84);
            label2.TabIndex = 1;
            label2.Text = "Cliente para Compartilhar Arquivo\r\n";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxEnderecoIP
            // 
            textBoxEnderecoIP.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxEnderecoIP.Location = new Point(12, 109);
            textBoxEnderecoIP.Name = "textBoxEnderecoIP";
            textBoxEnderecoIP.Size = new Size(378, 29);
            textBoxEnderecoIP.TabIndex = 2;
            textBoxEnderecoIP.Text = "127.0.0.1";
            // 
            // numericUpDownPorta
            // 
            numericUpDownPorta.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            numericUpDownPorta.Location = new Point(396, 110);
            numericUpDownPorta.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            numericUpDownPorta.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDownPorta.Name = "numericUpDownPorta";
            numericUpDownPorta.Size = new Size(120, 29);
            numericUpDownPorta.TabIndex = 3;
            numericUpDownPorta.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // linkLabelArquivo
            // 
            linkLabelArquivo.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkLabelArquivo.LinkBehavior = LinkBehavior.NeverUnderline;
            linkLabelArquivo.Location = new Point(12, 142);
            linkLabelArquivo.Name = "linkLabelArquivo";
            linkLabelArquivo.Size = new Size(762, 40);
            linkLabelArquivo.TabIndex = 6;
            linkLabelArquivo.TabStop = true;
            linkLabelArquivo.Text = "Clique para selecionar o arquivo...";
            linkLabelArquivo.TextAlign = ContentAlignment.MiddleLeft;
            linkLabelArquivo.LinkClicked += linkLabelArquivo_LinkClicked;
            // 
            // btnEnviarArquivo
            // 
            btnEnviarArquivo.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnviarArquivo.Location = new Point(12, 185);
            btnEnviarArquivo.Name = "btnEnviarArquivo";
            btnEnviarArquivo.Size = new Size(378, 57);
            btnEnviarArquivo.TabIndex = 7;
            btnEnviarArquivo.Text = "Enviar Arquivo";
            btnEnviarArquivo.UseVisualStyleBackColor = true;
            btnEnviarArquivo.Click += btnEnviarArquivo_Click;
            // 
            // labelStatus
            // 
            labelStatus.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStatus.ForeColor = Color.Green;
            labelStatus.Location = new Point(12, 261);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(762, 180);
            labelStatus.TabIndex = 8;
            labelStatus.Text = "Status";
            labelStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelStatus);
            Controls.Add(btnEnviarArquivo);
            Controls.Add(linkLabelArquivo);
            Controls.Add(numericUpDownPorta);
            Controls.Add(textBoxEnderecoIP);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numericUpDownPorta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox textBoxEnderecoIP;
        private NumericUpDown numericUpDownPorta;
        private LinkLabel linkLabelArquivo;
        private Button btnEnviarArquivo;
        private Label labelStatus;
    }
}
