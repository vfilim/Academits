using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VectorTask
{
    public class Vector
    {
        public double[] Coordinates { get; set; }

        public Vector(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Dimensions count can't be < 0", nameof(n));
            }

            Coordinates = new double[n];

            for (int i = 0; i < n; i++)
            {
                Coordinates[i] = 0;
            }
        }

        public Vector(Vector vector)
        {
            int dimension = vector.Coordinates.Length;

            this.Coordinates = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                this.Coordinates[i] = vector.Coordinates[i];
            }
        }

        public Vector(params double[] coordinates)
        {
            int dimension = coordinates.Length;

            Coordinates = new double[dimension];

            for (int i = 0; i < dimension; i++)
            {
                Coordinates[i] = coordinates[i];
            }
        }

        public Vector(int n, params double[] coordinates)
        {
            if (n < 0)
            {
                throw new ArgumentException("Dimensions count can't be < 0", nameof(n));
            }

            int dimension = coordinates.Length;

            Coordinates = new double[n > dimension ? n : dimension];

            for (int i = 0; i < dimension; i++)
            {
                if (i > n - 1)
                {
                    Coordinates[i] = 0;
                }
                else
                {
                    Coordinates[i] = coordinates[i];
                }
            }
        }

        public int GetSize()
        {
            return Coordinates.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("{ ");

            int dimension = Coordinates.Length;

            for (int i = 0; i < dimension - 1; i++)
            {
                sb.Append(Coordinates[i] + ", ");
            }

            sb.Append(Coordinates[dimension - 1] + " }");

            return sb.ToString();
        }
        
        public void Add(Vector vector)
        {
            if (GetSize() >= vector.GetSize())
            {
                for (int i = 0; i < vector.GetSize(); i++)
                {
                    Coordinates[i] += vector.Coordinates[i];
                }
            }
            else
            {
                double[] newCoordinates = new double[vector.GetSize()];

                for (int i = 0; i < GetSize(); i++)
                {
                    newCoordinates[i] = Coordinates[i] + vector.Coordinates[i];
                }

                for (int i = GetSize(); i < vector.GetSize(); i++)
                {
                    newCoordinates[i] = vector.Coordinates[i];
                }

                Coordinates = newCoordinates;
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
            for (int i = 0; i < GetSize(); i++)
            {
                Coordinates[i] *= number;
            }
        }

        public void TurnOver()
        {
            MultiplyOnNumber(-1);
        }

        public double GetLength()
        {
            double lengthSquare = 0;

            for (int i = 0; i < GetSize(); i++)
            {
                lengthSquare += Math.Pow(Coordinates[i], 2);
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

            int smallerVectorSize = vector1.GetSize() < vector2.GetSize() ? vector1.GetSize() : vector2.GetSize(); 
            
            for (int i = 0; i < smallerVectorSize; i++)
            {
                scalar += vector1.Coordinates[i] * vector2.Coordinates[i];
            }

            return scalar;
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

            if (GetSize() != v.GetSize())
            {
                return false;
            }

            for (int i = 0; i < GetSize(); i++)
            {
                if (Coordinates[i] != v.Coordinates[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 27;
            int hash = 1;

            for (int i = 0; i < GetSize(); i++)
            {
                hash = prime * hash + Coordinates[i].GetHashCode();
            }

            return hash;
        }
    }
}
