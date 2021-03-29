using System;

namespace ConstructingClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            // Rise custom exception.
            try
            {
                throw new DerivedException();
            }
            catch (DerivedException ex)
            {

                Console.WriteLine("Source {0}, Error: {1}", ex.Source, ex.Message);
            }

            //IMessage message = new EmailMessage();

            //Console.WriteLine(message.Message);

            // Use partial class.
            MyPartialClass myPartialClass = new MyPartialClass();
            myPartialClass.One();
            myPartialClass.Two();


            // work with Generic Type

            // Add two strings using the Obj class.
            Obj oa = new Obj("Hello", " World!");
            Console.WriteLine((string)oa.t + (string)oa.u);

            // Add two strings using the Gen class.
            Gen<string, string> ga = new Gen<string, string>("Hello", " World!");
            Console.WriteLine(ga.t, ga.u);

            // Add double and integer using the Obj class.
            Obj ob = new Obj(10.125, 2005);
            Console.WriteLine((double)ob.t + (int)ob.u);
            //Console.WriteLine((int)ob.t + (int)ob.u); // Rise error at run time

            // Add double and int to genreic class.
            Gen<double, int> gb = new Gen<double, int>(10.125, 2005);
            Console.WriteLine(gb.t + gb.u);



        }
    }



    class DerivedException : System.ApplicationException
    {
        public override string Message => "An error occured in application";
    }


    #region Implement Interface
    interface IMessage
    {
        bool Send();
        string Message { get; set; }
        string Address { get; set; }

    }

    class EmailMessage : IMessage
    {
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Address { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Send()
        {
            throw new NotImplementedException();
        }
    }

    #endregion

    #region Partial Class

    partial class MyPartialClass
    {
        // Some methods here.
        public void One() { }
    }

    partial class MyPartialClass
    {
        // More methods here.
        public void Two() { }
    }

    #endregion


    #region Generic Type

    // Work faster, not requre boxing and unboxing.
    public class Obj
    {
        public object t;
        public object u;

        public Obj(object _t, object _u)
        {
            t = _t;
            u = _u;
        }

    }

    public class Gen<T,U>
    {
        public T t;
        public U u;

        public Gen(T _t, U _u)
        {
            t = _t;
            u = _u;
        }
    }

    // Generic Constraints.
    public class CompGen<T>
        where T : IComparable
    {
        public T t1;
        public T t2;

        public CompGen(T _t1, T _t2)
        {
            t1 = _t1;
            t2 = _t2;
        }

        public T Max()
        {
            if (t2.CompareTo(t1)<0)
            {
                return t1;
            }
            else
            {
                return t2;
            }
        }

    }

    #endregion


    #region Events

    class MyClassEvent
    {
        // 1. Create delegate.
        public delegate void MyEventHandler(object sender, EventArgs e);

        // 2. Create Event object.
        public event MyEventHandler MyEvent;


        public void Add()
        {

            // 3. Invoke the delecgat ewith in method when you  need to rise event.

            EventArgs e = new EventArgs();

            if (MyEvent != null) // Rquire to check whether handler is null.
            {
                // Invoke the delegate.
                MyEvent(this, e);
            }

        }


    }



    #endregion
}
