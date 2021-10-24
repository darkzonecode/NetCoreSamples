using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CreatingAndStartingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Tasks!");


            Console.WriteLine("Hello Create Task By Calling Task Constructor!");

            //SomeMethod();
            //Console.Read();

            // Create a task by calling the Task cunstructor and passing a lambda expression
            // containing method we want to execute.
            // Using lambda expressions syntax.
            Console.WriteLine("Using lambda expressions syntax.");
            Task taskLambdaExpression = new Task(() => PrintNumber10Times());
            taskLambdaExpression.Start();
            taskLambdaExpression.Wait();

            // Using the Action delegate.
            Console.WriteLine("\nUsing the Action delegate.");
            Task taskActionDelegate = new Task(new Action(PrintNumber10Times));
            taskActionDelegate.Start();
            taskActionDelegate.Wait();

            // Using delegate.
            Console.WriteLine("\nUsing delegate.");
            Task taskUsingDelegate = new Task(delegate { PrintNumber10Times(); });
            taskUsingDelegate.Start();
            taskUsingDelegate.Wait();

            //*********************************************************************************

            // Task and Task.Factory method do the same thing, just have different syntaxes.
            // Using TaskFactory.
            Console.WriteLine("\n*********** Using TaskFactory *************** ");

            // Using Lambda expression syntax.
            Console.WriteLine("\nUsing Lambda expression syntax.");
            Task.Factory.StartNew(() => PrintNumber10Times());
            Task.WaitAll();

            // Using Action delegate.
            Console.WriteLine("\nUsing the Action delegate.");
            Task.Factory.StartNew(new Action(PrintNumber10Times));

            // Using delegate.
            Console.WriteLine("\nUsing Delegate");
            Task.Factory.StartNew(delegate { PrintNumber10Times(); });



            // ***********************************************************************************

            // The System.Threading.Tasks.Task.Run method.
            // This works just like the StartNew method and return a ThreadPool thread.
            Console.WriteLine("\n*********** Using Task.Run()  *************** ");
            Task.Run(() => PrintNumber10Times());

            // Using Action delegate.
            Console.WriteLine("\nUsing the Action delegate.");
            Task.Run(new Action(PrintNumber10Times));

            // Using delegate
            Task.Run(delegate { PrintNumber10Times(); });

            // The System.Threading.Tasks.Task.Delay method
            // Task.Sleep() still use CPU resources, Task.Delay() is better alternative without utilising CPU.
            Console.WriteLine("\nUsing Task.Delay() method.");

            Console.WriteLine("\nWhat is the output of 20/2. We will show result in 2 seconds.");
            Task.Delay(20000);
            Console.WriteLine("After 2 seconds delay");
            Console.WriteLine("The output is 10");

            // ***********************************************************************************

            // The System.Threading.Tasks.Task.Yield method.
            Console.WriteLine("\n*************** Using Task.Yield() *************");

            TaskYield();

            Console.ReadLine();

            // ***********************************************************************************



        }

        private async static void TaskYield()
        {
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(i);
                if (i % 1000 == 0)
                    await Task.Yield();
            }

        }


        private static void PrintNumber10Times()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

    }
}
