using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AsyncBonusTasks
{
    class ServerAndClient
    {
        public int port;

        public ServerAndClient(int port)
        {
            this.port = port;
        }




        public async void server()
        {
            string text;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);
            TcpListener listener = new TcpListener(localEndpoint);

            listener.Start();

            Console.WriteLine("Awaiting clients...");
            Console.Write("\nWrite your welcome message here: ");
            text = Console.ReadLine();
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            TcpClient client = await listener.AcceptTcpClientAsync();


            NetworkStream stream = client.GetStream();
            stream.Write(buffer, 0, buffer.Length);
            RecieveMessage(stream, "User");
        }
        public void client()
        {
            string connectedTo = "Server";

            TcpClient client = new TcpClient();
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint endPoint = new IPEndPoint(ip, port);
            client.Connect(endPoint);

            NetworkStream stream1 = client.GetStream();
            RecieveMessage(stream1, connectedTo);
            string text = Console.ReadLine();

            Console.WriteLine("------------------------------------------------------\n<" + connectedTo + ">");
                        
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            stream1.Write(buffer, 0, buffer.Length);
        }
        public async void RecieveMessage(NetworkStream stream, string User)
        {
            byte[] buffer = new byte[256];

            int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
            string recievedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n" + User + " says: ");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(recievedMessage + "\n");

            if (User == "Server")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Your response: ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
