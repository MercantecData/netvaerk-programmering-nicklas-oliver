using System;

namespace AsyncTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionAndMessage Connection = new ConnectionAndMessage(4269);
            Connection.Connection();
        }
    }
}
