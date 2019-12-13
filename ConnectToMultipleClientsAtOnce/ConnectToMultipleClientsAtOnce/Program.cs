using System;

namespace AsyncBonusTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerAndClient connection = new ServerAndClient(4269);


            connection.server();
        }
    }
}
