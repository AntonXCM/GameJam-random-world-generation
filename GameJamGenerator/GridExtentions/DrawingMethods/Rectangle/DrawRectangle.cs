public static partial class GridDrawingMethods
{
    public static void DrawRect<T>(this IGrid<T> grid, T drawingObject, RectInt rectInt) => (rectInt & grid.SizeRect).Iterate(v => DrawTile(grid, drawingObject, v));
    public static void DrawRect<T>(this IGrid<T> grid, IBrush<T> brush, RectInt rectInt) => (rectInt & grid.SizeRect).Iterate(v => DrawTile(grid, brush, v));
}