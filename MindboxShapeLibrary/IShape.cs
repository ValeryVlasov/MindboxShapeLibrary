namespace MindboxShapeLibrary
{
    public interface IShape
    {
        public const double Eps = 1e-6;
        public double CalcArea();
    }
}
