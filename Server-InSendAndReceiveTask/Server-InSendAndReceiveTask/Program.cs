using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;

namespace Server_InSendAndReceiveTask
{
    class Program
    {

        static void Main(string[] args)
        {
            bool ISTrue = true;
            while (ISTrue)
            {
                // ===================== Receiving message ==========================0
                int port = 9420;

                IPAddress ip = IPAddress.Any;
                IPEndPoint localEndpoint = new IPEndPoint(ip, port);

                TcpListener listener = new TcpListener(localEndpoint);
                listener.Start();

                Console.WriteLine("Awaiting Clients");
                TcpClient client = listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[256];
                int numberOfBytesRead = stream.Read(buffer, 0, 256);

                string message = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                Console.WriteLine(message);
                // ===================== Sending message ============================0
                Thread.Sleep(2000);
                Console.ReadKey();

                TcpClient client2 = new TcpClient();

                int serverPort = 9420;
                IPAddress serverIP = IPAddress.Parse("172.16.142.201");
                IPEndPoint serverEndPoint = new IPEndPoint(serverIP, serverPort);

                client2.Connect(serverEndPoint);

                NetworkStream stream2 = client.GetStream();

                string text = Console.ReadLine();
                byte[] clientBuffer = Encoding.UTF8.GetBytes(text);

                stream2.Write(clientBuffer, 0, clientBuffer.Length);

                client.Close();


            }
        }
    }
}
