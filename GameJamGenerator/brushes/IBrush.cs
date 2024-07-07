internal interface IBrush<T>
{
    public T GetValue(int x, int y, T current);
}
