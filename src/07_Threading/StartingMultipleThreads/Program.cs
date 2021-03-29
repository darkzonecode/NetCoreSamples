using System;
using System.Diagnostics.Tracing;
using System.Threading;

namespace StartingMultipleThreads
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Multiple threads!");


            #region Simple use of ThreadPool
            int workerThread;
            int completionPortThread;

            ThreadPool.GetMaxThreads(out workerThread, out completionPortThread);

            Console.WriteLine("Maximum worker threads: " + workerThread);

            ThreadPool.QueueUserWorkItem(ThreadProc);


            Console.WriteLine("Main Thread does some work than go sleep");

            //Thread.Sleep(10000);

            Console.WriteLine("Main thread exit.");

            #endregion

            #region Fibonacci

            const int FibonacciCalculations = 5;

            var doneEvents = new ManualResetEvent[FibonacciCalculations];

            var fibArray = new Fibonacci[FibonacciCalculations];

            var rand = new Random();

            Console.WriteLine($"Launching {FibonacciCalculations} tasks...");

            for (int i = 0; i < FibonacciCalculations; i++)
            {
                doneEvents[i] = new ManualResetEvent(false);

                var f = new Fibonacci(rand.Next(20, 40), doneEvents[i]);

                fibArray[i] = f;

                ThreadPool.QueueUserWorkItem(f.ThreadPoolCallback, i);          
            }

            WaitHandle.WaitAll(doneEvents);
            //WaitHandle.WaitAny(doneEvents);
            //WaitHandle.SignalAndWait(doneEvents[0], doneEvents[3]);

            Console.WriteLine("All callculation completed.");

            for (int i = 0; i < FibonacciCalculations; i++)
            {
                Fibonacci f = fibArray[i];
                Console.WriteLine($"Fibonacci({f.N}) = {f.FibOfN}");
            }



            #endregion

        }


        static void ThreadProc(object stateInfo)
        {
            Thread.Sleep(60000);
            Console.WriteLine("Hello from thread pool.");
        }

    }


    class Fibonacci
    {
        private ManualResetEvent _doneEvent;

        public Fibonacci(int n , ManualResetEvent doneEvent)
        {
            N = n;
            _doneEvent = doneEvent;
        }

        public int N { get; set; }

        public int FibOfN { get; private set; }

        public void ThreadPoolCallback(object threadContext)
        {
            int threadIndex = (int)threadContext;
            Console.WriteLine($"Thread {threadIndex} started...");
            FibOfN = Calculate(N);
            Console.WriteLine($"Thread {threadIndex} result calculated...");
            _doneEvent.Set();
        }



        public int Calculate(int n)
        {
            if (n <= 0)
            {
                return n;
            }

            return Calculate(n - 1) + Calculate(n - 2);
        }

    }


}
