using MathA;

namespace GameJamGenerator
{
    internal class Program
    {
        static void Main()
        {
            start:
                Console.WriteLine(new River().Generate(new()).ToString());//Вызываем генерацию и сразу делаем в ToString
                Console.ReadLine();
            goto start;
        }
    }
}
