namespace MindboxShapeLibrary
{
    public class Triangle : ITriangle
    {
        public double a { get; }
        public double b { get; }
        public double c { get; }

        private readonly bool _isRightTriangle;
        public bool IsRightTriangle => _isRightTriangle;

        public Triangle(double a, double b, double c)
        {
            if (a <= 0 + IShape.Eps || b <= 0 + IShape.Eps || c <= 0 + IShape.Eps)
            {
                throw new ArgumentException("The lengths of the sides must be greater than zero.");
            }

            if (a - (b + c) > IShape.Eps || b - (a + c) > IShape.Eps || c - (a + b) > IShape.Eps)
            {
                throw new ArgumentException("No side can be larger than the other two.");
            }

            this.a = a;
            this.b = b;
            this.c = c;

            _isRightTriangle = getIsRightTriangle();
        }
        private bool getIsRightTriangle()
        {
            Func<double, double, double, bool> PythagoreanTheorem = (leg1, leg2, hypotenuse) =>
            (Math.Abs(Math.Pow(leg1, 2) + Math.Pow(leg2, 2) - Math.Pow(hypotenuse, 2)) < IShape.Accuracy);
            return PythagoreanTheorem(b, c, a) || PythagoreanTheorem(a, c, b) || PythagoreanTheorem(a, b, c);
        }

        public double CalcArea()
        {
            var semiperimeter = (a + b + c) / 2.0;
            return Math.Sqrt(semiperimeter * (semiperimeter - a) * (semiperimeter - b) * (semiperimeter - c));
        }
    }
}
