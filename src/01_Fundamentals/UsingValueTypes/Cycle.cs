using System;
using System.Collections.Generic;
using System.Text;

namespace UsingValueTypes
{
    /// <summary>
    /// Custom Value Type.
    /// </summary>
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
                    if (value < _min)
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

        public override string ToString()
        {
            return Value.ToString();
        }

        public static Cycle operator + (Cycle arg1, int arg2)
        {
            arg1.Value += arg2;

            return arg1;
        }

        public static Cycle operator -(Cycle arg1, int arg2)
        {
            arg1.Value -= arg2;

            return arg1;
        }


    }
}
