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
            Console.ReadLine();

            // **************************************************************************************

            // Handling exceptions from multiple tasks.





        }
    }
}
