using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CancelingTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Cancel task!");

            // How to cancel tasks.

            Console.WriteLine("\nHow to cancel Tasks:");

            

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            var sumTaskViaTaskOfIntCancelToken = new Task<int>(() => Sum(5), cancellationToken);
            sumTaskViaTaskOfIntCancelToken.Start();
            Console.WriteLine($"Result from sumTask is {sumTaskViaTaskOfIntCancelToken.Result}");

            var sumTaskViaFactoryCancelToken = Task.Factory.StartNew<int>(() => Sum(5), cancellationToken);
            Console.WriteLine($"Result from sumTask is {sumTaskViaFactoryCancelToken.Result}");

            var sumTaskViaTaskRunCancelToken = Task.Run<int>(() => Sum(5), cancellationToken);
            Console.WriteLine($"Result from sumTask is {sumTaskViaTaskRunCancelToken}");

            // Wait for user to press key to cancel task.
            Console.ReadKey();
            cancellationTokenSource.Cancel();

            // -----------------------------------------------------------------------------------
            

            CancellationTokenSource cancellationTokenSource1 = new CancellationTokenSource();
            CancellationToken token1 = cancellationTokenSource1.Token;

            var sumTaskViaTaskOfInt = new Task(() => LongRunningSum(token1), token1);
            sumTaskViaTaskOfInt.Start();
            //Wait for user to press key to cancel task
            Console.ReadLine();

            cancellationTokenSource1.Cancel();

            // Registering for a request cancellation using the Callback delegate

            CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource();
            CancellationToken token2 = cancellationTokenSource2.Token;
            DownloadFileWithToken(token2);
            //Random delay before we cancel token
            Task.Delay(2000);
            cancellationTokenSource2.Cancel();
            Console.ReadLine();

        }

        private static void LongRunningSum(CancellationToken token)
        {
            for (int i = 0; i < 1000; i++)
            {
                //Simulate long running operation
                Task.Delay(100);

                if (token.IsCancellationRequested)
                    token.ThrowIfCancellationRequested();
            }
        }

        private static int Sum(int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += i;
            }
            return sum;
        }


        private static void DownloadFileWithToken(CancellationToken token)
        {
            WebClient webClient = new WebClient();
            //Here we are registering callback delegate that will get called as soon as user cancels token
            token.Register(() => webClient.CancelAsync());

            webClient.DownloadStringAsync(new Uri("http://www.google.com"));
            webClient.DownloadStringCompleted += (sender, e) => {
                if (!e.Cancelled)
                    Console.WriteLine("Download Complete.");
                else
                    Console.WriteLine("Download Cancelled.");
            };

        }

        private static void DownloadFileWithoutToken()
        {
            WebClient webClient = new WebClient();

            webClient.DownloadStringAsync(new Uri("http://www.google.com"));
            webClient.DownloadStringCompleted += (sender, e) => {
                if (!e.Cancelled)
                    Console.WriteLine("Download Complete.");
                else
                    Console.WriteLine("Download Cancelled.");
            };
        }
    }
}
