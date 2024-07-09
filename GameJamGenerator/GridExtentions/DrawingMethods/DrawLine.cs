public static partial class GridDrawingMethods
{
    public static void DrawLine<T>(this IGrid<T> grid, T drawingObject, Vector2 startPos, Vector2 endPos)
    {
        Vector2 direction = endPos - startPos;
        int distance = (int)Math.Max(Math.Abs(direction.x), Math.Abs(direction.y));
        direction.NormalizeMin1();
        Vector2Int lastCell = new(startPos);
        for (int i = 0; i <= distance; i++)
        {
            Vector2Int currentCell = new(startPos + direction * i);
            if (currentCell.x != lastCell.x)
                grid[new(lastCell.x, currentCell.y)] = drawingObject;
            grid[currentCell] = drawingObject;
            lastCell = currentCell;
        }
    }
}