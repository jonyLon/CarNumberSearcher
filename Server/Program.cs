using Server.Database;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IPAddress iPAddress = IPAddress.Any;
            int port = 8000;

            TcpListener listener = new TcpListener(iPAddress, port);

            listener.Start();
            Console.WriteLine("Server listens on port " + port);


            
            using (var context = new RegionContext())
            {
                DbInitializer.Init(context);
            }


            while (true)
            {
                Console.WriteLine("Waiting for connection...");

                TcpClient client = await listener.AcceptTcpClientAsync();
                Console.WriteLine("Client connected!");

                _ = Task.Run(() => HendleClient(client));
            }



        }
        static async Task HendleClient(TcpClient cl)
        {
            NetworkStream ns = cl.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                while ((bytesRead = await ns.ReadAsync(buffer, 0, buffer.Length)) != 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {message}");





                    var search = new Searcher();
                    string res = search.ReturnRegion(message).ToString();

                    byte[] responseBytes = Encoding.UTF8.GetBytes(res);
                    await ns.WriteAsync(responseBytes, 0, responseBytes.Length);
                    Console.WriteLine($"Sent: {res}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            finally
            {
                cl.Close();
                Console.WriteLine("Client disconnected.");
            }
        }
    }
}
