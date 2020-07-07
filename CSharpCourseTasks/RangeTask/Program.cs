using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Range range = new Range(2, 5.7);
            double number = 3;

            Console.WriteLine(range.GetLength());
            Console.WriteLine(range.IsInside(number));
            Console.ReadLine();
        }
    }
}
