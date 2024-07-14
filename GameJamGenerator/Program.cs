namespace GameJamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, программисты. Это та генерация, которую я сделал для геймджема. Оцените код честно и если вам понравится, я сделаю генератор для вас <3");
            while (true)
            {
                GameGenerator gameGenerator = new GeneratorFactory();
                GlobalGenRandom.InitSeed((int)DateTime.Now.ToBinary());
                Console.WriteLine(new NoiseForest().Generate(GlobalGenRandom.Next(7)).ToString());//Вызываем генерацию и сразу делаем в ToString
                Console.ReadKey();
            }
        }
    }
}
