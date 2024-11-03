using MathA;

public static class SimpleItarationMethods
{
    public static void Iterate(this IGrid grid, Func<Vector2Int, bool> iterationFunction, Direction direction = Direction.Right, List<int> ignoreList = null, ActionStopMode actionStopMode = ActionStopMode.None) => grid.SizeRect.Iterate(iterationFunction, direction, ignoreList, actionStopMode);
    public static void Iterate<T>(this T[,] grid, Func<Vector2Int, bool> iterationFunction, Direction direction = Direction.Right, List<int> ignoreList = null, ActionStopMode actionStopMode = ActionStopMode.None) => Iterate(new RectInt(grid.GetLength(0), grid.GetLength(1)),iterationFunction, direction, ignoreList, actionStopMode);
    public static void Iterate(this RectInt rect, Func<Vector2Int, bool> iterationFunction, Direction direction = Direction.Right, List<int> ignoreList = null, ActionStopMode actionStopMode = ActionStopMode.None)=>Iterate(rect,iterationFunction, direction.ToVector(),direction.ToVector().Perpendicular(),ignoreList,actionStopMode);
    public static void Iterate(this IGrid grid, Func<Vector2Int, bool> iterationFunction, Vector2Int innerDir, Vector2Int outerDir, List<int> ignoreList = null, ActionStopMode actionStopMode = ActionStopMode.None) => grid.SizeRect.Iterate(iterationFunction, innerDir, outerDir, ignoreList, actionStopMode);
    public static void Iterate(this RectInt rect, Func<Vector2Int, bool> iterationFunction, Vector2Int innerDir, Vector2Int outerDir, List<int> ignoreList = null, ActionStopMode actionStopMode = ActionStopMode.None)
    {
        ignoreList ??= [];
        for(Vector2Int pos = new(
            MathA.Checks.FirstIsPositive(outerDir.x, innerDir.x) ? rect.Min.x : rect.Max.x-1,
            MathA.Checks.FirstIsPositive(outerDir.y, innerDir.y) ? rect.Min.y : rect.Max.y-1);
            rect.IsInRect(pos); pos += outerDir)
            for((Vector2Int currentIteration, int i) = (pos, 0); rect.IsInRect(currentIteration); currentIteration += innerDir, i++)
                if(!ignoreList.Contains(i))
                    if(iterationFunction(currentIteration))
                        switch(actionStopMode)
                        {
                            case ActionStopMode.StopInnerIteration:
                            currentIteration = -Vector2Int.One;
                            break;
                            case ActionStopMode.AddRowToIgnoreList:
                            ignoreList.Add(i);
                            break;
                            case ActionStopMode.StopIterating:
                            return;
                        }
    }
}