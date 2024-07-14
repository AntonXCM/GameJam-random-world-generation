public interface IBrush<T>
{
    public T GetValue(int x, int y, T current);
    public T GetValue(Vector2Int pos, T current) => GetValue(pos.x, pos.y, current);
}
