namespace MindboxShapeLibrary
{
    public interface ITriangle : IShape
    {
        public double a { get; }
        public double b { get; }
        public double c { get; }
        public bool IsRightTriangle { get; }
    }
}
