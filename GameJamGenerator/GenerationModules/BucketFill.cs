public class BucketFill<T>(List<Vector2Int> startPositions, List<Vector2Int> notAllowedPositions, IBrush<T> brush) : BucketIterator<T>(startPositions, notAllowedPositions)
{
    protected IBrush<T> Brush = brush;
    protected T[] fillingValues;

    protected override void Initialze(ref IGrid<T> grid)
    {
        base.Initialze(ref grid);
        List<T> fillingValues = new(positionsToCheck.Count);
        foreach (Vector2Int position in positionsToCheck) fillingValues.Add(grid[position]);
        this.fillingValues = [..fillingValues];
    }
    public override bool Action(Vector2Int pos)
    {
        iteratingGrid.DrawTile(pos, Brush);
        return false;
    }
    public override bool CheckPosition(Vector2Int pos)
    {
        if (fillingValues.Contains(iteratingGrid[pos])) return base.CheckPosition(pos);
        checkedPositions.Add(pos);
        return false;
    }
}