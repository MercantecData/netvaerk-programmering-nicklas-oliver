using System;

namespace AsyncBonusTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerAndClient connection = new ServerAndClient(7777);

            connection.server();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nA client has connected!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("-----------------------------------------------------------------\n<Client>");

            connection.client();
        }
    }
}
