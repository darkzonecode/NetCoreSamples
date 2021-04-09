using System;
using System.Threading.Tasks;

namespace ParallelInvokeMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Parallel.Invoke method.!");

            try
            {
                Parallel.Invoke(() => Console.WriteLine("Action 1"),
                    new Action(() => Console.WriteLine("Action 2")), 
                    () => Console.WriteLine("Action 3"));
            }
            catch (AggregateException aggregateException)
            {
                foreach (var ex in aggregateException.InnerExceptions)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine("Unblocked");
            Console.ReadLine();

            Task.Factory.StartNew(
                () =>
                {
                    Task.Factory.StartNew(() => Console.WriteLine("Action 1"), TaskCreationOptions.AttachedToParent);
                    Task.Factory.StartNew(() => Console.WriteLine("Action 2"), TaskCreationOptions.AttachedToParent);
                    Task.Factory.StartNew(() => Console.WriteLine("Action 3"), TaskCreationOptions.AttachedToParent);
                }
                );




        }
    }
}
