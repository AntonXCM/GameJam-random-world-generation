using MathA;
public class MakeLinesFromTiles<T> :SimpleIteratorGenerationModule<T>, IHasBrush<T>
{
    T StartTile;
    T[] EndTile;
    public IBrush<T> Brush { get; set; }
    
    Vector2Int direction;

    public MakeLinesFromTiles(Direction iterating, Direction soliding, T startTile, T? endTile = default, IComponent<GenerationModule<T>>[] components = null) : base(components)
    {
        base.direction = iterating;
        direction = soliding.ToVector();
        actionStopMode = ActionStopMode.AddRowToIgnoreList;
        EndTile = endTile.Equals(default(T)) ? [startTile] : [startTile,endTile];
        StartTile = startTile;
    }
    public MakeLinesFromTiles(Direction soliding, T startTile) : this(soliding, soliding, startTile) {}
    public override bool Action(Vector2Int pos)
    {
        Vector2Int posWithOffset = pos + direction;
        if(!posWithOffset.AnyMoreThan(iteratingGrid.Size - Vector2Int.One) && !posWithOffset.AnyLessThan(0) && iteratingGrid[pos].Equals(StartTile) && !iteratingGrid[posWithOffset].Equals(StartTile) && !iteratingGrid[posWithOffset].Equals(EndTile))
            iteratingGrid.DrawLine(posWithOffset, direction, Brush, EndTile);
        return false;
    }
}