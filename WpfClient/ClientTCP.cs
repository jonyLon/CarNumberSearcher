using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfClient
{
    public class ClientTCP
    {
        private TcpClient tcpClient;
        public ClientTCP(string server, int port) {
            this.tcpClient = new TcpClient(server, port);
        }
        public string Stream(string text)
        {
            NetworkStream stream = tcpClient.GetStream();
            
            MessageBox.Show("Connected to server...");

            while (true)
            {
                string message = text;

                if (message == "exit")
                {
                    stream.Close();
                    return "exit";
                }

                byte[] data = Encoding.UTF8.GetBytes(message);

                stream.Write(data, 0, data.Length);


                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string res = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                return res;
            }
        }

    }
}
