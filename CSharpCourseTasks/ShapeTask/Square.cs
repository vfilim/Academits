using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    public class Square : IShape
    {
        public double SideLength
        {
            get;
            set;
        }

        public Square(double sideLength)
        {
            this.SideLength = sideLength;
        }

        public double GetWidth()
        {
            return SideLength;
        }

        public double GetHight()
        {
            return SideLength;
        }

        public double GetArea()
        {
            return Math.Pow(SideLength, 2);
        }

        public double GetPerimeter()
        {
            return 4 * SideLength;
        }
    }
}
