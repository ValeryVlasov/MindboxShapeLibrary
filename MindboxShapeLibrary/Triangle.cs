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
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("The lengths of the sides must be greater than zero.");
            }

            if (a > (b + c) || b > (c + a) || c > (a + b))
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
            (Math.Abs(leg1 * leg1 + leg2 * leg2 - hypotenuse * hypotenuse) < IShape.Accuracy);
            return PythagoreanTheorem(a, b, c) || PythagoreanTheorem(a, c, b) || PythagoreanTheorem(b, c, a);
        }

        public double CalcArea()
        {
            var semiperimeter = (a + b + c) / 2.0;
            return Math.Sqrt(semiperimeter * (semiperimeter - a) * (semiperimeter - b) * (semiperimeter - c));
        }
    }
}
