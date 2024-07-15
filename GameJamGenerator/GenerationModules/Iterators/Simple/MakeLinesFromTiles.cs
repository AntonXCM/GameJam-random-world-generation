public class MakeLinesFromTiles<T> : SimpleIteratorGenerationModule<T>
{
    Direction iteratingDirection, solidingDirection;
    T StartTile, DrawingTile;
    T? EndTile;
    public MakeLinesFromTiles(Direction iterating, Direction soliding, T startTile, T drawingTile, T? endTile, IComponent<GenerationModule<T>>[] components = null) : base(components)
    {
        iteratingDirection = iterating;
        solidingDirection = soliding;
        actionStopMode = ActionStopMode.AddRowToIgnoreList;
        EndTile = endTile;
        DrawingTile = drawingTile;
        StartTile = startTile;
    }
    public override bool Action(Vector2Int pos)
    {
        if(!iteratingGrid[pos].Equals(StartTile)) return false;
        if(EndTile != null) iteratingGrid.DrawLine(pos, solidingDirection, DrawingTile, EndTile);
        else iteratingGrid.DrawLine(pos, solidingDirection, DrawingTile);
        return false;
    }
}