using System;
using System.Threading.Tasks;

namespace WaitOnRunningTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Wait on running task!");

            // Task.Wait method can be used to wait on single task.
            // The calling method will be blocked until the thread either completes, is canceled,
            // or throws an exception.

            var normalWaittask = Task.Factory.StartNew(() => Console.WriteLine("Inside thread."));
            // Block current thread until task finished.
            normalWaittask.Wait();


            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("TaskA finished"));
            Task taskB = Task.Factory.StartNew(() => Console.WriteLine("TaskB finished"));
            
            // Return Task when any one task is completed.
            Task.WhenAny(taskA, taskB);

            // Return Task when all task are completed.
            //Task.WhenAll(taskA, taskB);

            // Waits when any task completed.
            //Task.WaitAny(taskA, taskB);

            // Waits when all task completed.
            //Task.WaitAll(taskA, taskB);

            Console.WriteLine("Calling method finishes");

            WaitAllDemo();
            WaitAnyDemo();
            WhenAllDemo();
            WhenAnyDemo();

        }

        private static void WhenAnyDemo()
        {
            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("TaskA finished"));
            Task taskB = Task.Factory.StartNew(() => Console.WriteLine("TaskB finished"));
            Task.WhenAny(taskA, taskB);
            Console.WriteLine("Calling method finishes");
        }

        private static void WhenAllDemo()
        {
            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("TaskA finished"));
            Task taskB = Task.Factory.StartNew(() => Console.WriteLine("TaskB finished"));
            Task.WhenAll(taskA, taskB);
            Console.WriteLine("Calling method finishes");
        }

        private static void WaitAnyDemo()
        {
            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("TaskA finished"));
            Task taskB = Task.Factory.StartNew(() => Console.WriteLine("TaskB finished"));
            Task.WaitAny(taskA, taskB);
            Console.WriteLine("Calling method finishes");
        }

        private static void WaitAllDemo()
        {
            Task taskA = Task.Factory.StartNew(() => Console.WriteLine("TaskA finished"));
            Task taskB = Task.Factory.StartNew(() => Console.WriteLine("TaskB finished"));
            Task.WaitAll(taskA, taskB);
            Console.WriteLine("Calling method finishes");
        }
    }
}
