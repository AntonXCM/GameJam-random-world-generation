public static partial class TileDrawingMethods
{
    public static void DrawLine<T>(this IGrid<T> grid, Vector2Int pos, Direction direction, T drawingObject, int thickness)
    {
        double maxSize = thickness - (thickness / 2);
        for(int i = -thickness / 2; i < maxSize; i++)
        {
            int cos = (int)Math.Round(Math.Sqrt(maxSize*maxSize-i*i ));
            Vector2Int offset = direction switch
            {
                Direction.Right => Vector2Int.Left,
                Direction.Left => Vector2Int.Right,
                Direction.Up => Vector2Int.Down,
                _ => Vector2Int.Up,
            };
            grid.DrawLine((pos + offset * cos+offset.Rotate90()*i).ClampInGrid(grid), direction, drawingObject);
        }
    }
    public static void DrawLine<T>(this IGrid<T> grid, Vector2Int pos, Direction direction, T drawingObject) => grid.DrawLine(pos, direction, (pos, grid) =>grid.DrawTile(drawingObject, pos));
    public static void DrawLine<T>(this IGrid<T> grid, Vector2Int pos, Direction direction, T drawingObject,T stopObject) => grid.DrawLine(pos, direction, (pos, grid) => grid.DrawTile(drawingObject,stopObject,pos));
    static void DrawLine<T>(this IGrid<T> grid, Vector2Int pos, Direction direction, DrawDelegate<T> drawAction)
    {
        try{switch(direction)
        {
            case Direction.Down:
            int cols = grid.Height;
            for(; pos.y < cols; pos.y++)
                CheckAndDraw();
            break;
            case Direction.Up:
            for(; pos.y >= 0; pos.y--)
                CheckAndDraw();
            break;
            case Direction.Right:
            int rows = grid.Width;
            for(; pos.x < rows; pos.x++)
                CheckAndDraw();
            break;
            case Direction.Left:
            for(; pos.x >= 0; pos.x--)
                CheckAndDraw();
            break;
        }
        }catch(Exception ex)
        {
            if(ex.GetType() == typeof(OperationCanceledException)) return;
            throw;
        }
        void CheckAndDraw()
        { if(drawAction(pos, grid)) throw new OperationCanceledException(); }
    }
    delegate bool DrawDelegate<T>(Vector2Int pos, IGrid<T> grid);
}