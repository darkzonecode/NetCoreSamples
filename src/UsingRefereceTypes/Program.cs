using System;
using System.Text;

namespace UsingRefereceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Reference types!");


            Numbers n1 = new Numbers(0);
            Numbers n2 = n1;

            n1._val += 1;
            n2._val += 2;

            Console.WriteLine("n1 = {0}, n2 = {1}", n1, n2);


            // String and StringBuilder.

            Console.WriteLine("*********** Build a String ************");

            string s;

            s = "wombat";      // wombat
            s += " kangaroo";  // wombat kangaroo
            s += " wallaby";   // wombat kangaroo wallaby
            s += " koala";     // wombat kangaroo wallaby koala

            Console.WriteLine(s);

            Console.WriteLine("*********** Build a String in StringBuilder ************");

            StringBuilder sb = new StringBuilder(30);

            sb.Append("wombat");     // wombat
            sb.Append(" kangaroo");  // wombat kangaroo
            sb.Append(" wallaby");   // wombat kangaroo wallaby
            sb.Append(" koala");     // wombat kangaroo wallaby koala

            string s1 = sb.ToString();

            Console.WriteLine(s1);

        }
    }

    struct Numbers
    {
        public int _val;

        public Numbers(int val)
        {
            _val = val;
        }

        public override string ToString()
        {
            return _val.ToString();
        }

    }

}
