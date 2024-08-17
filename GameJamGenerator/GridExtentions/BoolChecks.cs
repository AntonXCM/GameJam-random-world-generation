public static class BoolChecks
{
    public static bool IsEquals<T>(this IGrid<T> grid, Vector2Int pos, params T[] tiles)
    {
        T tile = grid[pos];
        return tiles.Any(t => tile.Equals(t));
    }
}