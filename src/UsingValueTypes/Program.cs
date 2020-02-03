using System;

namespace UsingValueTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Cycle ttt = new Cycle(0, 369);


            ttt.Value = 500;

            Console.WriteLine(ttt.Value);

            Console.WriteLine(ttt.ToString());

            Cycle degrees = new Cycle(0, 359);
            Cycle quarters = new Cycle(1, 4);

            for (int i = 0; i < 8; i++)
            {
                degrees += 90;
                quarters += 1;
                Console.WriteLine("Degrees = {0}, quarters = {1}", degrees, quarters);


            }

            

        }
    }
}
