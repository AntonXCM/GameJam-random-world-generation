public static partial class GridDrawingMethods
{
    /// <summary>
    /// Код рисования линии между двумя точками
    /// </summary>
    /// <typeparam name="T">Тип тайлов</typeparam>
    /// <param name="grid"> Сетка </param>
    /// <param name="drawingObject"> Тайл, которым мы рисуем</param>
    /// <param name="startPos"> Точка начала линии</param>
    /// <param name="endPos"> Точка конца линии</param>
    public static void DrawLine<T>(this IGrid<T> grid, T drawingObject, Vector2 startPos, Vector2 endPos) => grid.LineIterate(pos => {
        grid[pos] = drawingObject;
        return false;
        }, startPos, endPos);
}