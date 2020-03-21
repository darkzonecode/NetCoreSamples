using System;
using System.Text.RegularExpressions;

namespace RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Regular Expression World! \n");


            string[] input = { "(555)555-1212", "(555) 555-1212", "555-555-1212", "5555551212", "01111", "01111-1111", "47", "111-11-1111" };
            foreach (string s in input)
            {
                if (IsPhone(s)) Console.WriteLine(s + " is a phone number");
                else if (IsZip(s)) Console.WriteLine(s + " is a zip code");
                else Console.WriteLine(s + " is unknown");
            }

            foreach (string s in input)
            {
                if (IsPhone(s)) Console.WriteLine(ReformatPhone(s) + " is a phone number");
                else if (IsZip(s)) Console.WriteLine(s + " is a zip code");
                else Console.WriteLine(s + " is unknown");
            }

            //  (555)555 - 1212 is a phone number
            //  (555) 555 - 1212 is a phone number
            //  555 - 555 - 1212 is a phone number
            //  5555551212 is a phone number
            //  01111 is a zip code
            //  01111 - 1111 is a zip code
            //  47 is unknown
            //  111 - 11 - 1111 is unknown

            //  (555) 555 - 1212 is a phone number
            //  (555) 555 - 1212 is a phone number
            //  (555) 555 - 1212 is a phone number
            //  (555) 555 - 1212 is a phone number
            //  01111 is a zip code
            //  01111 - 1111 is a zip code
            //  47 is unknown
            //  111 - 11 - 1111 is unknown


            // How match simple text.

            

        }


        static bool IsPhone(string s)
        {
            return Regex.IsMatch(s, @"^\(?\d{3}\)?[\s\-]?\d{3}\-?\d{4}$");
        }

        static string ReformatPhone(string s)
        {
            Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");
            return string.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]);
        }

        static bool IsZip(string s)
        {
            return Regex.IsMatch(s, @"^\d{5}(\-\d{4})?$");
        }

    }
}
