using MindboxShapeLibrary;

namespace ShapeLibraryTest
{
    public class CircleTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CircleNotNullTest()
        {
            // Arrange
            double radius = 4.0;

            // Act
            var circle = new Circle(radius);

            // Assert
            Assert.NotNull(circle);
        }

        [Test]
        public void ZeroRadiusTest() => Assert.Catch<ArgumentException>(() => new Circle(0));

        [Test]
        public void NegativeRadiusTest() => Assert.Catch<ArgumentException>(() => new Circle(-2));

        [Test]
        [TestCase(double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity)]
        public void TooLargeRadiusTest(double radius) =>
            Assert.Catch<ArgumentException>(() => new Circle(radius));

        [Test]
        public void ResultOfCalcAreaTest()
        {
            // Arrange
            var circle = new Circle(5);
            var expected = Math.PI * 5 * 5;

            // Act
            var actual = circle.CalcArea();

            // Assert
            Assert.AreEqual(expected, actual, Constants.Eps);
        }
    }
}