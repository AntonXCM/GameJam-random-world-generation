public enum ActionStopMode
{
    None, StopInnerIteration, AddRowToIgnoreList, StopIterating
}
public interface IGrid : ICloneable
{
    public int Width { get; }
    public int Height { get; }
    public Vector2Int Size { get => new(Width, Height); }
    public RectInt SizeRect { get => new(Size, Vector2Int.Zero); }
}
public interface IGrid<T> : IGrid, IEnumerable<T>
{
    public T this[int row, int col] { get; set; }
    public T this[Vector2Int pos] { get => this[pos.x, pos.y]; set => this[pos.x, pos.y] = value; }
    void ReplaceGrid(T[,] newGrid);
}