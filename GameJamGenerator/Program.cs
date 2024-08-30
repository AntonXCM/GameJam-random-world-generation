using MathA;

namespace GameJamGenerator
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine(new VectorGrid(5, 5, 1));
            start:
                Console.WriteLine(new PerlinNoiseLevel().Generate(0).ToString());//Вызываем генерацию и сразу делаем в ToString
                Console.ReadLine();
            goto start;

        }
    }
}
