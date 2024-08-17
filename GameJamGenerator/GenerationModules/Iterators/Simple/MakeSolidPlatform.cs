public class MakeSolidPlatform<T> : SimpleIteratorGenerationModule<T>, IHasBrush<T>
{
    int maxHeight;
    T platformStartsFromThis;
    public IBrush<T> Brush { get; set; }
    public MakeSolidPlatform(int height, T platformStartsFromThis)
    {
        maxHeight = height;
        this.platformStartsFromThis = platformStartsFromThis;
        actionStopMode = ActionStopMode.StopIterating;
        direction = Direction.Left;
    }
    protected override RectInt CutoutRect => new(Vector2Int.Down * maxHeight, Vector2Int.One * int.MaxValue);
    public override bool Action(Vector2Int pos)
    {
        if(!iteratingGrid[pos].Equals(platformStartsFromThis))
            return false;
        iteratingGrid.DrawRect(Brush, new(Vector2Int.Down * pos.y, iteratingGrid.SizeRect.Max));
        return true;
    }
}