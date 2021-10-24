using System;
using System.Threading.Tasks;

namespace ParentChildTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Parent Child tasks!");

            DetachedTask();

            AttachedTasks();

        }


        private static void AttachedTasks()
        {
            Task parentTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("     Parent task started");

                Task childTask = Task.Factory.StartNew(() => {
                    Console.WriteLine("     Child task started");
                }, TaskCreationOptions.AttachedToParent);
                Console.WriteLine("     Parent task Finish");
            });
            //Wait for parent to finish
            parentTask.Wait();
            Console.WriteLine("     Work Finished");
        }

        private static void DetachedTask()
        {
            Task parentTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("     Parent task started");

                Task childTask = Task.Factory.StartNew(() => {
                    Console.WriteLine("     Child task started");
                });
                Console.WriteLine("     Parent task Finish");
            });
            //Wait for parent to finish
            parentTask.Wait();
            Console.WriteLine("     Work Finished");
        }

    }
}
