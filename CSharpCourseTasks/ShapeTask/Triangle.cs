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

        public double X2
        {
            get;
            set;
        }

        public double X3
        {
            get;
            set;
        }

        public double Y1
        {
            get;
            set;
        }

        public double Y2
        {
            get;
            set;
        }

        public double Y3
        {
            get;
            set;
        }

        public Triangle(double x1, double x2, double x3, double y1, double y2, double y3)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.X3 = x3;
            this.Y1 = y1;
            this.Y2 = y2;
            this.Y3 = y3;
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
            double 
        }

        public double GetPerimeter()
        {
        
        }
    }
}
