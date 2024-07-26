namespace MathA;
public static class Vector
{
    public static Vector2Int MaxBoth(params Vector2Int[] vectors) => vectors.OrderByDescending(v => v.x + v.y).First();
    public static Vector2Int MinBoth(params Vector2Int[] vectors) => vectors.OrderBy(v => v.x + v.y).First();
    public static Vector2Int MaxMagnitude(params Vector2Int[] vectors) => vectors.OrderByDescending(v => v.Magnitude).First();
    public static Vector2Int MinMagnitude(params Vector2Int[] vectors) => vectors.OrderBy(v => v.Magnitude).First();
}