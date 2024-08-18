using MathA;

public static class MaskIterator
{
    public static void IterateMask<T>(this IGrid<T> mask, Func<Vector2Int, bool> iterationFunction, Func<T, bool> maskCheckFunction, Direction direction = Direction.Right, List<int> ignoreList = null, ActionStopMode actionStopMode = ActionStopMode.None) => mask.IterateMask(iterationFunction, maskCheckFunction, direction.ToVector(), direction.ToVector().Perpendicular(), ignoreList, actionStopMode);
    public static void IterateMask<T>(this IGrid<T> mask, Func<Vector2Int, bool> iterationFunction, Func<T, bool> maskCheckFunction, Vector2Int innerDir, Vector2Int outerDir, List<int> ignoreList = null, ActionStopMode actionStopMode = ActionStopMode.None)=>
        mask.Iterate(pos => maskCheckFunction(mask[pos])?iterationFunction(pos):false,innerDir,outerDir,ignoreList,actionStopMode);
}