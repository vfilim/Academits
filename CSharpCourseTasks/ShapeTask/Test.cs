using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    class Test
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(0, 0, 0, 3, 4, 0);

            Console.WriteLine(triangle.GetArea());

            Console.ReadKey();
        }
    }
}
