public static class GetCellsByPos
{
    public static T[] GetNearFourCells<T>(this IGrid<T> grid, Vector2Int pos, T defaultCell = default) =>
        [pos.y == 0 ? defaultCell : grid[pos.x, pos.y - 1],              //Up
         pos.x + 1 == grid.Width ? defaultCell : grid[pos.x + 1, pos.y], //Right
         pos.y + 1 == grid.Height ? defaultCell : grid[pos.x, pos.y + 1],//Down
         pos.x == 0 ? defaultCell : grid[pos.x - 1, pos.y]];             //Left
    public static Vector2Int[] GetNearFourCells(this Vector2Int pos, Vector2Int minBound, Vector2Int maxBound)
    {
        List<Vector2Int> cells = [];
        if (pos.x != maxBound.x) cells.Add(pos + Vector2Int.Right);
        if (pos.x != minBound.x) cells.Add(pos + Vector2Int.Left);
        if (pos.y != maxBound.y) cells.Add(pos + Vector2Int.Down);
        if (pos.y != minBound.y) cells.Add(pos + Vector2Int.Up);
        return [..cells];
    }
}