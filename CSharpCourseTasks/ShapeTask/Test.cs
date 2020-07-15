using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask
{
    class Test
    {
        public static IShape GetMaxAreaShape(params IShape[] shapes)
        {
            Array.Sort(shapes, new AreaComparer());

            return shapes[shapes.Length - 1];
        }

        public static IShape GetSecondPerimeterShape(params IShape[] shapes)
        {
            Array.Sort(shapes, new PerimeterComparer());

            return shapes[shapes.Length - 2];
        }

        static void Main(string[] args)
        {
            Circle circle = new Circle(2);
            Square square = new Square(20);
            Triangle triangle1 = new Triangle(0, 0, 0, 3, 4, 0);
            Rectangle rectangle = new Rectangle(2000, 5000);
            Triangle triagnle2 = new Triangle(-3, 2, 2, 4, 0, 0);

            IShape[] shapes =
            {
                circle,
                square,
                triangle1,
                rectangle,
                triagnle2
            };

            Console.WriteLine(GetMaxAreaShape(shapes).ToString())

            Console.WriteLine(GetSecondPerimeterShape(shapes).ToString());

            Console.ReadKey();
        }
    }
}
