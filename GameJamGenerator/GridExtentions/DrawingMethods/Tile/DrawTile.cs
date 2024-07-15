public static partial class GridDrawingMethods
{
    public static bool DrawTile<T>(this IGrid<T> grid, T tile, Vector2Int pos)
    {
        if(!grid[pos].Equals(tile)) grid[pos] = tile;
        return false;
    }
    public static bool DrawTile<T>(this IGrid<T> grid, T tile, T notAllowedTile, Vector2Int pos)
    {
        if(grid[pos].Equals(notAllowedTile)) return true;
        return grid.DrawTile(tile, pos);
    }
}