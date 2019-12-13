using System;
using System.Threading;

namespace NetworkRecieveAndSendTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before we get started, please write the number of the port, you'd like to connect to: ");
            int userPortChoice = int.Parse(Console.ReadLine());
            Console.WriteLine("Next up, write the ip from the pc you'd like to connect to.");
            string userIpChoice = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nOne moment, and everything will be ready to go!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("Fantastic, NOW! What would you like to do? \n1. Recieve message\n2. Send message");
            string userChoice = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGreat! you will continue shortly");
            Console.ForegroundColor = ConsoleColor.Gray;
            Thread.Sleep(1200);
            Console.Clear();


            bool IsTrue = true;
            while (IsTrue) 
            {
                if (userChoice == "1")
                {
                    IsTrue = false;

                    Console.Clear();
                    SendAndRecieve recieveing = new SendAndRecieve(userPortChoice, userIpChoice);
                    recieveing.EstablishConnction(userPortChoice);

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("THAT WAS IT FOR TODAY!");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    //recieveing.SendMessage(userPortChoice, userIpChoice);
                }
                else if (userChoice == "2")
                {
                    IsTrue = false;
                    SendAndRecieve sending = new SendAndRecieve(userPortChoice, userIpChoice);

                    sending.SendMessage(userPortChoice, userIpChoice);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please chose either--->");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("1. for recieve message\n2. for send message");

                    userChoice = Console.ReadLine();
                }
            }
        }
    }
}
