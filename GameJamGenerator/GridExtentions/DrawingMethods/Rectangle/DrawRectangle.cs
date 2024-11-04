public static partial class GridDrawingMethods
{
    public static void DrawRect<T>(this IGrid<T> grid, T drawingObject, RectInt rectInt) => (rectInt & grid.SizeRect).IterateParallel(v => DrawTile(grid, v, drawingObject));
    public static void DrawRect<T>(this IGrid<T> grid, IBrush<T> brush, RectInt rectInt) => (rectInt & grid.SizeRect).IterateParallel(v => DrawTile(grid, v, brush));
}