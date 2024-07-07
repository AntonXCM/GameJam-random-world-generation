namespace GameJamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                GameGenerator gameGenerator = new GeneratorFactory();
                GlobalGenRandom.InitSeed((int)DateTime.Now.ToBinary());
                Console.WriteLine(new GeneratorFactory().Generate(GlobalGenRandom.Next(7)).ToString());//Вызываем генерацию и сразу делаем в ToString
                Console.ReadKey();
            }
        }
    }
}
