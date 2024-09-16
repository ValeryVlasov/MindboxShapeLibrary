using MindboxShapeLibrary;

namespace ShapeLibraryTest
{
    public class CircleTest
    {
        private const double eps = 1e-7;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ZeroRadiusTest() => Assert.Catch<ArgumentException>(() => new Circle(0));

        [Test]
        public void NegativeRadiusTest() => Assert.Catch<ArgumentException>(() => new Circle(-2));

        [Test]
        public void CalcAreaTest()
        {
            // Arrange
            var radius = 5;
            var circle = new Circle(radius);
            var expected = 25 * Math.PI;

            // Act
            var actual = circle.CalcArea();

            // Assert
            //Assert.AreEqual(expected, actual);
            //Assert.That(Math.Abs(actual - expected), Is.LessThan(eps));
            Assert.Less(Math.Abs(actual - expected), eps);

        }
    }
}