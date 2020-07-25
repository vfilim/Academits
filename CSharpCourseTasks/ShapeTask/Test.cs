using System;
using ShapeTask.Shapes;

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
            IShape[] shapes =
            {
                new Circle(2),
                new Square(20),
                new Triangle(0, 0, 0, 3, 4, 0),
                new Rectangle(2000, 5000),
                new Triangle(-3, 2, 2, 4, 0, 0)
            };

            Console.WriteLine("The shape with the biggest area is " + GetMaxAreaShape(shapes));

            Console.WriteLine("The shape with the second longest perimeter is " + GetSecondPerimeterShape(shapes));

            Console.ReadKey();
        }
    }
}
