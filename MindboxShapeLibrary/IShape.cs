namespace MindboxShapeLibrary
{
    public interface IShape
    {
        public const double Accuracy = 1e-7;
        public const double Eps = 1e-6;
        public double CalcArea();
    }
}
