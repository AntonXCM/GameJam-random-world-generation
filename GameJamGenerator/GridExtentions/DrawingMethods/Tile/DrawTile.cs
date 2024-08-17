public static partial class GridDrawingMethods
{
    public static bool DrawTile<T>(this IGrid<T> grid, Vector2Int pos, IBrush<T> brush, params T[] notAllowedTiles)
    {
        if(grid.IsEquals(pos,notAllowedTiles)) return true;
        return grid.DrawTile(pos, brush);
    }
    public static bool DrawTile<T>(this IGrid<T> grid, Vector2Int pos,IBrush<T> brush) => grid.DrawTile(pos,brush.GetValue(pos, grid[pos]));
    public static bool DrawTile<T>(this IGrid<T> grid, Vector2Int pos, T tile)
    {
        if(!grid.SizeRect.IsInRect(pos)) return true;
        if(!grid[pos].Equals(tile)) grid[pos] = tile;
        return false;
    }
    public static bool DrawTile<T>(this IGrid<T> grid, Vector2Int pos, T tile, params T[] notAllowedTiles)
    {
        if(grid.IsEquals(pos,notAllowedTiles)) return true;
        return grid.DrawTile(pos,tile);
    }
}