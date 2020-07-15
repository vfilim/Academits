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
            SideLength = sideLength;
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

        public override string ToString()
        {
            return "the square with side = " + SideLength;
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != this.GetType())
            {
                return false;
            }

            Square s = (Square)o;

            return SideLength == s.SideLength;
        }

        public override int GetHashCode()
        {
            return (int)SideLength;
        }
    }
}
