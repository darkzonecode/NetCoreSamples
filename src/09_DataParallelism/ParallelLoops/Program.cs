using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ParallelLoops!");

            // This approach can be useful if you don't want to cancel, break, or maintain any thread local
            // state and the order of execution is not important.
            ParallelLoopResult parallelLoopResult = Parallel.For(1, 1000, (i) => Console.WriteLine(i));
            Console.WriteLine($"Paraller.For result is completed: {parallelLoopResult.IsCompleted}");
            
            ParallelFor();

            // Tip:  For some collections, sequential executions work faster, depending on the
            //       syntax of the loop and the type of work that's being done.

            // **************************************************************************************************

            // The code is made parallel and the order is also not important
            ParallelForEach();
        }

        private static void ParallelForEach()
        {
            List<string> urls = new List<string>() { "www.google.com", "www.yahoo.com", "www.bing.com" };
            Parallel.ForEach(urls, url =>
            {
                Ping pinger = new Ping();
                Console.WriteLine($"Ping Url {url} status is {pinger.Send(url).Status} by Task {Task.CurrentId}");
            });


        }

        private static void ParallelFor()
        {
            int totalFiles = 0;
            var files = Directory.GetFiles("C:\\");
            Parallel.For(0, files.Length, (i) =>
            {
                FileInfo fileInfo = new FileInfo(files[i]);
                if (fileInfo.CreationTime.Day == DateTime.Now.Day)
                    Interlocked.Increment(ref totalFiles);
            });
            Console.WriteLine($"Total number of files in C: drive are {files.Count()} and  {totalFiles} files were created today.");
        }
    }
}
