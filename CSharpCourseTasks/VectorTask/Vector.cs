using System;
using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] coordinates;

        public Vector(int coordinatesCount)
        {
            if (coordinatesCount < 1)
            {
                throw new ArgumentException("Coordinates count can't be < 1, it is " + coordinatesCount, nameof(coordinatesCount));
            }

            coordinates = new double[coordinatesCount];
        }

        public Vector(Vector vector)
        {
            int coordinatesCount = vector.GetSize();

            coordinates = new double[coordinatesCount];

            vector.coordinates.CopyTo(coordinates, 0);
        }

        public Vector(params double[] coordinates)
        {
            int coordinatesCount = coordinates.Length;

            if (coordinatesCount < 1)
            {
                throw new ArgumentException("Coordinates count can't be < 1, it is " + coordinatesCount, nameof(coordinatesCount));
            }

            this.coordinates = new double[coordinatesCount];

            coordinates.CopyTo(this.coordinates, 0);
        }

        public Vector(int vectorCoordinatesCount, params double[] coordinates)
        {
            if (vectorCoordinatesCount < 1)
            {
                throw new ArgumentException("Coordinates count can't be < 1, it is " + vectorCoordinatesCount, nameof(vectorCoordinatesCount));
            }

            int coordinatesCount = coordinates.Length;

            this.coordinates = new double[vectorCoordinatesCount];

            Array.Copy(coordinates, 0, this.coordinates, 0, Math.Min(coordinatesCount, vectorCoordinatesCount));
        }

        public double GetCoordinate(int index)
        {
            return coordinates[index];
        }

        public void SetCoordinate(int index, double value)
        {
            coordinates[index] = value;
        }

        public int GetSize()
        {
            return coordinates.Length;
        }

        public void Add(Vector vector)
        {
            double[] newCoordinates = new double[Math.Max(coordinates.Length, vector.GetSize())];

            vector.coordinates.CopyTo(newCoordinates, 0);

            for (int i = 0; i < GetSize(); i++)
            {
                newCoordinates[i] += coordinates[i];
            }

            coordinates = newCoordinates;
        }

        public void Subtract(Vector vector)
        {
            double[] newCoordinates = new double[Math.Max(coordinates.Length, vector.GetSize())];

            vector.coordinates.CopyTo(newCoordinates, 0);

            for (int i = 0; i < GetSize(); i++)
            {
                newCoordinates[i] -= coordinates[i];
            }

            coordinates = newCoordinates;
        }

        public void MultiplyOnNumber(double number)
        {
            for (int i = 0; i < coordinates.Length; i++)
            {
                coordinates[i] *= number;
            }
        }

        public void TurnOver()
        {
            MultiplyOnNumber(-1);
        }

        public double GetLength()
        {
            double lengthSquare = 0;

            foreach (double c in coordinates)
            {
                lengthSquare += Math.Pow(c, 2);
            }

            return Math.Sqrt(lengthSquare);
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector sum = new Vector(vector1);

            sum.Add(vector2);

            return sum;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector dif = new Vector(vector1);

            dif.Subtract(vector2);

            return dif;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double scalar = 0;

            int smallerVectorSize = Math.Min(vector1.GetSize(), vector2.GetSize());

            for (int i = 0; i < smallerVectorSize; i++)
            {
                scalar += vector1.GetCoordinate(i) * vector2.GetCoordinate(i);
            }

            return scalar;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{ ");

            int newCoordinatesCount = coordinates.Length;

            for (int i = 0; i < newCoordinatesCount - 1; i++)
            {
                sb.Append(coordinates[i]);
                sb.Append(", ");
            }

            sb.Append(coordinates[newCoordinatesCount - 1]);
            sb.Append(" }");

            return sb.ToString();
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

            Vector v = (Vector)o;

            if (coordinates.Length != v.GetSize())
            {
                return false;
            }

            for (int i = 0; i < coordinates.Length; i++)
            {
                if (coordinates[i] != v.GetCoordinate(i))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 17;
            int hash = 1;

            foreach (double c in coordinates)
            {
                hash = prime * hash + c.GetHashCode();
            }

            return hash;
        }
    }
}
