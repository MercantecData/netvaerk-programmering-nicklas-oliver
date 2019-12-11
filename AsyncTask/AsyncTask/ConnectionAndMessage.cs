using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace AsyncTask
{
    class ConnectionAndMessage
    {
        public int port;

        public ConnectionAndMessage(int port)
        {
            this.port = port;
        }

        public void Connection()
        {
            string text;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);
            TcpListener listener = new TcpListener(localEndpoint);

            listener.Start();

            Console.WriteLine("Awaiting clients...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                RecieveMessage(stream);

                Console.Write("\nWrite your message here: ");
                text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);
            }
        }

        public async void RecieveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];

            int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
            string recievedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\n\nUser says-----> " + recievedMessage + "\n");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
