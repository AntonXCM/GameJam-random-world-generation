public class SmoothTerrain<T> : CellularMachine<T>
{
    private readonly MaskBinaryGrid aroundCheckerGrid;
    private readonly Func<IEnumerable<T>, T> averangeFunction;

    public SmoothTerrain(Func<IEnumerable<T>, T> averangeFunction, MaskBinaryGrid grid = null)
    {
        grid ??= new(new bool[,] { { true, true, true }, { true, true, true }, { true, true, true } });
        aroundCheckerGrid = grid;
        this.averangeFunction = averangeFunction;
    }
    public override bool Action(Vector2Int pos)
    {
        iteratingGrid[pos] = averangeFunction(aroundCheckerGrid.GetValues(inputGrid,pos));
        return false;
    }
}