﻿using System;
using System.Linq;

namespace WorkingLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Parallel!");

            int[] myArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };


            var test = from d in myArray
                       
                       select d;





        }
    }
}
