
public class BucketFill<T> : BucketIterator<T>
{
    protected IBrush<T> Brush;
    protected T[] fillingValues;
    public BucketFill(List<Vector2Int> positionsToCheck, List<Vector2Int> notAllowedPositions, IBrush<T> brush) : base(positionsToCheck, notAllowedPositions) => Brush = brush;
    protected override void Initialze(ref IGrid<T> grid)
    {
        base.Initialze(ref grid);
        List<T> fillingValues = new(positionsToCheck.Count);
        foreach (Vector2Int position in positionsToCheck) fillingValues.Add(grid[position]);
        this.fillingValues = fillingValues.ToArray();
    }
    public override bool? Action(Vector2Int pos)
    {
        iteratingGrid[pos] = Brush.GetValue(pos.x,pos.y, iteratingGrid[pos]);
        return false;
    }
    public override bool CheckPosition(Vector2Int pos) => base.CheckPosition(pos) && fillingValues.Contains(iteratingGrid[pos]);
}