namespace GameJamGenerator
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                GlobalGenRandom.InitSeed((int)DateTime.Now.ToBinary());
                Console.WriteLine(new NoiseForest().Generate(GlobalGenRandom.Next(7)).ToString());//Вызываем генерацию и сразу делаем в ToString
                Console.ReadKey();
            }
        }
    }
}
