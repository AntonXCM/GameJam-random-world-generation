public static partial class TileDrawingMethods
{
    public static void DrawLine<T>(this IGrid<T> grid, Vector2Int pos, Vector2Int direction, T drawingObject, int thickness)
    {
        Vector2Int offset = direction*-1;
        double maxSize = thickness - (thickness / 2);
        for(int i = -thickness / 2; i < maxSize; i++)
        {
            int cos = (int)Math.Round(Math.Sqrt(maxSize*maxSize-i*i ));
            grid.DrawLine((pos + offset * cos+offset.Perpendicular()*i).ClampInGrid(grid), direction, drawingObject);
        }
    }
    public static void DrawLine<T>(this IGrid<T> grid, Vector2Int pos, Vector2Int direction, T drawingObject) => grid.DrawLine(pos, direction, (pos, grid) => grid.DrawTile(drawingObject, pos));
    public static void DrawLine<T>(this IGrid<T> grid, Vector2Int pos, Vector2Int direction, T drawingObject,T[] stopObjects) => grid.DrawLine(pos, direction, (pos, grid) => grid.DrawTile(drawingObject,stopObjects,pos));
    static void DrawLine<T>(this IGrid<T> grid, Vector2Int pos, Vector2Int direction, DrawDelegate<T> drawAction)
    {
        if(direction == Vector2Int.Zero) throw new ArgumentNullException("Натурально нулевое направление!");
        Vector2Int size = grid.Size;
        for(; pos < size && pos>=0; pos += direction)
            if(drawAction(pos, grid)) return;
    }
    delegate bool DrawDelegate<T>(Vector2Int pos, IGrid<T> grid);
}