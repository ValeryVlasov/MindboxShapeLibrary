namespace MindboxShapeLibrary
{
    public class Circle : IShape
    {
        public double Radius { get; }
        public Circle(double radius)
        {
            if (radius <= 0 + IShape.Eps)
                throw new ArgumentException("Invalid radius of circle", nameof(radius));
            Radius = radius;
        }

        public double CalcArea() => Math.PI * Math.Pow(Radius, 2);
    }
}
