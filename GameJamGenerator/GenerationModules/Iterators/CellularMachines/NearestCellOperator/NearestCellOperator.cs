public abstract class NearestCellOperator<T> : CellularMachine<T>
{
    protected MaskBinaryGrid Mask;
    protected Vector2Int maskOffset;
    public NearestCellOperator(IComponent<GenerationModule<T>>[] components = null) : base(components) { }
    public override bool Action(Vector2Int pos)
    {
        iteratingGrid[pos] = CalculateValueFromCells(Mask.ChopByMask(inputGrid,pos+maskOffset), Mask.GetValues(inputGrid, pos+maskOffset),pos);
        return false;
    }
    protected abstract T CalculateValueFromCells(T[,] nearest,T[] nearestValues, Vector2Int pos);
}