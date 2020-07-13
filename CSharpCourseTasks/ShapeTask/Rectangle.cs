using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    public class Rectangle : IShape
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }

        public Rectangle(double side1, double side2)
        {
            Side1 = side1;
            Side2 = side2;
        }

        public double GetWidth()
        {
            return Math.Min(Side1, Side2);
        }

        public double GetHight()
        {
            return Math.Max(Side1, Side2);
        }

        public double GetArea()
        {
            return Side1 * Side2;
        }

        public double GetPerimeter()
        {
            return (2 * Side1) + (2 * Side2);
        }
    }
}
