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

            var test = ttt.Value;

           
        }
    }


    struct Cycle
    {
        // Private Fields.
        int _val, _min, _max;

        //Constructor
        public Cycle(int min, int max)
        {
            // Must Initialise all declared values, else error, try to commet initialization.
            _val = min;
            _min = min;
            _max = max;
        }

        public int Value
        {
            get { return _val; }
            set
            {
                if (value > _max)
                {
                    this.Value = value - _max + _min - 1;
                }
                else
                {
                    if (value <_min)
                    {
                        this.Value = _min - value + _max - 1;
                    }
                    else
                    {
                        _val = value;
                    }
                }
            }
        }

    }


}
