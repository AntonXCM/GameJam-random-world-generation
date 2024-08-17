namespace MathA;
public static class Vector
{
    public static Vector2Int MaxBoth(params Vector2Int[] vectors) => vectors.OrderByDescending(v => v.x + v.y).First();
    public static Vector2Int MinBoth(params Vector2Int[] vectors) => vectors.OrderBy(v => v.x + v.y).First();
    public static Vector2Int MaxMagnitude(params Vector2Int[] vectors) => vectors.OrderByDescending(v => v.Magnitude).First();
    public static Vector2Int MinMagnitude(params Vector2Int[] vectors) => vectors.OrderBy(v => v.Magnitude).First();
    public static Vector2Int Abs(this Vector2Int vector)=> new(Math.Abs(vector.x), Math.Abs(vector.y));
    public static Vector2Int ClampInGrid(this Vector2 vector, IGrid grid) => new Vector2Int(vector).Clamp(Vector2Int.Zero, grid.Size - Vector2Int.One);
    public static Vector2Int ClampInGrid(this Vector2Int vector, IGrid grid) => vector.Clamp(Vector2Int.Zero, grid.Size - Vector2Int.One);
    public static Vector2Int Clamp(this Vector2Int vector, Vector2Int min, Vector2Int max)
    {
        if(min.x > max.x || min.y > max.y) throw new ArgumentOutOfRangeException("Максимум меньше минимума? Ты чё, гений-Альберт-Энштейн???");
        return new(Math.Clamp(vector.x, min.x, max.x), Math.Clamp(vector.y, min.y, max.y));
    }
    public static Vector2 Perpendicular(this Vector2 vector) => new(vector.y, -vector.x);
    public static Vector2Int Perpendicular(this Vector2Int vector) => new(vector.y, -vector.x);
    public static bool AnyLessThan(this Vector2Int vector, int value) => vector.AnyLessThan(Vector2Int.One * value);
    public static bool AnyLessThan(this Vector2Int vector, Vector2Int value) => vector.x < value.x || vector.y < value.y;
    public static bool AnyMoreThan(this Vector2Int vector, int value) => vector.AnyMoreThan(Vector2Int.One * value);
    public static bool AnyMoreThan(this Vector2Int vector, Vector2Int value) => vector.x > value.x || vector.y > value.y;
    public static Vector2 Abs(this Vector2 vector) => new(Math.Abs(vector.x), Math.Abs(vector.y));
}