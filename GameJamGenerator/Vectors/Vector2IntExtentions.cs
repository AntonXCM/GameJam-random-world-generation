public static class Vector2IntExtentions
{
    public static Vector2Int ClampInGrid(this Vector2 vector, IGrid grid) => new Vector2Int(vector).Clamp(Vector2Int.Zero, grid.Size - Vector2Int.One);
    public static Vector2Int ClampInGrid(this Vector2Int vector, IGrid grid) => vector.Clamp(Vector2Int.Zero, grid.Size - Vector2Int.One);
    public static Vector2Int Clamp(this Vector2Int vector, Vector2Int min, Vector2Int max)
    {
        if(min.x > max.x || min.y > max.y) throw new ArgumentOutOfRangeException("Максимум меньше минимума? Ты чё, гений-Альберт-Энштейн???");
        return new(Math.Clamp(vector.x, min.x, max.x), Math.Clamp(vector.y, min.y, max.y));
    }
    public static Vector2Int Perpendicular(this Vector2Int vector) => new(vector.y, -vector.x);
    public static bool AnyLessThan(this Vector2Int vector, int value) => vector.AnyLessThan(Vector2Int.One * value);
    public static bool AnyLessThan(this Vector2Int vector, Vector2Int value) => vector.x < value.x || vector.y < value.y;
    public static bool AnyMoreThan(this Vector2Int vector, int value) => vector.AnyMoreThan(Vector2Int.One * value);
    public static bool AnyMoreThan(this Vector2Int vector, Vector2Int value) => vector.x > value.x || vector.y > value.y;
}