using System;

namespace ShapeTask.Shapes
{
    public class Triangle : IShape
    {
        public double X1 { get; set; }

        public double Y1 { get; set; }

        public double X2 { get; set; }

        public double Y2 { get; set; }

        public double X3 { get; set; }

        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public static double GetSide(double x1, double x2, double y1, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double GetWidth()
        {
            double leftPoint = Math.Min(Math.Min(X1, X2), X3);
            double rightPoint = Math.Max(Math.Max(X1, X2), X3);

            return rightPoint - leftPoint;
        }

        public double GetHeight()
        {
            double lowerPoint = Math.Min(Math.Min(Y1, Y2), Y3);
            double upperPoint = Math.Max(Math.Max(Y1, Y2), Y3);

            return upperPoint - lowerPoint;
        }

        public double GetArea()
        {
            double perimeterHalf = GetPerimeter() / 2;

            return Math.Sqrt(perimeterHalf * (perimeterHalf - GetSide(X1, X2, Y1, Y2)) * (perimeterHalf - GetSide(X2, X3, Y2, Y3)) * (perimeterHalf - GetSide(X3, X1, Y3, Y1)));
        }

        public double GetPerimeter()
        {
            return GetSide(X1, X2, Y1, Y2) + GetSide(X2, X3, Y2, Y3) + GetSide(X3, X1, Y3, Y1);
        }

        public override string ToString()
        {
            return "the triangle with firts side = " + GetSide(X1, X2, Y1, Y2) + ", second side = " + GetSide(X2, X3, Y2, Y3) + " and third side = " + GetSide(X3, X1, Y3, Y1);
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != GetType())
            {
                return false;
            }

            Triangle t = (Triangle)o;

            return (X1 == t.X1) && (X2 == t.X2) && (X3 == t.X3) && (Y1 == t.Y1) && (Y2 == t.Y2) && (Y3 == t.Y3);
        }

        public override int GetHashCode()
        {
            int prime = 41;
            int hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}
