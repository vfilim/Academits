using System;
using System.Text;
using VectorTask;

namespace MatrixTask
{
    public class Matrix
    {
        private Vector[] strings;

        public Matrix(int stringsCount, int columnsCount)
        {
            if (stringsCount < 1)
            {
                throw new ArgumentException("Strings count can't be < 1, it is " + stringsCount, nameof(stringsCount));
            }

            if (stringsCount < 1)
            {
                throw new ArgumentException("Columns count can't be < 1, it is " + columnsCount, nameof(columnsCount));
            }

            strings = new Vector[stringsCount];

            for (int i = 0; i < stringsCount; i++)
            {
                strings[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            strings = new Vector[matrix.strings.Length];

            for (int i = 0; i < matrix.strings.Length; i++)
            {
                strings[i] = new Vector(matrix.strings[i]);
            }
        }

        public Matrix(double[,] numbers)
        {
            if (numbers.Length < 1)
            {
                throw new ArgumentException("Elements count can't be 0", nameof(numbers));
            }

            strings = new Vector[numbers.GetLength(0)];

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                strings[i] = new Vector(numbers.GetLength(1));
            }

            for (int i = 0; i < numbers.GetLength(0); i++)
            {
                for (int j = 0; j < numbers.GetLength(1); j++)
                {
                    strings[i].SetCoordinate(j, numbers[i, j]);
                }
            }
        }

        public Matrix(params Vector[] strings)
        {
            if (strings.Length == 0)
            {
                throw new ArgumentException("Strings count can't be 0", nameof(strings));
            }

            int coordinatesCount = 0;

            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].GetSize() > coordinatesCount)
                {
                    coordinatesCount = strings[i].GetSize();
                }
            }

            Vector[] matrixStrings = new Vector[strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                matrixStrings[i] = new Vector(coordinatesCount);

                for (int j = 0; j < strings[i].GetSize(); j++)
                {
                    matrixStrings[i].SetCoordinate(j, strings[i].GetCoordinate(j));
                }
            }

            this.strings = matrixStrings;
        }

        public int GetStringsCount()
        {
            return strings.Length;
        }

        public int GetColumnsCount()
        {
            return strings[0].GetSize();
        }

        public Vector GetColumn(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException("The index can't be < 0 (it is " + index + ")", nameof(index));
            }

            Vector column = new Vector(strings.Length);

            for (int i = 0; i < strings.Length; i++)
            {
                column.SetCoordinate(i, strings[i].GetCoordinate(index));
            }

            return column;
        }

        public void Transpose()
        {
            Matrix transposed = new Matrix(GetColumnsCount(), GetStringsCount());

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                transposed.strings[i] = GetColumn(i);
            }

            strings = transposed.strings;
        }

        public void MultiplyOnNumber(double number)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i].MultiplyOnNumber(number);
            }
        }

        public void MultiplyOnVector(Vector vector)
        {
            int vectorSize = vector.GetSize();

            if (vectorSize != GetColumnsCount())
            {
                throw new ArgumentException("The count of matrix columns must be equal to the vector coordinates count, they are " + GetStringsCount() + " and " + vector.GetSize(), nameof(vector));
            }

            double[] coordinates = new double[vectorSize];

            for (int i = 0; i < vectorSize; i++)
            {
                for (int j = 0; j < vectorSize; j++)
                {
                    coordinates[i] += strings[i].GetCoordinate(j) * vector.GetCoordinate(j);
                }
            }

            Array.Resize<Vector>(ref strings, 1);

            Vector resultVector = new Vector(coordinates);

            strings[0] = resultVector;
        }

        public double GetDeterminant()
        {
            double determinant = 0;



            return determinant;
        }

        public void AddMatrix(Matrix matrix)
        {
            if (GetStringsCount() != matrix.GetStringsCount() || GetColumnsCount() != matrix.GetColumnsCount())
            {
                throw new ArgumentException("The matrices sizes must be the same. They are (" + GetStringsCount() + ", " + GetColumnsCount() + ") and (" + matrix.GetStringsCount() + ", " + GetColumnsCount(), nameof(matrix));
            }

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i].Add(matrix.strings[i]);
            }
        }

        public void SubtractMatrix(Matrix matrix)
        {
            if (GetStringsCount() != matrix.GetStringsCount() || GetColumnsCount() != matrix.GetColumnsCount())
            {
                throw new ArgumentException("The matrices sizes must be the same. They are (" + GetStringsCount() + ", " + GetColumnsCount() + ") and (" + matrix.GetStringsCount() + ", " + GetColumnsCount(), nameof(matrix));
            }

            for (int i = 0; i < strings.Length; i++)
            {
                strings[i].Subtract(matrix.strings[i]);
            }
        }

        public static Matrix GetMatrixSum(Matrix matrix1, Matrix matrix2)
        {
            Matrix sum = new Matrix(matrix1);

            sum.AddMatrix(matrix2);

            return sum;
        }

        public static Matrix GetMatrixDifference(Matrix matrix1, Matrix matrix2)
        {
            Matrix dif = new Matrix(matrix1);

            dif.SubtractMatrix(matrix2);

            return dif;
        }

        public static Matrix GetMatrixMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetStringsCount())
            {
                throw new ArgumentException("The first matrix columns count must be equal to the second matrix strings count, they are " + matrix1.GetColumnsCount() + " and " + matrix2.GetStringsCount(), nameof(matrix1) + ", " + nameof(matrix2));
            }

            Matrix multiplication = new Matrix(matrix1.GetStringsCount(), matrix2.GetColumnsCount());

            for (int i = 0; i < matrix1.GetStringsCount(); i++)
            {
                for (int j = 0; j < matrix2.GetColumnsCount(); j++)
                {
                    multiplication.strings[i].SetCoordinate(j, Vector.GetScalarMultiplication(matrix1.strings[i], matrix2.GetColumn(j)));
                }
            }

            return multiplication;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{");
            for (int i = 0; i < strings.Length - 1; i++)
            {
                sb.Append(strings[i]);
                sb.Append(", ");
            }
            sb.Append(strings[strings.Length - 1]);
            sb.Append("}");

            return sb.ToString();
        }
    }
}
