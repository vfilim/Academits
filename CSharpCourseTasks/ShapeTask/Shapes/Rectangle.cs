namespace ShapeTask.Shapes
{
    public class Rectangle : IShape
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public double GetWidth()
        {
            return Width;
        }

        public double GetHeight()
        {
            return Height;
        }

        public double GetArea()
        {
            return Width * Height;
        }

        public double GetPerimeter()
        {
            return (2 * Width) + (2 * Height);
        }

        public override string ToString()
        {
            return "The rectangle with one side = " + Width + " and another side = " + Height;
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

            Rectangle r = (Rectangle)o;

            return (Width == r.Width) && (Height == r.Height);
        }

        public override int GetHashCode()
        {
            int prime = 31;
            int hash = 1;

            hash = prime * hash + Width.GetHashCode();
            hash = prime * hash + Height.GetHashCode();

            return hash;
        }
    }
}
