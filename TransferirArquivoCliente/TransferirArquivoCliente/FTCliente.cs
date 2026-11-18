using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TransferirArquivoCliente
{
    internal class FTCliente
    {

        static IPEndPoint ipEnd_cliente; //Endereço IP do cliente

        static Socket clientSocket_cliente; //Socket do cliente

        public static string EnderecoIP = "127.0.0.1"; //Endereço IP do servidor

        public static int PortaHost = 1000; //Porta do servidor

        public static Label LabelMensagem; //Label para exibir mensagens de status

        public static void EnviarArquivo(string arquivo) 
        {
            try
            {
                ipEnd_cliente = new IPEndPoint(IPAddress.Parse(EnderecoIP), PortaHost); //Cria o endpoint do cliente

                clientSocket_cliente = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);//Cria o socket do cliente

                string pasta = " ";

                pasta = arquivo.Substring(0,arquivo.LastIndexOf(@"\") + 1);//Obtém a pasta do arquivo

                arquivo = arquivo.Substring(arquivo.LastIndexOf(@"\") + 1);//Obtém o nome do arquivo


                byte[] nomeArquivoByte = Encoding.UTF8.GetBytes(arquivo); //Converte o nome do arquivo para bytes

                if (nomeArquivoByte.Length > 50000 * 1024)// Verifica se o nome do arquivo é maior que 255 bytes
                {
                    LabelMensagem.Invoke(new Action(()=>
                    {
                        LabelMensagem.ForeColor = Color.Red; 
                        LabelMensagem.Text = "O tamanho do arquivo é maior que 50MB, tente um arquivo menor.";
                    }));
                    return; //Encerra a função se o arquivo for muito grande
                }

                
                string caminhoCompleto = pasta + arquivo; //Caminho completo do arquivo

                long tamanhoArquivo = new FileInfo(caminhoCompleto).Length; // Tamanho real do arquivo em bytes

                if (tamanhoArquivo > 50000 * 1024) // Verifica se o ARQUIVO é maior que 50 MB
                {
                    LabelMensagem.Invoke(new Action(() =>
                    {
                        LabelMensagem.ForeColor = Color.Red;
                        LabelMensagem.Text = "O tamanho do arquivo é maior que 50MB, tente um arquivo menor.";
                    }));
                    return;
                }

                byte[] fileData = File.ReadAllBytes(caminhoCompleto); //Lê o arquivo e converte para bytes

                byte[] clienteData = new byte[4 + nomeArquivoByte.Length + fileData.Length]; //Cria um array de bytes para enviar o nome do arquivo e os dados do arquivo

                byte[] nomeArquivoLen = BitConverter.GetBytes(nomeArquivoByte.Length); //Obtém o tamanho do nome do arquivo em bytes

                nomeArquivoLen.CopyTo(clienteData, 0); //Copia o tamanho do nome do arquivo para o array de bytes

                nomeArquivoByte.CopyTo(clienteData, 4); //Copia o nome do arquivo para o array de bytes

                fileData.CopyTo(clienteData, 4 + nomeArquivoByte.Length); //Copia os dados do arquivo para o array de bytes

                clientSocket_cliente.Connect(ipEnd_cliente); //Conecta ao servidor

                clientSocket_cliente.Send(clienteData, 0, clienteData.Length, 0); //Envia os dados do arquivo para o servidor

                clientSocket_cliente.Shutdown(SocketShutdown.Send); // Avisa o servidor que terminou de enviar

                clientSocket_cliente.Close(); //Fecha o socket do cliente

                LabelMensagem.Invoke(new Action(() =>
                {
                    LabelMensagem.ForeColor = Color.Green;
                    LabelMensagem.Text = $"Arquivo {arquivo} transferido. "; //Exibe mensagem de sucesso
                }));
            }
            catch (Exception ex)
            {

                LabelMensagem.Invoke(new Action(() =>
                {
                    LabelMensagem.ForeColor = Color.Red;
                    LabelMensagem.Text = "Falha, O Servidor não esta atendendo... \n" + ex.Message;
                }));

            }
            finally 
            {
                // clientSocket_cliente.Disconnect(false); //Desconecta o socket do cliente

                clientSocket_cliente?.Close(); //Fecha o socket do cliente (o ?. evita erro se ele não foi criado)

            }
        }


    }
}
