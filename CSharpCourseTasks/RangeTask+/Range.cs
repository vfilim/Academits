using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTaskAdvanced
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

        public Range GetIntersection(Range range2)
        {
            if ((From <= range2.From) && (To >= range2.To))
            {
                return range2;
            }
            else if ((From > range2.From) && (To < range2.To))
            {
                return this;
            }
            else if ((range2.From < To) && (range2.To > To))
            {
                return new Range(range2.From, To);
            }
            else if ((From < range2.To) && (To > range2.To))
            {
                return new Range(From, range2.To);
            }
            else
            {
                return null;
            }
        }

        public Range[] GetUnion(Range range2)
        {
            if ((From <= range2.From) && (To >= range2.To))
            {
                return new Range[] { this };
            }
            else if ((From >= range2.From) && (To <= range2.To))
            {
                return new Range[] { range2 };
            }
            else if ((range2.From <= To) && (range2.To >= To))
            {
                return new Range[] { new Range(From, range2.To) };
            }
            else if ((From <= range2.To) && (To >= range2.To))
            {
                return new Range[] { new Range(range2.From, To) };
            }
            else
            {
                return new Range[] { this, range2 };
            }
        }

        public Range[] GetComplement(Range range2)
        {
            if ((From < range2.From) && (To > range2.To))
            {
                return new Range[] { new Range(From, range2.From), new Range(range2.To, To) };
            }
            else if ((From >= range2.From) && (To <= range2.To))
            {
                return new Range[] { };
            }
            else if ((range2.From <= To) && (range2.To >= To))
            {
                return new Range[] { new Range(From, range2.From) };
            }
            else if ((From <= range2.To) && (To >= range2.To))
            {
                return new Range[] { new Range(range2.To, To) };
            }
            else
            {
                return new Range[] { this };
            }
        }
    }
}
