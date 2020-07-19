using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    class Test
    {
        static void Main(string[] args)
        {
            Range range1 = new Range(2, 5.7);
            double number = 3;

            Range range2 = new Range(1, 8);

            Console.WriteLine(range1.GetLength());
            Console.WriteLine(range1.IsInside(number));

            Range intersection = range1.GetIntersection(range2);
            if (intersection == null)
            {
                Console.WriteLine("The intersection is empty");
            }
            else
            {
                Console.WriteLine("The intersection is " + intersection);
            }

            Range[] union = range1.GetUnion(range2);

            if (union.Length > 1)
            {
                Console.WriteLine("The union is " + union[0] + " and " + union[1]);
            }
            else
            {
                Console.WriteLine("The union is " + union[0]);
            }

            Range[] complement = range1.GetComplement(range2);

            if (complement.Length < 1)
            {
                Console.WriteLine("The complement is empty");
            }
            else if (complement.Length == 1)
            {
                Console.WriteLine("The complement is " + complement[0]);
            }
            else
            {
                Console.WriteLine("The complement is " + complement[0] + " and " + complement[1]);
            }

            Console.ReadLine();
        }
    }
}
