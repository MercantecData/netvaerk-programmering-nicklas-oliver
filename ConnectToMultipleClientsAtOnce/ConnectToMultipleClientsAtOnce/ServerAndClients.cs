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


        public List<TcpClient> clients = new List<TcpClient>();

        public void server()
        {
            IPAddress ip = IPAddress.Any;
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            AcceptClients(listener);

            bool isRunning = true;
            while (isRunning)
            {
                //Send a message
                Console.WriteLine("Write message: ");
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);

                //Stream.write(buffer, 0, buffer.length);
                foreach(TcpClient client in clients)
                {
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }
            }
        }

        public async void AcceptClients(TcpListener listener)
        {
            bool isRunning = true;
            while (isRunning)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                clients.Add(client);
                NetworkStream stream = client.GetStream();
                RecieveMessages(stream);
            }
        }

        public async void RecieveMessages(NetworkStream stream)
        {
            byte[] buffer = new byte[256];
            bool isRunning = true;
            while (isRunning)
            {
                int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                string text = Encoding.UTF8.GetString(buffer, 0, read);
                Console.WriteLine("client writes " + text);
            }
        }
    }
}
