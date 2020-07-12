using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    class Range
    {
        public double From { get; set; }
        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return ((number >= From) && (number <= To));
        }

        public Range GetIntersection(Range range)
        {
            if (range.From >= To || range.To <= From)
            {
                return null;
            }

            double leftPoint = Math.Max(From, range.From);
            double rightPoint = Math.Min(To, range.To);

            return new Range(leftPoint, rightPoint);
        }

        public Range[] GetUnion(Range range)
        {
            if (To < range.From)
            {
                return new Range[] { new Range(From, To), new Range(range.From, range.To) };
            }

            if (From > range.To)
            {
                return new Range[] { new Range(range.From, range.To), new Range(From, To) };
            }

            double leftPoint = Math.Min(From, range.From);
            double rightPoint = Math.Max(To, range.To);

            return new Range[] { new Range(leftPoint, rightPoint) };
        }

        public Range[] GetComplement(Range range)
        {
            if ((From < range.From) && (To > range.To))
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if ((From >= range.From) && (To <= range.To))
            {
                return new Range[] { };
            }

            if ((range.From <= To) && (range.To >= To))
            {
                return new Range[] { new Range(From, range.From) };
            }

            if ((From <= range.To) && (To >= range.To))
            {
                return new Range[] { new Range(range.To, To) };
            }

            return new Range[] { new Range(From, To) };
        }

        public override string ToString()
        {
            return "from " + From + " to " + To;
        }
    }
}
