using System;
using System.Threading.Tasks;

namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Handling Exceptions.!");

            // Handling Exception from single Task
            Task task = null;
            try
            {
                task = Task.Factory.StartNew(() =>
                {
                    int num = 0, num2 = 25;
                    var result = num2 / num;
                });
                task.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"Task has finished with exception {ex.InnerException.Message}");
            }
            Console.WriteLine("\nFinish error handling for single task.");

            // **************************************************************************************

            // Handling exceptions from multiple tasks.
            Console.WriteLine("\nStart error handling for multiple task.");
            Task taskA = Task.Factory.StartNew(() => throw new DivideByZeroException());
            Task taskB = Task.Factory.StartNew(() => throw new ArithmeticException());
            Task taskC = Task.Factory.StartNew(() => throw new NullReferenceException());
            try
            {
                Task.WaitAll(taskA, taskB, taskC);
            }
            catch (AggregateException ex)
            {
                foreach (Exception innerException in ex.InnerExceptions)
                {
                    Console.WriteLine(innerException.Message);
                }
            }

            Console.WriteLine("\nFinish error handling for multiple task.");

            // *****************************************************************************************

            // Handling task exceptions with a callback function.
            Console.WriteLine("\nStart error handling for multiple task using callback function.");
            Task taskA1 = Task.Factory.StartNew(() => throw new DivideByZeroException());
            Task taskB1 = Task.Factory.StartNew(() => throw new ArithmeticException());
            Task taskC1 = Task.Factory.StartNew(() => throw new NullReferenceException());
            try
            {
                Task.WaitAll(taskA1, taskB1, taskC1);
            }
            catch (AggregateException ex)
            {
                ex.Handle(innerException =>
                {
                    Console.WriteLine(innerException.Message);
                    return true;
                }
                );


            }

            Console.WriteLine("\nFinish error handling for multiple task using callback.");
        }
    }
}
