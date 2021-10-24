using System;
using System.Threading;

namespace SyncAccessToResources
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Syncronize access to resources using lock, Monitor.

            Math math = new Math(2, 3);

            Thread t1 = new Thread(new ThreadStart(math.Add));
            Thread t2 = new Thread(new ThreadStart(math.Subtract));
            Thread t3 = new Thread(new ThreadStart(math.Multiply));

            t1.Start();
            t2.Start();
            t3.Start();

        }
    }


    class Math
    {
        public int value1;
        public int value2;
        private int result;

        public Math(int _value1, int _value2)
        {
            value1 = _value1;
            value2 = _value2;
        }

        public void Add()
        {
            Monitor.Enter(this);

            result = value1 + value2;
            Thread.Sleep(1000);
            Console.WriteLine("Add: " + result);

            Monitor.Exit(this);
        }

        public void Subtract()
        {
            lock (this)
            {
                result = value1 - value2;
                Thread.Sleep(1000);
                Console.WriteLine("Subtract: " + result);

            }
        }

        public void Multiply()
        {
            lock (this)
            {
                result = value1 * value2;
                Thread.Sleep(1000);
                Console.WriteLine("Multiply: " + result);

            }

            
        }

        
    }
}
