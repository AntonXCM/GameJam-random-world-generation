
public class PathCutter<T> : MazeSolver<T>, IHasBrush<T>
{
    public IBrush<T> Brush { get; set; }

    protected override void WorkWithSolution(List<Vector2Int> solution)
    {
        foreach (var pos in solution)
            iteratingGrid.DrawTile(pos, Brush);
    }
    public PathCutter(Vector2Int startPos, Vector2Int endPos, Func<T, int> tileWeight, IComponent<GenerationModule<T>>[] components = null) : base(startPos, endPos, tileWeight, components){}
}