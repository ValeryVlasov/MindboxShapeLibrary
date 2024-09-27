namespace MindboxShapeLibrary
{
    public class Circle : IShape
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("Invalid radius of circle", nameof(radius));
            if (double.IsInfinity(radius))
                throw new ArgumentException("Radius of circle is too large", nameof(radius));
            Radius = radius;
        }

        public double CalcArea() => Math.PI * Math.Pow(Radius, 2);
    }
}
