using MathA;

using System.Diagnostics;

namespace GameJamGenerator
{
    internal class Program
    {
        static void Main()
        {
            start:
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
                Console.WriteLine(new River().Generate(new()).ToString());//Вызываем генерацию и сразу делаем в ToString
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
            goto start;
        }
    }
}
