using System;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace MultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello MultiThreading!\n");

            #region Print number 10 Times
            Console.WriteLine("Start print number 10 times:");
            PrintNumber10Times();
            Console.WriteLine("Finish print number 10 times.\n");

            #endregion

            #region Print numbers using Thread without parameter
            Console.WriteLine("Start print number 10 times:");

            Thread threadWithoutParameter = new Thread(PrintNumber10Times);
            threadWithoutParameter.Start();

            Console.WriteLine("Finish print number 10 times.\n");

            #endregion 

            #region Print numbers using Thread with parameter
            Console.WriteLine("Start print number 10 times:");

            Thread threadWithParameter = new Thread(PrintNumberNTimes);
            threadWithParameter.Start(10);

            Console.WriteLine("Finish print number 10 times.\n");

            #endregion

            #region Print numbers using TheadPool without parameter

            Console.WriteLine("Start print numbers using ThreadPool:");

            ThreadPool.QueueUserWorkItem(PrintNumber10TimesWithParam);
            


            Console.WriteLine("Finish print numbers using ThreadPool:");
            #endregion


            #region Use BacgroudWorker to get progress

            var backgroundWorker = new BackgroundWorker();

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += SimulateServiceCall;
            backgroundWorker.ProgressChanged += ProgressChanged;
            backgroundWorker.RunWorkerCompleted += RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();

            Console.WriteLine("To Cancel Worker Thread Press C.");
            while (backgroundWorker.IsBusy)
            {
                if (Console.ReadKey(true).KeyChar == 'C')
                {
                    backgroundWorker.CancelAsync();
                }
            }
            #endregion
        }

        private static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
            }
            else
            {
                Console.WriteLine($"Result from service call is {e.Result}");
            }
        }

        // This method is called when background worker want to
        // report progress to caller
        private static void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.ProgressPercentage}% completed");
        }

        // Service call we are trying to simulate
        private static void SimulateServiceCall(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            StringBuilder data = new StringBuilder();
            //Simulate a streaming service call which gets data and
            //store it to return back to caller
            for (int i = 1; i <= 100; i++)
            {
                //worker.CancellationPending will be true if user
                //press C
                if (!worker.CancellationPending)
                {
                    data.Append(i);
                    worker.ReportProgress(i);
                    Thread.Sleep(100);
                    //Try to uncomment and throw error
                    //throw new Exception("Some Error has occurred");
                }
                else
                {
                    //Cancels the execution of worker
                    worker.CancelAsync();
                }
            }
            e.Result = data;
        }



        private static void PrintNumber10Times()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
            }

            Console.WriteLine();
        }

        private static void PrintNumberNTimes(object times)
        {
            int n = Convert.ToInt32(times);
            for (int i = 0; i < n; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }

        private static void PrintNumber10TimesWithParam(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
            }
            Console.WriteLine();
        }
    }
}
