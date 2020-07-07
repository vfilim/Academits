using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTaskAdvanced
{
    class Test
    {
        static void Main(string[] args)
        {
            Range range = new Range(2, 5.7);
            double number = 3;

            Range range2 = new Range(5, 8);

            Console.WriteLine(range.GetLength());
            Console.WriteLine(range.IsInside(number));

            Range intersection = range.GetIntersection(range2);
            Range[] union = range.GetUnion(range2);
            Range[] complement = range.GetComplement(range2);

            if (intersection == null)
            {
                Console.WriteLine("There is no intersection");
            }
            else
            {
                Console.WriteLine("The intersection is from {0} to {1}", intersection.From, intersection.To);
            }

            if (union.Length > 1)
            {
                Console.WriteLine("The union is from {0} to {1} and from {2} to {3}", union[0].From, union[0].To, union[1].From, union[1].To);
            }
            else
            {
                Console.WriteLine("The union is from {0} to {1}", union[0].From, union[0].To);
            }

            if (complement.Length == 0)
            {
                Console.WriteLine("The complement is empty");
            }
            else if (complement.Length == 1)
            {
                Console.WriteLine("The complement is from {0} to {1}", complement[0].From, complement[0].To);
            }
            else
            {
                Console.WriteLine("The complement is from {0} to {1} and from {2} to {3}", complement[0].From, complement[0].To, complement[1].From, complement[1].To);
            }

            Console.ReadLine();
        }
    }
}
