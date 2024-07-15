public enum Direction
{
    Right = 0b_1000_0000, Left = 0b_1100_0000, Down = 0b_0011_0000, Up = 0b_0010_0000
}
public enum ActionStopMode
{
    None, StopCycle, AddRowToIgnoreList, StopIterating
}
public interface IGrid : ICloneable
{
    public int Width { get; }
    public int Height { get; }
    public Vector2Int Size { get => new(Width, Height); }
}
public interface IGrid<T> : IGrid, IEnumerable<T>
{
    public T this[int row, int col] { get; set; }
    public T this[Vector2Int pos] { get => this[pos.x, pos.y]; set => this[pos.x, pos.y] = value; }
    void ReplaceGrid(T[,] newGrid);
}