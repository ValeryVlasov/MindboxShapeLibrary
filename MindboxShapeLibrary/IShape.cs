namespace MindboxShapeLibrary
{
    public interface IShape
    {
        // Константа, используемая для сравнения чисел с плавающей точкой
        public const double Eps = 1e-6;
        public double CalcArea();
    }
}
