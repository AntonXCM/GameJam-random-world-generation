public static partial class GridDrawingMethods
{
    public static bool DrawTile<T>(this IGrid<T> grid, IBrush<T> brush, Vector2Int pos) => grid.DrawTile(brush.GetValue(pos, grid[pos]), pos);
    public static bool DrawTile<T>(this IGrid<T> grid, T tile, Vector2Int pos)
    {
        if(!grid.SizeRect.IsInRect(pos)) return true;
        if(!grid[pos].Equals(tile)) grid[pos] = tile;
        return false;
    }
    public static bool DrawTile<T>(this IGrid<T> grid, T tile, T notAllowedTile, Vector2Int pos)
    {
        if(grid[pos].Equals(notAllowedTile)) return true;
        return grid.DrawTile(tile, pos);
    }
    public static bool DrawTile<T>(this IGrid<T> grid, T tile, T[] notAllowedTiles, Vector2Int pos)
    {
        if(notAllowedTiles.Any(t => grid[pos].Equals(t))) return true;
        return grid.DrawTile(tile, pos);
    }
}