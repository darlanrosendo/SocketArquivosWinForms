namespace TransferirArquivoCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FTCliente.LabelMensagem = labelStatus; // Atribui a referência do label ao campo estático da classe FTCliente
        }

        private void btnEnviarArquivo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEnderecoIP.Text) || string.IsNullOrEmpty(numericUpDownPorta.Value.ToString()) || linkLabelArquivo.Text == "Clique para selecionar o arquivo...")// Verifica se os campos de endereço IP, porta e arquivo estão preenchidos
            {
                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = "Por favor, preencha todos os campos antes de enviar o arquivo.";
                return; // Encerra a função se algum campo estiver vazio
            }
           
            string enderecoIP = textBoxEnderecoIP.Text; // Obtém o endereço IP do servidor a partir do TextBox
            
            int porta = (int)numericUpDownPorta.Value; // Obtém a porta do servidor a partir do NumericUpDown

            string arquivo = linkLabelArquivo.Text; // Obtém o caminho do arquivo a partir do LinkLabel

            FTCliente.EnderecoIP = enderecoIP; // Atribui o endereço IP ao campo estático da classe FTCliente

            FTCliente.PortaHost = porta; // Atribui a porta ao campo estático da classe FTCliente

            FTCliente.LabelMensagem = labelStatus; // Atribui a referência do label ao campo estático da classe FTCliente

            try
            {
                Task.Factory.StartNew(() => {
                
                    FTCliente.EnviarArquivo(arquivo); // Chama o método para enviar o arquivo em uma nova tarefa para evitar bloquear a interface do usuário
                });
            }
            catch (Exception ex)
            {
                labelStatus.ForeColor = Color.Red;
                labelStatus.Text = $"Erro : \n {ex.Message}";// Mostra menssagem de erro 
                
            }

        }

        private void linkLabelArquivo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog(); // Cria um diálogo para selecionar o arquivo a ser enviado

            dialog.Title = "Enviar Arquivo"; // Define o título do diálogo

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                linkLabelArquivo.Text = dialog.FileName; // Exibe o caminho do arquivo selecionado no linkLabel


            }
        }
    }
}
