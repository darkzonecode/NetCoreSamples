using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CancellingLoop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello CancellingLoop!");

            // BreakParallelLoop();

            //LowestBreakIteration();
            ParallelLoopStateStop();
            //CancelParallelLoops();


        }

        private static void ParallelLoopStateStop()
        {
            // If you don't want to mimic the results of sequential loops and want to exit the loop as soon
            // as possible, you can call ParallelLoopState.Stop.Just like we did with the Break()
            // method, all the iterations running in parallel finish before the loop exits:

            var numbers = Enumerable.Range(1, 1000);
            Parallel.ForEach(numbers, (i, parallelLoopState) =>
            {
                Console.Write(i + " ");
                if (i % 4 == 0)
                {
                    Console.WriteLine("Loop Stopped on {0}", i);
                    parallelLoopState.Stop();
                }
            });
        }

        static object locker = new object();
        private static void LowestBreakIteration()
        {
            // Parallel.Break tries to mimic the results of a sequential execution.
            // To break out of the loop, we called parallelLoopState.Break(), which tries to mimic
            // the behavior of the actual break keyword in a sequential loop.When the Break() method
            // is encountered by any of the cores, it will set an iteration number in the
            // LowestBreakIteration property of the ParallelLoopState object.This becomes the
            // maximum number or the last iteration that can be executed. All the other tasks will
            // continue iterating until this number is reached.

            var numbers = Enumerable.Range(1, 1000);
            Parallel.ForEach(numbers, (i, parallelLoopState) =>
            {
                lock (locker)
                {
                    Console.WriteLine(string.Format(
                   $"For i={i} LowestBreakIteration={parallelLoopState.LowestBreakIteration} and Task id ={Task.CurrentId}"));

                    if (i >= 10)
                    {
                        parallelLoopState.Break();
                    }
                }
            });
        }

        private static void CancelParallelLoops()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                cancellationTokenSource.Cancel();
                Console.WriteLine("Token has been cancelled");
            });

            ParallelOptions loopOptions = new ParallelOptions()
            {
                CancellationToken = cancellationTokenSource.Token
            };
            try
            {
                Parallel.For(0, Int64.MaxValue, loopOptions, index =>
                {
                    Thread.Sleep(3000);
                    double result = Math.Sqrt(index);
                    Console.WriteLine($"Index {index}, result {result}");
                });
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Cancellation exception caught!");
            }
        }

        private static void BreakParallelLoop()
        {
            var numbers = Enumerable.Range(1, 1000);
            int numToFind = 2;
            Parallel.ForEach(numbers, (number, parallelLoopState) =>
            {
                Console.Write(number + "-");

                if (number == numToFind)
                {
                    Console.WriteLine($"Calling Break at {number}");
                    parallelLoopState.Break();
                }

            });
        }

    }
}
