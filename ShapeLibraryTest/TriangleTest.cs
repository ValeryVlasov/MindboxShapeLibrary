using MindboxShapeLibrary;

namespace ShapeLibraryTest
{
    public class TriangleTest
    {
        private const double eps = 1e-7;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void InitTriangleTest()
        {
            // Arrange
            double a = 3, b = 4, c = 5;

            // Act
            var triangle = new Triangle(a, b, c);

            // Assert
            Assert.NotNull(triangle);
            Assert.Less(Math.Abs(triangle.a - a), IShape.Accuracy);
            Assert.Less(Math.Abs(triangle.b - b), IShape.Accuracy);
            Assert.Less(Math.Abs(triangle.c - c), IShape.Accuracy);
        }

        [Test]
        [TestCase(0, 4, 5)]
        [TestCase(3, 0, 5)]
        [TestCase(3, 4, 0)]
        public void InitTriangleWithZeroValuesTest(double a, double b, double c) =>
            Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));

        [Test]
        [TestCase(-3, 4, 5)]
        [TestCase(3, -4, 5)]
        [TestCase(3, 4, -5)]
        public void InitTriangleWithNegativeValuesTest(double a, double b, double c) =>
            Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));

        [Test]
        public void InitWithOneSideLargerOthersTwoTest() =>
                        Assert.Catch<ArgumentException>(() => new Triangle(3, 3, 50));

        [Test]
        public void CalcAreaTest()
        {
            // Arrange
            double a = 3, b = 4, c = 5;
            double expected = 6;
            var triangle = new Triangle(a, b, c);

            // Act
            var actual = triangle.CalcArea();

            // Assert
            Assert.NotNull(actual);
            Assert.Less(Math.Abs(actual - expected), IShape.Accuracy);
        }

        [Test]
        [TestCase(3, 4, 5, ExpectedResult = true)]
        [TestCase(6, 8, 10, ExpectedResult = true)]
        [TestCase(6, 7, 10, ExpectedResult = false)]
        [TestCase(6, 8, 10 + 1e-9, ExpectedResult = true)]
        [TestCase(6, 8, 10 + 2e-7, ExpectedResult = false)]
        public bool RightTriangleTest(double a, double b, double c)
        {
            // Arrange
            var triangle = new Triangle(a, b, c);

            // Act
            var isRight = triangle.IsRightTriangle;

            // Assert
            return isRight;
        }
    }
}