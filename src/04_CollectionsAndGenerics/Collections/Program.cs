using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Collections!\n");

            // *********  ArrayList  **************

            ArrayList al = new ArrayList
            {
                "Hello",
                "Collection",
                "from me :)"
            };

            Console.WriteLine("The array has " + al.Count + "items:");

            foreach (var item in al)
            {
                Console.WriteLine(item.ToString());
            }

            //  Hello Collections!

            //  The array has 4items:
            //  Hello
            //  Collection
            //  from me :)

            al.Sort();

            Console.WriteLine("\nSorting result:");

            foreach (var item in al)
            {
                Console.WriteLine(item.ToString());
            }

            al.Sort(new MyReverseSort());

            Console.WriteLine("\nCustom reverse sorting result:");

            foreach (var item in al)
            {
                Console.WriteLine(item.ToString());
            }

            al.Reverse();
            Console.WriteLine("\nReverse sorting result:");

            foreach (var item in al)
            {
                Console.WriteLine(item.ToString());
            }


            // ****************************************

            Dictionary<int, string> keyValuePairs = new Dictionary<int, string>
            {
                { 101 , "Hello error" },
                { 202, "Another error" }
            };

            Dictionary<int, string> keyValuePairs1 = new Dictionary<int, string>
            {
                [101] = "Hello error",
                [203] = "Another error"
            };

            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, 23);
            hashtable.Add(2, 24);



        }
    }


    class MyReverseSort : IComparer
    {
        public int Compare(object x, object y)
        {
            return new CaseInsensitiveComparer().Compare(y, x);
        }

    }

}
