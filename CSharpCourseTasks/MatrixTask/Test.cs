using System;
using VectorTask;
using System.Collections.Generic;
using System.Linq;
namespace MatrixTask
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] strings = { { 1, 2 }, { 4, 5 }, { 6, 7 } };

            Matrix matrix1 = new Matrix(strings);

            matrix1.Transpose();

            Console.WriteLine(matrix1);

            Vector vector1 = new Vector(1.0, 5.0, 8.0);
            Vector vector2 = new Vector(7.0, 9.0, 10.0, 3.0);

            Matrix matrix2 = new Matrix(vector1, vector2);

            Console.WriteLine(matrix2);

            Matrix matrix3 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } });
            matrix3.MultiplyOnVector(vector1);

            Console.WriteLine(matrix3);

            Matrix multiplier1 = new Matrix(new double[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Matrix multiplier2 = new Matrix(new double[,] { { 7, 8, 9, 10 }, { 11, 12, 13, 14 }, { 15, 16, 17, 18 }});

            Console.WriteLine(Matrix.GetMatrixMultiplication(multiplier1, multiplier2));

            Console.ReadKey();
        }
}
}
