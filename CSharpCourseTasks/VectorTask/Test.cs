using System;

namespace VectorTask
{
    class Test
    {
        static void Main(string[] args)
        {

            Vector vector1 = new Vector(new double[] { 3.0, 4.0 });
            Vector vector2 = new Vector(new double[] { 2.1, 5.0, 1.5 });

            Vector vector3 = Vector.GetSum(vector1, vector2);
            Vector vector4 = Vector.GetSum(vector2, vector1);
            Vector vector5 = Vector.GetDifference(vector1, vector2);
            Vector vector6 = Vector.GetDifference(vector2, vector1);


            Console.WriteLine(vector3.ToString() + vector4 + vector5 + vector6 + Vector.GetScalar(vector1, vector2));

            Vector wrongVector = new Vector(-3);

            Console.ReadKey();
        }
    }
}
