using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientAppNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hvad for en ip vil du forbinde til: ");
            string IPString = "172.16.241.96";
            Console.ReadLine();
            Console.Write("Hvad for en port vil du forbinde til: ");
            int port = int.Parse(Console.ReadLine());
            IPAddress ip1 = IPAddress.Any;
            IPEndPoint localEndpoint2 = new IPEndPoint(ip1, port);
            TcpListener listener = new TcpListener(localEndpoint2);
            listener.Start();
            bool ISTrue = true;

            while (ISTrue)
            {
                Console.WriteLine("Awaiting client(s)");
                TcpClient client = new TcpClient();
                IPAddress ip = IPAddress.Parse(IPString);
                IPEndPoint endPoint = new IPEndPoint(ip, port);

                client.Connect(endPoint);

                NetworkStream stream = client.GetStream();

                Console.Write("Hvad vil du skrive: ");
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);

                Console.WriteLine("Besked sent!");




                Console.WriteLine("Venter svar........");
                TcpClient client2 = listener.AcceptTcpClient();
                NetworkStream stream2 = client2.GetStream();
                byte[] buffer1 = new byte[256];

                int numberOfBytesRead = stream2.Read(buffer1, 0, 256);

                string message = Encoding.UTF8.GetString(buffer1, 0, numberOfBytesRead);
                Console.WriteLine(message);
            }
        }
    }
}
