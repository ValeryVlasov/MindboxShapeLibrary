using MindboxShapeLibrary;

namespace ShapeLibraryTest
{
    public class TriangleTest
    {
        [Test]
        public void TriangleNotNullTest()
        {
            // Arrange
            double a = 5, b = 6, c = 10;

            // Act
            var triangle = new Triangle(a, b, c);

            // Assert
            Assert.NotNull(triangle);
        }

        [Test]
        public void SideEqualityTest()
        {
            // Arrange
            double a = 3, b = 4, c = 5;

            // Act
            var triangle = new Triangle(a, b, c);

            // Assert
            Assert.Less(Math.Abs(triangle.a - a), Constants.Eps);
            Assert.Less(Math.Abs(triangle.b - b), Constants.Eps);
            Assert.Less(Math.Abs(triangle.c - c), Constants.Eps);
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
        [TestCase(3, 10, 50)]
        [TestCase(3, 50, 10)]
        [TestCase(50, 3, 10)]
        public void InitWithOneSideLargerOthersTwoTest(double a, double b, double c) =>
                        Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));

        [Test]
        public void ResultOfCalcAreaTest()
        {
            // Arrange
            double a = 3, b = 4, c = 5;
            double expected = 6;
            var triangle = new Triangle(a, b, c);

            // Act
            var actual = triangle.CalcArea();

            // Assert
            Assert.Less(Math.Abs(actual - expected), Constants.Eps);
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