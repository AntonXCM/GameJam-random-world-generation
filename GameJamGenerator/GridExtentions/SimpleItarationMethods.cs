public static class SimpleItarationMethods
{
    public static void Iterate(this IGrid grid, Func<Vector2Int, bool> iterationFunction, Direction direction = Direction.Right, List<int> ignoreList = null, ActionStopMode actionStopMode = ActionStopMode.None) => Iterate(grid.Size, iterationFunction, direction, ignoreList, actionStopMode);
    public static void Iterate(Vector2Int size, Func<Vector2Int, bool> iterationFunction, Direction direction = Direction.Right, List<int> ignoreList = null, ActionStopMode actionStopMode = ActionStopMode.None)
    {
        ignoreList ??= [];
        int width = size.x, height = size.y;
        try
        {
            switch (direction)
            {
                case Direction.Up:
                    for (int i = 0; i < width; i++)
                        for (int j = height - 1; j >= 0; j--)
                            if (WeNeedToStopOperation(i, j, true))
                                StopIterating(ref j);
                    break;
                case Direction.Left:
                    for (int j = 0; j < height; j++)
                        for (int i = width - 1; i >= 0; i--)
                            if (WeNeedToStopOperation(i, j, false))
                                StopIterating(ref i);
                    break;
                case Direction.Down:
                    for (int i = 0; i < width; i++)
                        for (int j = 0; j < height; j++)
                            if (WeNeedToStopOperation(i, j, true))
                                StopIterating(ref j);
                    break;
                case Direction.Right:
                    for (int j = 0; j < height; j++)
                        for (int i = 0; i < width; i++)
                            if (WeNeedToStopOperation(i, j, false))
                                StopIterating(ref i);
                    break;
            }
        }
        catch (Exception ex)
        {
            if (ex.GetType() == typeof(OperationCanceledException)) return;
            throw;
        }
        bool WeNeedToStopOperation(int i, int j, bool isVertical) => !ignoreList.Contains(isVertical ? j : i) && iterationFunction(new(i, j));
        void StopIterating(ref int i)
        {
            switch (actionStopMode)
            {
                case ActionStopMode.StopCycle:
                    i = -1;
                    break;
                case ActionStopMode.AddRowToIgnoreList:
                    ignoreList.Add(i);
                    break;
                case ActionStopMode.StopIterating:
                    throw new OperationCanceledException();
            }
        }
    }
}