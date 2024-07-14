public class SimpleBrush<T> : IBrush<T>
{
    protected T Value;

    public SimpleBrush(T value) => Value = value;

    public virtual T GetValue(int x, int y, T current) => Value;
}