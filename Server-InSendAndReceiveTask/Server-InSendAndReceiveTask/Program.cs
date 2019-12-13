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
            // ===================== Receiving message ==========================
            Console.WriteLine("Before we get started, please write the number of the port, you'd like to connect to: ");
            int UserPortChoice = int.Parse(Console.ReadLine());
            Console.WriteLine("Next up, write the ip from the pc you'd like to connect to.");
            string UserIpChoice = (Console.ReadLine());

            int port = UserPortChoice;

                IPAddress ip = IPAddress.Any;
                IPEndPoint localEndpoint = new IPEndPoint(ip, port);

                TcpListener listener = new TcpListener(localEndpoint);
                listener.Start();
            while (ISTrue)
            {
                Console.WriteLine("Awaiting Clients");
                TcpClient client = listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[256];
                int numberOfBytesRead = stream.Read(buffer, 0, 256);

                string message = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                Console.WriteLine(message);
                // ===================== Sending message ============================0
                Console.WriteLine("write your message");

                // Establishing connection so that i can send a message
                TcpClient client2 = new TcpClient();
                IPAddress ip2 = IPAddress.Parse(UserIpChoice);
                IPEndPoint endPoint2 = new IPEndPoint(ip2, port);
                client2.Connect(endPoint2);


                //TcpClient client2 = listener.AcceptTcpClient();
                NetworkStream stream2 = client2.GetStream();

                string text = Console.ReadLine();
                byte[] clientBuffer = Encoding.UTF8.GetBytes(text);

                stream2.Write(clientBuffer, 0, clientBuffer.Length);
            }
        }
    }
}
