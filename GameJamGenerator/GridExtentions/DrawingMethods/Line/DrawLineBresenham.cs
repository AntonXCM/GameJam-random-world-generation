public static partial class GridDrawingMethods
{
    /// <summary>
    /// Код рисования линии по алгоритму Брезенхэма 
    /// https://ru.wikipedia.org/wiki/%D0%90%D0%BB%D0%B3%D0%BE%D1%80%D0%B8%D1%82%D0%BC_%D0%91%D1%80%D0%B5%D0%B7%D0%B5%D0%BD%D1%85%D1%8D%D0%BC%D0%B0
    /// </summary>
    /// <typeparam name="T">Тип тайлов</typeparam>
    /// <param name="grid"> Сетка </param>
    /// <param name="drawingObject"> Тайл, которым мы рисуем</param>
    /// <param name="startPos"> Точка начала линии</param>
    /// <param name="endPos"> Точка конца линии</param>
    public static void DrawLine<T>(this IGrid<T> grid, T drawingObject, Vector2 startPos, Vector2 endPos)
    {
        Vector2 direction = endPos - startPos;
        int distance = (int)Math.Max(Math.Abs(direction.x), Math.Abs(direction.y));
        direction.NormalizeMin1();
        Vector2Int lastCell = new(startPos);
        for (int i = 0; i <= distance; i++)
        {
            Vector2Int currentCell = new(startPos + direction * i);
            if (currentCell == lastCell) continue;
            if (currentCell.x != lastCell.x) grid[new(lastCell.x, currentCell.y)] = drawingObject;
            grid[currentCell] = drawingObject;
            lastCell = currentCell;
        }
    }
}