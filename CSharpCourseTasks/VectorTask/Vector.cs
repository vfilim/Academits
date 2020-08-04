using System;
using System.Text;

namespace VectorTask
{
    public class Vector
    {
        private double[] coordinates;

        public Vector(int dimensionsCount)
        {
            if (dimensionsCount < 1)
            {
                throw new ArgumentException("Dimensions count can't be < 1", nameof(dimensionsCount));
            }

            coordinates = new double[dimensionsCount];

            for (int i = 0; i < dimensionsCount; i++)
            {
                coordinates[i] = 0;
            }
        }

        public Vector(Vector vector)
        {
            int dimension = vector.GetSize();

            coordinates = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                coordinates[i] = vector.GetCoordinate(i);
            }
        }

        public Vector(params double[] coordinates)
        {
            int dimension = coordinates.Length;

            this.coordinates = new double[dimension];

            coordinates.CopyTo(this.coordinates, 0);
        }

        public Vector(int dimensionsCount, params double[] coordinates)
        {
            if (dimensionsCount < 1)
            {
                throw new ArgumentException("Dimensions count can't be < 1", nameof(dimensionsCount));
            }

            int dimension = coordinates.Length;

            this.coordinates = new double[Math.Max(dimensionsCount, dimension)];

            for (int i = 0; i < dimension; i++)
            {
                if (i > dimensionsCount - 1)
                {
                    this.coordinates[i] = 0;
                }
                else
                {
                    this.coordinates[i] = coordinates[i];
                }
            }
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
            if (coordinates.Length >= vector.GetSize())
            {
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    coordinates[i] += vector.GetCoordinate(i);
                }
            }
            else
            {
                double[] newCoordinates = new double[vector.GetSize()];

                for (int i = 0; i < GetSize(); i++)
                {
                    newCoordinates[i] = coordinates[i] + vector.GetCoordinate(i);
                }

                for (int i = GetSize(); i < vector.GetSize(); i++)
                {
                    newCoordinates[i] = vector.GetCoordinate(i);
                }

                coordinates = newCoordinates;
            }
        }

        public void Subtract(Vector vector)
        {
            Vector vectorCopy = new Vector(vector);
            vectorCopy.MultiplyOnNumber(-1);

            Add(vectorCopy);
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

        public static double GetScalar(Vector vector1, Vector vector2)
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

            int dimension = coordinates.Length;

            for (int i = 0; i < dimension - 1; i++)
            {
                sb.Append(coordinates[i]);
                sb.Append(", ");
            }

            sb.Append(coordinates[dimension - 1]);
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
