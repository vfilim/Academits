using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] pp = { { 1, 2, 3 }, { 4, 5, 6 } };

            Matrix matrix = new Matrix(pp);
            matrix.GetTransposed();
            Console.WriteLine(matrix);
            
            Console.ReadKey();
        }
    }
}
