public class PathCutter<T> : MazeSolver<T>
{
    private readonly IBrush<T> brush;

    public PathCutter(Vector2Int startPos, Vector2Int endPos, Func<T, int> tileWeight, IBrush<T> brush, IComponent<GenerationModule<T>>[] components = null) : base(startPos, endPos, tileWeight, components) => this.brush = brush;

    protected override void WorkWithSolution(List<Vector2Int> solution)
    {
        foreach (var pos in solution)
            iteratingGrid.DrawTile(pos, brush);
    }
}