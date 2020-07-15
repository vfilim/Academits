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

        public override string ToString()
        {
            return "the rectangle with one side = " + Side1 + " and another side = " + Side2;
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

            Rectangle r = (Rectangle)o;

            return (Side1 == r.Side1) && (Side2 == r.Side2);
        }

        public override int GetHashCode()
        {
            return (int)(Side1 * Side2);
        }
    }
}
