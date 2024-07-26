public class MakeLinesFromTiles<T> :SimpleIteratorGenerationModule<T>
{
    T StartTile, DrawingTile;
    T[] EndTile;
    bool checksEndTile;
    Vector2Int offset;
    public MakeLinesFromTiles(Direction iterating, Direction soliding, T startTile, T drawingTile, T? endTile = default, IComponent<GenerationModule<T>>[] components = null) : base(components)
    {
        direction = iterating;
        offset = soliding.ToVector();
        actionStopMode = ActionStopMode.AddRowToIgnoreList;
        EndTile = endTile.Equals(default(T)) ? [startTile] : [startTile,endTile];
        DrawingTile = drawingTile;
        StartTile = startTile;
    }
    public MakeLinesFromTiles(Direction soliding, T startTile, T drawingTile, T? endTile = default, IComponent<GenerationModule<T>>[] components = null) : this(soliding, soliding, startTile, drawingTile, endTile, components){}
    public override bool Action(Vector2Int pos)
    {
        Vector2Int posWithOffset = pos + offset;
        if(posWithOffset.AnyMoreThan(iteratingGrid.Size-Vector2Int.One)||posWithOffset.AnyLessThan(0)) return false;
        if(!iteratingGrid[pos].Equals(StartTile) || iteratingGrid[posWithOffset].Equals(StartTile) || iteratingGrid[posWithOffset].Equals(EndTile)) return false;
        iteratingGrid.DrawLine(posWithOffset, offset, DrawingTile, EndTile);
        return false;
    }
}