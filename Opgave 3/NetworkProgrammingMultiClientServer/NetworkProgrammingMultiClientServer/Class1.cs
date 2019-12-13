using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace NetworkProgrammingMultiClientServer
{

    class Server
    {
        public List<TcpClient> clients = new List<TcpClient>();
        public Server()
        {
            IPAddress ip = IPAddress.Any;
            int port = 13356;
            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            AcceptClients(listener);

            //TcpClient client = listener.AcceptTcpClient();
            //NetworkStream stream = client.GetStream();

            //ReceiveMessages(stream);

            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("Write message: ");
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                //stream.Write(buffer, 0, buffer.Length);
                foreach(TcpClient client in clients){
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }
            }
        }
        public async void AcceptClients(TcpListener listener)
        {
            bool isRuning = true;
            while (isRuning)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                clients.Add(client);
                NetworkStream stream = client.GetStream();
                ReceiveMessages(stream);
            }
        }
        public async void ReceiveMessages(NetworkStream stream)
        {
            byte[] buffer = new byte[256];
            bool isRunning = true;
            while (isRunning)
            {
                int read = await stream.ReadAsync(buffer, 0, buffer.Length);
                String text = Encoding.UTF8.GetString(buffer, 0, read);
                Console.WriteLine("Client Writes: " + text);
            }
        }
    }
}
