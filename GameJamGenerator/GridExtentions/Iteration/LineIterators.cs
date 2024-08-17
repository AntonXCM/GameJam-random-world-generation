public static class LineIterators
{
    public static void LineIterate(this IGrid grid, Func<Vector2Int, bool> func, Vector2 startPos, Vector2 endPos) => LineIterate(pos => grid.SizeRect.IsInRect(pos) ?
    true : func(pos),startPos,endPos);
    public static void LineIterate(Func<Vector2Int,bool> func, Vector2 startPos, Vector2 endPos)
    {
        Vector2 direction = endPos - startPos;
        int distance = (int)Math.Max(Math.Abs(direction.x), Math.Abs(direction.y));
        direction.NormalizeMin1();
        Vector2Int lastCell = new(startPos);
        try
        {
            for(int i = 0; i <= distance; i++)
            {
                Vector2Int currentCell = new(startPos + direction * i);
                if(currentCell == lastCell) continue;
                if(currentCell.x != lastCell.x) invokeFunc(new(lastCell.x, currentCell.y));
                invokeFunc(currentCell);
                lastCell = currentCell;
                void invokeFunc(Vector2Int pos)
                {
                    if(func(pos)) throw new OperationCanceledException();
                }
            }
        }
        catch(OperationCanceledException) { return; }
        catch(Exception) { throw; }
    }
}