using System;
using System.Text;

namespace netveark_programmering_opgave_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // =========================== Converting with ASCII =============================
            string Tekst1 = "O hello there hæhæ!";

            // Converting string Tekst1 to bytes
            var Tekst1InBytes = Encoding.ASCII.GetBytes(Tekst1);

            // Converting bytes back to a string
            string Tekst1ByteConvert = Encoding.ASCII.GetString(Tekst1InBytes);

            // Now writing the code
            Console.WriteLine(Tekst1ByteConvert);


            // ======================= Converting with UTF8 ================================000
            string Tekst2 = "O hello there hæhæ!";

            // Converting string Tekst1 to bytes
            var Tekst2InBytes = Encoding.UTF8.GetBytes(Tekst2);

            // Converting bytes back to a string
            string Tekst2ByteConvert = Encoding.UTF8.GetString(Tekst2InBytes);

            // Now writing the code
            Console.WriteLine(Tekst2ByteConvert);
        }
    }
}
