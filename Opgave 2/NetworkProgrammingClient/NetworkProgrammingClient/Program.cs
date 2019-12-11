using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace NetworkProgrammingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient();

            int port = 4269;
            IPAddress ip = IPAddress.Parse("172.16.241.96");
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            Console.Write("Forbinder.....");
            client.Connect(endPoint);
            Console.Clear();

            NetworkStream stream = client.GetStream();
            ReceiveMessage(stream);

            Console.Write("Write you message here: ");
            String text = Console.ReadLine();
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            stream.Write(buffer, 0, buffer.Length);

            client.Close();
        }
        public async static void ReceiveMessage(NetworkStream stream) {
            byte[] buffer = new byte[256];

            int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
            String receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.Write("\n" + receivedMessage);
        }
    }
}
