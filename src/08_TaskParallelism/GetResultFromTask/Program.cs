using System;
using System.Threading.Tasks;

namespace GetResultFromTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Get result from task!");


            // Getting results from finished tasks

            Console.WriteLine("\n*************** Get result from task *************");

            Console.WriteLine("\nGet result from task:");

            var sumTaskViaTaskOfInt = new Task<int>(() => Sum(5));
            sumTaskViaTaskOfInt.Start();
            Console.WriteLine($"Result from sumTask is {sumTaskViaTaskOfInt.Result}");

            var sumTaskViaFactory = Task.Factory.StartNew<int>(() => Sum(5));
            Console.WriteLine($"Result from sumTask is {sumTaskViaFactory.Result}");

            var sumTaskViaTaskRun = Task.Run<int>(() => Sum(5));
            Console.WriteLine($"Result from sumTask is {sumTaskViaTaskRun.Result}");

            var sumTaskViaTaskResult = Task.FromResult<int>(Sum(5));
            Console.WriteLine($"Result from sumTask is {sumTaskViaTaskResult.Result}");


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
