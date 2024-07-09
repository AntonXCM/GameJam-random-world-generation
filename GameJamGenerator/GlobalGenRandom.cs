public static class GlobalGenRandom
{
    static Random random;
    public static double NextDouble() => random.NextDouble();
    public static float NextFloat() => (float)random.NextDouble();
    public static bool NextBool() => random.Next(0,2)==1;
    public static int Next() => random.Next();
    public static int Next(int max) => random.Next(max);
    public static int Next(int min, int max) => random.Next(min, ++max);
    public static int Next(Vector2Int bounds) => random.Next(bounds.x, ++bounds.y);
    public static void InitSeed(int seed) => random = new Random(seed);
}