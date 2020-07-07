using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    class Range
    {
        public double From
        {
            get;
            set;
        }

        public double To
        {
            get;
            set;
        }

        public Range(double from, double to)
        {
            this.From = from;
            this.To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            if ((number >= From) && (number <= To))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
