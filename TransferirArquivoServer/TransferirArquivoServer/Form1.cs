namespace TransferirArquivoServer
{
    public partial class Form1 : Form
    {
        Task tarefa;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabelPasta.Text = FTServer.PastaRecepcaoArquivos; // Exibir o caminho da pasta de recepção de arquivos no link label
           
            FTServer.ListaMensagem = listBoxListaLogs; // Atribuir a ListBox do formulário à propriedade estática do servidor para exibir mensagens
           

        }

        private void btnEstabelecerConexao_Click(object sender, EventArgs e)
        {
            int porta = (int)numericUpDownPorta.Value;// Obter a porta selecionada pelo usuário no NumericUpDown

            string enderecoIP = textBoxEnderecoIP.Text; // Obter o endereço IP digitado pelo usuário no TextBox

            try
            {
                FTServer.EnderecoIP = textBoxEnderecoIP.Text; // Atribuir o endereço IP digitado pelo usuário à propriedade estática do servidor

                FTServer.PortaHost = (int)numericUpDownPorta.Value;// Atribuir a porta selecionada pelo usuário à propriedade estática do servidor

                tarefa = Task.Factory.StartNew(() =>
                {
                    FTServer.IniciarServidor(); // Iniciar o servidor em uma tarefa separada para não bloquear a interface do usuário
                });
                
                
            }
            catch (Exception ex)
            {

                listBoxListaLogs.Invoke(new Action(()=>
                {
                    
                    listBoxListaLogs.Items.Add($"Erro ao iniciar o servidor: {ex.Message}"); // Exibir mensagem de erro na ListBox
                    
                    listBoxListaLogs.SetSelected(listBoxListaLogs.Items.Count - 1, true); // Selecionar a última mensagem adicionada para rolar a ListBox para baixo
                
                }));

                throw;
            }
        }

        private void btnPararServidor_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Restart();//Para matar o serviço que restar em segundo plano 
            }
            catch (Exception ex)
            {
                listBoxListaLogs.Invoke(new Action(() =>
                {

                    listBoxListaLogs.Items.Add($"Erro : {ex.Message}"); // Exibir mensagem de erro na ListBox

                    listBoxListaLogs.SetSelected(listBoxListaLogs.Items.Count - 1, true); // Selecionar a última mensagem adicionada para rolar a ListBox para baixo

                }));
            }
        }

        private void linkLabelPasta_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog(); // Criar um diálogo para selecionar pastas

            if (dialog.ShowDialog() != DialogResult.Cancel) 
            {
                FTServer.PastaRecepcaoArquivos = dialog.SelectedPath + @"\"; // Atribuir o caminho da pasta selecionada à propriedade estática do servidor
                linkLabelPasta.Text = FTServer.PastaRecepcaoArquivos; // Atualizar o texto do link label para exibir o novo caminho da pasta de recepção de arquivos
            } 
                return;
        }
    }
}
