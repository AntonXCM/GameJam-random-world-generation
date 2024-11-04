public class BrushApplier<T> :CellularMachine<T>, IHasBrush<T>
{
    public IBrush<T> Brush { get; set; }

    public BrushApplier(IBrush<T> brush)
    {
        Brush = brush;
    }

    public override bool Action(Vector2Int pos)
    {
        iteratingGrid[pos] = Brush.GetValue(pos,inputGrid[pos]);
        return false;
    }
}