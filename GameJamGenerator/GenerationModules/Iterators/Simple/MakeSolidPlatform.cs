public class MakeSolidPlatform<T> :SimpleIteratorGenerationModule<T>
{
    int maxHeight;
    T platformStartsFromThis;
    IBrush<T> brush;
    public MakeSolidPlatform(int height, T platformStartsFromThis,IBrush<T> brush)
    {
        maxHeight = height;
        this.platformStartsFromThis = platformStartsFromThis;
        this.brush=brush;
        actionStopMode = ActionStopMode.StopIterating;
        direction = Direction.Left;
    }
    protected override RectInt CutoutRect => new(Vector2Int.Down * maxHeight, Vector2Int.One * int.MaxValue);
    public override bool Action(Vector2Int pos)
    {
        if(iteratingGrid[pos].Equals(platformStartsFromThis))
        {
            iteratingGrid.DrawRect(brush, new(Vector2Int.Down * pos.y, iteratingGrid.SizeRect.Max));
            return true;
        }
        return false;
    }
}