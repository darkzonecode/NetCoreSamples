using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManagingThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Starting and stopping Threads.

            #region Starting and Stopping Threads

            // Create the thread object , passing in the 
            // DoWork method using ThreadStart delegate.

            Thread DoWorkThread = new Thread(new ThreadStart(DoWork));

            DoWorkThread.Priority = ThreadPriority.Highest;

            DoWorkThread.Name = "Andriy Thread";

            // Start the thred 
            DoWorkThread.Start();

            // Wait one second to allow the thread start.
            Thread.Sleep(1000);


            // NOTE:
            // Please read : https://docs.microsoft.com/en-us/dotnet/standard/threading/using-threads-and-threading 
            // How to: Stop a thread 
            // The Thread.Abort method is not supported in .NET Core.
            // If you need to terminate the execution of third-party code forcibly in .NET Core, run it in the separate process and use Process.Kill.

            // Abort the thread.
            // DoWorkThread.Abort();
            

            Console.WriteLine("The main thread is ending.");

            Thread.Sleep(6000);

            #endregion


            #region Passing data to and from Threads.

            

            #endregion

        }


      


        public static void DoWork()
        {
            Console.WriteLine("DoWork is running on another thread.");

            try
            {
                Thread.Sleep(5000);

            }
            catch ( ThreadAbortException )
            {
                Console.WriteLine("DoWork was Aborted.");
            }
            finally
            {
                Console.WriteLine("Use finnaly to close all open resources.");
            }

            Console.WriteLine("DoWOrk has ended.");

        }

    }
}
