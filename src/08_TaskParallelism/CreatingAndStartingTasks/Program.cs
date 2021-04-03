using System;
using System.Threading.Tasks;

namespace CreatingAndStartingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tasks!");

            SomeMethod();
            Console.Read();


            Task task1 = new Task(() => PrintNumber10Times());
            task1.Start();


        }

        public static async void SomeMethod()
        {
            await Task.Delay(60000);

            Console.WriteLine("Hello, async NOT use Thread"); // Set break point here.
        }


        private static void PrintNumber10Times()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }


        private static int Sum(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += i;
            }
            return sum;
        }
    }
}
