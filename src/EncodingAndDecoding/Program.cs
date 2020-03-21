using System;
using System.IO;
using System.Text;

namespace EncodingAndDecoding
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! How to encode an decode text.\n");

            StreamReader sr = new StreamReader(@"C:\Test\win.ini");
            StreamWriter sw = new StreamWriter(@"C:\Test\win-utf7.txt", false, Encoding.UTF7);
            sw.WriteLine(sr.ReadToEnd());
            sw.Close();
            sr.Close();

            //********** Using Encoding Class

            Encoding ec = Encoding.GetEncoding("utf-32");

            byte[] encoded = ec.GetBytes("Hello from encoding!");

            for (int i = 0; i < encoded.Length; i++)
            {
                Console.WriteLine("Byte {0}: {1}", i, encoded);

            }

            //  Examine supported code pages in NET Core

            Console.WriteLine("\n  Supported Encoding in NET Core:");

            EncodingInfo[] ei = Encoding.GetEncodings();

            foreach (var item in ei)
            {
                Console.WriteLine("{0}: {1}, {2}", item.CodePage, item.Name, item.DisplayName);
            }




        }
    }
}
