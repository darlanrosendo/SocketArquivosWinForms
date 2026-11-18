using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TransferirArquivoServer
{
    internal class FTServer
    {
        // FTServer = File Transfer Server (Servidor de Transferência de Arquivo)

        static IPEndPoint ipEnd_servidor; // Endereço IP e porta do servidor

        static Socket sockt_Servidor;// Socket do servidor para aceitar conexões

        public static string EnderecoIP = "127.0.0.1"; // Endereço IP do servidor (localhost)

        public static int PortaHost = 1000; // Porta do servidor

        public static string PastaRecepcaoArquivos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\"; // Pasta onde os arquivos recebidos serão salvos (pasta "Meus Documentos")

        public static ListBox ListaMensagem; // Lista para exibir mensagens no formulário

        public static void IniciarServidor() 
        {
            try
            {
                ipEnd_servidor = new IPEndPoint(IPAddress.Parse(EnderecoIP), PortaHost); // Criar o endpoint do servidor com o endereço IP e porta especificados

                sockt_Servidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP); // Criar um socket TCP para o servidor

                sockt_Servidor.Bind(ipEnd_servidor); // Associar o socket ao endpoint do servidor
            }
            catch (Exception ex)
            {

                ListaMensagem.Invoke(new Action(() => {
                    ListaMensagem.Items.Add("Erro ao iniciar o servidor:  \n" + ex.Message); // Adicionar a mensagem de erro à lista de mensagens no formulário
                    ListaMensagem.SetSelected(ListaMensagem.Items.Count - 1, true); // Selecionar a última mensagem adicionada
                }));
                return;// Encerrar a execução do método em caso de erro
            }


            try
            {
                sockt_Servidor.Listen(100); // Colocar o socket em modo de escuta, permitindo até 100 conexões pendentes
                ListaMensagem.Invoke(new Action(() => {
                    ListaMensagem.Items.Add("Servidor em atendimento e aguardando para receber arquivo... " );// Adicionar a mensagem de que o servidor está em atendimento à lista de mensagens no formulário
                    ListaMensagem.SetSelected(ListaMensagem.Items.Count - 1, true); // Selecionar a última mensagem adicionada
                }));

                Socket sockt_Cliente = sockt_Servidor.Accept(); // Aceitar uma conexão de um cliente

                sockt_Cliente.ReceiveBufferSize = 16384; // Definir o tamanho do buffer de recepção para 16 KB

                byte[] dadosCliente = new byte[1024 * 50000]; // Criar um buffer para armazenar os dados recebidos do cliente (50 MB)

                int bytesRecebidos = sockt_Cliente.Receive(dadosCliente, dadosCliente.Length, 0); // Receber os dados do cliente e armazenar o número de bytes recebidos
           
                int tamanhoNomeArquivo = BitConverter.ToInt32(dadosCliente, 0); // Extrair o tamanho do nome do arquivo a partir dos primeiros 4 bytes dos dados recebidos
               
                string nomeArquivo = Encoding.UTF8.GetString(dadosCliente, 4, tamanhoNomeArquivo); // Extrair o nome do arquivo a partir dos dados recebidos, usando o tamanho do nome do arquivo para determinar a posição correta
           
                
                BinaryWriter bWriter = new BinaryWriter(File.Open(PastaRecepcaoArquivos + nomeArquivo, FileMode.Create)); // Criar um BinaryWriter para escrever os dados recebidos em um arquivo na pasta de recepção, usando o nome do arquivo recebido)
             
                bWriter.Write(dadosCliente, 4 + tamanhoNomeArquivo, bytesRecebidos - 4 - tamanhoNomeArquivo); // Escrever os dados do arquivo no arquivo de destino, ignorando os bytes usados para o tamanho do nome do arquivo e o nome do arquivo em si

                long totalBytes = bytesRecebidos - 4 - tamanhoNomeArquivo; // contador com os bytes do arquivo que já chegaram 

                while (bytesRecebidos > 0) // Continuar recebendo dados do cliente enquanto houver dados a serem recebidos
                {
                    bytesRecebidos = sockt_Cliente.Receive(dadosCliente, dadosCliente.Length, 0); // Continuar recebendo dados do cliente até que não haja mais dados a serem recebidos

                    if (bytesRecebidos > 0) // Verificar se não há mais dados a serem recebidos (bytesRecebidos igual a 0)
                    {
                        bWriter.Write(dadosCliente, 0, bytesRecebidos);// Escreve o pedaço recebido 
                        totalBytes += bytesRecebidos; // somar cada pedaco no contador 
                    }

                }

                    bWriter.Close(); // Fechar o BinaryWriter quando não houver mais dados a serem recebidos

                    ListaMensagem.Invoke(new Action(() => {
                        ListaMensagem.Items.Add("Arquivo Recebido e Arquivado [" + nomeArquivo + "] (" + totalBytes + "bytes recebido)");// Adicionar a mensagem de que o arquivo foi recebido e arquivado à lista de mensagens no formulário
                        ListaMensagem.SetSelected(ListaMensagem.Items.Count - 1, true); // Selecionar a última mensagem adicionada
                    }));

                    sockt_Cliente.Close(); // Fechar a conexão com o cliente após o arquivo ter sido completamente recebido e arquivado
                
            }
            catch (SocketException ex)
            {
                ListaMensagem.Invoke(new Action(() => {
                    ListaMensagem.Items.Add("Erro ao Receber Arquivo: \n" + ex.Message); // Adicionar a mensagem de erro ao receber o arquivo à lista de mensagens no formulário
                    ListaMensagem.SetSelected(ListaMensagem.Items.Count - 1, true); // Selecionar a última mensagem adicionada
                }));

            }
            finally 
            {
                sockt_Servidor.Close(); // Fechar o socket do servidor quando a operação de recebimento de arquivos for concluída ou em caso de erro
                sockt_Servidor.Dispose(); // Liberar os recursos associados ao socket do servidor
                IniciarServidor(); // Reiniciar o servidor para continuar aguardando por novas conexões e arquivos a serem recebidos
            }
        }

    }
}
