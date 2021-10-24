using System;
using System.Net;
using System.Threading.Tasks;

namespace EAPToTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Event-Based Asynchronous Patterns (EAPs) ");

            EAPImplementation();
            EAPToTask();


        }


        private static Task<string> EAPToTask()
        {
            var taskCompletionSource = new TaskCompletionSource<string>();
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error != null)
                    taskCompletionSource.TrySetException(e.Error);
                else if (e.Cancelled)
                    taskCompletionSource.TrySetCanceled();
                else
                    taskCompletionSource.TrySetResult(e.Result);
            };
            webClient.DownloadStringAsync(new Uri("http://www.someurl.com"));
            return taskCompletionSource.Task;
        }

        private static void EAPImplementation()
        {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += (s, e) =>
            {
                if (e.Error != null)
                    Console.WriteLine(e.Error.Message);
                else if (e.Cancelled)
                    Console.WriteLine("Download Cancel");
                else
                    Console.WriteLine(e.Result);
            };
            webClient.DownloadStringAsync(new Uri("http://www.someurl.com"));
        }

    }
}
