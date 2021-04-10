using System;
using System.Linq;
using System.Threading.Tasks;

namespace DegreeOfParallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Degree of parallelism!");

            // DegreeOfParallelismWithParallelFor();
            DegreeOfParallelismWithParallelForEach();


        }


        private static void DegreeOfParallelismWithParallelForEach()
        {
            var items = Enumerable.Range(1, 20);
            Parallel.ForEach(items, new ParallelOptions { MaxDegreeOfParallelism = 4 }, item =>
            {
                Console.WriteLine($"Index {item} executing on Task Id {Task.CurrentId}");
            });
        }

        private static void DegreeOfParallelismWithParallelFor()
        {
            Parallel.For(1, 20, new ParallelOptions { MaxDegreeOfParallelism = 4 }, index =>
            {
                Console.WriteLine($"Index {index} executing on Task Id {Task.CurrentId}");
            });
        }
    }
}
