using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VectorTask;

namespace MatrixTask
{
    public class Matrix
    {
        public Vector[] Vectors { get; set; }

        public Matrix(int m, int n)
        {
            Vectors = new Vector[m];

            for (int i = 0; i < m; i++)
            {
                Vectors[i] = new Vector(n);
            }
        }

        public Matrix(Matrix matrix)
        {
            Vectors = new Vector[matrix.Vectors.Length];

            for (int i = 0; i < matrix.Vectors.Length; i++)
            {
                Vectors[i] = new Vector(matrix.Vectors[i]);
            }
        }

        public Matrix(double[,] numbers)
        {
            Vectors = new Vector[numbers.GetLength(0)];

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                Vectors[i] = new Vector(numbers.GetLength(1));
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    Vectors[i].Coordinates[j] = numbers[i, j];
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            Vectors = vectors;
        }

        public int[] GetSize()
        {
            int[] size = new int[2];

            size[0] = Vectors.Length;
            size[1] = Vectors[0].GetSize();

            return size;
        }

        public Vector GetColumn(int j)
        {
            Vector column = new Vector(Vectors.Length);

            for (int i = 0; i < Vectors.Length; i++)
            {
                column.Coordinates[i] = Vectors[i].Coordinates[j];
            }

            return column;
        }

        public void GetTransposed()
        {
            Matrix transposed = new Matrix(GetSize()[1], GetSize()[0]);

            for (int i = 0; i < GetSize()[1]; i++)
            {
                transposed.Vectors[i] = GetColumn(i);
            }

            Vectors = transposed.Vectors;
        }

        public void MultiplyOnNumber(double number)
        {
            for (int i = 0; i < Vectors.Length; i++)
            {
                for (int j = 0; j < Vectors[0].GetSize(); j++)
                {
                    Vectors[i].Coordinates[j] *= number;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            for (int i = 0; i < Vectors.Length - 1; i++)
            {
                sb.Append(Vectors[i].ToString());
                sb.Append(", ");
            }
            sb.Append(Vectors[Vectors.Length - 1]);
            sb.Append("}");

            return sb.ToString();
        }
    }
}
