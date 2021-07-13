using System;
using System.Linq;

namespace AsParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var range = Enumerable.Range(1, 100000);

            var result = range.Where(i => i % 3 == 0).ToList();


            

        }
    }
}
