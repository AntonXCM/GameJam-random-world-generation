

public class PathCutter<T>(Vector2Int startPos, Vector2Int endPos, Func<T, int> tileWeight, IBrush<T> brush) : MazeSolver<T>(startPos, endPos, tileWeight)
{
    protected override void WorkWithSolution(List<Vector2Int> solution)
    {
        foreach (var pos in solution)
            iteratingGrid.DrawTile(pos, brush);
    }
}