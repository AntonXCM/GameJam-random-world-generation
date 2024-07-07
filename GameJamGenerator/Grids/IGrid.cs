using System.Collections;

public interface IGrid : ICloneable
{
    public int Width { get; }
    public int Height { get; }
}
public interface IGrid<T> : IGrid, IEnumerable<T>
{
    public T this[int row, int col] { get; set; }
    internal T this[Vector2Int pos] { get => this[pos.x, pos.y]; set => this[pos.x, pos.y] = value; }
}