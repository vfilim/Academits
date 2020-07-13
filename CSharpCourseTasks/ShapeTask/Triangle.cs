using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    public class Triangle : IShape
    {
        public double X1
        {
            get;
            set;
        }

        public double Y1
        {
            get;
            set;
        }

        public double X2
        {
            get;
            set;
        }

        public double Y2
        {
            get;
            set;
        }

        public double X3
        {
            get;
            set;
        }

        public double Y3
        {
            get;
            set;
        }

        double side1;
        double side2;
        double side3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;

            side1 = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
            side2 = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
            side3 = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));
        }

        public double GetWidth()
        {
            double leftPoint = Math.Min(Math.Min(X1, X2), X3);
            double rightPoint = Math.Max(Math.Max(X1, X2), X3);

            return rightPoint - leftPoint;
        }

        public double GetHight()
        {
            double lowerPoint = Math.Min(Math.Min(Y1, Y2), Y3);
            double upperPoint = Math.Max(Math.Max(Y1, Y2), Y3);

            return upperPoint - lowerPoint;
        }

        public double GetArea()
        {
            double perimeterHalf = GetPerimeter() / 2;

            return Math.Sqrt(perimeterHalf * (perimeterHalf - side1) * (perimeterHalf - side2) * (perimeterHalf - side3));
        }

        public double GetPerimeter()
        {
            return side1 + side2 + side3;
        }
    }
}
