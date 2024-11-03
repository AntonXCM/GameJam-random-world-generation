public class GridBlurrer<T> :NearestCellOperator<T>
{
    private readonly Func<IEnumerable<T>, T> averangeFunction;

    public GridBlurrer(Func<IEnumerable<T>, T> averangeFunction, MaskBinaryGrid grid = null)
    {
        Mask ??= new(new bool[,] { { true, true, true }, { true, true, true }, { true, true, true } });
        this.averangeFunction = averangeFunction;
    }

    protected override T CalculateValueFromCells(T[,] nearest,T[] nearestValues,Vector2Int pos) => averangeFunction(nearestValues);
}