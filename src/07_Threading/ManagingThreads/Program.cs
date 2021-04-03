using System;
using System.Threading;
using System.Threading.Tasks;

namespace ManagingThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            // Book 70-536.

            Console.WriteLine("Hello World!");

            // Starting and stopping Threads.

            #region Starting and Stopping Threads

            //// Create the thread object , passing in the 
            //// DoWork method using ThreadStart delegate.

            //Thread DoWorkThread = new Thread(new ThreadStart(DoWork));

            //DoWorkThread.Priority = ThreadPriority.Highest;

            //DoWorkThread.Name = "My Super Thread";

            //// Before call Start() set thread priority here:
            //DoWorkThread.Priority = ThreadPriority.Normal; // Default is Normal.

            //// Start the thred 
            //DoWorkThread.Start();

            //// Wait one second to allow the thread start.
            //Thread.Sleep(1000);


            //// NOTE:
            //// Please read : https://docs.microsoft.com/en-us/dotnet/standard/threading/using-threads-and-threading 
            //// How to: Stop a thread 
            //// The Thread.Abort method is not supported in .NET Core.
            //// If you need to terminate the execution of third-party code forcibly in .NET Core, run it in the separate process and use Process.Kill.

            //// Abort the thread.
            //// DoWorkThread.Abort();


            //Console.WriteLine("The main thread is ending.");

            //Thread.Sleep(6000);

            #endregion


            #region Passing data to and from Threads.

            // Supply the state information required by the task.
            Multiply m = new Multiply("Hello world! Passing data.", 13, new Multiply.ResultDelegate(ResultCallback));

            Thread t = new Thread(new ThreadStart(m.ThreadProc));
            t.Start();

            Console.WriteLine("Main thread do some work than waits. (Passing data)");
            t.Join();

            Console.WriteLine("Thread completed.");

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

        // The callback method must match the signature of the callback delegate.
        public static void ResultCallback(int retValue)
        {
            Console.WriteLine("Returned value: {0}, (Passing data)", retValue);
        }


    }


    public class Multiply
    {
        // State information used in task.
        private string greeting;
        private int value;

        // Delegate to execure the callbackmethod when task complete.
        private ResultDelegate callback;

        // Delegate that define the signature for the callback method.
        public delegate void ResultDelegate(int value);

        // The constructor obtains the state information and the callback delegate.
        public Multiply(string _greeting, int _value, ResultDelegate _callback)
        {
            greeting = _greeting;
            value = _value;
            callback = _callback;
        }

        // The thread procedure perform the tasks, displying greeting and multiplying  the value by 2.
        public void ThreadProc()
        {
            Console.WriteLine(greeting);
            if (callback != null)
            {
                callback(value * 2);
            }
        }

    }

}
