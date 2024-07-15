namespace GameJamGenerator
{
    internal class Program
    {
        static void Main()
        {
            while(true)
            {
                Console.WriteLine(new NoiseForest().Generate(0).ToString());//Вызываем генерацию и сразу делаем в ToString
                Console.ReadLine();
            }
        }
    }
}
