using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NetworkRecieveAndSendTask
{
    class SendAndRecieve
    {
        private int UserPortChoice;
        private string UserIpChoice;

        public SendAndRecieve(int userPortChoice, string userIpChoice)
        {
            UserPortChoice = userPortChoice;
            UserIpChoice = userIpChoice;
        }
        public void EstablishConnction(int portChoice)
        {
            int port = portChoice;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);
            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();
            Console.WriteLine("Awaiting connection from user...");

            TcpClient client = listener.AcceptTcpClient();
            Console.WriteLine("User connected successfully!");
            Thread.Sleep(800);

                NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[256];
            int numberOfBytesRead = stream.Read(buffer, 0, 256);
            string message = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            
                Console.WriteLine("\nUser wrote the following to you--->");
                Console.WriteLine(message);

                Console.WriteLine("\nYour response--->");
                string text2 = Console.ReadLine();
                byte[] clientBuffer2 = Encoding.UTF8.GetBytes(text2);

                stream.Write(clientBuffer2, 0, clientBuffer2.Length);
        }
        public void SendMessage(int port, string userIpChoice)
        {
            while (true)
            {
                Console.WriteLine("write your message");

                // Establishing connection so that i can send a message
                TcpClient client = new TcpClient();
                IPAddress ip = IPAddress.Parse(userIpChoice);
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                client.Connect(endPoint);


                //TcpClient client2 = listener.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                string text = Console.ReadLine();
                byte[] clientBuffer = Encoding.UTF8.GetBytes(text);

                stream.Write(clientBuffer, 0, clientBuffer.Length);

            }
        }
    }
}
