using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ThreadStorage!");

            Console.WriteLine("Execute Parallel.For:\n");
            ThreadLocalVariableFor();
            Console.WriteLine("\nExecute Parallel.ForEach:\n");
            ThreadLocalVariableForEach();
            

        }

        private static void ThreadLocalVariableFor()
        {
            var numbers = Enumerable.Range(1, 5);  // Result must be 15
            long sumOfNumbers = 0;

            Action<long> taskFinishedMethod = (taskResult) => {
                Console.WriteLine($"Sum at the end of all task iterations for task {Task.CurrentId} is {taskResult}");
                Interlocked.Add(ref sumOfNumbers, taskResult);
            };

            Parallel.For(0, numbers.Count(), // collection of 60 number with each number having value equal to index
                                     () => 0, // method to initialize the local variable
                                     (j, loop, subtotal) => // Action performed on each iteration
                                     {
                                         subtotal += j; //Subtotal is Thread local variable
                                         return subtotal; // value to be passed to next iteration
                                     },
                                     taskFinishedMethod
                                     );


            Console.WriteLine($"The total of 60 numbers is {sumOfNumbers}");
        }

        private static void ThreadLocalVariableForEach()
        {
            var numbers = Enumerable.Range(1, 5); // Result must be 15
            long sumOfNumbers = 0;

            Action<long> taskFinishedMethod = (taskResult) => {
                Console.WriteLine($"Sum at the end of all task iterations for task {Task.CurrentId} is {taskResult}");
                Interlocked.Add(ref sumOfNumbers, taskResult);
            };

            Parallel.ForEach<int, long>(numbers, // collection of 60 number with each number having value equal to index
                                     () => 0, // method to initialize the local variable
                                     (j, loop, subtotal) => // Action performed on each iteration
                                     {
                                         subtotal += j; //Subtotal is Thread local variable
                                         return subtotal; // value to be passed to next iteration
                                     },
                                     taskFinishedMethod
                                     );


            Console.WriteLine($"The total of 60 numbers is {sumOfNumbers}"); 
        }

    }
}
